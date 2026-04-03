// src/QAMS.Domain/Entities/KanbanBoard.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    /// <summary>Tablero Kanban asociado a un proyecto.</summary>
    public class KanbanBoard : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        
        // ISoftDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual ICollection<KanbanColumn> Columns { get; set; } = [];
    }
}
