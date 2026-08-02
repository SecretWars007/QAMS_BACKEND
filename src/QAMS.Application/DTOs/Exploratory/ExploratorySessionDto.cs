// src/QAMS.Application/DTOs/Exploratory/ExploratorySessionDto.cs
namespace QAMS.Application.DTOs.Exploratory
{
    public class ExploratorySessionDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public Guid TesterId { get; set; }
        public string TesterName { get; set; } = string.Empty;
        public string Charter { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ExploratoryFindingDto> Findings { get; set; } = [];
    }

    public class CreateExploratorySessionDto
    {
        public Guid ProjectId { get; set; }
        public Guid TesterId { get; set; }
        public string Charter { get; set; } = string.Empty;
        public DateTime? StartTime { get; set; }
        public string? Notes { get; set; }
    }

    public class UpdateExploratorySessionDto
    {
        public string? Notes { get; set; }
        public DateTime? EndTime { get; set; }
        public int? DurationMinutes { get; set; }
    }

    public class ExploratoryFindingDto
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
    }

    public class CreateExploratoryFindingDto
    {
        public Guid SessionId { get; set; }
        public int TypeId { get; set; } // 1: Bug, 2: Nota, 3: Pregunta
        public string Description { get; set; } = string.Empty;
    }
}
