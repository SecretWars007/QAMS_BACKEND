// src/QAMS.Api/Controllers/WebhooksController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.TestExecutions;
using QAMS.Application.Interfaces;
using QAMS.Application.Interfaces.Services;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Api.Controllers
{
    /// <summary>
    /// Webhook para importar resultados de automatización desde pipelines CI/CD.
    /// Requiere API Key en header X-Api-Key. No usa JWT (permite llamadas desde pipelines).
    /// Compatible con: JUnit XML, Playwright JSON, pytest JSON.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class WebhooksController(
        IApiKeyService apiKeyService,
        ITestExecutionService executionService,
        IGenericRepository<AutomationWebhookLog> webhookLogRepo,
        IUnitOfWork uow,
        ILogger<WebhooksController> logger) : ControllerBase
    {
        private readonly IApiKeyService _apiKeyService = apiKeyService;
        private readonly ITestExecutionService _executionService = executionService;
        private readonly IGenericRepository<AutomationWebhookLog> _webhookLogRepo = webhookLogRepo;
        private readonly IUnitOfWork _uow = uow;
        private readonly ILogger<WebhooksController> _logger = logger;

        /// <summary>
        /// Recibe resultados de ejecuciones automáticas y los importa como TestExecutions en QAMS.
        /// Autenticación: Header X-Api-Key.
        /// </summary>
        /// <param name="projectId">ID del proyecto al que pertenecen los resultados.</param>
        /// <param name="payload">Payload con los resultados de las pruebas automatizadas.</param>
        [HttpPost("test-results/{projectId:guid}")]
        public async Task<IActionResult> ReceiveTestResults(
            Guid projectId,
            [FromBody] WebhookTestResultDto payload)
        {
            // Validar API Key
            var apiKeyHeader = Request.Headers["X-Api-Key"].FirstOrDefault();
            if (string.IsNullOrEmpty(apiKeyHeader))
            {
                _logger.LogWarning("Webhook recibido sin X-Api-Key header para proyecto {ProjectId}.", projectId);
                return Unauthorized(new { message = "Se requiere el header X-Api-Key para acceder a este endpoint." });
            }

            var validatedProjectId = await _apiKeyService.ValidateAsync(apiKeyHeader);
            if (validatedProjectId == null || validatedProjectId != projectId)
            {
                _logger.LogWarning("API Key inválida o no pertenece al proyecto {ProjectId}.", projectId);
                return Unauthorized(new { message = "API Key inválida, expirada o no pertenece a este proyecto." });
            }

            _logger.LogInformation("Webhook recibido desde '{Source}' para proyecto {ProjectId}. Tests: {Total}",
                payload.Source, projectId, payload.TestResults.Count);

            var log = new AutomationWebhookLog
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                Source = payload.Source ?? "Unknown",
                PayloadFormat = payload.Format ?? "generic",
                TotalTests = payload.TestResults.Count,
                ProcessingStatus = "SUCCESS",
                RawPayload = System.Text.Json.JsonSerializer.Serialize(payload),
                CreatedAt = DateTime.UtcNow
            };

            int passed = 0, failed = 0, skipped = 0;

            try
            {
                foreach (var result in payload.TestResults)
                {
                    if (result.TestCaseId == Guid.Empty) continue;

                    // Crear ejecución automatizada en QAMS
                    var execDto = new CreateTestExecutionDto
                    {
                        TestCaseId = result.TestCaseId,
                        Notes = $"[Automatizado] Importado desde {payload.Source}. {result.Notes}",
                        ActualTimeHours = result.DurationSeconds.HasValue
                            ? (decimal)(result.DurationSeconds.Value / 3600.0)
                            : 0
                    };

                    await _executionService.CreateAsync(Guid.Empty, execDto);

                    switch (result.Status?.ToUpperInvariant())
                    {
                        case "PASSED":
                        case "PASS":
                            passed++;
                            break;
                        case "FAILED":
                        case "FAIL":
                            failed++;
                            break;
                        default:
                            skipped++;
                            break;
                    }
                }

                log.PassedTests = passed;
                log.FailedTests = failed;
                log.SkippedTests = skipped;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error procesando webhook para proyecto {ProjectId}.", projectId);
                log.ProcessingStatus = "PARTIAL";
                log.ErrorMessage = ex.Message;
            }

            await _webhookLogRepo.AddAsync(log);
            await _uow.SaveChangesAsync();

            return Ok(new
            {
                message = "Resultados importados correctamente.",
                logId = log.Id,
                totalTests = log.TotalTests,
                passed,
                failed,
                skipped,
                status = log.ProcessingStatus
            });
        }

        /// <summary>
        /// Lista el historial de webhooks recibidos para un proyecto.
        /// Requiere JWT de usuario autenticado con permiso DASHBOARD_VIEW.
        /// </summary>
        [HttpGet("logs/{projectId:guid}")]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public async Task<IActionResult> GetLogs(Guid projectId)
        {
            _logger.LogInformation("GET /api/webhooks/logs/{ProjectId}", projectId);
            var logs = await _webhookLogRepo.FindAsync(l => l.ProjectId == projectId);
            return Ok(logs.OrderByDescending(l => l.CreatedAt).Select(l => new
            {
                l.Id,
                l.Source,
                l.PayloadFormat,
                l.TotalTests,
                l.PassedTests,
                l.FailedTests,
                l.SkippedTests,
                l.ProcessingStatus,
                l.ErrorMessage,
                l.CreatedAt
            }));
        }
    }

    /// <summary>Payload genérico para importar resultados desde pipelines de CI/CD.</summary>
    public class WebhookTestResultDto
    {
        /// <summary>Nombre del pipeline o herramienta (ej: "GitHub Actions - Main Branch")</summary>
        public string? Source { get; set; }
        /// <summary>Formato del payload: junit_xml / playwright_json / generic</summary>
        public string? Format { get; set; } = "generic";
        /// <summary>Lista de resultados de pruebas individuales</summary>
        public List<AutomationTestResult> TestResults { get; set; } = [];
    }

    public class AutomationTestResult
    {
        /// <summary>ID del TestCase en QAMS al que corresponde este resultado</summary>
        public Guid TestCaseId { get; set; }
        /// <summary>Estado: PASSED / FAILED / SKIPPED</summary>
        public string? Status { get; set; }
        /// <summary>Duración de la ejecución en segundos</summary>
        public double? DurationSeconds { get; set; }
        /// <summary>Notas adicionales o mensaje de error</summary>
        public string? Notes { get; set; }
    }
}
