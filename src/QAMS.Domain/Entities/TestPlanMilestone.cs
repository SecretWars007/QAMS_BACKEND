using System;
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    public class TestPlanMilestone : IAuditable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public Guid TestPlanId { get; set; }
        public virtual TestPlan? TestPlan { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
