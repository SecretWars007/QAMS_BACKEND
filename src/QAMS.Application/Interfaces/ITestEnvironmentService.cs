// src/QAMS.Application/Interfaces/ITestEnvironmentService.cs
using QAMS.Application.DTOs.TestEnvironments;

namespace QAMS.Application.Interfaces
{
    public interface ITestEnvironmentService
    {
        Task<List<TestEnvironmentDto>> GetByProjectAsync(Guid projectId);
        Task<TestEnvironmentDto> GetByIdAsync(Guid id);
        Task<TestEnvironmentDto> CreateAsync(CreateTestEnvironmentDto dto);
        Task<TestEnvironmentDto> UpdateAsync(Guid id, UpdateTestEnvironmentDto dto);
        Task DeleteAsync(Guid id);
    }
}
