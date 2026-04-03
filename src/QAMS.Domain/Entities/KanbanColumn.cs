// src/QAMS.Domain/Entities/KanbanColumn.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    /// <summary>Columna (estado) dentro de un tablero Kanban.</summary>
    public class KanbanColumn : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid BoardId { get; set; }
        public KanbanBoard? Board { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OrderIndex { get; set; }

        public ICollection<KanbanTask> Tasks { get; set; } = [];

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
