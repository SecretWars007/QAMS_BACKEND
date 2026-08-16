using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QAMS.Application.DTOs.TestSuites;

namespace QAMS.Application.Interfaces
{
    public interface ITestSuiteService
    {
        Task<TestSuiteDto> CreateAsync(CreateTestSuiteDto dto);
        Task<TestSuiteDto> GetByIdAsync(Guid id);
        Task<List<TestSuiteDto>> GetByProjectIdAsync(Guid projectId);
        Task<List<TestSuiteDto>> GetByTestPlanIdAsync(Guid testPlanId);
        Task<TestSuiteDto> UpdateAsync(Guid id, CreateTestSuiteDto dto);
        Task DeleteAsync(Guid id);
        Task<TestSuiteDto> ToggleStatusAsync(Guid id);
        // Enhancements
        Task<TestSuiteStatsDto> GetSummaryStatsAsync(Guid id);
        Task<TestSuiteDto> CloneAsync(Guid id, string newName);
        Task MoveToProjectAsync(Guid id, Guid targetProjectId);
    }
}
