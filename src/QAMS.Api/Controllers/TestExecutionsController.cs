// src/QAMS.Api/Controllers/TestExecutionsController.cs
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
    public class TestExecutionsController : ControllerBase
    {
        private readonly ITestExecutionService _service;
        private readonly ILogger<TestExecutionsController> _logger;
        public TestExecutionsController(ITestExecutionService service, ILogger<TestExecutionsController> logger) 
        { 
            _service = service; 
            _logger = logger;
        }

        private Guid GetUserId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            return claim != null ? Guid.Parse(claim.Value) : Guid.Empty;
        }

        [HttpGet("{id:guid}")]
        [HasPermission("EXECUTIONS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpGet("testcase/{testCaseId:guid}")]
        [HasPermission("EXECUTIONS_VIEW")]
        public async Task<IActionResult> GetByTestCase(Guid testCaseId)
            => Ok(await _service.GetByTestCaseAsync(testCaseId));

        [HttpGet("my-executions")]
        [HasPermission("EXECUTIONS_VIEW")]
        public async Task<IActionResult> GetMyExecutions()
            => Ok(await _service.GetByTesterAsync(GetUserId()));

        [HttpPost]
        [HasPermission("EXECUTIONS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateTestExecutionDto dto)
        {
            var exec = await _service.CreateAsync(GetUserId(), dto);
            return CreatedAtAction(nameof(GetById), new { id = exec.Id }, exec);
        }

        [HttpPost("complete")]
        [HasPermission("EXECUTIONS_CREATE")]
        public async Task<IActionResult> CreateComplete([FromBody] CreateCompleteExecutionDto dto)
        {
            var exec = await _service.CreateCompleteAsync(GetUserId(), dto);
            return CreatedAtAction(nameof(GetById), new { id = exec.Id }, exec);
        }

        [HttpPut("{executionId:guid}/step-result")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> UpdateStepResult(
            Guid executionId, [FromBody] UpdateStepResultDto dto)
            => Ok(await _service.UpdateStepResultAsync(executionId, dto));

        [HttpPut("{id:guid}")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateExecutionStatusDto dto)
            => Ok(await _service.UpdateStatusAsync(id, dto.StatusId));

        [HttpPut("{id:guid}/full-update")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> FullUpdate(Guid id, [FromBody] UpdateCompleteExecutionDto dto)
            => Ok(await _service.UpdateCompleteAsync(id, dto));

        [HttpPut("{executionId:guid}/complete/{statusId:int}")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> Complete(Guid executionId, int statusId)
            => Ok(await _service.CompleteExecutionAsync(executionId, statusId));

        /// <summary>
        /// POST api/testexecutions/{executionId}/evidence
        /// Sube una imagen o video como evidencia.
        /// </summary>
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

        [HttpPost("observation/{observationId:guid}/response")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> PostResponse(Guid observationId, [FromBody] ResponseObservationDto dto)
        {
            var obs = await _service.AddResponseToObservationAsync(GetUserId(), observationId, dto);
            return Ok(obs);
        }
    }
}
