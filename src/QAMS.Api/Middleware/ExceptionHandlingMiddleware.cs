// src/QAMS.Api/Middleware/ExceptionHandlingMiddleware.cs
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QAMS.Domain.Exceptions;

namespace QAMS.Api.Middleware
{
    /// <summary>
    /// Middleware global de manejo de excepciones.
    /// Convierte excepciones de dominio en respuestas HTTP apropiadas.
    /// </summary>
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogWarning(ex, "Entidad no encontrada: {Message}", ex.Message);
                await WriteResponse(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (DuplicateEntityException ex)
            {
                _logger.LogWarning(ex, "Duplicado detectado: {Message}", ex.Message);
                await WriteResponse(context, HttpStatusCode.Conflict, ex.Message);
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "Error de dominio: {Message}", ex.Message);
                await WriteResponse(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (UnauthorizedException ex)
            {
                _logger.LogWarning(ex, "Intento de acceso no autorizado: {Message}", ex.Message);
                await WriteResponse(context, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error interno no controlado.");

                string detail = "Ha ocurrido un error interno en el servidor.";

                // Temporalmente enviamos el error completo siempre para depurar en Render
                detail = ex.ToString();
                if (ex.InnerException != null)
                    detail += " | INNER: " + ex.InnerException.ToString();

                await WriteResponse(context, HttpStatusCode.InternalServerError, detail);
            }
        }

        private static async Task WriteResponse(HttpContext context, HttpStatusCode code, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var response = JsonSerializer.Serialize(new { error = message, statusCode = (int)code });
            await context.Response.WriteAsync(response);
        }
    }
}
