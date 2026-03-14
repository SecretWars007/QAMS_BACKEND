// src/QAMS.Application/DTOs/Dashboard/TimelineEventDto.cs
namespace QAMS.Application.DTOs.Dashboard
{
    public class TimelineEventDto
    {
        public Guid ExecutionId { get; set; }
        public string TestCaseTitle { get; set; } = string.Empty;
        public DateTime ExecutionDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusColor { get; set; } = string.Empty;
        public int DayIndex { get; set; }
        public int Hour { get; set; }
    }
}
