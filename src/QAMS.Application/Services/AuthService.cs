// src/QAMS.Application/Services/AuthService.cs
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
    /// Servicio de autenticación: login, registro, refresh, logout.
    /// SRP: solo autenticación. DIP: todas las dependencias son interfaces.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IRbacService _rbacService;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtTokenGenerator _jwt;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IUserRepository userRepo, IRbacService rbacService,
            IPasswordHasher hasher, IJwtTokenGenerator jwt,
            IUnitOfWork uow, ILogger<AuthService> logger)
        {
            _userRepo = userRepo; _rbacService = rbacService;
            _hasher = hasher; _jwt = jwt; _uow = uow; _logger = logger;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            _logger.LogInformation("Intento de login: '{Username}'.", request.Username);

            var user = await _userRepo.GetWithRolesAndPermissionsAsync(request.Username);
            if (user is null || !user.IsActive)
            {
                _logger.LogWarning("Login fallido para '{Username}'.", request.Username);
                throw new DomainException("Credenciales inválidas.");
            }

            if (!_hasher.VerifyPassword(request.Password, user.PasswordHash))
            {
                _logger.LogWarning("Contraseña incorrecta para '{Username}'.", request.Username);
                throw new DomainException("Credenciales inválidas.");
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
                Permissions = permissions.ToList()
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
            return await LoginAsync(new LoginRequestDto { Username = request.Username, Password = request.Password });
        }

        public async Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            _logger.LogInformation("Renovación de token solicitada.");

            var users = await _userRepo.FindAsync(u => u.RefreshToken == request.RefreshToken);
            var user = users.FirstOrDefault();

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
                FullName = user.FullName, Permissions = permissions.ToList()
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
    }
}
