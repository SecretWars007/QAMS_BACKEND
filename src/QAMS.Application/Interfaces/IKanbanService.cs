// src/QAMS.Application/Interfaces/IKanbanService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QAMS.Application.DTOs.Kanban;
namespace QAMS.Application.Interfaces
{
    public interface IKanbanService
    {
        Task<KanbanBoardDto> GetBoardAsync(Guid boardId);
        Task<List<KanbanBoardDto>> GetBoardsByProjectAsync(Guid projectId);
        Task<KanbanBoardDto> CreateBoardAsync(Guid projectId, string name);
        Task<KanbanTaskDto> CreateTaskAsync(CreateKanbanTaskDto dto);
        Task<KanbanTaskDto> UpdateTaskAsync(Guid taskId, UpdateKanbanTaskDto dto);
        Task<KanbanTaskDto> MoveTaskAsync(Guid taskId, MoveTaskDto dto);
        Task DeleteTaskAsync(Guid taskId);
    }
}
