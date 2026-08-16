using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.TestPlans
{
    public class CreateTestPlanDto
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Objectives { get; set; }

        // ISTQB Fields
        public string? Scope { get; set; }
        public string? OutOfScope { get; set; }
        public int? TestStrategyId { get; set; }
        public int? TestPlanTypeId { get; set; }
        public int? TestLevelId { get; set; }
        public Guid? TestManagerId { get; set; }
        public int? RiskLevelId { get; set; }
        public int? TestEnvironmentId { get; set; }
        public string? TestSchedule { get; set; }
        public decimal EstimatedEffortHours { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public List<Guid>? TestSuiteIds { get; set; }
        public List<TestPlanCriteriaDto>? Criteria { get; set; }
        public List<TestPlanMilestoneDto>? Milestones { get; set; }
        public List<TestPlanRiskDto>? Risks { get; set; }
    }
}
