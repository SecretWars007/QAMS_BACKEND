// src/QAMS.Api/Controllers/ProjectsController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        [HttpGet]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET /api/projects - Obteniendo todos los proyectos.");
            return Ok(await _projectService.GetAllAsync());
        }

        [HttpGet("my")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetMyProjects()
        {
            var userIdStr = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var userId = userIdStr != null ? Guid.Parse(userIdStr) : Guid.Empty;
            _logger.LogInformation("GET /api/projects/my - Obteniendo proyectos del usuario {UserId}.", userId);
            return Ok(await _projectService.GetMyProjectsAsync(userId));
        }

        [HttpGet("{id:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/projects/{ProjectId} - Obteniendo proyecto.", id);
            return Ok(await _projectService.GetByIdAsync(id));
        }

        [HttpPost]
        [HasPermission("PROJECTS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateProjectDto dto)
        {
            _logger.LogInformation("POST /api/projects - Creando proyecto '{Name}'.", dto.Name);
            var project = await _projectService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpPut("{id:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateProjectDto dto)
        {
            _logger.LogInformation("PUT /api/projects/{ProjectId} - Actualizando proyecto.", id);
            return Ok(await _projectService.UpdateAsync(id, dto));
        }

        [HttpDelete("{id:guid}")]
        [HasPermission("PROJECTS_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/projects/{ProjectId} - Eliminando proyecto.", id);
            await _projectService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id:guid}/testcases")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetTestCasesByProject(Guid id, [FromServices] ITestCaseService testCaseService)
        {
            _logger.LogInformation("GET /api/projects/{ProjectId}/testcases - Obteniendo casos de prueba.", id);
            return Ok(await testCaseService.GetByProjectIdAsync(id));
        }

        [HttpPost("{id:guid}/devolution")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> RegisterDevolution(Guid id, [FromBody] RegisterDevolutionDto dto)
        {
            var userIdStr = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var userId = userIdStr != null ? Guid.Parse(userIdStr) : Guid.Empty;
            _logger.LogInformation("POST /api/projects/{ProjectId}/devolution - Registrando devolución. UserId: {UserId}", id, userId);
            return Ok(await _projectService.RegisterDevolutionAsync(id, userId, dto));
        }

        [HttpPost("devolution/{devolutionId:guid}/response")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> RespondDevolution(Guid devolutionId, [FromBody] RespondDevolutionDto dto)
        {
            _logger.LogInformation("POST /api/projects/devolution/{DevolutionId}/response - Respondiendo devolución.", devolutionId);
            return Ok(await _projectService.RespondToDevolutionAsync(devolutionId, dto));
        }
    }
}
