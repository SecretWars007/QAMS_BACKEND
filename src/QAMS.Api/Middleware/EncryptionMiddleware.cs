using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Middleware;

public class EncryptionMiddleware(RequestDelegate next, ILogger<EncryptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<EncryptionMiddleware> _logger = logger;
    private static readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

    public async Task InvokeAsync(HttpContext context, IEncryptionService encryptionService)
    {
        // Skip encryption for Swagger, Health checks, Evidences or if explicitly requested via header (for integration tests)
        if (context.Request.Path.StartsWithSegments("/swagger") ||
            context.Request.Path.StartsWithSegments("/health") ||
            context.Request.Path.StartsWithSegments("/api/evidences") ||
            context.Request.Method == "OPTIONS" ||
            context.Request.Headers.ContainsKey("X-Skip-Encryption") ||
            context.Request.HasFormContentType)
        {
            await _next(context);
            return;
        }

        // 1. Decrypt Request Body
        if (context.Request.ContentLength > 0 &&
            (context.Request.Method == "POST" || context.Request.Method == "PUT" || context.Request.Method == "PATCH"))
        {
            try
            {
                context.Request.EnableBuffering();
                using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
                var encryptedBody = await reader.ReadToEndAsync();

                // Intenta deserializar el sobre de cifrado (soporta Data/data por CaseInsensitive)
                string? cipherText = null;
                try
                {
                    var envelope = JsonSerializer.Deserialize<EncryptionEnvelope>(encryptedBody, _jsonOptions);
                    if (envelope != null && !string.IsNullOrEmpty(envelope.Data))
                    {
                        cipherText = envelope.Data;
                    }
                }
                catch { /* Si no es un sobre JSON, tratamos el cuerpo como texto cifrado directo */ }

                if (string.IsNullOrEmpty(cipherText))
                    cipherText = encryptedBody;

                var decryptedBody = encryptionService.Decrypt(cipherText);
                var requestData = Encoding.UTF8.GetBytes(decryptedBody);

                context.Request.Body = new MemoryStream(requestData);
                context.Request.ContentLength = requestData.Length;
                context.Request.ContentType = "application/json";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error crítico al descifrar el cuerpo de la petición");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("El payload cifrado es inválido o la clave es incorrecta.");
                return;
            }
        }

        // 2. Intercept Response Body
        var originalBodyStream = context.Response.Body;
        var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        try
        {
            await _next(context);

            // 3. Encrypt Response Body
            if (context.Response.ContentType != null && context.Response.ContentType.Contains("application/json"))
            {
                context.Response.Body = originalBodyStream;
                responseBody.Seek(0, SeekOrigin.Begin);
                var plainTextResponse = await new StreamReader(responseBody).ReadToEndAsync();

                if (!string.IsNullOrEmpty(plainTextResponse))
                {
                    var encryptedResponse = encryptionService.Encrypt(plainTextResponse);
                    var envelope = new EncryptionEnvelope { Data = encryptedResponse };
                    var jsonResponse = JsonSerializer.Serialize(envelope);

                    var responseData = Encoding.UTF8.GetBytes(jsonResponse);
                    context.Response.ContentLength = responseData.Length;
                    await context.Response.Body.WriteAsync(responseData);
                }
            }
            else
            {
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
                context.Response.Body = originalBodyStream;
            }
        }
        finally
        {
            if (context.Response.Body == responseBody)
            {
                context.Response.Body = originalBodyStream;
            }
            responseBody.Dispose();
        }
    }

    private class EncryptionEnvelope
    {
        public string Data { get; set; } = string.Empty;
    }
}
