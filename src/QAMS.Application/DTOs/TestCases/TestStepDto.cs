// src/QAMS.Application/DTOs/TestCases/TestStepDto.cs
namespace QAMS.Application.DTOs.TestCases
{
    public class TestStepDto
    {
        public Guid Id { get; set; }
        public int StepOrder { get; set; }
        public string Action { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
    }
}
