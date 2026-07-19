// src/QAMS.Application/Services/RbacService.cs
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using QAMS.Application.Interfaces;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio RBAC dinámico con caché de permisos.
    /// SRP: solo verifica permisos.
    /// DIP: depende de IPermissionRepository e IMemoryCache, no de implementaciones concretas.
    /// </summary>
    public class RbacService(
        IPermissionRepository permissionRepository,
        IMemoryCache memoryCache,
        ILogger<RbacService> logger) : IRbacService
    {
        // TTL de 5 minutos: equilibrio entre rendimiento y consistencia
        private static readonly TimeSpan _cacheTtl = TimeSpan.FromMinutes(5);
        private static string CacheKey(Guid userId) => $"rbac_permissions_{userId}";

        private async Task<IReadOnlyList<string>> GetPermissionsCachedAsync(Guid userId)
        {
            var key = CacheKey(userId);

            if (memoryCache.TryGetValue(key, out IReadOnlyList<string>? cached) && cached is not null)
            {
                logger.LogDebug("Permisos del usuario '{UserId}' obtenidos desde caché.", userId);
                return cached;
            }

            logger.LogDebug("Consultando permisos del usuario '{UserId}' en BD.", userId);
            var permissions = await permissionRepository.GetPermissionCodesByUserIdAsync(userId);

            memoryCache.Set(key, permissions, _cacheTtl);
            return permissions;
        }

        public async Task<bool> UserHasPermissionAsync(Guid userId, string permissionCode)
        {
            logger.LogDebug(
                "Verificando permiso '{Permission}' para usuario '{UserId}'.",
                permissionCode,
                userId
            );

            var userPermissions = await GetPermissionsCachedAsync(userId);
            var has = userPermissions.Any(p =>
                p.Equals(permissionCode, StringComparison.OrdinalIgnoreCase)
            );

            logger.Log(
                has ? LogLevel.Information : LogLevel.Warning,
                "Permiso '{Permission}' {Result} para usuario '{UserId}'.",
                permissionCode,
                has ? "CONCEDIDO" : "DENEGADO",
                userId
            );

            return has;
        }

        public async Task<IReadOnlyList<string>> GetUserPermissionsAsync(Guid userId)
        {
            logger.LogInformation("Obteniendo permisos del usuario '{UserId}'.", userId);
            var permissions = await GetPermissionsCachedAsync(userId);
            logger.LogInformation(
                "Usuario '{UserId}' tiene {Count} permisos.",
                userId,
                permissions.Count
            );
            return permissions;
        }

        public async Task<bool> UserHasAnyPermissionAsync(
            Guid userId,
            params string[] permissionCodes
        )
        {
            logger.LogInformation(
                "Verificando permisos [{Permissions}] para '{UserId}'.",
                string.Join(", ", permissionCodes),
                userId
            );

            var userPermissions = await GetPermissionsCachedAsync(userId);
            return permissionCodes.Any(req =>
                userPermissions.Any(up => up.Equals(req, StringComparison.OrdinalIgnoreCase))
            );
        }
    }
}
