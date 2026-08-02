// src/QAMS.Domain/Entities/KanbanTask.cs
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    public class KanbanTask : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid KanbanColumnId { get; set; }
        public KanbanColumn? Column { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int OrderIndex { get; set; }
        public DateTime? DueDate { get; set; }

        public Guid? AssigneeId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.InverseProperty("ResponsibleForTasks")]
        public User? ResponsibleUser { get; set; }

        public Guid? TestCaseId { get; set; }
        public TestCase? TestCase { get; set; }

        public Guid? TestExecutionId { get; set; }
        public TestExecution? TestExecution { get; set; }

        public DateTime ColumnEnteredAt { get; set; } = DateTime.UtcNow;

        public int PriorityId { get; set; }
        public TestCasePriority? Priority { get; set; }

        // ISoftDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }
        public User? DeletedBy { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
