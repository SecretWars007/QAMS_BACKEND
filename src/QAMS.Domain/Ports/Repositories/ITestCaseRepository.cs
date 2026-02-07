// src/QAMS.Domain/Ports/Repositories/ITestCaseRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface ITestCaseRepository : IGenericRepository<TestCase>
    {
        Task<TestCase?> GetWithStepsAsync(Guid testCaseId);
        Task<IReadOnlyList<TestCase>> GetBySuiteWithStepsAsync(Guid suiteId);
    }
}
