// src/QAMS.Api/Filters/HasPermissionAttribute.cs
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
    public class HasPermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _permissionCode;

        public HasPermissionAttribute(string permissionCode)
        {
            _permissionCode = permissionCode;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // Obtener el ID del usuario del JWT
            var userIdClaim = context.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim is null || !Guid.TryParse(userIdClaim.Value, out var userId))
            {
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
