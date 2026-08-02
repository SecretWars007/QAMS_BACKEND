// src/QAMS.Api/Controllers/TestEnvironmentsController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.TestEnvironments;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    /// <summary>
    /// Gestión de Entornos de Prueba (ISTQB Cap. 5.4).
    /// Registra la configuración formal de entornos para reproducir pruebas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class TestEnvironmentsController(
        ITestEnvironmentService service,
        ILogger<TestEnvironmentsController> logger) : ControllerBase
    {
        private readonly ITestEnvironmentService _service = service;
        private readonly ILogger<TestEnvironmentsController> _logger = logger;

        /// <summary>Lista todos los entornos de prueba de un proyecto.</summary>
        [HttpGet("project/{projectId:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetByProject(Guid projectId)
        {
            _logger.LogInformation("GET /api/testenvironments/project/{ProjectId}", projectId);
            return Ok(await _service.GetByProjectAsync(projectId));
        }

        /// <summary>Obtiene el detalle de un entorno de prueba.</summary>
        [HttpGet("{id:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/testenvironments/{Id}", id);
            return Ok(await _service.GetByIdAsync(id));
        }

        /// <summary>Crea un nuevo entorno de prueba para un proyecto.</summary>
        [HttpPost]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Create([FromBody] CreateTestEnvironmentDto dto)
        {
            _logger.LogInformation("POST /api/testenvironments");
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>Actualiza un entorno de prueba existente.</summary>
        [HttpPut("{id:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTestEnvironmentDto dto)
        {
            _logger.LogInformation("PUT /api/testenvironments/{Id}", id);
            return Ok(await _service.UpdateAsync(id, dto));
        }

        /// <summary>Elimina un entorno de prueba (soft delete).</summary>
        [HttpDelete("{id:guid}")]
        [HasPermission("PROJECTS_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/testenvironments/{Id}", id);
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
