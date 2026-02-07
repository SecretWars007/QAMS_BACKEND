// src/QAMS.Application/DTOs/TestExecutions/TestExecutionDto.cs
namespace QAMS.Application.DTOs.TestExecutions
{
    public class TestExecutionDto
    {
        public Guid Id { get; set; }
        public Guid TestCaseId { get; set; }
        public string TestCaseTitle { get; set; } = string.Empty;
        public Guid TesterId { get; set; }
        public string TesterName { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime? CompletedAt { get; set; }
        public List<StepResultDto> StepResults { get; set; } = new();
        public List<EvidenceDto> Evidences { get; set; } = new();
    }
}
