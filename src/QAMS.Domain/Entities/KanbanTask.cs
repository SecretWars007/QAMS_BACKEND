// src/QAMS.Domain/Entities/KanbanTask.cs
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Tarea Kanban. PriorityId referencia a catálogo task_priorities (no enum).
    /// </summary>
    public class KanbanTask
    {
        public Guid Id { get; set; }
        public Guid KanbanColumnId { get; set; }
        public KanbanColumn KanbanColumn { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? AssigneeId { get; set; }
        public User? Assignee { get; set; }
        public Guid? TestCaseId { get; set; }
        public TestCase? TestCase { get; set; }
        public int PriorityId { get; set; }
        public TaskPriority Priority { get; set; } = null!;
        public DateTime? DueDate { get; set; }
        public int OrderIndex { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
