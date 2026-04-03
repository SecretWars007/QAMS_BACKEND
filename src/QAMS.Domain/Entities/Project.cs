// src/QAMS.Domain/Entities/Project.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    /// <summary>Proyecto QA: agrupa suites y tableros Kanban.</summary>
    public class Project : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        
        public string Version { get; set; } = "1.0";
        public decimal Budget { get; set; } = 0m;
        public string? Risks { get; set; }
        public Guid? LeaderId { get; set; }
        
        // ISoftDelete implementation
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }

        // IAuditable implementation
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public decimal WorkHoursPerDay { get; set; } = 7;
        public decimal ExecutedHours { get; set; } = 0;
        public decimal RemainingHours { get; set; } = 0;
        public int DevolucionesCounter { get; set; } = 0;

        // Auditoría relationships
        public User? CreatedBy { get; set; }
        public User? UpdatedBy { get; set; }
        // Lider del proyecto
        public virtual User? Leader { get; set; }

        public User? DeletedBy { get; set; }

        // Prioridad
        public int ProjectPriorityId { get; set; }
        public virtual QAMS.Domain.Entities.Catalogs.ProjectPriority? ProjectPriority { get; set; }

        // Estado del proyecto
        public int ProjectStatusId { get; set; }
        public virtual QAMS.Domain.Entities.Catalogs.ProjectStatus? ProjectStatus { get; set; }

        public virtual ICollection<TestSuite> TestSuites { get; set; } = [];
        public virtual ICollection<KanbanBoard> KanbanBoards { get; set; } = [];
        public virtual ICollection<TestCase> TestCases { get; set; } = [];

        // Testers asignados al proyecto
        public virtual ICollection<ProjectTester> ProjectTesters { get; set; } = [];
        public virtual ICollection<ProjectDevolution> HistoricDevolutions { get; set; } = [];
        public virtual ICollection<ProjectObservation> Observations { get; set; } = [];
        public virtual ICollection<Requirement> Requirements { get; set; } = [];

        /// <summary>Calcula las horas totales estimadas basadas en días hábiles (L-V) y WorkHoursPerDay.</summary>
        public decimal GetCalculatedTotalHours()
        {
            return GetCalculatedTotalDays() * WorkHoursPerDay;
        }

        /// <summary>Calcula los días totales estimados basándose en días hábiles (L-V).</summary>
        public int GetCalculatedTotalDays()
        {
            if (!StartDate.HasValue || !EndDate.HasValue) return 0;

            int workingDays = 0;
            for (var date = StartDate.Value.Date; date <= EndDate.Value.Date; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
            }
            return workingDays;
        }
    }
}
