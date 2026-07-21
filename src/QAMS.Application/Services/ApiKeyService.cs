// src/QAMS.Application/Services/ApiKeyService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.ApiKeys;
using QAMS.Application.Interfaces;
using QAMS.Application.Interfaces.Repositories;
using QAMS.Application.Interfaces.Services;
using QAMS.Domain.Entities;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de API Keys para integración CI/CD.
    /// Genera claves seguras con BCrypt hash — el valor plano solo se devuelve una vez.
    /// </summary>
    public class ApiKeyService(
        IApiKeyRepository apiKeyRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        ICurrentUserService currentUserService,
        ILogger<ApiKeyService> logger,
        IMapper mapper) : IApiKeyService
    {
        public async Task<List<ApiKeyDto>> GetByProjectAsync(Guid projectId)
        {
            var keys = await apiKeyRepository.GetByProjectAsync(projectId);
            return mapper.Map<List<ApiKeyDto>>(keys);
        }

        public async Task<ApiKeyCreatedDto> CreateAsync(CreateApiKeyDto dto)
        {
            logger.LogInformation("Generando API Key para proyecto {ProjectId}.", dto.ProjectId);

            // Generar llave aleatoria segura
            var plainKey = GenerateSecureKey();
            var prefix = plainKey[..8];  // primeros 8 caracteres como prefijo visible
            var hash = passwordHasher.HashPassword(plainKey);

            var apiKey = new ApiKey
            {
                Id = Guid.NewGuid(),
                ProjectId = dto.ProjectId,
                Name = dto.Name,
                KeyHash = hash,
                KeyPrefix = prefix,
                IsActive = true,
                ExpiresAt = dto.ExpiresAt,
                CreatedByUserId = currentUserService.UserId,
                CreatedAt = DateTime.UtcNow
            };

            await apiKeyRepository.AddAsync(apiKey);
            await unitOfWork.SaveChangesAsync();

            logger.LogInformation("API Key '{Name}' creada con prefijo {Prefix}.", dto.Name, prefix);

            return new ApiKeyCreatedDto
            {
                Id = apiKey.Id,
                Name = apiKey.Name,
                KeyPrefix = prefix,
                PlainKey = plainKey,
                ExpiresAt = apiKey.ExpiresAt,
                CreatedAt = apiKey.CreatedAt
            };
        }

        public async Task<bool> RevokeAsync(Guid id)
        {
            var apiKey = await apiKeyRepository.GetByIdAsync(id)
                ?? throw new EntityNotFoundException(nameof(ApiKey), id);

            apiKey.IsActive = false;
            apiKey.UpdatedAt = DateTime.UtcNow;
            apiKey.UpdatedByUserId = currentUserService.UserId;
            apiKeyRepository.Update(apiKey);
            await unitOfWork.SaveChangesAsync();

            logger.LogInformation("API Key {Id} revocada.", id);
            return true;
        }

        public async Task<Guid?> ValidateAsync(string plainKey)
        {
            if (string.IsNullOrWhiteSpace(plainKey) || plainKey.Length < 8)
                return null;

            var prefix = plainKey[..8];
            var apiKey = await apiKeyRepository.GetByPrefixAsync(prefix);
            if (apiKey == null) return null;

            // Verificar expiración
            if (apiKey.ExpiresAt < DateTime.UtcNow)
            {
                logger.LogWarning("Intento de uso de API Key expirada {Id}.", apiKey.Id);
                return null;
            }

            // Verificar hash
            if (!passwordHasher.VerifyPassword(plainKey, apiKey.KeyHash))
                return null;

            // Actualizar último uso (fire-and-forget para no bloquear)
            apiKey.LastUsedAt = DateTime.UtcNow;
            apiKeyRepository.Update(apiKey);
            await unitOfWork.SaveChangesAsync();

            return apiKey.ProjectId;
        }

        /// <summary>Genera una clave segura de 32 caracteres en Base64Url.</summary>
        private static string GenerateSecureKey()
        {
            var bytes = new byte[24]; // 24 bytes → 32 chars en Base64
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes)
                .Replace("+", "-")
                .Replace("/", "_")
                .Replace("=", "");
        }
    }
}
