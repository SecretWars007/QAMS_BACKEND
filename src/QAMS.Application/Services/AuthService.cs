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

namespace QAMS.Application.Services;

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

            // 1. Verificar si el usuario existe y si está bloqueado
            if (user?.LockoutEnd > DateTime.UtcNow)
            {
                var remaining = user.LockoutEnd.Value - DateTime.UtcNow;
                _logger.LogWarning("Intento de login en cuenta bloqueada: '{Username}'. Faltan {Minutes} min.",
                    request.Username, (int)remaining.TotalMinutes);
                throw new UnauthorizedException($"La cuenta está bloqueada temporalmente. Intente de nuevo en {(int)Math.Ceiling(remaining.TotalMinutes)} minutos.");
            }

            if (user?.IsActive is not true)
            {
                _logger.LogWarning("Login fallido para '{Username}' (Inexistante o inactivo).", request.Username);
                throw new UnauthorizedException("Credenciales inválidas.");
            }

            // 2. Verificar contraseña
            if (!_hasher.VerifyPassword(request.Password, user.PasswordHash))
            {
                user.AccessFailedCount++;
                _logger.LogWarning("Contraseña incorrecta para '{Username}'. Intento #{Count}.",
                    request.Username, user.AccessFailedCount);

                if (user.AccessFailedCount >= 5)
                {
                    user.LockoutEnd = DateTime.UtcNow.AddMinutes(15);
                    _logger.LogCritical("Cuenta bloqueada por seguridad: '{Username}'.", request.Username);
                }

                _userRepo.Update(user);
                await _uow.SaveChangesAsync();

                throw new UnauthorizedException("Credenciales inválidas.");
            }

            // 3. Login exitoso: Resetear contadores
            user.AccessFailedCount = 0;
            user.LockoutEnd = null;

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
            // SEC-B02: Anonimizar PII (email) en logs — principio de minimización GDPR/LGPD
            var maskedEmail = MaskEmail(request.Email);
            _logger.LogInformation("Intento de registro: '{Username}' con email '{MaskedEmail}'.", request.Username, maskedEmail);

            // 1. Validar conflictos ACTIVOS primero (para arrojar 400 Bad Request)
            var emailLower = request.Email?.Trim().ToLower();
            var usernameLower = request.Username?.Trim().ToLower();
            var activeConflicts = await _userRepo.FindAsync(u =>
                (u.Email != null && emailLower != null && u.Email.ToLower() == emailLower) ||
                (u.Username != null && usernameLower != null && u.Username.ToLower() == usernameLower) ||
                (u.DocumentoIdentidad == request.DocumentoIdentidad && u.FechaNacimiento == request.FechaNacimiento));

            if (activeConflicts.Count > 0)
            {
                var conflict = activeConflicts[0];
                if (string.Equals(conflict.Email, request.Email, StringComparison.OrdinalIgnoreCase))
                    throw new DomainException("El correo electrónico ya está en uso.");
                if (string.Equals(conflict.Username, request.Username, StringComparison.OrdinalIgnoreCase))
                    throw new DomainException("El nombre de usuario ya está en uso.");
                throw new DomainException("El documento de identidad ya está registrado.");
            }

            // 2. Buscar TODOS los conflictos físicos (incluyendo borrados) para limpieza total
            var physicalConflicts = await _userRepo.GetPhysicalConflictsAsync(request.Email ?? string.Empty, request.Username ?? string.Empty, request.DocumentoIdentidad ?? string.Empty);

            if (physicalConflicts.Count > 0)
            {
                _logger.LogInformation("Se encontraron {Count} conflictos en el historial. Iniciando anonimización masiva...", physicalConflicts.Count);

                foreach (var clashingUser in physicalConflicts)
                {
                    // Solo anonimizamos registros que estén marcados como ELIMINADOS
                    // Los activos ya fueron filtrados arriba (aunque por redundancia lo validamos)
                    if (clashingUser.IsDeleted)
                    {
                        var suffix = Guid.NewGuid().ToString()[..8];

                        // Liberar campos únicos
                        clashingUser.Email = $"del_{suffix}_{clashingUser.Email}";
                        if (clashingUser.Email.Length > 150) clashingUser.Email = clashingUser.Email[..150];

                        clashingUser.Username = $"del_{suffix}_{clashingUser.Username}";
                        if (clashingUser.Username.Length > 100) clashingUser.Username = clashingUser.Username[..100];

                        // Max length DocumentoIdentidad es 20
                        if (clashingUser.DocumentoIdentidad.Length <= 11)
                            clashingUser.DocumentoIdentidad = $"del_{suffix}_{clashingUser.DocumentoIdentidad}";
                        else
                            clashingUser.DocumentoIdentidad = $"del_{suffix}";

                        clashingUser.UpdatedAt = DateTime.UtcNow;
                        _userRepo.Update(clashingUser);
                    }
                }

                await _uow.SaveChangesAsync(); // Limpiar historial definitivamente
                _logger.LogInformation("Historial limpiado exitosamente.");
            }

            // 3. Validar edad (entre 18 y 80 años)
            var age = DateTime.Today.Year - request.FechaNacimiento.Year;
            if (request.FechaNacimiento.ToDateTime(TimeOnly.MinValue).Date > DateTime.Today.AddYears(-age)) age--;
            if (age < 18 || age > 80)
                throw new DomainException("La edad del usuario debe estar entre 18 y 80 años.");

            // 4. Validar que el Documento y Fecha no estén duplicados (Índice único compuesto)
            if (await _userRepo.AnyAsync(u => u.DocumentoIdentidad == request.DocumentoIdentidad && u.FechaNacimiento == request.FechaNacimiento))
                throw new DomainException($"El documento de identidad '{request.DocumentoIdentidad}' vinculado a esa fecha de nacimiento ya está registrado en el sistema.");

            // 5. Crear NUEVO usuario
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username ?? string.Empty,
                Email = request.Email ?? string.Empty,
                PasswordHash = _hasher.HashPassword(request.Password ?? string.Empty),
                FullName = request.FullName ?? string.Empty,
                DocumentoIdentidad = request.DocumentoIdentidad ?? string.Empty,
                FechaNacimiento = request.FechaNacimiento,
                Telefono = request.Telefono,
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepo.AddAsync(user);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Usuario registrado como NUEVO registro: '{Username}' ({Id}).", user.Username, user.Id);

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
            return await LoginAsync(new LoginRequestDto { Username = request.Username ?? string.Empty, Password = request.Password ?? string.Empty });
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
                AccessToken = newAccess,
                RefreshToken = newRefresh,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60),
                FullName = user.FullName,
                Permissions = [.. permissions]
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
            if (user?.IsActive is not true)
            {
                // SEC-B02: Enmascarar email en logs para cumplir GDPR/LGPD
                _logger.LogWarning("Email '{MaskedEmail}' no encontrado en forgot-password.", MaskEmail(request.Email));
                return string.Empty;
            }

            var randomBytes = new byte[32];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            var token = Convert.ToHexString(randomBytes);
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
            catch (Exception emailEx)
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
            catch (Exception emailEx)
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
            catch (Exception emailEx)
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
        /// <summary>
        /// SEC-B02: Enmascara un email para su registro en logs de aplicación.
        /// Cumple con el principio de minimización de datos (GDPR Art. 5 / LGPD Art. 6).
        /// Ejemplo: "john.doe@example.com" → "jo***@example.com"
        /// </summary>
        private static string MaskEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return "***";
            var parts = email.Split('@');
            if (parts.Length != 2) return "***@***";
            var name = parts[0].Length > 2 ? parts[0][..2] + "***" : "***";
            return $"{name}@{parts[1]}";
        }
    }

