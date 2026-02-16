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
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(QamsDbContext context) : base(context) { }

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
                .Include(p => p.KanbanBoards)
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
