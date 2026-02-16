// src/QAMS.Application/DTOs/Projects/ProjectDto.cs
namespace QAMS.Application.DTOs.Projects
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public int ProjectStatusId { get; set; }
        public string ProjectStatusName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? CreatedByUserName { get; set; }
        public int TestSuiteCount { get; set; }
        public int KanbanBoardCount { get; set; }
        public List<string> TesterNames { get; set; } = new List<string>();
    }
}
