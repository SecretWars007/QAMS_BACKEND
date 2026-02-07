// src/QAMS.Application/Interfaces/ITestExecutionService.cs
using QAMS.Application.DTOs.TestExecutions;
namespace QAMS.Application.Interfaces
{
    public interface ITestExecutionService
    {
        Task<TestExecutionDto> GetByIdAsync(Guid id);
        Task<List<TestExecutionDto>> GetByTestCaseAsync(Guid testCaseId);
        Task<List<TestExecutionDto>> GetByTesterAsync(Guid testerId);
        Task<TestExecutionDto> CreateAsync(Guid testerId, CreateTestExecutionDto dto);
        Task<TestExecutionDto> UpdateStepResultAsync(Guid executionId, UpdateStepResultDto dto);
        Task<TestExecutionDto> CompleteExecutionAsync(Guid executionId, int finalStatusId);
        Task<EvidenceDto> UploadEvidenceAsync(Guid executionId, Stream fileStream,
            string fileName, string contentType, string? description);
    }
}
