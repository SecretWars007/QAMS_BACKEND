// src/QAMS.Domain/Entities/KanbanColumn.cs
namespace QAMS.Domain.Entities
{
    public class KanbanColumn
    {
        public Guid Id { get; set; }
        public Guid KanbanBoardId { get; set; }
        public KanbanBoard KanbanBoard { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<KanbanTask> Tasks { get; set; } = new List<KanbanTask>();
    }
}
