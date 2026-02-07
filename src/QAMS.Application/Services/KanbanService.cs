// src/QAMS.Application/Services/KanbanService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Kanban;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de gestión del tablero Kanban: crear tableros,
    /// crear tareas, mover tareas entre columnas.
    /// </summary>
    public class KanbanService : IKanbanService
    {
        private readonly IKanbanBoardRepository _boardRepo;
        private readonly IGenericRepository<KanbanColumn> _columnRepo;
        private readonly IGenericRepository<KanbanTask> _taskRepo;
        private readonly ICatalogRepository<TaskPriority> _priorityRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<KanbanService> _logger;

        public KanbanService(
            IKanbanBoardRepository boardRepo,
            IGenericRepository<KanbanColumn> columnRepo,
            IGenericRepository<KanbanTask> taskRepo,
            ICatalogRepository<TaskPriority> priorityRepo,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<KanbanService> logger
        )
        {
            _boardRepo = boardRepo;
            _columnRepo = columnRepo;
            _taskRepo = taskRepo;
            _priorityRepo = priorityRepo;
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<KanbanBoardDto> GetBoardAsync(Guid boardId)
        {
            _logger.LogInformation("Obteniendo tablero {BoardId}.", boardId);
            var board =
                await _boardRepo.GetFullBoardAsync(boardId)
                ?? throw new EntityNotFoundException(nameof(KanbanBoard), boardId);
            return _mapper.Map<KanbanBoardDto>(board);
        }

        public async Task<List<KanbanBoardDto>> GetBoardsByProjectAsync(Guid projectId)
        {
            _logger.LogInformation("Obteniendo tableros del proyecto {ProjectId}.", projectId);
            var boards = await _boardRepo.GetByProjectAsync(projectId);
            return _mapper.Map<List<KanbanBoardDto>>(boards);
        }

        /// <summary>
        /// Crea un tablero Kanban con columnas predeterminadas:
        /// To Do, In Progress, In Review, Done.
        /// </summary>
        public async Task<KanbanBoardDto> CreateBoardAsync(Guid projectId, string name)
        {
            _logger.LogInformation(
                "Creando tablero '{Name}' para proyecto {ProjectId}.",
                name,
                projectId
            );

            var board = new KanbanBoard
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                Name = name,
                CreatedAt = DateTime.UtcNow,
            };

            // Crear columnas predeterminadas
            var defaultColumns = new[]
            {
                ("Por Hacer", 0),
                ("En Progreso", 1),
                ("En Revisión", 2),
                ("Completado", 3),
            };

            foreach (var (columnName, order) in defaultColumns)
            {
                board.Columns.Add(
                    new KanbanColumn
                    {
                        Id = Guid.NewGuid(),
                        KanbanBoardId = board.Id,
                        Name = columnName,
                        OrderIndex = order,
                        CreatedAt = DateTime.UtcNow,
                    }
                );
            }

            await _boardRepo.AddAsync(board);
            await _uow.SaveChangesAsync();

            _logger.LogInformation(
                "Tablero '{Name}' creado con {ColCount} columnas.",
                name,
                board.Columns.Count
            );

            var created = await _boardRepo.GetFullBoardAsync(board.Id);
            return _mapper.Map<KanbanBoardDto>(created);
        }

        /// <summary>
        /// Crea una nueva tarea en una columna del tablero Kanban.
        /// </summary>
        public async Task<KanbanTaskDto> CreateTaskAsync(CreateKanbanTaskDto dto)
        {
            _logger.LogInformation(
                "Creando tarea '{Title}' en columna {ColumnId}.",
                dto.Title,
                dto.KanbanColumnId
            );

            // Validar que la prioridad del catálogo existe
            _ = await _priorityRepo.GetByIdAsync(dto.PriorityId)
                ?? throw new EntityNotFoundException(nameof(TaskPriority), dto.PriorityId);

            // Obtener el mayor OrderIndex de la columna para colocar al final
            var existingTasks = await _taskRepo.FindAsync(t =>
                t.KanbanColumnId == dto.KanbanColumnId
            );
            var maxOrder = existingTasks.Any() ? existingTasks.Max(t => t.OrderIndex) + 1 : 0;

            var task = new KanbanTask
            {
                Id = Guid.NewGuid(),
                KanbanColumnId = dto.KanbanColumnId,
                Title = dto.Title,
                Description = dto.Description,
                AssigneeId = dto.AssigneeId,
                TestCaseId = dto.TestCaseId,
                PriorityId = dto.PriorityId,
                DueDate = dto.DueDate,
                OrderIndex = maxOrder,
                CreatedAt = DateTime.UtcNow,
            };

            await _taskRepo.AddAsync(task);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Tarea '{Title}' creada con ID {TaskId}.", task.Title, task.Id);

            return _mapper.Map<KanbanTaskDto>(task);
        }

        /// <summary>
        /// Mueve una tarea a otra columna y/o cambia su posición.
        /// Reordena las tareas en la columna de destino.
        /// </summary>
        public async Task<KanbanTaskDto> MoveTaskAsync(Guid taskId, MoveTaskDto dto)
        {
            _logger.LogInformation(
                "Moviendo tarea {TaskId} a columna {ColumnId}, posición {Order}.",
                taskId,
                dto.TargetColumnId,
                dto.NewOrderIndex
            );

            var task =
                await _taskRepo.GetByIdAsync(taskId)
                ?? throw new EntityNotFoundException(nameof(KanbanTask), taskId);

            // Actualizar columna y orden
            task.KanbanColumnId = dto.TargetColumnId;
            task.OrderIndex = dto.NewOrderIndex;
            task.UpdatedAt = DateTime.UtcNow;

            // Reordenar tareas existentes en la columna destino
            var tasksInColumn = await _taskRepo.FindAsync(t =>
                t.KanbanColumnId == dto.TargetColumnId && t.Id != taskId
            );

            foreach (
                var existingTask in tasksInColumn.Where(t => t.OrderIndex >= dto.NewOrderIndex)
            )
            {
                existingTask.OrderIndex++;
                _taskRepo.Update(existingTask);
            }

            _taskRepo.Update(task);
            await _uow.SaveChangesAsync();

            _logger.LogInformation("Tarea {TaskId} movida exitosamente.", taskId);
            return _mapper.Map<KanbanTaskDto>(task);
        }

        public async Task DeleteTaskAsync(Guid taskId)
        {
            _logger.LogInformation("Eliminando tarea {TaskId}.", taskId);
            var task =
                await _taskRepo.GetByIdAsync(taskId)
                ?? throw new EntityNotFoundException(nameof(KanbanTask), taskId);

            _taskRepo.Delete(task);
            await _uow.SaveChangesAsync();
        }
    }
}
