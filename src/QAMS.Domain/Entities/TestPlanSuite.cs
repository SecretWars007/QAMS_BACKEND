using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    public class TestPlanSuite : IAuditable
    {
        public Guid TestPlanId { get; set; }
        public TestPlan? TestPlan { get; set; }

        public Guid TestSuiteId { get; set; }
        public TestSuite? TestSuite { get; set; }

        public int ExecutionOrder { get; set; } = 0;
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public Guid? ResponsibleUserId { get; set; }
        public User? Responsible { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
