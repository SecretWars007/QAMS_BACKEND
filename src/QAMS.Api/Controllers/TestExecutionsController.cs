// src/QAMS.Api/Controllers/TestExecutionsController.cs
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.TestExecutions;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestExecutionsController(ITestExecutionService service, ILogger<TestExecutionsController> logger) : ControllerBase
    {
        private readonly ITestExecutionService _service = service;
        private readonly ILogger<TestExecutionsController> _logger = logger;

        private Guid GetUserId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            return claim != null ? Guid.Parse(claim.Value) : Guid.Empty;
        }

        /// <summary>
        /// Obtiene una ejecución de prueba por su ID. Requiere permiso EXECUTIONS_VIEW.
        /// </summary>
        /// <param name="id">ID de la ejecución.</param>
        /// <returns>Detalle de la ejecución y resultados de sus pasos.</returns>
        [HttpGet("{id:guid}")]
        [HasPermission("EXECUTIONS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        /// <summary>
        /// Obtiene el historial de ejecuciones de un caso de prueba. Requiere permiso EXECUTIONS_VIEW.
        /// </summary>
        /// <param name="testCaseId">ID del caso de prueba.</param>
        /// <returns>Lista de ejecuciones previas.</returns>
        [HttpGet("testcase/{testCaseId:guid}")]
        [HasPermission("EXECUTIONS_VIEW")]
        public async Task<IActionResult> GetByTestCase(Guid testCaseId)
            => Ok(await _service.GetByTestCaseAsync(testCaseId));

        /// <summary>
        /// Obtiene las ejecuciones asignadas o realizadas por el usuario actual. Requiere permiso EXECUTIONS_VIEW.
        /// </summary>
        /// <returns>Lista de ejecuciones del usuario.</returns>
        [HttpGet("my-executions")]
        [HasPermission("EXECUTIONS_VIEW")]
        public async Task<IActionResult> GetMyExecutions()
            => Ok(await _service.GetByTesterAsync(GetUserId()));

        /// <summary>
        /// Inicia una nueva ejecución para un caso de prueba. Requiere permiso EXECUTIONS_CREATE.
        /// </summary>
        /// <param name="dto">Datos para iniciar la ejecución.</param>
        /// <returns>La ejecución iniciada.</returns>
        [HttpPost]
        [HasPermission("EXECUTIONS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateTestExecutionDto dto)
        {
            var exec = await _service.CreateAsync(GetUserId(), dto);
            return CreatedAtAction(nameof(GetById), new { id = exec.Id }, exec);
        }

        /// <summary>
        /// Registra una ejecución completa (inicio, fin y resultados de pasos) en una sola operación. Requiere permiso EXECUTIONS_CREATE.
        /// </summary>
        /// <param name="dto">Datos completos de la ejecución.</param>
        /// <returns>La ejecución registrada.</returns>
        [HttpPost("complete")]
        [HasPermission("EXECUTIONS_CREATE")]
        public async Task<IActionResult> CreateComplete([FromBody] CreateCompleteExecutionDto dto)
        {
            var exec = await _service.CreateCompleteAsync(GetUserId(), dto);
            return CreatedAtAction(nameof(GetById), new { id = exec.Id }, exec);
        }

        /// <summary>
        /// Actualiza el resultado (estado, comentario) de un paso específico en una ejecución. Requiere permiso EXECUTIONS_UPDATE.
        /// </summary>
        /// <param name="executionId">ID de la ejecución.</param>
        /// <param name="dto">Nuevo resultado del paso.</param>
        /// <returns>El resultado del paso actualizado.</returns>
        [HttpPut("{executionId:guid}/step-result")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> UpdateStepResult(
            Guid executionId, [FromBody] UpdateStepResultDto dto)
            => Ok(await _service.UpdateStepResultAsync(executionId, dto));

        /// <summary>
        /// Actualiza el estado general de una ejecución. Requiere permiso EXECUTIONS_UPDATE.
        /// </summary>
        /// <param name="id">ID de la ejecución.</param>
        /// <param name="dto">Nuevo estado.</param>
        /// <returns>La ejecución actualizada.</returns>
        [HttpPut("{id:guid}")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateExecutionStatusDto dto)
            => Ok(await _service.UpdateStatusAsync(id, dto.StatusId));

        /// <summary>
        /// Realiza una actualización masiva de todos los datos de una ejecución. Requiere permiso EXECUTIONS_UPDATE.
        /// </summary>
        /// <param name="id">ID de la ejecución.</param>
        /// <param name="dto">Datos actualizados.</param>
        /// <returns>La ejecución actualizada.</returns>
        [HttpPut("{id:guid}/full-update")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> FullUpdate(Guid id, [FromBody] UpdateCompleteExecutionDto dto)
            => Ok(await _service.UpdateCompleteAsync(id, dto));

        /// <summary>
        /// Finaliza una ejecución, marcándola con un estado final. Requiere permiso EXECUTIONS_UPDATE.
        /// </summary>
        /// <param name="executionId">ID de la ejecución.</param>
        /// <param name="statusId">ID del estado final (Pass, Fail, etc.).</param>
        /// <returns>La ejecución finalizada.</returns>
        [HttpPut("{executionId:guid}/complete/{statusId:int}")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> Complete(Guid executionId, int statusId)
            => Ok(await _service.CompleteExecutionAsync(executionId, statusId));

        /// <summary>
        /// Sube un archivo de evidencia (imagen o video) para una ejecución o paso específico. Requiere permiso EXECUTIONS_UPLOAD_EVIDENCE.
        /// </summary>
        /// <param name="executionId">ID de la ejecución.</param>
        /// <param name="request">Archivo y metadatos de la evidencia.</param>
        /// <returns>Referencia a la evidencia subida.</returns>
        [HttpPost("{executionId:guid}/evidence")]
        [HasPermission("EXECUTIONS_UPLOAD_EVIDENCE")]
        public async Task<IActionResult> UploadEvidence(
            Guid executionId, [FromForm] QAMS.Api.Models.TestExecutions.UploadEvidenceRequest request)
        {
            if (request.File == null || request.File.Length == 0)
                return BadRequest(new { error = "El archivo es obligatorio." });

            // Validar tamaño máximo (50 MB)
            if (request.File.Length > 50 * 1024 * 1024)
                return BadRequest(new { error = "El archivo excede el tamaño máximo de 50 MB." });

            using var stream = request.File.OpenReadStream();
            var evidence = await _service.UploadEvidenceAsync(
                executionId, stream, request.File.FileName,
                request.File.ContentType, request.Description, request.StepResultId);

            return Created("", evidence);
        }

        /// <summary>
        /// Registra una observación o hallazgo sobre un paso de ejecución, opcionalmente subiendo una captura. Requiere permiso EXECUTIONS_UPDATE.
        /// </summary>
        /// <param name="request">Texto de la observación y archivo opcional.</param>
        /// <returns>La observación creada.</returns>
        [HttpPost("observation")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> PostObservation([FromForm] QAMS.Api.Models.TestExecutions.ObservationRequest request)
        {
            Stream? fileStream = null;
            if (request.File != null && request.File.Length > 0)
            {
                // Validar tamaño máximo (50 MB)
                if (request.File.Length > 50 * 1024 * 1024)
                    return BadRequest(new { error = "El archivo excede el tamaño máximo de 50 MB." });
                
                fileStream = request.File.OpenReadStream();
            }

            var dto = new CreateObservationDto
            {
                ExecutionStepResultId = request.ExecutionStepResultId,
                Observation = request.Observation
            };

            // Use a using statement for fileStream if it was opened
            if (fileStream != null)
            {
                await using (fileStream) // 'await using' for IAsyncDisposable
                {
                    var obs = await _service.AddObservationAsync(
                        GetUserId(), 
                        dto, 
                        fileStream, 
                        request.File?.FileName, 
                        request.File?.ContentType);

                    return Created("", obs);
                }
            }
            else
            {
                var obs = await _service.AddObservationAsync(
                    GetUserId(), 
                    dto, 
                    null, // No file stream
                    null, 
                    null);

                return Created("", obs);
            }
        }

        /// <summary>
        /// Agrega una respuesta o comentario de seguimiento a una observación. Requiere permiso EXECUTIONS_UPDATE.
        /// </summary>
        /// <param name="observationId">ID de la observación origen.</param>
        /// <param name="dto">Texto de la respuesta.</param>
        /// <returns>La observación actualizada.</returns>
        [HttpPost("observation/{observationId:guid}/response")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> PostResponse(Guid observationId, [FromBody] ResponseObservationDto dto)
        {
            var obs = await _service.AddResponseToObservationAsync(GetUserId(), observationId, dto);
            return Ok(obs);
        }
    }
}
