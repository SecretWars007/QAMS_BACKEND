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
        
        public string Version { get; set; } = "1.0";
        public decimal Budget { get; set; } = 0m;
        public string? Risks { get; set; }
        public Guid? LeaderId { get; set; }
        public string? LeaderName { get; set; }
        
        public int ProjectPriorityId { get; set; }
        public string ProjectPriorityName { get; set; } = string.Empty;
        public int ProjectStatusId { get; set; }
        public string ProjectStatusName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? CreatedByUserName { get; set; }
        public int TestSuiteCount { get; set; }
        public int KanbanBoardCount { get; set; }
        public List<string> TesterNames { get; set; } = [];
        public int DevolucionesCounter { get; set; }
        public List<ProjectDevolutionDto> HistoricDevolutions { get; set; } = [];
        public List<RequirementDto> Requirements { get; set; } = [];
    }
}
