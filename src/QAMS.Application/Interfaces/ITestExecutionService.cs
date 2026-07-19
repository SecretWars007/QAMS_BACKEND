// src/QAMS.Application/Interfaces/ITestExecutionService.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using QAMS.Application.DTOs.TestExecutions;
namespace QAMS.Application.Interfaces
{
    public interface ITestExecutionService
    {
        Task<TestExecutionDto> GetByIdAsync(Guid id);
        Task<List<TestExecutionDto>> GetByTestCaseAsync(Guid testCaseId);
        Task<List<TestExecutionDto>> GetByTesterAsync(Guid testerId);
        Task<TestExecutionDto> CreateAsync(Guid testerId, CreateTestExecutionDto dto);
        Task<TestExecutionDto> CreateCompleteAsync(Guid testerId, CreateCompleteExecutionDto dto);
        Task<TestExecutionDto> UpdateStepResultAsync(Guid executionId, UpdateStepResultDto dto);
        Task<TestExecutionDto> UpdateStatusAsync(Guid id, int statusId);
        Task<TestExecutionDto> UpdateCompleteAsync(Guid id, UpdateCompleteExecutionDto dto);
        Task<TestExecutionDto> CompleteExecutionAsync(Guid executionId, int finalStatusId);
        Task<EvidenceDto> UploadEvidenceAsync(Guid executionId, Stream fileStream,
            string fileName, string contentType, string? description, Guid? stepResultId = null);

        // Observaciones
        Task<ObservationDto> AddObservationAsync(Guid createdByUserId, CreateObservationDto dto,
            Stream? fileStream = null, string? fileName = null, string? contentType = null);
        Task<ObservationDto> AddResponseToObservationAsync(Guid responderUserId, Guid observationId, ResponseObservationDto dto);
    }
}
