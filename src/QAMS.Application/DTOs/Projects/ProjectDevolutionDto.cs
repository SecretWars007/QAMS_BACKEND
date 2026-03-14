// src/QAMS.Application/DTOs/Projects/ProjectDevolutionDto.cs
namespace QAMS.Application.DTOs.Projects
{
    public class RegisterDevolutionDto
    {
        public string Notes { get; set; } = string.Empty;
    }

    public class RespondDevolutionDto
    {
        public string Response { get; set; } = string.Empty;
    }

    public class ProjectDevolutionDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime DevolutionDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime? ResponseDate { get; set; }
        public string? ResponseNotes { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
        public int ObservationsCount { get; set; }
    }
}
