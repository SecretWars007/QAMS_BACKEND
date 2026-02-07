// src/QAMS.Application/DTOs/TestExecutions/CreateTestExecutionDto.cs
namespace QAMS.Application.DTOs.TestExecutions
{
    public class CreateTestExecutionDto
    {
        public Guid TestCaseId { get; set; }
        public string? Notes { get; set; }
    }
}
