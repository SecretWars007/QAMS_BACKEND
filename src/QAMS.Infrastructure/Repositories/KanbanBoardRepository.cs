// src/QAMS.Infrastructure/Repositories/KanbanBoardRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio específico para KanbanBoard.
    /// </summary>
    public class KanbanBoardRepository : GenericRepository<KanbanBoard>, IKanbanBoardRepository
    {
        public KanbanBoardRepository(QamsDbContext context)
            : base(context) { }

        /// <summary>
        /// Obtiene un tablero completo con columnas, tareas,
        /// asignados y prioridades del catálogo.
        /// </summary>
        public async Task<KanbanBoard?> GetFullBoardAsync(Guid boardId)
        {
            return await _dbSet
                .Include(b => b.Columns.OrderBy(c => c.OrderIndex))
                .ThenInclude(c => c.Tasks.OrderBy(t => t.OrderIndex))
                .ThenInclude(t => t.Assignee)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.Priority)
                .FirstOrDefaultAsync(b => b.Id == boardId);
        }

        /// <summary>
        /// Obtiene todos los tableros de un proyecto.
        /// </summary>
        public async Task<IReadOnlyList<KanbanBoard>> GetByProjectAsync(Guid projectId)
        {
            return await _dbSet
                .Where(b => b.ProjectId == projectId)
                .Include(b => b.Columns.OrderBy(c => c.OrderIndex))
                .ThenInclude(c => c.Tasks.OrderBy(t => t.OrderIndex))
                .ThenInclude(t => t.Assignee)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.Priority)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
