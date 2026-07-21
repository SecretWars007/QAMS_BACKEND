using System;
using System.Collections.Generic;
using QAMS.Application.DTOs.TestSuites;
using QAMS.Application.DTOs.Catalogs;
using QAMS.Application.DTOs.TestPlans;

namespace QAMS.Application.DTOs.TestPlans
{
    public class TestPlanDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string? Objectives { get; set; }

        // ISTQB Fields
        public string? Scope { get; set; }
        public string? OutOfScope { get; set; }
        public string? TestStrategy { get; set; }
        public string? RiskAnalysis { get; set; }
        public string? EnvironmentRequirements { get; set; }
        public string? TestSchedule { get; set; }
        public decimal EstimatedEffortHours { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }
        public CatalogItemDto? Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;

        public List<TestSuiteDto> TestSuites { get; set; } = new();
        public List<TestPlanCriteriaDto> Criteria { get; set; } = new();
    }
}
