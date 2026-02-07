// src/QAMS.Application/Interfaces/IKanbanService.cs
using QAMS.Application.DTOs.Kanban;
namespace QAMS.Application.Interfaces
{
    public interface IKanbanService
    {
        Task<KanbanBoardDto> GetBoardAsync(Guid boardId);
        Task<List<KanbanBoardDto>> GetBoardsByProjectAsync(Guid projectId);
        Task<KanbanBoardDto> CreateBoardAsync(Guid projectId, string name);
        Task<KanbanTaskDto> CreateTaskAsync(CreateKanbanTaskDto dto);
        Task<KanbanTaskDto> MoveTaskAsync(Guid taskId, MoveTaskDto dto);
        Task DeleteTaskAsync(Guid taskId);
    }
}
