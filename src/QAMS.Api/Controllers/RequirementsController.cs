// src/QAMS.Api/Controllers/RequirementsController.cs
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Projects;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequirementsController(
        IRequirementService requirementService,
        ILogger<RequirementsController> logger) : ControllerBase
    {
        /// <summary>
        /// Obtiene un requisito funcional por su ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            logger.LogInformation("GET /api/requirements/{Id}", id);
            return Ok(await requirementService.GetByIdAsync(id));
        }

        /// <summary>
        /// Obtiene todos los requisitos funcionales asociados a un proyecto.
        /// </summary>
        [HttpGet("project/{projectId:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetByProject(Guid projectId)
        {
            logger.LogInformation("GET /api/requirements/project/{ProjectId}", projectId);
            return Ok(await requirementService.GetByProjectIdAsync(projectId));
        }

        /// <summary>
        /// Agrega un nuevo requisito funcional a un proyecto.
        /// </summary>
        [HttpPost("project/{projectId:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Create(Guid projectId, [FromBody] CreateRequirementDto dto)
        {
            logger.LogInformation("POST /api/requirements/project/{ProjectId}", projectId);
            var result = await requirementService.CreateAsync(projectId, dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Actualiza un requisito funcional específico.
        /// </summary>
        [HttpPut("{id:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateRequirementDto dto)
        {
            logger.LogInformation("PUT /api/requirements/{Id}", id);
            return Ok(await requirementService.UpdateAsync(id, dto));
        }

        /// <summary>
        /// Realiza una eliminación lógica de un requisito funcional.
        /// </summary>
        [HttpDelete("{id:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            logger.LogInformation("DELETE /api/requirements/{Id}", id);
            await requirementService.DeleteAsync(id);
            return NoContent();
        }
    }
}
