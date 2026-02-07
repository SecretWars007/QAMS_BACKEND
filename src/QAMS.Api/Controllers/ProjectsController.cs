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
    }
}
