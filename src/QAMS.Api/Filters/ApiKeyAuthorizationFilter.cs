// src/QAMS.Api/Filters/ApiKeyAuthorizationFilter.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QAMS.Application.Interfaces.Services;

namespace QAMS.Api.Filters
{
    /// <summary>
    /// Filtro que valida el header X-Api-Key para peticiones de automatización/CI-CD.
    /// Uso: decorar el controlador o acción con [ApiKeyAuthorize].
    /// </summary>
    public class ApiKeyAuthorizationFilter : IAsyncActionFilter
    {
        private const string ApiKeyHeader = "X-Api-Key";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeader, out var keyValues))
            {
                context.Result = new UnauthorizedObjectResult(new { message = "API Key requerida. Incluya el header 'X-Api-Key'." });
                return;
            }

            var plainKey = keyValues.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(plainKey))
            {
                context.Result = new UnauthorizedObjectResult(new { message = "API Key inválida." });
                return;
            }

            var apiKeyService = context.HttpContext.RequestServices.GetRequiredService<IApiKeyService>();
            var projectId = await apiKeyService.ValidateAsync(plainKey);

            if (projectId == null)
            {
                context.Result = new UnauthorizedObjectResult(new { message = "API Key inválida, expirada o revocada." });
                return;
            }

            // Inyectar el ProjectId en los items del contexto para que los controladores puedan accederlo
            context.HttpContext.Items["ApiKeyProjectId"] = projectId;

            await next();
        }
    }

    /// <summary>Atributo de conveniencia para aplicar la validación de API Key.</summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthorizeAttribute : ServiceFilterAttribute
    {
        public ApiKeyAuthorizeAttribute() : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
