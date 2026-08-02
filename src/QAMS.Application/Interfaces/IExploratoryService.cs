// src/QAMS.Application/Interfaces/IExploratoryService.cs
using QAMS.Application.DTOs.Exploratory;

namespace QAMS.Application.Interfaces
{
    public interface IExploratoryService
    {
        Task<List<ExploratorySessionDto>> GetByProjectAsync(Guid projectId);
        Task<ExploratorySessionDto> GetByIdAsync(Guid id);
        Task<ExploratorySessionDto> CreateAsync(CreateExploratorySessionDto dto);
        Task<ExploratorySessionDto> StartSessionAsync(Guid id);
        Task<ExploratorySessionDto> CompleteSessionAsync(Guid id, UpdateExploratorySessionDto dto);
        Task DeleteAsync(Guid id);
        Task<ExploratoryFindingDto> AddFindingAsync(CreateExploratoryFindingDto dto);
        Task DeleteFindingAsync(Guid findingId);
    }
}
