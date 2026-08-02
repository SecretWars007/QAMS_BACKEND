// src/QAMS.Application/Interfaces/IDashboardService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        /// <summary>
        /// Fase 1 ISTQB: Calcula KPIs avanzados (DDP, DRE, MTTR) y evalúa el Quality Gate de un proyecto.
        /// </summary>
        Task<IstqbMetricsDto> GetIstqbMetricsAsync(Guid projectId);

        /// <summary>
        /// Fase 1 ISTQB: Actualiza los umbrales del Quality Gate de un proyecto.
        /// </summary>
        Task UpdateQualityGateAsync(Guid projectId, double minReqCoverage, double minPassRate, int maxOpenDefects, bool requireSut);

    }
}
