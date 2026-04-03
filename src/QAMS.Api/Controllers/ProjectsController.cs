// [MermaidChart: dba505bf-b5c6-4407-b02d-1d093aabf55c]
// src/QAMS.Api/Controllers/ProjectsController.cs
using System;
using System.Threading.Tasks;
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
    public class ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;
        private readonly ILogger<ProjectsController> _logger = logger;

        /// <summary>
        /// Obtiene todos los proyectos registrados. Requiere permiso PROJECTS_VIEW.
        /// </summary>
        /// <returns>Lista de todos los proyectos.</returns>
        [HttpGet]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET /api/projects - Obteniendo todos los proyectos.");
            return Ok(await _projectService.GetAllAsync());
        }

        /// <summary>
        /// Obtiene los proyectos donde el usuario actual participa. Requiere permiso PROJECTS_VIEW.
        /// </summary>
        /// <returns>Lista de proyectos del usuario actual.</returns>
        [HttpGet("my")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetMyProjects()
        {
            var userIdStr = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var userId = userIdStr != null ? Guid.Parse(userIdStr) : Guid.Empty;
            _logger.LogInformation("GET /api/projects/my - Obteniendo proyectos del usuario {UserId}.", userId);
            return Ok(await _projectService.GetMyProjectsAsync(userId));
        }

        /// <summary>
        /// Obtiene el detalle de un proyecto específico por su ID. Requiere permiso PROJECTS_VIEW.
        /// </summary>
        /// <param name="id">ID único del proyecto.</param>
        /// <returns>Detalle del proyecto.</returns>
        [HttpGet("{id:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/projects/{ProjectId} - Obteniendo proyecto.", id);
            return Ok(await _projectService.GetByIdAsync(id));
        }

        /// <summary>
        /// Crea un nuevo proyecto. Requiere permiso PROJECTS_CREATE.
        /// </summary>
        /// <param name="dto">Datos básicos del proyecto.</param>
        /// <returns>El proyecto recién creado.</returns>
        [HttpPost]
        [HasPermission("PROJECTS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateProjectDto dto)
        {
            _logger.LogInformation("POST /api/projects - Creando proyecto '{Name}'.", dto.Name);
            var project = await _projectService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        /// <summary>
        /// Actualiza la información de un proyecto. Requiere permiso PROJECTS_UPDATE.
        /// </summary>
        /// <param name="id">ID del proyecto a actualizar.</param>
        /// <param name="dto">Nuevos datos del proyecto.</param>
        /// <returns>El proyecto actualizado.</returns>
        [HttpPut("{id:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateProjectDto dto)
        {
            _logger.LogInformation("PUT /api/projects/{ProjectId} - Actualizando proyecto.", id);
            return Ok(await _projectService.UpdateAsync(id, dto));
        }

        /// <summary>
        /// Realiza una eliminación lógica del proyecto. Requiere permiso PROJECTS_DELETE.
        /// </summary>
        /// <param name="id">ID del proyecto a eliminar.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpDelete("{id:guid}")]
        [HasPermission("PROJECTS_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/projects/{ProjectId} - Eliminando proyecto.", id);
            await _projectService.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Obtiene todos los casos de prueba asociados a un proyecto. Requiere permiso PROJECTS_VIEW.
        /// </summary>
        /// <param name="id">ID del proyecto.</param>
        /// <param name="testCaseService">Inyección de servicio de casos de prueba.</param>
        /// <returns>Lista de casos de prueba del proyecto.</returns>
        [HttpGet("{id:guid}/testcases")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetTestCasesByProject(Guid id, [FromServices] ITestCaseService testCaseService)
        {
            _logger.LogInformation("GET /api/projects/{ProjectId}/testcases - Obteniendo casos de prueba.", id);
            return Ok(await testCaseService.GetByProjectIdAsync(id));
        }

        /// <summary>
        /// Registra una devolución o feedback para un proyecto. Requiere permiso PROJECTS_UPDATE.
        /// </summary>
        /// <param name="id">ID del proyecto.</param>
        /// <param name="dto">Detalles de la devolución.</param>
        /// <returns>El registro de devolución creado.</returns>
        [HttpPost("{id:guid}/devolution")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> RegisterDevolution(Guid id, [FromBody] RegisterDevolutionDto dto)
        {
            var userIdStr = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var userId = userIdStr != null ? Guid.Parse(userIdStr) : Guid.Empty;
            _logger.LogInformation("POST /api/projects/{ProjectId}/devolution - Registrando devolución. UserId: {UserId}", id, userId);
            return Ok(await _projectService.RegisterDevolutionAsync(id, userId, dto));
        }

        /// <summary>
        /// Registra la respuesta de un desarrollador a una devolución previa. Requiere permiso PROJECTS_UPDATE.
        /// </summary>
        /// <param name="devolutionId">ID de la devolución.</param>
        /// <param name="dto">Detalles de la respuesta.</param>
        /// <returns>La devolución actualizada con la respuesta.</returns>
        [HttpPost("devolution/{devolutionId:guid}/response")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> RespondDevolution(Guid devolutionId, [FromBody] RespondDevolutionDto dto)
        {
            _logger.LogInformation("POST /api/projects/devolution/{DevolutionId}/response - Respondiendo devolución.", devolutionId);
            return Ok(await _projectService.RespondToDevolutionAsync(devolutionId, dto));
        }
    }
}
