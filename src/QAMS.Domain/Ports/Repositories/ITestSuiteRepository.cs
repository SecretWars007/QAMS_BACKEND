// src/QAMS.Domain/Ports/Repositories/ITestSuiteRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface ITestSuiteRepository : IGenericRepository<TestSuite>
    {
        Task<IReadOnlyList<TestSuite>> GetByProjectWithTestCasesAsync(Guid projectId);
    }
}
