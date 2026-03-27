// src/QAMS.Application/Interfaces/IProjectService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<List<ProjectDto>> GetMyProjectsAsync(Guid userId);

        // Devoluciones
        Task<ProjectDevolutionDto> RegisterDevolutionAsync(Guid projectId, Guid createdByUserId, RegisterDevolutionDto dto);
        Task<ProjectDevolutionDto> RespondToDevolutionAsync(Guid devolutionId, RespondDevolutionDto dto);
    }
}
