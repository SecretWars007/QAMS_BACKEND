// src/QAMS.Application/Services/KanbanService.cs
using AutoMapper;
using Microsoft.Extensions.Logging;
using QAMS.Application.DTOs.Kanban;
using QAMS.Application.Interfaces;
using QAMS.Domain.Entities;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Exceptions;
using QAMS.Domain.Ports.Repositories;
using QAMS.Domain.Ports.Services;

namespace QAMS.Application.Services
{
    /// <summary>
    /// Servicio de gestión del tablero Kanban: crear tableros,
    /// crear tareas, mover tareas entre columnas.
    /// </summary>
    public class KanbanService(
        IKanbanBoardRepository boardRepo,
        IGenericRepository<KanbanColumn> columnRepo,
        IGenericRepository<KanbanTask> taskRepo,
        ICatalogRepository<TaskPriority> priorityRepo,
        ITestExecutionRepository execRepo,
        ICatalogRepository<ExecutionStatus> execStatusRepo,
        IUserRepository userRepo,
        IEmailService emailService,
        IUnitOfWork uow,
        IMapper mapper,
        ILogger<KanbanService> logger
    ) : IKanbanService
    {

        public async Task<KanbanBoardDto> GetBoardAsync(Guid boardId)
        {
            logger.LogInformation("Obteniendo tablero {BoardId}.", boardId);
            var board =
                await boardRepo.GetFullBoardAsync(boardId)
                ?? throw new EntityNotFoundException(nameof(KanbanBoard), boardId);
            return mapper.Map<KanbanBoardDto>(board);
        }

        public async Task<List<KanbanBoardDto>> GetBoardsByProjectAsync(Guid projectId)
        {
            logger.LogInformation("Obteniendo tableros del proyecto {ProjectId}.", projectId);
            var boards = await boardRepo.GetByProjectAsync(projectId);
            return mapper.Map<List<KanbanBoardDto>>(boards);
        }

        /// <summary>
        /// Crea un tablero Kanban con columnas predeterminadas:
        /// To Do, In Progress, In Review, Done.
        /// </summary>
        public async Task<KanbanBoardDto> CreateBoardAsync(Guid projectId, string name)
        {
            logger.LogInformation(
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
                        BoardId = board.Id,
                        Name = columnName,
                        OrderIndex = order,
                        CreatedAt = DateTime.UtcNow,
                    }
                );
            }

            await boardRepo.AddAsync(board);
            await uow.SaveChangesAsync();

            logger.LogInformation(
                "Tablero '{Name}' creado con {ColCount} columnas.",
                name,
                board.Columns.Count
            );

