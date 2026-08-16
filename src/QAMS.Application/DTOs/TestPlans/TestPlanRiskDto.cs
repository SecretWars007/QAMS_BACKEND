using System;

namespace QAMS.Application.DTOs.TestPlans
{
    public class TestPlanRiskDto
    {
        public Guid? Id { get; set; }
        public Guid? TestPlanId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Probability { get; set; }
        public int Impact { get; set; }
        public string? Mitigation { get; set; }
    }
}
