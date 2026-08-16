// src/QAMS.Api/Controllers/DashboardController.cs
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Dashboard;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController(IDashboardService dashboardService, ILogger<DashboardController> logger) : ControllerBase
    {
        private readonly IDashboardService _dashboardService = dashboardService;
        private readonly ILogger<DashboardController> _logger = logger;

        /// <summary>
        /// Obtiene un resumen general de estadísticas para un usuario. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        /// <param name="userId">Opcional. ID del usuario para filtrar el resumen. Si no se provee, usa el usuario actual.</param>
        /// <returns>Objeto con contadores de proyectos, casos de prueba y ejecuciones.</returns>
        [HttpGet]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetSummary(
            [FromQuery] Guid? userId = null,
            [FromQuery] Guid? sutId = null,
            [FromQuery] Guid? testerUserId = null)
        {
            var currentUserIdStr = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var currentUserId = currentUserIdStr != null ? Guid.Parse(currentUserIdStr) : Guid.Empty;
            var targetUserId = userId ?? currentUserId;

            // Determinar si el usuario tiene rol privilegiado
            bool isPrivileged = User.IsInRole("Administrator") || User.IsInRole("Líder de Pruebas (Lead)");

            _logger.LogInformation("GET /api/Dashboard - Obteniendo resumen para usuario {UserId}. Privileged: {IsPrivileged}", targetUserId, isPrivileged);
            var summary = await _dashboardService.GetSummaryAsync(targetUserId, isPrivileged, sutId, testerUserId);
            return Ok(summary);
        }

        /// <summary>
        /// Obtiene un resumen de estadísticas para el usuario autenticado actual. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        /// <returns>Resumen del dashboard para el usuario logueado.</returns>
        [HttpGet("summary")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetSummaryForCurrentUser()
        {
            var userIdStr = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var userId = userIdStr != null ? Guid.Parse(userIdStr) : Guid.Empty;

            _logger.LogInformation("GET /api/Dashboard/summary - Obteniendo resumen para usuario logueado {UserId}", userId);
            var summary = await _dashboardService.GetSummaryAsync(userId);
            return Ok(summary);
        }

        /// <summary>
        /// Obtiene la línea de tiempo de eventos para un proyecto específico. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        /// <param name="projectId">ID único del proyecto.</param>
        /// <returns>Lista de eventos cronológicos del proyecto.</returns>
        [HttpGet("project/{projectId:guid}/timeline")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetProjectTimeline(Guid projectId)
        {
            _logger.LogInformation("GET /api/dashboard/project/{ProjectId}/timeline", projectId);
            var timeline = await _dashboardService.GetProjectTimelineAsync(projectId);
            return Ok(timeline);
        }

        /// <summary>
        /// Obtiene datos formateados para el gráfico de línea de tiempo de un proyecto. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Datos estructurados para gráficos de progreso temporal.</returns>
        [HttpGet("project/{projectId:guid}/chart/timeline")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetTimelineChartData(Guid projectId)
        {
            _logger.LogInformation("GET /api/dashboard/project/{ProjectId}/chart/timeline", projectId);
            var data = await _dashboardService.GetTimelineChartDataAsync(projectId);
            return Ok(data);
        }

        /// <summary>
        /// Obtiene datos para el gráfico de Drawdown (fallos acumulados) de un proyecto. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Serie de datos para gráfico de drawdown.</returns>
        [HttpGet("project/{projectId:guid}/chart/drawdown")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetDrawdownData(Guid projectId)
        {
            _logger.LogInformation("GET /api/dashboard/project/{ProjectId}/chart/drawdown", projectId);
            var data = await _dashboardService.GetDrawdownDataAsync(projectId);
            return Ok(data);
        }

        /// <summary>
        /// Obtiene datos para el gráfico de Burndown (trabajo pendiente/ejecuciones) de un proyecto. Requiere permiso DASHBOARD_VIEW.
        /// </summary>
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Serie de datos para gráfico de burndown.</returns>
        [HttpGet("project/{projectId:guid}/chart/burndown")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetBurndownData(Guid projectId)
        {
            _logger.LogInformation("GET /api/dashboard/project/{ProjectId}/chart/burndown", projectId);
            var data = await _dashboardService.GetBurndownDataAsync(projectId);
            return Ok(data);
        }

        /// <summary>
        /// ISTQB Fase 1: Obtiene KPIs avanzados (DDP, DRE, MTTR) y el estado del Quality Gate de un proyecto.
        /// </summary>
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Objeto IstqbMetricsDto con métricas ISTQB y resultado del Quality Gate.</returns>
        [HttpGet("project/{projectId:guid}/istqb-metrics")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetIstqbMetrics(Guid projectId)
        {
            _logger.LogInformation("GET /api/dashboard/project/{ProjectId}/istqb-metrics", projectId);
            var metrics = await _dashboardService.GetIstqbMetricsAsync(projectId);
            return Ok(metrics);
        }

        /// <summary>
        /// ISTQB Fase 1: Actualiza los umbrales del Quality Gate de un proyecto. Requiere permiso PROJECT_MANAGE.
        /// </summary>
        [HttpPut("project/{projectId:guid}/quality-gate")]
        [HasPermission("PROJECT_MANAGE")]
        public async Task<IActionResult> UpdateQualityGate(Guid projectId, [FromBody] UpdateQualityGateRequest request)
        {
            _logger.LogInformation("PUT /api/dashboard/project/{ProjectId}/quality-gate", projectId);
            await _dashboardService.UpdateQualityGateAsync(
                projectId,
                request.MinRequirementCoverage,
                request.MinPassRate,
                request.MaxOpenDefects,
                request.RequireSutLinked);
            return NoContent();
        }
    }

    public record UpdateQualityGateRequest(
        double MinRequirementCoverage,
        double MinPassRate,
        int MaxOpenDefects,
        bool RequireSutLinked
    );
}
