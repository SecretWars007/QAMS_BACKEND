// src/QAMS.Domain/Entities/KanbanBoard.cs
namespace QAMS.Domain.Entities
{
    public class KanbanBoard
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<KanbanColumn> Columns { get; set; } = new List<KanbanColumn>();
    }
}
