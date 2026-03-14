// src/QAMS.Domain/Ports/Repositories/IProjectRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<Project?> GetWithTestSuitesAsync(Guid projectId);
        Task<Project?> GetWithKanbanBoardsAsync(Guid projectId);
        Task<Project?> GetWithDetailsAsync(Guid projectId);
        Task<Project?> GetByIdTrackedAsync(Guid projectId);
        Task<List<Project>> FindWithDetailsAsync(System.Linq.Expressions.Expression<Func<Project, bool>> predicate);
        Task<Project?> GetFullProjectForComplianceReportAsync(Guid projectId);
    }
}
