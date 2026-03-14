// src/QAMS.Application/DTOs/Reports/ProjectReportFilterDto.cs
namespace QAMS.Application.DTOs.Reports
{
    public class ProjectReportFilterDto
    {
        public Guid ProjectId { get; set; }
        public List<int>? ExecutionStatusIds { get; set; }
        public List<string>? TaskStatusNames { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
