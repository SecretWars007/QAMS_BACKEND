// src/QAMS.Api/Controllers/KanbanController.cs
using System;
using System.Threading.Tasks;
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

        /// <summary>
        /// Obtiene un tablero de Kanban específico por su ID. Requiere permiso PROJECTS_VIEW.
        /// </summary>
        /// <param name="boardId">ID único del tablero.</param>
        /// <returns>Detalle del tablero y sus columnas/tareas.</returns>
        [HttpGet("board/{boardId:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetBoard(Guid boardId)
        {
            _logger.LogInformation("GET /api/kanban/board/{BoardId}", boardId);
            return Ok(await _service.GetBoardAsync(boardId));
        }

        /// <summary>
        /// Obtiene todos los tableros asociados a un proyecto. Requiere permiso PROJECTS_VIEW.
        /// </summary>
        /// <param name="projectId">ID del proyecto.</param>
        /// <returns>Lista de tableros del proyecto.</returns>
        [HttpGet("project/{projectId:guid}")]
        [HasPermission("PROJECTS_VIEW")]
        public async Task<IActionResult> GetByProject(Guid projectId)
        {
            _logger.LogInformation("GET /api/kanban/project/{ProjectId}", projectId);
            return Ok(await _service.GetBoardsByProjectAsync(projectId));
        }

        /// <summary>
        /// Crea un nuevo tablero Kanban en un proyecto. Requiere permiso PROJECTS_UPDATE.
        /// </summary>
        /// <param name="dto">Datos para la creación del tablero.</param>
        /// <returns>El tablero creado.</returns>
        [HttpPost("board")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> CreateBoard([FromBody] CreateBoardDto dto)
        {
            _logger.LogInformation("POST /api/kanban/board - Creating board: {Name}", dto.Name);
            var board = await _service.CreateBoardAsync(dto.ProjectId, dto.Name);
            return CreatedAtAction(nameof(GetBoard), new { boardId = board.Id }, board);
        }

        /// <summary>
        /// Crea una nueva tarea en una columna del tablero. Requiere permiso PROJECTS_UPDATE.
        /// </summary>
        /// <param name="dto">Datos de la tarea.</param>
        /// <returns>La tarea creada.</returns>
        [HttpPost("task")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> CreateTask([FromBody] CreateKanbanTaskDto dto)
        {
            _logger.LogInformation("POST /api/kanban/task - Creando tarea '{Title}' en columna {ColumnId}", dto.Title, dto.KanbanColumnId);
            var task = await _service.CreateTaskAsync(dto);
            return Ok(task);
        }

        /// <summary>
        /// Actualiza el contenido (título/descripción) de una tarea. Requiere permiso PROJECTS_UPDATE.
        /// </summary>
        /// <param name="taskId">ID de la tarea.</param>
        /// <param name="dto">Nuevos datos de la tarea.</param>
        /// <returns>La tarea actualizada.</returns>
        [HttpPut("task/{taskId:guid}")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> UpdateTask(Guid taskId, [FromBody] UpdateKanbanTaskDto dto)
        {
            _logger.LogInformation("PUT /api/kanban/task/{TaskId} - Actualizando tarea", taskId);
            return Ok(await _service.UpdateTaskAsync(taskId, dto));
        }

        /// <summary>
        /// Mueve una tarea a una columna diferente o cambia su orden. Requiere permiso PROJECTS_UPDATE.
        /// </summary>
        /// <param name="taskId">ID de la tarea a mover.</param>
        /// <param name="dto">Datos del destino (columna e índice).</param>
        /// <returns>La tarea en su nueva posición.</returns>
        [HttpPut("task/{taskId:guid}/move")]
        [HasPermission("PROJECTS_UPDATE")]
        public async Task<IActionResult> MoveTask(Guid taskId, [FromBody] MoveTaskDto dto)
        {
            _logger.LogInformation("PUT /api/kanban/task/{TaskId}/move - Moviendo a columna {ColumnId} posición {Order}", taskId, dto.TargetColumnId, dto.NewOrderIndex);
            return Ok(await _service.MoveTaskAsync(taskId, dto));
        }

        /// <summary>
        /// Elimina físicamente una tarea del tablero. Requiere permiso PROJECTS_UPDATE.
        /// </summary>
        /// <param name="taskId">ID de la tarea a eliminar.</param>
        /// <returns>Sin contenido (NoContent).</returns>
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
