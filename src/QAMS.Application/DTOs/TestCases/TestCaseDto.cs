// src/QAMS.Application/DTOs/TestCases/TestCaseDto.cs
namespace QAMS.Application.DTOs.TestCases
{
    public class TestCaseDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TestSuiteId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Preconditions { get; set; }
        public string ExpectedResult { get; set; } = string.Empty;
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = string.Empty;
        public string PriorityCode { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedByUserName { get; set; }
        public decimal EstimatedTimeHours { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TestTypeId { get; set; }
        public string TestTypeName { get; set; } = string.Empty;
        public List<string> CertifierNames { get; set; } = new();
        public List<TestStepDto> Steps { get; set; } = new();
    }
}
