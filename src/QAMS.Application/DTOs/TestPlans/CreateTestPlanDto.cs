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
        public string? TestStrategy { get; set; }
        public string? RiskAnalysis { get; set; }
        public string? EnvironmentRequirements { get; set; }
        public string? TestSchedule { get; set; }
        public decimal EstimatedEffortHours { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public List<Guid>? TestSuiteIds { get; set; }
        public List<TestPlanCriteriaDto>? Criteria { get; set; }
    }
}
