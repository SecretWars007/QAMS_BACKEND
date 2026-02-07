// src/QAMS.Api/Controllers/KanbanController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using QAMS.Application.DTOs.Kanban;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class KanbanController : ControllerBase
    {
        private readonly IKanbanService _service;

        public KanbanController(IKanbanService service)
        {
            _service = service;
        }

        [HttpGet("board/{boardId:guid}")]
        [HasPermission("KANBAN_VIEW")]
        public async Task<IActionResult> GetBoard(Guid boardId) =>
            Ok(await _service.GetBoardAsync(boardId));

        [HttpGet("project/{projectId:guid}")]
        [HasPermission("KANBAN_VIEW")]
        public async Task<IActionResult> GetByProject(Guid projectId) =>
            Ok(await _service.GetBoardsByProjectAsync(projectId));

        [HttpPost("board")]
        [HasPermission("KANBAN_CREATE")]
        public async Task<IActionResult> CreateBoard([FromBody] CreateBoardDto dto)
        {
            var board = await _service.CreateBoardAsync(dto.ProjectId, dto.Name);
            return Created("", board);
        }

        [HttpPost("task")]
        [HasPermission("KANBAN_CREATE")]
        public async Task<IActionResult> CreateTask([FromBody] CreateKanbanTaskDto dto) =>
            Created("", await _service.CreateTaskAsync(dto));

        [HttpPut("task/{taskId:guid}/move")]
        [HasPermission("KANBAN_UPDATE")]
        public async Task<IActionResult> MoveTask(Guid taskId, [FromBody] MoveTaskDto dto) =>
            Ok(await _service.MoveTaskAsync(taskId, dto));

        [HttpDelete("task/{taskId:guid}")]
        [HasPermission("KANBAN_DELETE")]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            await _service.DeleteTaskAsync(taskId);
            return NoContent();
        }
    }
}
