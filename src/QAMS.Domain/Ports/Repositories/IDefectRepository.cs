// src/QAMS.Domain/Ports/Repositories/IDefectRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IDefectRepository : IGenericRepository<Defect>
    {
        Task<IReadOnlyList<Defect>> GetByProjectAsync(Guid projectId);
        Task<IReadOnlyList<Defect>> GetByTestCaseAsync(Guid testCaseId);
        Task<IReadOnlyList<Defect>> GetByTestExecutionAsync(Guid testExecutionId);
        Task<IReadOnlyList<Defect>> GetAssignedToUserAsync(Guid userId);
        Task<int> CountOpenDefectsByProjectAsync(Guid projectId);
    }
}
