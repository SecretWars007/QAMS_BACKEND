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
        public TestSuitesController(ITestSuiteService service) { _service = service; }

        [HttpPost]
        [HasPermission("PROJECTS_CREATE")] // Re-using PROJECT permission as Suite is part of Project
        public async Task<IActionResult> Create([FromBody] CreateTestSuiteDto dto)
        {
            var suite = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = suite.Id }, suite);
        }

        [HttpGet("{id:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpGet("project/{projectId:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetByProject(Guid projectId)
            => Ok(await _service.GetByProjectIdAsync(projectId));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateTestSuiteDto dto)
            => Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id:guid}")]
        [HasPermission("PROJECTS_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        { 
            await _service.DeleteAsync(id); 
            return NoContent(); 
        }
    }
}
