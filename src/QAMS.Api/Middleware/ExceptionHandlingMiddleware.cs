// src/QAMS.Api/Middleware/ExceptionHandlingMiddleware.cs
using System.Net;
using System.Text.Json;
using QAMS.Domain.Exceptions;

namespace QAMS.Api.Middleware
{
    /// <summary>
    /// Middleware global de manejo de excepciones.
    /// Convierte excepciones de dominio en respuestas HTTP apropiadas.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
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
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "Error de dominio: {Message}", ex.Message);
                await WriteResponse(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error interno no controlado.");
                await WriteResponse(context, HttpStatusCode.InternalServerError,
                    "Ocurrió un error interno. Contacte al administrador.");
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
