// src/QAMS.Application/Interfaces/IDashboardService.cs
using QAMS.Application.DTOs.Dashboard;

namespace QAMS.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardSummaryDto> GetSummaryAsync(Guid? projectId = null);
    }
}
