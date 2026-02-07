// src/QAMS.Application/DTOs/TestCases/CreateTestCaseDto.cs
namespace QAMS.Application.DTOs.TestCases
{
    public class CreateTestCaseDto
    {
        public Guid TestSuiteId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Preconditions { get; set; }
        public string ExpectedResult { get; set; } = string.Empty;
        public int PriorityId { get; set; }
        public List<CreateTestStepDto> Steps { get; set; } = new();
    }

    public class CreateTestStepDto
    {
        public int StepOrder { get; set; }
        public string Action { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
    }
}
