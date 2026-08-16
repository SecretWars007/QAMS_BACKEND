// src/QAMS.Infrastructure/Repositories/KanbanBoardRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio específico para KanbanBoard.
    /// Carga el tablero completo con datos enriquecidos de certificación ISTQB:
    /// casos de prueba, pasos, defectos abiertos y última ejecución.
    /// </summary>
    public class KanbanBoardRepository(QamsDbContext context)
        : GenericRepository<KanbanBoard>(context), IKanbanBoardRepository
    {

        /// <summary>
        /// Obtiene un tablero completo con columnas, tareas,
        /// asignados, prioridades, caso de prueba vinculado,
        /// pasos, defectos abiertos y última ejecución.
        /// </summary>
        public async Task<KanbanBoard?> GetFullBoardAsync(Guid boardId)
        {
            return await _dbSet
                .Include(b => b.Columns.OrderBy(c => c.OrderIndex))
                .ThenInclude(c => c.Tasks.OrderBy(t => t.OrderIndex))
                .ThenInclude(t => t.ResponsibleUser)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.Priority)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.TestCase!)
                .ThenInclude(tc => tc.TestSteps)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.TestCase!)
                .ThenInclude(tc => tc.Defects)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.TestCase!)
                .ThenInclude(tc => tc.TestExecutions.OrderByDescending(e => e.CreatedAt).Take(1))
                .ThenInclude(e => e.Status)
                .Include(b => b.Project!)
                .ThenInclude(p => p.SystemUnderTest)
                .FirstOrDefaultAsync(b => b.Id == boardId);
        }

        /// <summary>
        /// Obtiene todos los tableros de un proyecto con datos enriquecidos.
        /// </summary>
        public async Task<IReadOnlyList<KanbanBoard>> GetByProjectAsync(Guid projectId)
        {
            return await _dbSet
                .Where(b => b.ProjectId == projectId && !b.IsDeleted)
                .Include(b => b.Columns.OrderBy(c => c.OrderIndex))
                .ThenInclude(c => c.Tasks.OrderBy(t => t.OrderIndex))
                .ThenInclude(t => t.ResponsibleUser)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.Priority)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.TestCase!)
                .ThenInclude(tc => tc.TestSteps)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.TestCase!)
                .ThenInclude(tc => tc.Defects)
                .Include(b => b.Columns)
                .ThenInclude(c => c.Tasks)
                .ThenInclude(t => t.TestCase!)
                .ThenInclude(tc => tc.TestExecutions.OrderByDescending(e => e.CreatedAt).Take(1))
                .ThenInclude(e => e.Status)
                .Include(b => b.Project!)
                .ThenInclude(p => p.SystemUnderTest)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
