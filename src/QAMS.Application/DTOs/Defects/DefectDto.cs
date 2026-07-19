// src/QAMS.Application/DTOs/Defects/DefectDto.cs
namespace QAMS.Application.DTOs.Defects
{
    public class DefectDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        // Trazabilidad ISTQB
        public Guid? TestCaseId { get; set; }
        public string? TestCaseTitle { get; set; }
        public Guid? TestExecutionId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? StepsToReproduce { get; set; }
        public string? ActualResult { get; set; }
        public string? ExpectedResult { get; set; }

        public int DefectPriorityId { get; set; }
        public string DefectPriorityCode { get; set; } = string.Empty;
        public string DefectPriorityName { get; set; } = string.Empty;

        public int DefectStatusId { get; set; }
        public string DefectStatusCode { get; set; } = string.Empty;
        public string DefectStatusName { get; set; } = string.Empty;

        public Guid ReportedByUserId { get; set; }
        public string ReportedByUserName { get; set; } = string.Empty;
        public Guid? AssignedToUserId { get; set; }
        public string? AssignedToUserName { get; set; }

        public DateTime? ResolvedAt { get; set; }
        public string? ResolutionNotes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
