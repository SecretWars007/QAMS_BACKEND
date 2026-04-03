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
    public class KanbanBoardRepository(QamsDbContext context)
        : GenericRepository<KanbanBoard>(context), IKanbanBoardRepository
    {

        /// <summary>
        /// Obtiene un tablero completo con columnas, tareas,
        /// asignados y prioridades del catálogo.
        /// </summary>
        public async Task<KanbanBoard?> GetFullBoardAsync(Guid boardId)
        {
            return await _dbSet
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.ResponsibleUser)
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
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.ResponsibleUser)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.Priority)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
