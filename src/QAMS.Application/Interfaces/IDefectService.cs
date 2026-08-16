// src/QAMS.Application/Interfaces/IDefectService.cs
using QAMS.Application.DTOs.Defects;

namespace QAMS.Application.Interfaces
{
    public interface IDefectService
    {
        Task<IReadOnlyList<DefectDto>> GetByProjectAsync(Guid projectId);
        Task<IReadOnlyList<DefectDto>> GetByTestCaseAsync(Guid testCaseId);
        Task<DefectDto?> GetByIdAsync(Guid defectId);
        Task<DefectDto> CreateAsync(Guid reportedByUserId, CreateDefectDto dto);
        Task<DefectDto> UpdateAsync(Guid defectId, UpdateDefectDto dto);
        Task<DefectDto> UploadAttachmentAsync(Guid defectId, Stream fileStream, string fileName, string contentType);
        Task DeleteAsync(Guid defectId);
    }
}
