// src/QAMS.Api/Controllers/TestSuitesController.cs
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.TestSuites;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestSuitesController(ITestSuiteService service, ILogger<TestSuitesController> logger) : ControllerBase
    {
        private readonly ITestSuiteService _service = service;
        private readonly ILogger<TestSuitesController> _logger = logger;

        /// <summary>
        /// Crea una nueva suite de pruebas dentro de un proyecto. Requiere permiso PROJECTS_CREATE.
        /// </summary>
        /// <param name="dto">Datos de la suite y el ID del proyecto asociado.</param>
        /// <returns>La suite de pruebas creada.</returns>
        [HttpPost]
        [HasPermission("PROJECTS_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateTestSuiteDto dto)
        {
            _logger.LogInformation("POST /api/testsuites - Creando suite '{Name}' para proyecto {ProjectId}.", dto.Name, dto.ProjectId);
            var suite = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = suite.Id }, suite);
        }

        /// <summary>
        /// Obtiene una suite de pruebas por su ID. Requiere permiso PROJECTS_VIEW.
        /// </summary>
        /// <param name="id">ID de la suite.</param>
        /// <returns>Detalle de la suite.</returns>
        [HttpGet("{id:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/testsuites/{SuiteId}", id);
            return Ok(await _service.GetByIdAsync(id));
        }

        /// <summary>
        /// Obtiene todas las suites de pruebas pertenecientes a un proyecto. Requiere permiso PROJECTS_VIEW.
        /// </summary>
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Lista de suites de pruebas.</returns>
        [HttpGet("project/{projectId:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetByProject(Guid projectId)
        {
            _logger.LogInformation("GET /api/testsuites/project/{ProjectId}", projectId);
            return Ok(await _service.GetByProjectIdAsync(projectId));
        }

        /// <summary>
        /// Actualiza el nombre o descripción de una suite. Requiere permiso PROJECTS_UPDATE.
        /// </summary>
        /// <param name="id">ID de la suite a actualizar.</param>
        /// <param name="dto">Nuevos datos de la suite.</param>
        /// <returns>La suite actualizada.</returns>
        [HttpPut("{id:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateTestSuiteDto dto)
        {
            _logger.LogInformation("PUT /api/testsuites/{SuiteId} - Actualizando suite.", id);
            return Ok(await _service.UpdateAsync(id, dto));
        }

        /// <summary>
        /// Elimina una suite de pruebas. Requiere permiso PROJECTS_DELETE.
        /// </summary>
        /// <param name="id">ID de la suite a eliminar.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpDelete("{id:guid}")]
        [HasPermission("PROJECTS_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/testsuites/{SuiteId}", id);
            await _service.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Obtiene estadísticas resumidas de ejecución para una suite (Pass, Fail, Pending). Requiere permiso PROJECTS_VIEW.
        /// </summary>
        /// <param name="id">ID de la suite.</param>
        /// <returns>Objeto con contadores de estados de prueba.</returns>
        [HttpGet("{id:guid}/stats")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetStats(Guid id)
        {
            _logger.LogInformation("GET /api/testsuites/{SuiteId}/stats", id);
            return Ok(await _service.GetSummaryStatsAsync(id));
        }

        /// <summary>
        /// Clona una suite de pruebas y todos sus casos de prueba asociados con un nuevo nombre. Requiere permiso PROJECTS_CREATE.
        /// </summary>
        /// <param name="id">ID de la suite origen.</param>
        /// <param name="newName">Nombre para la nueva suite duplicada.</param>
        /// <returns>La nueva suite clonada.</returns>
        [HttpPost("{id:guid}/clone")]
        [HasPermission("PROJECTS_CREATE")]
        public async Task<IActionResult> Clone(Guid id, [FromQuery] string newName)
        {
            _logger.LogInformation("POST /api/testsuites/{SuiteId}/clone", id);
            return Ok(await _service.CloneAsync(id, newName));
        }

        /// <summary>
        /// Mueve una suite de pruebas a un proyecto diferente. Requiere permiso PROJECTS_UPDATE.
        /// </summary>
        /// <param name="id">ID de la suite.</param>
        /// <param name="projectId">ID del proyecto destino.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpPatch("{id:guid}/move/{projectId:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Move(Guid id, Guid projectId)
        {
            _logger.LogInformation("PATCH /api/testsuites/{SuiteId}/move/{ProjectId}", id, projectId);
            await _service.MoveToProjectAsync(id, projectId);
            return NoContent();
        }
    }
}
