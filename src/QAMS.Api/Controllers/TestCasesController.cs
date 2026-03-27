// src/QAMS.Api/Controllers/TestCasesController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.TestCases;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestCasesController(ITestCaseService service, ILogger<TestCasesController> logger) : ControllerBase
    {
        private readonly ITestCaseService _service = service;
        private readonly ILogger<TestCasesController> _logger = logger;

        [HttpGet("{id:guid}")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/testcases/{TestCaseId}", id);
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("suite/{suiteId:guid}")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetBySuite(Guid suiteId)
        {
            _logger.LogInformation("GET /api/testcases/suite/{SuiteId}", suiteId);
            return Ok(await _service.GetBySuiteAsync(suiteId));
        }

        [HttpGet]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetByProject([FromQuery] Guid projectId)
        {
            _logger.LogInformation("GET /api/testcases?projectId={ProjectId}", projectId);
            return Ok(await _service.GetByProjectIdAsync(projectId));
        }

        [HttpGet("project/{projectId:guid}/suite/{suiteId:guid}")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetByProjectAndSuite(Guid projectId, Guid suiteId)
        {
            _logger.LogInformation("GET /api/testcases/project/{ProjectId}/suite/{SuiteId}", projectId, suiteId);
            return Ok(await _service.GetByProjectAndSuiteAsync(projectId, suiteId));
        }

        [HttpGet("{id:guid}/steps")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetSteps(Guid id)
        {
            _logger.LogInformation("GET /api/testcases/{TestCaseId}/steps", id);
            return Ok(await _service.GetStepsAsync(id));
        }

        [HttpPost]
        [HasPermission("TEST_CASES_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateTestCaseDto dto)
        {
            _logger.LogInformation("POST /api/testcases - Creando caso '{Title}'.", dto.Title);
            var tc = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = tc.Id }, tc);
        }

        [HttpPut("{id:guid}")]
        [HasPermission("TEST_CASES_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateTestCaseDto dto)
        {
            _logger.LogInformation("PUT /api/testcases/{TestCaseId} - Actualizando caso.", id);
            return Ok(await _service.UpdateAsync(id, dto));
        }

        [HttpDelete("{id:guid}")]
        [HasPermission("TEST_CASES_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/testcases/{TestCaseId}", id);
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
