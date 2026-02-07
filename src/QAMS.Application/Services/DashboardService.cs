// src/QAMS.Application/Services/DashboardService.cs
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Dashboard;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de dashboard: métricas y resúmenes para gráficos.
    /// </summary>
    public class DashboardService : IDashboardService
    {
        private readonly IProjectRepository _projectRepo;
        private readonly ITestCaseRepository _testCaseRepo;
        private readonly ITestExecutionRepository _execRepo;
        private readonly IKanbanBoardRepository _boardRepo;
        private readonly ICatalogRepository<ExecutionStatus> _statusRepo;
        private readonly ILogger<DashboardService> _logger;

        public DashboardService(
            IProjectRepository projectRepo,
            ITestCaseRepository testCaseRepo,
            ITestExecutionRepository execRepo,
            IKanbanBoardRepository boardRepo,
            ICatalogRepository<ExecutionStatus> statusRepo,
            ILogger<DashboardService> logger
        )
        {
            _projectRepo = projectRepo;
            _testCaseRepo = testCaseRepo;
            _execRepo = execRepo;
            _boardRepo = boardRepo;
            _statusRepo = statusRepo;
            _logger = logger;
        }

        /// <summary>
        /// Genera un resumen completo del sistema o de un proyecto específico.
        /// Incluye: totales, tasa de aprobación, conteos por estado y progreso Kanban.
        /// </summary>
        public async Task<DashboardSummaryDto> GetSummaryAsync(Guid? projectId = null)
        {
            _logger.LogInformation(
                "Generando dashboard. ProjectId: {ProjectId}.",
                projectId?.ToString() ?? "TODOS"
            );

            var summary = new DashboardSummaryDto();

            // Conteos globales
            summary.TotalProjects = await _projectRepo.CountAsync(p => p.IsActive);
            summary.TotalTestCases = await _testCaseRepo.CountAsync(tc => tc.IsActive);
            summary.TotalExecutions = await _execRepo.CountAsync(_ => true);

            // Obtener estados del catálogo
            var allStatuses = await _statusRepo.GetAllActiveAsync();
            var passedStatus = allStatuses.FirstOrDefault(s => s.Code == "PASSED");
            var failedStatus = allStatuses.FirstOrDefault(s => s.Code == "FAILED");
            var pendingStatus = allStatuses.FirstOrDefault(s => s.Code == "PENDING");

            if (passedStatus != null)
                summary.PassedExecutions = await _execRepo.CountAsync(e =>
                    e.StatusId == passedStatus.Id
                );

            if (failedStatus != null)
                summary.FailedExecutions = await _execRepo.CountAsync(e =>
                    e.StatusId == failedStatus.Id
                );

            if (pendingStatus != null)
                summary.PendingExecutions = await _execRepo.CountAsync(e =>
                    e.StatusId == pendingStatus.Id
                );

            // Calcular tasa de aprobación
            summary.PassRate =
                summary.TotalExecutions > 0
                    ? Math.Round(
                        (double)summary.PassedExecutions / summary.TotalExecutions * 100,
                        2
                    )
                    : 0;

            // Ejecuciones agrupadas por estado (para gráfico de barras/torta)
            if (projectId.HasValue)
            {
                var statusCounts = await _execRepo.GetStatusCountsByProjectAsync(projectId.Value);

                foreach (var kvp in statusCounts)
                {
                    var status = allStatuses.FirstOrDefault(s => s.Id == kvp.Key);
                    if (status != null)
                    {
                        summary.ExecutionsByStatus.Add(
                            new ExecutionsByStatusDto
                            {
                                StatusName = status.Name,
                                StatusCode = status.Code,
                                Count = kvp.Value,
                            }
                        );
                    }
                }
            }

            // Progreso Kanban (tareas por columna)
            if (projectId.HasValue)
            {
                var boards = await _boardRepo.GetByProjectAsync(projectId.Value);
                foreach (var board in boards)
                {
                    foreach (var column in board.Columns)
                    {
                        summary.TaskProgress.Add(
                            new TaskProgressDto
                            {
                                ColumnName = column.Name,
                                TaskCount = column.Tasks.Count,
                            }
                        );
                    }
                }
            }

            _logger.LogInformation(
                "Dashboard generado: {Total} ejecuciones, {Rate}% aprobación.",
                summary.TotalExecutions,
                summary.PassRate
            );

            return summary;
        }
    }
}
