// src/QAMS.Api/Controllers/TestCasesController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.TestCases;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestCasesController : ControllerBase
    {
        private readonly ITestCaseService _service;
        public TestCasesController(ITestCaseService service) { _service = service; }

        [HttpGet("{id:guid}")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpGet("suite/{suiteId:guid}")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetBySuite(Guid suiteId)
            => Ok(await _service.GetBySuiteAsync(suiteId));

        [HttpGet]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetByProject([FromQuery] Guid projectId)
            => Ok(await _service.GetByProjectIdAsync(projectId));

        [HttpGet("project/{projectId:guid}/suite/{suiteId:guid}")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetByProjectAndSuite(Guid projectId, Guid suiteId)
            => Ok(await _service.GetByProjectAndSuiteAsync(projectId, suiteId));

        [HttpPost]
        [HasPermission("TEST_CASES_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateTestCaseDto dto)
        {
            var tc = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = tc.Id }, tc);
        }

        [HttpPut("{id:guid}")]
        [HasPermission("TEST_CASES_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateTestCaseDto dto)
            => Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id:guid}")]
        [HasPermission("TEST_CASES_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        { await _service.DeleteAsync(id); return NoContent(); }
    }
}
