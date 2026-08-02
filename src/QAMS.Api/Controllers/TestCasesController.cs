// src/QAMS.Api/Controllers/TestCasesController.cs
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.TestCases;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestCasesController(ITestCaseService service, ILogger<TestCasesController> logger) : ControllerBase
    {
        private readonly ITestCaseService _service = service;
        private readonly ILogger<TestCasesController> _logger = logger;

        /// <summary>
        /// Obtiene un caso de prueba por su ID. Requiere permiso TEST_CASES_VIEW.
        /// </summary>
        /// <param name="id">ID del caso de prueba.</param>
        /// <returns>Detalle del caso de prueba y sus pasos.</returns>
        [HttpGet("{id:guid}")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("GET /api/testcases/{TestCaseId}", id);
            return Ok(await _service.GetByIdAsync(id));
        }

        /// <summary>
        /// Obtiene todos los casos de prueba de una suite. Requiere permiso TEST_CASES_VIEW.
        /// </summary>
        /// <param name="suiteId">ID de la suite de pruebas.</param>
        /// <returns>Lista de casos de prueba.</returns>
        [HttpGet("suite/{suiteId:guid}")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetBySuite(Guid suiteId)
        {
            _logger.LogInformation("GET /api/testcases/suite/{SuiteId}", suiteId);
            return Ok(await _service.GetBySuiteAsync(suiteId));
        }

        /// <summary>
        /// Obtiene todos los casos de prueba de un proyecto. Requiere permiso TEST_CASES_VIEW.
        /// </summary>
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Lista de casos de prueba.</returns>
        [HttpGet]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetByProject([FromQuery] Guid projectId)
        {
            _logger.LogInformation("GET /api/testcases?projectId={ProjectId}", projectId);
            return Ok(await _service.GetByProjectIdAsync(projectId));
        }

        /// <summary>
        /// Obtiene casos de prueba filtrados por proyecto y suite. Requiere permiso TEST_CASES_VIEW.
        /// </summary>
        /// <param name="projectId">ID del proyecto.</param>
        /// <param name="suiteId">ID de la suite.</param>
        /// <returns>Lista de casos de prueba filtrados.</returns>
        [HttpGet("project/{projectId:guid}/suite/{suiteId:guid}")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetByProjectAndSuite(Guid projectId, Guid suiteId)
        {
            _logger.LogInformation("GET /api/testcases/project/{ProjectId}/suite/{SuiteId}", projectId, suiteId);
            return Ok(await _service.GetByProjectAndSuiteAsync(projectId, suiteId));
        }

        /// <summary>
        /// Obtiene los pasos detallados de un caso de prueba. Requiere permiso TEST_CASES_VIEW.
        /// </summary>
        /// <param name="id">ID del caso de prueba.</param>
        /// <returns>Lista de pasos del caso de prueba.</returns>
        [HttpGet("{id:guid}/steps")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> GetSteps(Guid id)
        {
            _logger.LogInformation("GET /api/testcases/{TestCaseId}/steps", id);
            return Ok(await _service.GetStepsAsync(id));
        }

        /// <summary>
        /// Crea un nuevo caso de prueba con sus pasos. Requiere permiso TEST_CASES_CREATE.
        /// </summary>
        /// <param name="dto">Datos del caso de prueba.</param>
        /// <returns>El caso de prueba creado.</returns>
        [HttpPost]
        [HasPermission("TEST_CASES_CREATE")]
        public async Task<IActionResult> Create([FromBody] CreateTestCaseDto dto)
        {
            _logger.LogInformation("POST /api/testcases - Creando caso '{Title}'.", dto.Title);
            var tc = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = tc.Id }, tc);
        }

        /// <summary>
        /// Actualiza un caso de prueba existente. Requiere permiso TEST_CASES_UPDATE.
        /// </summary>
        /// <param name="id">ID del caso a actualizar.</param>
        /// <param name="dto">Nuevos datos del caso.</param>
        /// <returns>El caso actualizado.</returns>
        [HttpPut("{id:guid}")]
        [HasPermission("TEST_CASES_UPDATE")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateTestCaseDto dto)
        {
            _logger.LogInformation("PUT /api/testcases/{TestCaseId} - Actualizando caso.", id);
            return Ok(await _service.UpdateAsync(id, dto));
        }

        /// <summary>
        /// Exporta los casos de prueba de un proyecto a formato CSV. Requiere permiso TEST_CASES_VIEW.
        /// </summary>
        [HttpGet("export/csv")]
        [HasPermission("TEST_CASES_VIEW")]
        public async Task<IActionResult> ExportCsv([FromQuery] Guid projectId)
        {
            _logger.LogInformation("GET /api/testcases/export/csv?projectId={ProjectId}", projectId);
            var testCases = await _service.GetByProjectIdAsync(projectId);

            var sb = new System.Text.StringBuilder();
            sb.AppendLine("ID,Título,Descripción,Precondiciones,Resultado Esperado,Prioridad,Impacto,Probabilidad,ScoreRiesgo,TiempoEstimadoHoras");

            foreach (var tc in testCases)
            {
                var title = $"\"{tc.Title?.Replace("\"", "\"\"")}\"";
                var desc = $"\"{tc.Description?.Replace("\"", "\"\"")}\"";
                var pre = $"\"{tc.Preconditions?.Replace("\"", "\"\"")}\"";
                var exp = $"\"{tc.ExpectedResult?.Replace("\"", "\"\"")}\"";
                sb.AppendLine($"{tc.Id},{title},{desc},{pre},{exp},{tc.PriorityName},{tc.ImpactLevel},{tc.LikelihoodLevel},{tc.RiskScore},{tc.EstimatedTimeHours}");
            }

            var bytes = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            return File(bytes, "text/csv", $"Casos_Prueba_{DateTime.UtcNow:yyyyMMdd}.csv");
        }

        /// <summary>
        /// Realiza una eliminación lógica del caso de prueba. Requiere permiso TEST_CASES_DELETE.
        /// </summary>
        /// <param name="id">ID del caso a eliminar.</param>
        /// <returns>Sin contenido (NoContent).</returns>
        [HttpDelete("{id:guid}")]
        [HasPermission("TEST_CASES_DELETE")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("DELETE /api/testcases/{TestCaseId}", id);
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
