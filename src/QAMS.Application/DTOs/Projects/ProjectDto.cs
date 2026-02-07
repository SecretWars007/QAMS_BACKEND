// src/QAMS.Application/DTOs/Projects/ProjectDto.cs
namespace QAMS.Application.DTOs.Projects
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TestSuiteCount { get; set; }
        public int KanbanBoardCount { get; set; }
    }
}
