using System;
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    public class TestPlanRisk : IAuditable
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid TestPlanId { get; set; }
        public virtual TestPlan? TestPlan { get; set; }

        public string Description { get; set; } = string.Empty;
        
        // e.g., 1 to 5
        public int Probability { get; set; } = 3;
        
        // e.g., 1 to 5
        public int Impact { get; set; } = 3;
        
        public string? Mitigation { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
