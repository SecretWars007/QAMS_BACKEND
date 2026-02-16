using QAMS.Application.DTOs.TestSuites;

namespace QAMS.Application.Interfaces
{
    public interface ITestSuiteService
    {
        Task<TestSuiteDto> CreateAsync(CreateTestSuiteDto dto);
        Task<TestSuiteDto> GetByIdAsync(Guid id);
        Task<List<TestSuiteDto>> GetByProjectIdAsync(Guid projectId);
        Task<TestSuiteDto> UpdateAsync(Guid id, CreateTestSuiteDto dto);
        Task DeleteAsync(Guid id);
    }
}
