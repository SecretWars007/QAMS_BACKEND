// src/QAMS.Application/DTOs/TestCases/TestCaseDto.cs
namespace QAMS.Application.DTOs.TestCases
{
    public class TestCaseDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public Guid TestSuiteId { get; set; }
        public string TestSuiteName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Preconditions { get; set; }
        public string ExpectedResult { get; set; } = string.Empty;
        public string? Postconditions { get; set; }
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = string.Empty;
        public string PriorityCode { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int VersionNumber { get; set; }
        public bool IsLatestVersion { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedByUserName { get; set; }
        public decimal EstimatedTimeHours { get; set; }
        public int TestTypeId { get; set; }
        public string TestTypeName { get; set; } = string.Empty;
        public int? DesignTechniqueId { get; set; }
        public string? DesignTechniqueName { get; set; }
        public int ImpactLevel { get; set; } = 3;
        public int LikelihoodLevel { get; set; } = 3;
        public int RiskScore { get; set; } = 9;
        public int? LastCycleNumber { get; set; }
        public List<TestStepDto> Steps { get; set; } = [];
        public List<Guid> RequirementIds { get; set; } = [];
        public bool IsBdd { get; set; }
        public string? BddScenario { get; set; }
    }
}
