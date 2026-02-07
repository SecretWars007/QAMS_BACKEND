// src/QAMS.Domain/Ports/Repositories/IKanbanBoardRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IKanbanBoardRepository : IGenericRepository<KanbanBoard>
    {
        Task<KanbanBoard?> GetFullBoardAsync(Guid boardId);
        Task<IReadOnlyList<KanbanBoard>> GetByProjectAsync(Guid projectId);
    }
}
