using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    public class TestPlan : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        
        public string Name { get; set; } = string.Empty;
        public string? Objectives { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public int StatusId { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }
        public User? DeletedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedBy { get; set; }

        public ICollection<TestPlanSuite> TestPlanSuites { get; set; } = [];
    }
}
