// src/QAMS.Application/Interfaces/IProjectService.cs
using QAMS.Application.DTOs.Projects;
namespace QAMS.Application.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDto> GetByIdAsync(Guid id);
        Task<List<ProjectDto>> GetAllAsync();
        Task<ProjectDto> CreateAsync(CreateProjectDto dto);
        Task<ProjectDto> UpdateAsync(Guid id, CreateProjectDto dto);
        Task DeleteAsync(Guid id);
    }
}
