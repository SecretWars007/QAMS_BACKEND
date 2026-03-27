// src/QAMS.Application/Services/RbacService.cs
using Microsoft.Extensions.Logging;
using QAMS.Application.Interfaces;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio RBAC dinámico. Consulta BD en tiempo real.
    /// SRP: solo verifica permisos.
    /// DIP: depende de IPermissionRepository, no de implementación concreta.
    /// </summary>
    public class RbacService(IPermissionRepository permissionRepository, ILogger<RbacService> logger) : IRbacService
    {

        public async Task<bool> UserHasPermissionAsync(Guid userId, string permissionCode)
        {
            logger.LogDebug(
                "Verificando permiso '{Permission}' para usuario '{UserId}'.",
                permissionCode,
                userId
            );

            var userPermissions = await permissionRepository.GetPermissionCodesByUserIdAsync(
                userId
            );
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
            var permissions = await permissionRepository.GetPermissionCodesByUserIdAsync(userId);
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

            var userPermissions = await permissionRepository.GetPermissionCodesByUserIdAsync(
                userId
            );
            return permissionCodes.Any(req =>
                userPermissions.Any(up => up.Equals(req, StringComparison.OrdinalIgnoreCase))
            );
        }
    }
}
