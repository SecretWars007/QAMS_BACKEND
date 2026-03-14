// src/QAMS.Application/Interfaces/IDashboardService.cs
using QAMS.Application.DTOs.Dashboard;

namespace QAMS.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardSummaryDto> GetSummaryAsync(Guid userId);
        Task<List<TimelineEventDto>> GetProjectTimelineAsync(Guid projectId);
        Task<TimelineChartDto> GetTimelineChartDataAsync(Guid projectId);
        Task<List<DrawdownPointDto>> GetDrawdownDataAsync(Guid projectId);
        Task<List<BurndownPointDto>> GetBurndownDataAsync(Guid projectId);
    }
}
