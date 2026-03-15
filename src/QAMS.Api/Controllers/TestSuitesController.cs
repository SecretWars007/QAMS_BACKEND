// src/QAMS.Api/Controllers/TestSuitesController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.TestSuites;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestSuitesController : ControllerBase
    {
        private readonly ITestSuiteService _service;
        private readonly ILogger<TestSuitesController> _logger;

        public TestSuitesController(ITestSuiteService service, ILogger<TestSuitesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [HasPermission("PROJECTS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateTestSuiteDto dto)
        {
            _logger.LogInformation("POST /api/testsuites - Creando suite '{Name}' para proyecto {ProjectId}.", dto.Name, dto.ProjectId);
            var suite = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = suite.Id }, suite);
        }

        [HttpGet("{id:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/testsuites/{SuiteId}", id);
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("project/{projectId:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetByProject(Guid projectId)
        {
            _logger.LogInformation("GET /api/testsuites/project/{ProjectId}", projectId);
            return Ok(await _service.GetByProjectIdAsync(projectId));
        }

        [HttpPut("{id:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateTestSuiteDto dto)
        {
            _logger.LogInformation("PUT /api/testsuites/{SuiteId} - Actualizando suite.", id);
            return Ok(await _service.UpdateAsync(id, dto));
        }

        [HttpDelete("{id:guid}")]
        [HasPermission("PROJECTS_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/testsuites/{SuiteId}", id);
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