            var created = await boardRepo.GetFullBoardAsync(board.Id);
            return mapper.Map<KanbanBoardDto>(created);
        }

        /// <summary>
        /// Crea una nueva tarea en una columna del tablero Kanban.
        /// </summary>
        public async Task<KanbanTaskDto> CreateTaskAsync(CreateKanbanTaskDto dto)
        {
            logger.LogInformation(
                "Creando tarea '{Title}' en columna {ColumnId}.",
                dto.Title,
                dto.KanbanColumnId
            );

            // Validar que la prioridad del catálogo existe
            _ = await priorityRepo.GetByIdAsync(dto.PriorityId)
                ?? throw new EntityNotFoundException(nameof(TaskPriority), dto.PriorityId);

            // Obtener el mayor OrderIndex de la columna para colocar al final
            var existingTasks = await taskRepo.FindAsync(t =>
                t.KanbanColumnId == dto.KanbanColumnId
            );
            var maxOrder = existingTasks.Count > 0 ? existingTasks.Max(t => t.OrderIndex) + 1 : 0;

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

            await taskRepo.AddAsync(task);
            await uow.SaveChangesAsync();

            logger.LogInformation("Tarea '{Title}' creada con ID {TaskId}.", task.Title, task.Id);

            // Notificar al asignado si existe
            if (task.AssigneeId.HasValue)
            {
                try
                {
                    var assignee = await userRepo.GetByIdAsync(task.AssigneeId.Value);
                    if (assignee != null)
                    {
                        var subject = $"Nueva Tarea Kanban Asignada: {task.Title}";
                        var body = $@"<h2>Nueva Tarea Asignada &mdash; QAMS</h2>
                                     <p>Hola {assignee.FullName},</p>
                                     <p>Se te ha asignado una nueva tarea en el tablero Kanban.</p>
                                     <div style=""background:rgba(99,102,241,0.1);padding:15px;border-radius:8px;border-left:4px solid #6366f1;"">
                                         <p><strong>Tarea:</strong> {task.Title}</p>
                                         <p><strong>Descripci&oacute;n:</strong> {task.Description ?? "N/A"}</p>
                                     </div>
                                     <p><a href=""https://qams-web.onrender.com/kanban"">Ver en el Kanban</a></p>";
                        await emailService.SendEmailAsync(assignee.Email, subject, body);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "Error al enviar notificación de asignación de tarea.");
                }
            }

            return mapper.Map<KanbanTaskDto>(task);
        }

        /// <summary>
        /// Actualiza los datos de una tarea Kanban.
        /// </summary>
        public async Task<KanbanTaskDto> UpdateTaskAsync(Guid taskId, UpdateKanbanTaskDto dto)
        {
            logger.LogInformation("Actualizando tarea Kanban {TaskId}.", taskId);

            var task = await taskRepo.GetByIdAsync(taskId)
                ?? throw new EntityNotFoundException(nameof(KanbanTask), taskId);

            // Validar prioridad si cambió
            if (task.PriorityId != dto.PriorityId)
            {
                _ = await priorityRepo.GetByIdAsync(dto.PriorityId)
                    ?? throw new EntityNotFoundException(nameof(TaskPriority), dto.PriorityId);
                task.PriorityId = dto.PriorityId;
            }

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.AssigneeId = dto.AssigneeId;
            task.DueDate = dto.DueDate;
            task.UpdatedAt = DateTime.UtcNow;

            taskRepo.Update(task);
            await uow.SaveChangesAsync();

            return mapper.Map<KanbanTaskDto>(task);
        }

        /// <summary>
        /// Mueve una tarea a otra columna y/o cambia su posición.
        /// Reordena las tareas en la columna de destino.
        /// </summary>
        public async Task<KanbanTaskDto> MoveTaskAsync(Guid taskId, MoveTaskDto dto)
        {
            logger.LogInformation(
                "Moviendo tarea {TaskId} a columna {ColumnId}, posición {Order}.",
                taskId,
                dto.TargetColumnId,
                dto.NewOrderIndex
            );

            var task =
                await taskRepo.GetByIdAsync(taskId)
                ?? throw new EntityNotFoundException(nameof(KanbanTask), taskId);

            // Obtener información de la columna destino para sincronización
            var targetColumn = await columnRepo.GetByIdAsync(dto.TargetColumnId)
                ?? throw new EntityNotFoundException(nameof(KanbanColumn), dto.TargetColumnId);

            // Actualizar columna y orden
            task.KanbanColumnId = dto.TargetColumnId;
            task.OrderIndex = dto.NewOrderIndex;
            task.UpdatedAt = DateTime.UtcNow;

            // --- LÓGICA DE SINCRONIZACIÓN CON EJECUCIONES ---
            if (task.TestCaseId.HasValue)
            {
                await SyncExecutionStatusAsync(task.TestCaseId.Value, targetColumn.Name);
            }
            // ------------------------------------------------

            // Reordenar tareas existentes en la columna destino
            var tasksInColumn = await taskRepo.FindAsync(t =>
                t.KanbanColumnId == dto.TargetColumnId && t.Id != taskId
            );

            foreach (
                var existingTask in tasksInColumn.Where(t => t.OrderIndex >= dto.NewOrderIndex)
            )
            {
                existingTask.OrderIndex++;
                taskRepo.Update(existingTask);
            }

            taskRepo.Update(task);
            await uow.SaveChangesAsync();

            logger.LogInformation("Tarea {TaskId} movida exitosamente.", taskId);

            // Notificar al asignado del movimiento de columna
            if (task.AssigneeId.HasValue)
            {
                try
                {
                    var assignee = await userRepo.GetByIdAsync(task.AssigneeId.Value);
                    if (assignee != null)
                    {
                        var subject = $"Tarea Movida: {task.Title} → {targetColumn.Name}";
                        var body = $@"<h2>Tarea Movida — Kanban QAMS</h2>
                                     <p>Hola {assignee.FullName},</p>
                                     <p>La tarea <strong>{task.Title}</strong> ha sido movida a la columna <strong>{targetColumn.Name}</strong>.</p>
                                     <p><a href='https://qams-web.onrender.com/kanban'>Ver en el Kanban</a></p>";
                        await emailService.SendEmailAsync(assignee.Email, subject, body);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "Error al enviar notificación de movimiento de tarea.");
                }
            }

            return mapper.Map<KanbanTaskDto>(task);
        }

        public async Task DeleteTaskAsync(Guid taskId)
        {
            logger.LogInformation("Eliminando tarea {TaskId}.", taskId);
            var task =
                await taskRepo.GetByIdAsync(taskId)
                ?? throw new EntityNotFoundException(nameof(KanbanTask), taskId);

            taskRepo.Delete(task);
            await uow.SaveChangesAsync();
        }

        /// <summary>
        /// Sincroniza el estado de las ejecuciones basándose en la columna Kanban destino.
        /// Usa una query con tracking para que EF Core pueda persistir los cambios.
        /// </summary>
        private async Task SyncExecutionStatusAsync(Guid testCaseId, string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName)) return;

            string? statusCode = columnName.Trim() switch
            {
                var s when s.Equals("Tareas Pendientes", StringComparison.OrdinalIgnoreCase) => "PENDING",
                var s when s.Equals("Por Hacer", StringComparison.OrdinalIgnoreCase) => "PENDING",
                var s when s.Equals("En Progreso", StringComparison.OrdinalIgnoreCase) => "IN_PROGRESS",
                var s when s.Equals("En Revisión", StringComparison.OrdinalIgnoreCase) => "IN_PROGRESS",
                var s when s.Equals("Completado", StringComparison.OrdinalIgnoreCase) => "PASSED",
                _ => null
            };

            if (statusCode == null) return;

            logger.LogInformation(
                "Sincronizando ejecuciones de TestCase {TestCaseId} a estado {Status} por movimiento a columna '{Column}'.",
                testCaseId, statusCode, columnName);

            // Usar el método tracked para que EF Core pueda persistir los cambios
            var executions = await execRepo.GetByTestCaseTrackedAsync(testCaseId);
            if (executions.Count == 0)
            {
                logger.LogWarning("No se encontraron ejecuciones para el TestCase {TestCaseId}. No se sincronizó.", testCaseId);
                return;
            }

            var status = await execStatusRepo.GetByCodeAsync(statusCode);
            if (status == null)
            {
                logger.LogWarning("Estado con código '{Code}' no encontrado en catálogo. No se sincronizó.", statusCode);
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
                    execRepo.Update(latestExec);
                    logger.LogInformation("Ejecución {ExecId} marcada como PASSED.", latestExec.Id);
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
                        execRepo.Update(exec);
                        logger.LogInformation("Ejecución {ExecId} actualizada a {Status}.", exec.Id, statusCode);
                    }
                }
            }
        }
    }
}
