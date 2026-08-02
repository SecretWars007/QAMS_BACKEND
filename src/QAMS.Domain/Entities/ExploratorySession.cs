using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    public class ExploratorySession : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        
        public Guid TesterId { get; set; }
        public User? Tester { get; set; }

        public string Charter { get; set; } = string.Empty;
        public int StatusId { get; set; } // 1: Planned, 2: Running, 3: Completed
        
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? DurationMinutes { get; set; }

        public string? Notes { get; set; }

        public ICollection<ExploratoryFinding> Findings { get; set; } = [];

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedBy { get; set; }

        // ISoftDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }
        public User? DeletedBy { get; set; }
    }
}
