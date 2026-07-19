// src/QAMS.Application/Services/DashboardService.cs
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Dashboard;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de dashboard: métricas y resúmenes para gráficos.
    /// </summary>
    public class DashboardService(
        IProjectRepository projectRepo,
        ITestExecutionRepository execRepo,
        ICatalogRepository<ExecutionStatus> statusRepo,
        IGenericRepository<RequirementTestCase> reqTestCaseRepo,
        IDefectRepository defectRepo,
        ILogger<DashboardService> logger
    ) : IDashboardService
    {

        /// <summary>
        /// Genera un resumen de métricas para un usuario específico.
        /// Filtra proyectos, ejecuciones y tareas donde el usuario participa.
        /// </summary>
        public async Task<DashboardSummaryDto> GetSummaryAsync(Guid userId)
        {
            logger.LogInformation("Generando dashboard para el usuario: {UserId}.", userId);

            var summary = new DashboardSummaryDto();

            try
            {
                // 1. Proyectos donde el usuario participa: como tester O si fue el creador
                var userProjects = await projectRepo.FindWithDetailsAsync(p =>
                    p.IsActive && (p.ProjectTesters.Any(pt => pt.UserId == userId) || p.CreatedByUserId == userId));

                // Si no hay proyectos específicos, pero el usuario es admin/etc (opcional), mantenemos fallback o retornamos lo encontrado
                if (userProjects.Count == 0)
                {
                    logger.LogInformation("Usuario {UserId} no tiene proyectos asignados ni creados. Trayendo todos los activos como fallback.", userId);
                    userProjects = await projectRepo.FindWithDetailsAsync(p => p.IsActive);
                }

                summary.TotalProjects = userProjects.Count;
                var allTestCases = userProjects.SelectMany(p => p.TestCases ?? []).ToList();
                summary.TotalTestCases = allTestCases.Count;

                // Casos de prueba pendientes: No tienen ninguna ejecución exitosa (PASSED, ID=3)
                var allTestCaseIds = allTestCases.Select(tc => tc.Id).ToList();
                var passedTestCaseIds = (await execRepo.FindAsync(e =>
                    allTestCaseIds.Contains(e.TestCaseId)))
                    .Where(e => e.IsSuccessful())
                    .Select(e => e.TestCaseId)
                    .Distinct()
                    .ToList();

                summary.PendingTestCases = summary.TotalTestCases - passedTestCaseIds.Count;

                // 3. Métricas de Ejecución (Globales para los proyectos del usuario)
                var allExecutionsForProjects = await execRepo.FindAsync(e => allTestCaseIds.Contains(e.TestCaseId));
                summary.TotalExecutions = allExecutionsForProjects.Count;

                var allStatuses = await statusRepo.GetAllActiveAsync();
                var passedStatus = allStatuses.FirstOrDefault(s => s.Code == "PASSED");
                var failedStatus = allStatuses.FirstOrDefault(s => s.Code == "FAILED");
                var pendingStatus = allStatuses.FirstOrDefault(s => s.Code == "PENDING");

                if (passedStatus != null)
                    summary.PassedExecutions = allExecutionsForProjects.Count(e => e.StatusId == passedStatus.Id);

                if (failedStatus != null)
                    summary.FailedExecutions = allExecutionsForProjects.Count(e => e.StatusId == failedStatus.Id);

                if (pendingStatus != null)
                    summary.PendingExecutions = allExecutionsForProjects.Count(e => e.StatusId == pendingStatus.Id);

                // Tasa de Aprobación: Basada en Casos de Prueba (Cuántos tienen al menos una ejecución exitosa)
                summary.PassRate = summary.TotalTestCases > 0
                    ? Math.Round((double)passedTestCaseIds.Count / summary.TotalTestCases * 100, 2)
                    : 0;

                // Agrupado por estado para el gráfico (Doughnut)
                var statusGrouped = allExecutionsForProjects
                    .GroupBy(e => e.StatusId)
                    .Select(g => new { StatusId = g.Key, Count = g.Count() });

                foreach (var item in statusGrouped)
                {
                    var status = allStatuses.FirstOrDefault(s => s.Id == item.StatusId);
                    if (status != null)
                    {
                        summary.ExecutionsByStatus.Add(new ExecutionsByStatusDto
                        {
                            StatusName = status.Name,
                            StatusCode = status.Code,
                            Count = item.Count
                        });
                    }
                }

                var userTasks = userProjects
                    .SelectMany(p => p.KanbanBoards ?? [])
                    .SelectMany(b => b.Columns ?? [])
                    .GroupBy(c => c.Name)
                    .Select(g => new TaskProgressDto
                    {
                        ColumnName = g.Key,
                        TaskCount = g.Sum(c => c.Tasks?.Count ?? 0)
                    })
                    .ToList();

                summary.TaskProgress.AddRange(userTasks);

                // ── ISTQB: Métricas de Defectos ──
                var projectIds = userProjects.Select(p => p.Id).ToList();
                int openDefectsCount = 0;
                foreach (var pId in projectIds)
                {
                    openDefectsCount += await defectRepo.CountOpenDefectsByProjectAsync(pId);
                }
                summary.OpenDefects = openDefectsCount;

                // ── ISTQB: Cobertura de Requisitos ──
                var allRequirements = userProjects.SelectMany(p => p.Requirements ?? []).ToList();
                summary.TotalRequirements = allRequirements.Count;

                if (summary.TotalRequirements > 0)
                {
                    var allReqIds = allRequirements.Select(r => r.Id).ToList();

                    // Buscar en tabla puente cuántos requerimientos tienen al menos un caso de prueba
                    var links = await reqTestCaseRepo.FindAsync(rt => allReqIds.Contains(rt.RequirementId));
                    var coveredReqIds = links.Select(rt => rt.RequirementId).Distinct().ToList();

                    summary.CoveredRequirements = coveredReqIds.Count;
                    summary.RequirementCoverageRate = Math.Round((double)summary.CoveredRequirements / summary.TotalRequirements * 100, 2);
                }
                else
                {
                    summary.CoveredRequirements = 0;
                    summary.RequirementCoverageRate = 0;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error generando dashboard para el usuario: {UserId}.", userId);
            }

            logger.LogInformation(
                "Dashboard generado for {UserId}: {Total} ejecuciones, {Rate}% aprobación.",
                userId, summary.TotalExecutions, summary.PassRate
            );

            return summary;
        }

        public async Task<List<TimelineEventDto>> GetProjectTimelineAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo timeline para el proyecto: {ProjectId}.", projectId);

            // Obtenemos el proyecto para tener la fecha de inicio basica
            var project = await projectRepo.GetByIdAsync(projectId);
            var startDate = project?.CreatedAt.Date ?? DateTime.MinValue.Date;

            // Obtenemos las ejecuciones del proyecto con detalles de estados y resultados de pasos
            var projectExecutions = await execRepo.GetByProjectAsync(projectId);

            // Ordenamos por fecha de ejecución
            var sortedExecs = projectExecutions
                .OrderBy(e => e.ExecutionDate)
                .ToList();

            var timeline = new List<TimelineEventDto>();

            foreach (var exec in sortedExecs)
            {
                var eventDto = new TimelineEventDto
                {
                    ExecutionId = exec.Id,
                    TestCaseTitle = exec.TestCase?.Title ?? "Prueba Individual",
                    ExecutionDate = exec.ExecutionDate,
                    StatusId = exec.StatusId,
                    Hour = exec.ExecutionDate.Hour,
                    DayIndex = (project != null) ? (int)(exec.ExecutionDate.Date - startDate).TotalDays : 0
                };

                // Lógica de Estado e Inteligencia (Sincronizada con el Reporte PDF)
                var isTrulyPassed = exec.IsSuccessful();
                var isInReview = exec.IsInReview();
                var isEnProgreso = exec.StatusId == 2 || exec.Status?.Code == "IN_PROGRESS";

                if (isTrulyPassed)
                {
                    eventDto.StatusName = "Aprobado";
                    eventDto.StatusColor = "#4CAF50";
                }
                else if (isEnProgreso)
                {
                    if (isInReview)
                    {
                        eventDto.StatusName = "Completado/En Revisión";
                        eventDto.StatusColor = "#4CAF50";
                    }
                    else
                    {
                        eventDto.StatusName = "En Progreso";
                        eventDto.StatusColor = "#2196F3";
                    }
                }
                else if (exec.IsFailed())
                {
                    eventDto.StatusName = "Fallido";
                    eventDto.StatusColor = "#F44336";
                }
                else
                {
                    eventDto.StatusName = exec.Status?.Name ?? "Pendiente";
                    eventDto.StatusColor = "#9E9E9E";
                }

                timeline.Add(eventDto);
            }

            return timeline;
        }

        public async Task<TimelineChartDto> GetTimelineChartDataAsync(Guid projectId)
        {
            var events = await GetProjectTimelineAsync(projectId);
            var result = new TimelineChartDto
            {
                Events = events
            };

            if (events.Count > 0)
            {
                result.MinHour = events.Min(e => e.Hour);
                result.MaxHour = events.Max(e => e.Hour);

                // Generamos etiquetas de días únicos DD/MM
                result.DayLabels = [.. events
                    .OrderBy(e => e.ExecutionDate)
                    .Select(e => e.ExecutionDate.ToString("dd/MM"))
                    .Distinct()];
            }

            return result;
        }

        public async Task<List<BurndownPointDto>> GetBurndownDataAsync(Guid projectId)
        {
            logger.LogInformation("Calculando burndown (horas) para el proyecto: {ProjectId}.", projectId);

            var project = await projectRepo.FindWithDetailsAsync(p => p.Id == projectId);
            var projectEntity = project.FirstOrDefault();
            if (projectEntity == null) return [];

            var totalHours = projectEntity.GetCalculatedTotalHours();
            var executions = await execRepo.GetByProjectAsync(projectId);

            // Determinar rango de fechas
            var startDate = projectEntity.StartDate ?? projectEntity.CreatedAt;
            var endDate = projectEntity.EndDate ?? (executions.Any() ? executions.Max(e => e.ExecutionDate) : DateTime.Now);

            if (endDate < startDate) endDate = startDate.AddDays(7);

            var burndown = new List<BurndownPointDto>();
            decimal idealRemaining = totalHours;
            decimal actualRemaining = totalHours;
            decimal burnRate = projectEntity.WorkHoursPerDay > 0 ? projectEntity.WorkHoursPerDay : 7;

            // Agrupar ejecuciones exitosas por día
            var completedHoursByDay = executions
                .Where(e => e.IsSuccessful())
                .GroupBy(e => e.ExecutionDate.Date)
                .ToDictionary(g => g.Key, g => g.Select(e => e.TestCase?.EstimatedTimeHours ?? 0).Sum());

            var current = startDate.Date;
            var finalDate = endDate.Date;

            while (current <= finalDate || current <= DateTime.Now.Date)
            {
                // Excluir fines de semana de los puntos de datos del gráfico
                if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
                {
                    burndown.Add(new BurndownPointDto
                    {
                        Date = current,
                        DateLabel = current.ToString("dd/MM"),
                        IdealHours = Math.Max(0, idealRemaining),
                        ActualHours = Math.Max(0, actualRemaining)
                    });

                    if (completedHoursByDay.TryGetValue(current, out var burnedToday))
                    {
                        actualRemaining -= burnedToday;
                    }

                    idealRemaining -= burnRate;
                }

                current = current.AddDays(1);

                // Limites de seguridad para evitar loops infinitos
                if (current > finalDate && current > DateTime.Now.Date) break;
                if (current > startDate.AddDays(365)) break;
            }

            return burndown;
        }

        public async Task<List<DrawdownPointDto>> GetDrawdownDataAsync(Guid projectId)
        {
            logger.LogInformation("Calculando drawdown para el proyecto: {ProjectId}.", projectId);

            var project = await projectRepo.GetByIdAsync(projectId);
            if (project == null) return [];

            var totalCases = project.TestCases.Count;
            var executions = await execRepo.GetByProjectAsync(projectId);

            // Agrupar por fecha (solo fecha, sin hora)
            var execsByDay = executions
                .OrderBy(e => e.ExecutionDate)
                .GroupBy(e => e.ExecutionDate.Date)
                .ToList();

            var drawdown = new List<DrawdownPointDto>();
            var passedTestCases = new HashSet<Guid>();

            // Si no hay ejecuciones, punto inicial con todo pendiente
            if (execsByDay.Count == 0)
            {
                drawdown.Add(new DrawdownPointDto
                {
                    Date = DateTime.Now.Date,
                    DateLabel = DateTime.Now.ToString("dd/MM"),
                    RemainingCases = totalCases,
                    PassedTotal = 0,
                    PercentageRemaining = 100
                });
                return drawdown;
            }

            foreach (var dayGroup in execsByDay)
            {
                foreach (var exec in dayGroup)
                {
                    // Lógica inteligente de "Aprobado"
                    if (exec.IsSuccessful())
                    {
                        passedTestCases.Add(exec.TestCaseId);
                    }
                }

                var remaining = totalCases - passedTestCases.Count;
                drawdown.Add(new DrawdownPointDto
                {
                    Date = dayGroup.Key,
                    DateLabel = dayGroup.Key.ToString("dd/MM"),
                    RemainingCases = remaining,
                    PassedTotal = passedTestCases.Count,
                    PercentageRemaining = totalCases > 0 ? Math.Round((double)remaining / totalCases * 100, 2) : 0
                });
            }

            return drawdown;
        }
    }
}
