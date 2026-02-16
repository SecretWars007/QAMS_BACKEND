// src/QAMS.Domain/Entities/Project.cs
namespace QAMS.Domain.Entities
{
    /// <summary>Proyecto QA: agrupa suites y tableros Kanban.</summary>
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Auditoría: Quién registró el proyecto
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }

        // Prioridad (Puntuación)
        public int Priority { get; set; }

        // Estado del proyecto
        public int ProjectStatusId { get; set; }
        public QAMS.Domain.Entities.Catalogs.ProjectStatus? ProjectStatus { get; set; }

        public ICollection<TestSuite> TestSuites { get; set; } = new List<TestSuite>();
        public ICollection<KanbanBoard> KanbanBoards { get; set; } = new List<KanbanBoard>();
        public ICollection<TestCase> TestCases { get; set; } = new List<TestCase>();
        
        // Testers asignados al proyecto
        public ICollection<ProjectTester> ProjectTesters { get; set; } = new List<ProjectTester>();
    }
}
