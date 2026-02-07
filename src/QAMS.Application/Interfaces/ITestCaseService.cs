// src/QAMS.Application/Interfaces/ITestCaseService.cs
using QAMS.Application.DTOs.TestCases;

namespace QAMS.Application.Interfaces
{
    public interface ITestCaseService
    {
        Task<TestCaseDto> GetByIdAsync(Guid id);
        Task<List<TestCaseDto>> GetBySuiteAsync(Guid suiteId);
        Task<TestCaseDto> CreateAsync(CreateTestCaseDto dto);
        Task<TestCaseDto> UpdateAsync(Guid id, CreateTestCaseDto dto);
        Task DeleteAsync(Guid id);
    }
}
