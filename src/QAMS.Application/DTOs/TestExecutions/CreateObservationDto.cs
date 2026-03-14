// src/QAMS.Application/DTOs/TestExecutions/CreateObservationDto.cs
namespace QAMS.Application.DTOs.TestExecutions
{
    public class CreateObservationDto
    {
        public Guid ExecutionStepResultId { get; set; }
        public string Observation { get; set; } = string.Empty;
    }

    public class ResponseObservationDto
    {
        public string Response { get; set; } = string.Empty;
    }

    public class ObservationDto
    {
        public Guid Id { get; set; }
        public Guid ExecutionStepResultId { get; set; }
        public string Observation { get; set; } = string.Empty;
        public string? Response { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? RespondedByUserName { get; set; }
        public DateTime? RespondedAt { get; set; }

        public string? FileName { get; set; }
        public string? FilePath { get; set; }
    }
}
