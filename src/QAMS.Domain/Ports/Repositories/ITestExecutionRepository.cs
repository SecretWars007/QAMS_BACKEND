// src/QAMS.Domain/Ports/Repositories/ITestExecutionRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface ITestExecutionRepository : IGenericRepository<TestExecution>
    {
        Task<TestExecution?> GetFullExecutionAsync(Guid executionId);
        Task<IReadOnlyList<TestExecution>> GetByTestCaseAsync(Guid testCaseId);
        Task<IReadOnlyList<TestExecution>> GetByTesterAsync(Guid testerId);
        Task<Dictionary<int, int>> GetStatusCountsByProjectAsync(Guid projectId);
    }
}
