// src/QAMS.Api/Controllers/DashboardController.cs
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

        [HttpGet]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetSummary([FromQuery] Guid? userId = null)
        {
            var currentUserIdStr = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var currentUserId = currentUserIdStr != null ? Guid.Parse(currentUserIdStr) : Guid.Empty;

            var targetUserId = userId ?? currentUserId;
            
            _logger.LogInformation("GET /api/Dashboard - Obteniendo resumen para usuario {UserId}", targetUserId);
            var summary = await _dashboardService.GetSummaryAsync(targetUserId);
            return Ok(summary);
        }

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

        [HttpGet("project/{projectId:guid}/timeline")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetProjectTimeline(Guid projectId)
        {
            _logger.LogInformation("GET /api/dashboard/project/{ProjectId}/timeline", projectId);
            var timeline = await _dashboardService.GetProjectTimelineAsync(projectId);
            return Ok(timeline);
        }

        [HttpGet("project/{projectId:guid}/chart/timeline")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetTimelineChartData(Guid projectId)
        {
            _logger.LogInformation("GET /api/dashboard/project/{ProjectId}/chart/timeline", projectId);
            var data = await _dashboardService.GetTimelineChartDataAsync(projectId);
            return Ok(data);
        }

        [HttpGet("project/{projectId:guid}/chart/drawdown")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetDrawdownData(Guid projectId)
        {
            _logger.LogInformation("GET /api/dashboard/project/{ProjectId}/chart/drawdown", projectId);
            var data = await _dashboardService.GetDrawdownDataAsync(projectId);
            return Ok(data);
        }

        [HttpGet("project/{projectId:guid}/chart/burndown")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetBurndownData(Guid projectId)
        {
            _logger.LogInformation("GET /api/dashboard/project/{ProjectId}/chart/burndown", projectId);
            var data = await _dashboardService.GetBurndownDataAsync(projectId);
            return Ok(data);
        }
    }
}
