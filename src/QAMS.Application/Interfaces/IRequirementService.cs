// src/QAMS.Application/Interfaces/IRequirementService.cs
using QAMS.Application.DTOs.Projects;

namespace QAMS.Application.Interfaces
{
    public interface IRequirementService
    {
        Task<List<RequirementDto>> GetByProjectIdAsync(Guid projectId);
        Task<RequirementDto> GetByIdAsync(Guid id);
        Task<RequirementDto> CreateAsync(Guid projectId, CreateRequirementDto dto);
        Task<RequirementDto> UpdateAsync(Guid id, CreateRequirementDto dto);
        Task DeleteAsync(Guid id);
    }
}
