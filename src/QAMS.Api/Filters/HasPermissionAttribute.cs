// src/QAMS.Api/Filters/HasPermissionAttribute.cs
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Filters
{
    /// <summary>
    /// Atributo de autorización personalizado basado en permisos dinámicos.
    /// Uso: [HasPermission("TEST_CASE_CREATE")]
    /// Consulta la BD para verificar si el usuario tiene el permiso.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class HasPermissionAttribute(string permissionCode) : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _permissionCode = permissionCode;

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<Microsoft.Extensions.Logging.ILogger<HasPermissionAttribute>>();

            // Obtener el ID del usuario del JWT
            var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            logger.LogDebug("HasPermission: Validando para User={UserId}, Permiso={Permission}. Claims: {Claims}",
                userIdClaim?.Value ?? "null", _permissionCode,
                string.Join(", ", context.HttpContext.User.Claims.Select(c => $"{(c.Type ?? "N/A")}={(c.Value ?? "N/A")}")));

            if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            {
                logger.LogWarning("HasPermission: Claim NameIdentifier no encontrado o inválido.");
                context.Result = new UnauthorizedResult();
                return;
            }

            // Resolver el servicio RBAC desde DI
            var rbacService = context.HttpContext.RequestServices
                .GetRequiredService<IRbacService>();

            // Verificar el permiso contra la BD
            var hasPermission = await rbacService.UserHasPermissionAsync(userId, _permissionCode);

            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
