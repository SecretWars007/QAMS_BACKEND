// src/QAMS.Application/DTOs/TestExecutions/StepResultDto.cs
namespace QAMS.Application.DTOs.TestExecutions
{
    public class UpdateStepResultDto
    {
        public Guid TestStepId { get; set; }
        public int StatusId { get; set; }
        public string? ActualResult { get; set; }
        public string? Notes { get; set; }
    }
}
