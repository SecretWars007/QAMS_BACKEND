// src/QAMS.Application/DTOs/TestExecutions/StepResultDto.cs
namespace QAMS.Application.DTOs.TestExecutions
{
    public class StepResultDto
    {
        public Guid Id { get; set; }
        public Guid TestStepId { get; set; }
        public int StepOrder { get; set; }
        public string Action { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string? ActualResult { get; set; }
        public string? Notes { get; set; }
    }
}
