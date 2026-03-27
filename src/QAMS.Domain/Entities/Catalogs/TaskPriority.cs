// src/QAMS.Domain/Entities/Catalogs/TaskPriority.cs
namespace QAMS.Domain.Entities.Catalogs
{
    /// <summary>
    /// Catálogo: prioridades de tareas Kanban.
    /// Valores seed: LOW, MEDIUM, HIGH, CRITICAL.
    /// </summary>
    public class TaskPriority : CatalogBase
    {
        /// <summary>Tareas con esta prioridad</summary>
        public ICollection<KanbanTask> KanbanTasks { get; set; } = [];
    }
}
