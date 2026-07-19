using QAMS.Application.DTOs.TestSuites;

namespace QAMS.Application.DTOs.TestPlans
{
    public class TestPlanDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;
        public string? Objectives { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;

        public List<TestSuiteDto> Suites { get; set; } = new();
    }
}
