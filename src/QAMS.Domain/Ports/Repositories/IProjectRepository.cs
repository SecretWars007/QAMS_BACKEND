// src/QAMS.Domain/Ports/Repositories/IProjectRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<Project?> GetWithTestSuitesAsync(Guid projectId);
        Task<Project?> GetWithKanbanBoardsAsync(Guid projectId);
    }
}
