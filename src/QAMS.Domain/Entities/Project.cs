// src/QAMS.Domain/Entities/Project.cs
namespace QAMS.Domain.Entities
{
    /// <summary>Proyecto QA: agrupa suites y tableros Kanban.</summary>
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<TestSuite> TestSuites { get; set; } = new List<TestSuite>();
        public ICollection<KanbanBoard> KanbanBoards { get; set; } = new List<KanbanBoard>();
    }
}
