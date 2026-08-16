using System;

namespace QAMS.Application.DTOs.TestPlans
{
    public class TestPlanMilestoneDto
    {
        public Guid? Id { get; set; }
        public Guid? TestPlanId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
