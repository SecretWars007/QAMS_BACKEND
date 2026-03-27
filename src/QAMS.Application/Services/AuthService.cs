// src/QAMS.Application/Services/AuthService.cs
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Auth;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de autenticación: login, registro, refresh, logout,
    /// recuperación y cambio de contraseña.
    /// SRP: solo autenticación. DIP: todas las dependencias son interfaces.
    /// </summary>
    public class AuthService(
        IUserRepository userRepo, IRbacService rbacService,
        IPasswordHasher hasher, IJwtTokenGenerator jwt,
        IUnitOfWork uow, IEmailService emailService,
        ILogger<AuthService> logger) : IAuthService
    {
        private readonly IUserRepository _userRepo = userRepo;
        private readonly IRbacService _rbacService = rbacService;
        private readonly IPasswordHasher _hasher = hasher;
        private readonly IJwtTokenGenerator _jwt = jwt;
        private readonly IUnitOfWork _uow = uow;
        private readonly IEmailService _emailService = emailService;
        private readonly ILogger<AuthService> _logger = logger;

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            _logger.LogInformation("Intento de login: '{Username}'.", request.Username);

            var user = await _userRepo.GetWithRolesAndPermissionsAsync(request.Username);
            if (user is null || !user.IsActive)
            {
                _logger.LogWarning("Login fallido para '{Username}'.", request.Username);
                throw new UnauthorizedException("Credenciales inválidas.");
            }

            if (!_hasher.VerifyPassword(request.Password, user.PasswordHash))
            {
                _logger.LogWarning("Contraseña incorrecta para '{Username}'.", request.Username);
                throw new UnauthorizedException("Credenciales inválidas.");
            }

            var permissions = await _rbacService.GetUserPermissionsAsync(user.Id);
            var accessToken = _jwt.GenerateAccessToken(user, permissions);
            var refreshToken = _jwt.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Login exitoso: '{Username}', {Count} permisos.",
                user.Username, permissions.Count);

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60),
                FullName = user.FullName,
                Permissions = [.. permissions]
            };
        }

        public async Task<LoginResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            _logger.LogInformation("Registro: '{Username}'.", request.Username);

            if (await _userRepo.GetByUsernameAsync(request.Username) is not null)
                throw new DomainException($"Username '{request.Username}' ya existe.");

            if (await _userRepo.GetByEmailAsync(request.Email) is not null)
                throw new DomainException($"Email '{request.Email}' ya existe.");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                PasswordHash = _hasher.HashPassword(request.Password),
                FullName = request.FullName,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepo.AddAsync(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Usuario registrado: '{Username}' ({Id}).", user.Username, user.Id);

            // Enviar correo de bienvenida (no bloquea el registro si falla)
            try
            {
                var htmlBody = QAMS.Application.Templates.EmailTemplates.GetWelcomeEmailHtml(user.FullName, user.Username);
                await _emailService.SendEmailAsync(user.Email, "¡Bienvenido a QAMS! Tu cuenta ha sido creada", htmlBody);
                _logger.LogInformation("Correo de bienvenida enviado a '{Email}'.", user.Email);
            }
            catch (Exception emailEx)
            {
                _logger.LogWarning(emailEx, "No se pudo enviar el correo de bienvenida a '{Email}'. El registro fue exitoso.", user.Email);
            }
            return await LoginAsync(new LoginRequestDto { Username = request.Username, Password = request.Password });
        }

        public async Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            _logger.LogInformation("Renovación de token solicitada.");

            var users = await _userRepo.FindAsync(u => u.RefreshToken == request.RefreshToken);
            var user = users.Count > 0 ? users[0] : null;

            if (user is null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                throw new DomainException("Refresh token inválido o expirado.");

            var permissions = await _rbacService.GetUserPermissionsAsync(user.Id);
            var newAccess = _jwt.GenerateAccessToken(user, permissions);
            var newRefresh = _jwt.GenerateRefreshToken();

            user.RefreshToken = newRefresh;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Token renovado para '{UserId}'.", user.Id);

            return new LoginResponseDto
            {
                AccessToken = newAccess, RefreshToken = newRefresh,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60),
                FullName = user.FullName, Permissions = [.. permissions]
            };
        }

        public async Task RevokeRefreshTokenAsync(Guid userId)
        {
            var user = await _userRepo.GetByIdAsync(userId)
                ?? throw new EntityNotFoundException(nameof(User), userId);

            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Refresh token revocado para '{UserId}'.", userId);
        }

        // ─── Recuperación de contraseña ────────────────────────────────────────

        /// <summary>
        /// Genera un token temporal de 6 dígitos para restablecer la contraseña,
        /// asociado al email registrado. Válido por 15 minutos.
        /// En producción, el token debe enviarse por correo electrónico.
        /// </summary>
        public async Task<string> ForgotPasswordAsync(ForgotPasswordRequestDto request)
        {
            _logger.LogInformation("Solicitud de restablecimiento para '{Email}'.", request.Email);

            var user = await _userRepo.GetByEmailAsync(request.Email);

            // Por seguridad no se revela si el email existe o no
            if (user is null || !user.IsActive)
            {
                _logger.LogWarning("Email '{Email}' no encontrado en forgot-password.", request.Email);
                return string.Empty;
            }

            var token = new Random().Next(100000, 999999).ToString();
            user.PasswordResetToken = token;
            user.PasswordResetTokenExpiryTime = DateTime.UtcNow.AddMinutes(15);
            user.UpdatedAt = DateTime.UtcNow;

            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Token de reset generado para '{Email}'.", request.Email);

            // Enviar email con token
            try 
            {
                var resetLink = $"https://qams-web.onrender.com/reset-password?token={token}&email={Uri.EscapeDataString(user.Email)}";
                var body = QAMS.Application.Templates.EmailTemplates.GetForgotPasswordEmailHtml(user.FullName, resetLink);
                await _emailService.SendEmailAsync(user.Email, "Restablecer tu contraseña de QAMS", body);
            }
            catch(Exception emailEx) 
            {
                _logger.LogWarning(emailEx, "No se pudo enviar el correo de Forgot Password a '{Email}'.", request.Email);
            }

            return token;
        }

        /// <summary>
        /// Restablece la contraseña validando el token temporal enviado al email.
        /// </summary>
        public async Task ResetPasswordAsync(ResetPasswordRequestDto request)
        {
            _logger.LogInformation("Restablecimiento de contraseña para '{Email}'.", request.Email);

            var user = await _userRepo.GetByEmailAsync(request.Email)
                ?? throw new DomainException("Email o token inválido.");

            if (user.PasswordResetToken is null
                || user.PasswordResetToken != request.ResetToken
                || user.PasswordResetTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new DomainException("El token de restablecimiento es inválido o ha expirado.");
            }

            user.PasswordHash = _hasher.HashPassword(request.NewPassword);
            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiryTime = null;
            user.UpdatedAt = DateTime.UtcNow;

            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Contraseña restablecida para '{Email}'.", request.Email);

            try 
            {
                var body = QAMS.Application.Templates.EmailTemplates.GetPasswordResetSuccessEmailHtml(user.FullName);
                await _emailService.SendEmailAsync(user.Email, "Contraseña actualizada exitosamente", body);
            }
            catch(Exception emailEx) 
            {
                _logger.LogWarning(emailEx, "No se pudo enviar el correo de confirmación de Reset Password a '{Email}'.", request.Email);
            }
        }

        // ─── Cambio de contraseña (usuario autenticado) ───────────────────────

        /// <summary>
        /// Permite a un usuario autenticado cambiar su contraseña verificando la actual.
        /// </summary>
        public async Task ChangePasswordAsync(Guid userId, ChangePasswordRequestDto request)
        {
            _logger.LogInformation("Cambio de contraseña para UserId '{UserId}'.", userId);

            var user = await _userRepo.GetByIdAsync(userId)
                ?? throw new EntityNotFoundException(nameof(User), userId);

            if (!_hasher.VerifyPassword(request.CurrentPassword, user.PasswordHash))
                throw new DomainException("La contraseña actual es incorrecta.");

            user.PasswordHash = _hasher.HashPassword(request.NewPassword);
            user.UpdatedAt = DateTime.UtcNow;

            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Contraseña cambiada para UserId '{UserId}'.", userId);

            try 
            {
                var body = QAMS.Application.Templates.EmailTemplates.GetPasswordChangeSuccessEmailHtml(user.FullName);
                await _emailService.SendEmailAsync(user.Email, "Contraseña cambiada exitosamente", body);
            }
            catch(Exception emailEx) 
            {
                _logger.LogWarning(emailEx, "No se pudo enviar el correo de confirmación de Change Password a '{Email}'.", user.Email);
            }
        }

        // ─── Reset de contraseña por administrador ────────────────────────────

        /// <summary>
        /// Permite a un administrador restablecer la contraseña de cualquier usuario
        /// sin necesidad de conocer la contraseña actual ni un token de recuperación.
        /// </summary>
        public async Task AdminResetPasswordAsync(Guid targetUserId, string newPassword)
        {
            _logger.LogInformation("Admin reset de contraseña para UserId '{UserId}'.", targetUserId);

            var user = await _userRepo.GetByIdAsync(targetUserId)
                ?? throw new EntityNotFoundException(nameof(User), targetUserId);

            user.PasswordHash = _hasher.HashPassword(newPassword);
            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiryTime = null;
            user.UpdatedAt = DateTime.UtcNow;

            _userRepo.Update(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Admin reset de contraseña completado para UserId '{UserId}'.", targetUserId);
        }
    }
}
