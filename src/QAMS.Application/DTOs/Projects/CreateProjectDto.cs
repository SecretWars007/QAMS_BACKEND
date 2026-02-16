// src/QAMS.Application/DTOs/Projects/CreateProjectDto.cs
namespace QAMS.Application.DTOs.Projects
{
    public class CreateProjectDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public int ProjectStatusId { get; set; }
        public List<Guid>? TesterIds { get; set; }
    }
}
