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
        public TestExecutionsController(ITestExecutionService service) { _service = service; }

        private Guid GetUserId() =>
            Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

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

        [HttpPut("{executionId:guid}/step-result")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> UpdateStepResult(
            Guid executionId, [FromBody] UpdateStepResultDto dto)
            => Ok(await _service.UpdateStepResultAsync(executionId, dto));

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
            Guid executionId, IFormFile file, [FromForm] string? description)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { error = "El archivo es obligatorio." });

            // Validar tamaño máximo (50 MB)
            if (file.Length > 50 * 1024 * 1024)
                return BadRequest(new { error = "El archivo excede el tamaño máximo de 50 MB." });

            using var stream = file.OpenReadStream();
            var evidence = await _service.UploadEvidenceAsync(
                executionId, stream, file.FileName,
                file.ContentType, description);

            return Created("", evidence);
        }
    }
}
