// src/QAMS.Api/Controllers/DashboardController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetSummary([FromQuery] Guid userId)
        {
            var summary = await _dashboardService.GetSummaryAsync(userId);
            return Ok(summary);
        }

        [HttpGet("project/{projectId}/timeline")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetProjectTimeline(Guid projectId)
        {
            var timeline = await _dashboardService.GetProjectTimelineAsync(projectId);
            return Ok(timeline);
        }

        [HttpGet("project/{projectId}/timeline-chart")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetTimelineChartData(Guid projectId)
        {
            var chartData = await _dashboardService.GetTimelineChartDataAsync(projectId);
            return Ok(chartData);
        }

        [HttpGet("project/{projectId}/drawdown")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetDrawdownData(Guid projectId)
        {
            var drawdownData = await _dashboardService.GetDrawdownDataAsync(projectId);
            return Ok(drawdownData);
        }

        [HttpGet("project/{projectId}/burndown")]
        [HasPermission("DASHBOARD_VIEW")]
        public async Task<IActionResult> GetBurndownData(Guid projectId)
        {
            var burndownData = await _dashboardService.GetBurndownDataAsync(projectId);
            return Ok(burndownData);
        }
    }
}
