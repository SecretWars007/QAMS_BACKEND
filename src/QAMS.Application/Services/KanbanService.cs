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
        private readonly ITestExecutionRepository _execRepo;
        private readonly ICatalogRepository<ExecutionStatus> _execStatusRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<KanbanService> _logger;

        public KanbanService(
            IKanbanBoardRepository boardRepo,
            IGenericRepository<KanbanColumn> columnRepo,
            IGenericRepository<KanbanTask> taskRepo,
            ICatalogRepository<TaskPriority> priorityRepo,
            ITestExecutionRepository execRepo,
            ICatalogRepository<ExecutionStatus> execStatusRepo,
            IUnitOfWork uow,
            IMapper mapper,
            ILogger<KanbanService> logger
        )
        {
            _boardRepo = boardRepo;
            _columnRepo = columnRepo;
            _taskRepo = taskRepo;
            _priorityRepo = priorityRepo;
            _execRepo = execRepo;
            _execStatusRepo = execStatusRepo;
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
                ("Tareas Pendientes", 0),
                ("Por Hacer", 1),
                ("En Progreso", 2),
                ("En Revisión", 3),
                ("Completado", 4),
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
        /// Actualiza los datos de una tarea Kanban.
        /// </summary>
        public async Task<KanbanTaskDto> UpdateTaskAsync(Guid taskId, UpdateKanbanTaskDto dto)
        {
            _logger.LogInformation("Actualizando tarea Kanban {TaskId}.", taskId);

            var task = await _taskRepo.GetByIdAsync(taskId)
                ?? throw new EntityNotFoundException(nameof(KanbanTask), taskId);

            // Validar prioridad si cambió
            if (task.PriorityId != dto.PriorityId)
            {
                _ = await _priorityRepo.GetByIdAsync(dto.PriorityId)
                    ?? throw new EntityNotFoundException(nameof(TaskPriority), dto.PriorityId);
                task.PriorityId = dto.PriorityId;
            }

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.AssigneeId = dto.AssigneeId;
            task.DueDate = dto.DueDate;
            task.UpdatedAt = DateTime.UtcNow;

            _taskRepo.Update(task);
            await _uow.SaveChangesAsync();

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

            // Obtener información de la columna destino para sincronización
            var targetColumn = await _columnRepo.GetByIdAsync(dto.TargetColumnId)
                ?? throw new EntityNotFoundException(nameof(KanbanColumn), dto.TargetColumnId);

            // Actualizar columna y orden
            task.KanbanColumnId = dto.TargetColumnId;
            task.OrderIndex = dto.NewOrderIndex;
            task.UpdatedAt = DateTime.UtcNow;

            // --- LÓGICA DE SINCRONIZACIÓN CON EJECUCIONES ---
            if (task.TestCaseId.HasValue)
            {
                await SyncExecutionStatusAsync(task.TestCaseId.Value, targetColumn.Name, task.AssigneeId);
            }
            // ------------------------------------------------

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

        /// <summary>
        /// Sincroniza el estado de las ejecuciones basándose en la columna Kanban destino.
        /// Usa una query con tracking para que EF Core pueda persistir los cambios.
        /// </summary>
        private async Task SyncExecutionStatusAsync(Guid testCaseId, string columnName, Guid? testerId)
        {
            string? statusCode = columnName?.Trim() switch
            {
                var s when s.Equals("Tareas Pendientes", StringComparison.OrdinalIgnoreCase) => "PENDING",
                var s when s.Equals("Por Hacer", StringComparison.OrdinalIgnoreCase) => "PENDING",
                var s when s.Equals("En Progreso", StringComparison.OrdinalIgnoreCase) => "IN_PROGRESS",
                var s when s.Equals("En Revisión", StringComparison.OrdinalIgnoreCase) => "IN_PROGRESS",
                var s when s.Equals("Completado", StringComparison.OrdinalIgnoreCase) => "PASSED",
                _ => null
            };

            if (statusCode == null) return;

            _logger.LogInformation(
                "Sincronizando ejecuciones de TestCase {TestCaseId} a estado {Status} por movimiento a columna '{Column}'.",
                testCaseId, statusCode, columnName);

            // Usar el método tracked para que EF Core pueda persistir los cambios
            var executions = await _execRepo.GetByTestCaseTrackedAsync(testCaseId);
            if (!executions.Any())
            {
                _logger.LogWarning("No se encontraron ejecuciones para el TestCase {TestCaseId}. No se sincronizó.", testCaseId);
                return;
            }

            var status = await _execStatusRepo.GetByCodeAsync(statusCode);
            if (status == null)
            {
                _logger.LogWarning("Estado con código '{Code}' no encontrado en catálogo. No se sincronizó.", statusCode);
                return;
            }

            if (statusCode == "PASSED")
            {
                // Al completar: solo actualizar la ejecución más reciente
                var latestExec = executions.First(); // Ya ordenadas por fecha desc
                if (latestExec.StatusId != status.Id)
                {
                    latestExec.StatusId = status.Id;
                    latestExec.CompletedAt = DateTime.UtcNow;
                    _execRepo.Update(latestExec);
                    _logger.LogInformation("Ejecución {ExecId} marcada como PASSED.", latestExec.Id);
                }
            }
            else
            {
                // Para PENDING / IN_PROGRESS: actualizar todas las ejecuciones no terminales
                foreach (var exec in executions)
                {
                    var currentCode = exec.Status?.Code;
                    // No sobreescribir ejecuciones ya completadas (PASSED/FAILED)
                    if (currentCode == "PASSED" || currentCode == "FAILED" || currentCode == "BLOCKED") continue;

                    if (exec.StatusId != status.Id)
                    {
                        exec.StatusId = status.Id;
                        exec.CompletedAt = null;
                        _execRepo.Update(exec);
                        _logger.LogInformation("Ejecución {ExecId} actualizada a {Status}.", exec.Id, statusCode);
                    }
                }
            }
        }
    }
}
