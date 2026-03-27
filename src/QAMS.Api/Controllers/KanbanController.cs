// src/QAMS.Api/Controllers/KanbanController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAMS.Api.Filters;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Kanban;
using QAMS.Application.Interfaces;

namespace QAMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class KanbanController(IKanbanService service, ILogger<KanbanController> logger) : ControllerBase
    {
        private readonly IKanbanService _service = service;
        private readonly ILogger<KanbanController> _logger = logger;

        [HttpGet("board/{boardId:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetBoard(Guid boardId)
        {
            _logger.LogInformation("GET /api/kanban/board/{BoardId}", boardId);
            return Ok(await _service.GetBoardAsync(boardId));
        }

        [HttpGet("project/{projectId:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetByProject(Guid projectId)
        {
            _logger.LogInformation("GET /api/kanban/project/{ProjectId}", projectId);
            return Ok(await _service.GetBoardsByProjectAsync(projectId));
        }

        [HttpPost("board")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> CreateBoard([FromBody] CreateBoardDto dto)
        {
            _logger.LogInformation("POST /api/kanban/board - Creating board: {Name}", dto.Name);
            var board = await _service.CreateBoardAsync(dto.ProjectId, dto.Name);
            return CreatedAtAction(nameof(GetBoard), new { boardId = board.Id }, board);
        }

        [HttpPost("task")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> CreateTask([FromBody] CreateKanbanTaskDto dto)
        {
            _logger.LogInformation("POST /api/kanban/task - Creando tarea '{Title}' en columna {ColumnId}", dto.Title, dto.KanbanColumnId);
            var task = await _service.CreateTaskAsync(dto);
            return Ok(task);
        }

        [HttpPut("task/{taskId:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> UpdateTask(Guid taskId, [FromBody] UpdateKanbanTaskDto dto)
        {
            _logger.LogInformation("PUT /api/kanban/task/{TaskId} - Actualizando tarea", taskId);
            return Ok(await _service.UpdateTaskAsync(taskId, dto));
        }

        [HttpPut("task/{taskId:guid}/move")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> MoveTask(Guid taskId, [FromBody] MoveTaskDto dto)
        {
            _logger.LogInformation("PUT /api/kanban/task/{TaskId}/move - Moviendo a columna {ColumnId} posición {Order}", taskId, dto.TargetColumnId, dto.NewOrderIndex);
            return Ok(await _service.MoveTaskAsync(taskId, dto));
        }

        [HttpDelete("task/{taskId:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            _logger.LogInformation("DELETE /api/kanban/task/{TaskId}", taskId);
            await _service.DeleteTaskAsync(taskId);
            return NoContent();
        }
    }
}
