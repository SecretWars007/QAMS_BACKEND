namespace QAMS.Application.DTOs.TestExecutions
{
    public class StepResultDto
    {
        public Guid Id { get; set; }
        public Guid TestStepId { get; set; }
        public int StepOrder { get; set; }
        public string Action { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public string? ActualResult { get; set; }
        public string? Notes { get; set; }
        public List<EvidenceDto> Evidences { get; set; } = [];
        public List<ObservationDto> Observations { get; set; } = [];
    }
}
