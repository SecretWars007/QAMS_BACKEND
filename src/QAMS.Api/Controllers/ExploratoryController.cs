// src/QAMS.Api/Controllers/ExploratoryController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Exploratory;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    /// <summary>
    /// Sesiones de Prueba Exploratoria (ISTQB Cap. 4.4 — Técnicas basadas en experiencia).
    /// Permite gestionar sesiones time-boxed con charter y hallazgos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class ExploratoryController(
        IExploratoryService service,
        ILogger<ExploratoryController> logger) : ControllerBase
    {
        private readonly IExploratoryService _service = service;
        private readonly ILogger<ExploratoryController> _logger = logger;

        /// <summary>Lista todas las sesiones exploratorias de un proyecto.</summary>
        [HttpGet("project/{projectId:guid}")]
        [HasPermission("EXECUTIONS_VIEW")]
        public async Task<IActionResult> GetByProject(Guid projectId)
        {
            _logger.LogInformation("GET /api/exploratory/project/{ProjectId}", projectId);
            return Ok(await _service.GetByProjectAsync(projectId));
        }

        /// <summary>Obtiene el detalle de una sesión exploratoria con sus hallazgos.</summary>
        [HttpGet("{id:guid}")]
        [HasPermission("EXECUTIONS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/exploratory/{Id}", id);
            return Ok(await _service.GetByIdAsync(id));
        }

        /// <summary>Crea una nueva sesión de prueba exploratoria.</summary>
        [HttpPost]
        [HasPermission("EXECUTIONS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateExploratorySessionDto dto)
        {
            _logger.LogInformation("POST /api/exploratory");
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>Inicia una sesión exploratoria (cambia estado a En Progreso).</summary>
        [HttpPost("{id:guid}/start")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> Start(Guid id)
        {
            _logger.LogInformation("POST /api/exploratory/{Id}/start", id);
            return Ok(await _service.StartSessionAsync(id));
        }

        /// <summary>Completa una sesión exploratoria con notas y duración.</summary>
        [HttpPost("{id:guid}/complete")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> Complete(Guid id, [FromBody] UpdateExploratorySessionDto dto)
        {
            _logger.LogInformation("POST /api/exploratory/{Id}/complete", id);
            return Ok(await _service.CompleteSessionAsync(id, dto));
        }

        /// <summary>Elimina una sesión exploratoria (soft delete).</summary>
        [HttpDelete("{id:guid}")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/exploratory/{Id}", id);
            await _service.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>Agrega un hallazgo a una sesión exploratoria.</summary>
        [HttpPost("finding")]
        [HasPermission("EXECUTIONS_CREATE")]
        public async Task<IActionResult> AddFinding([FromBody] CreateExploratoryFindingDto dto)
        {
            _logger.LogInformation("POST /api/exploratory/finding");
            return Ok(await _service.AddFindingAsync(dto));
        }

        /// <summary>Elimina un hallazgo de una sesión exploratoria.</summary>
        [HttpDelete("finding/{findingId:guid}")]
        [HasPermission("EXECUTIONS_UPDATE")]
        public async Task<IActionResult> DeleteFinding(Guid findingId)
        {
            _logger.LogInformation("DELETE /api/exploratory/finding/{FindingId}", findingId);
            await _service.DeleteFindingAsync(findingId);
            return NoContent();
        }
    }
}
