// src/QAMS.Application/DTOs/Projects/CreateProjectDto.cs
namespace QAMS.Application.DTOs.Projects
{
    public class CreateProjectDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Version { get; set; } = "1.0";
        public decimal Budget { get; set; } = 0m;
        public string? Risks { get; set; }
        public Guid? LeaderId { get; set; }
        public int ProjectPriorityId { get; set; } = 2; // Default: Medium (Assuming 2 is Medium based on seed)
        public int ProjectStatusId { get; set; }
        public List<Guid>? TesterIds { get; set; }
    }
}
