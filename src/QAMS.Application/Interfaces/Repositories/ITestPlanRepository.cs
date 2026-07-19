using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Interfaces.Repositories
{
    public interface ITestPlanRepository : IGenericRepository<TestPlan>
    {
        Task<IReadOnlyList<TestPlan>> GetByProjectAsync(Guid projectId);
        Task<TestPlan?> GetByIdWithDetailsAsync(Guid id);
    }
}
