// src/QAMS.Api/Controllers/ProjectsController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Projects;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        { _projectService = projectService; }

        [HttpGet]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetAll() => Ok(await _projectService.GetAllAsync());

        [HttpGet("{id:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetById(Guid id) => Ok(await _projectService.GetByIdAsync(id));

        [HttpPost]
        [HasPermission("PROJECTS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateProjectDto dto)
        {
            var project = await _projectService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpPut("{id:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateProjectDto dto)
            => Ok(await _projectService.UpdateAsync(id, dto));

        [HttpDelete("{id:guid}")]
        [HasPermission("PROJECTS_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        { await _projectService.DeleteAsync(id); return NoContent(); }

        [HttpGet("{id:guid}/testcases")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetTestCasesByProject(Guid id, [FromServices] ITestCaseService testCaseService)
            => Ok(await testCaseService.GetByProjectIdAsync(id));

        [HttpPost("{id:guid}/devolution")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> RegisterDevolution(Guid id, [FromBody] RegisterDevolutionDto dto)
        {
            var userId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            return Ok(await _projectService.RegisterDevolutionAsync(id, userId, dto));
        }

        [HttpPost("devolution/{devolutionId:guid}/response")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> RespondDevolution(Guid devolutionId, [FromBody] RespondDevolutionDto dto)
            => Ok(await _projectService.RespondToDevolutionAsync(devolutionId, dto));
    }
}
