// src/QAMS.Infrastructure/Repositories/ProjectRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio específico para Project.
    /// Proporciona consultas con eager loading de suites y tableros.
    /// </summary>
    public class ProjectRepository(QamsDbContext context)
        : GenericRepository<Project>(context), IProjectRepository
    {

        /// <summary>
        /// Obtiene un proyecto con todas sus suites de prueba.
        /// </summary>
        public async Task<Project?> GetWithTestSuitesAsync(Guid projectId)
        {
            return await _dbSet
                .Include(p => p.TestSuites)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }

        /// <summary>
        /// Obtiene un proyecto con todos sus tableros Kanban.
        /// </summary>
        public async Task<Project?> GetWithKanbanBoardsAsync(Guid projectId)
        {
            return await _dbSet
                .Include(p => p.KanbanBoards)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task<Project?> GetWithDetailsAsync(Guid projectId)
        {
            return await _dbSet
                .Include(p => p.CreatedBy)
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProjectTesters)
                    .ThenInclude(pt => pt.User)
                .Include(p => p.TestSuites)
                .Include(p => p.KanbanBoards)
                .Include(p => p.HistoricDevolutions)
                .Include(p => p.Requirements)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task<Project?> GetByIdTrackedAsync(Guid projectId)
        {
            return await _dbSet
                .Include(p => p.TestCases)
                    .ThenInclude(tc => tc.TestExecutions)
                        .ThenInclude(te => te.Status)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task<List<Project>> FindWithDetailsAsync(System.Linq.Expressions.Expression<Func<Project, bool>> predicate)
        {
            return await _dbSet
                .Include(p => p.CreatedBy)
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProjectTesters)
                    .ThenInclude(pt => pt.User)
                .Include(p => p.TestSuites)
                .Include(p => p.TestCases)
                    .ThenInclude(tc => tc.TestSteps)
                .Include(p => p.KanbanBoards)
                    .ThenInclude(kb => kb.Columns)
                        .ThenInclude(kc => kc.Tasks)
                .Include(p => p.HistoricDevolutions)
                .Include(p => p.Requirements)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<Project?> GetFullProjectForComplianceReportAsync(Guid projectId)
        {
            return await _dbSet
                .Include(p => p.ProjectStatus)
                .Include(p => p.CreatedBy)
                .Include(p => p.TestCases)
                    .ThenInclude(tc => tc.TestExecutions)
                        .ThenInclude(te => te.Status)
                .Include(p => p.TestCases)
                    .ThenInclude(tc => tc.TestExecutions)
                        .ThenInclude(te => te.StepResults)
                            .ThenInclude(sr => sr.Status)
                .Include(p => p.TestCases)
                    .ThenInclude(tc => tc.TestExecutions)
                        .ThenInclude(te => te.StepResults)
                            .ThenInclude(sr => sr.TestStep)
                .Include(p => p.TestCases)
                    .ThenInclude(tc => tc.TestExecutions)
                        .ThenInclude(te => te.Evidences)
                            .ThenInclude(ev => ev.FileType)
                .Include(p => p.HistoricDevolutions)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }
    }
}
