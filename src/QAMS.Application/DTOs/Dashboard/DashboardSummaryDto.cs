// src/QAMS.Application/DTOs/Dashboard/DashboardSummaryDto.cs
namespace QAMS.Application.DTOs.Dashboard
{
    public class DashboardSummaryDto
    {
        public int TotalProjects { get; set; }
        public int TotalTestCases { get; set; }
        public int TotalExecutions { get; set; }
        public int PassedExecutions { get; set; }
        public int FailedExecutions { get; set; }
        public int PendingExecutions { get; set; }
        public double PassRate { get; set; }
        public List<TaskProgressDto> TaskProgress { get; set; } = new();
        public List<ExecutionsByStatusDto> ExecutionsByStatus { get; set; } = new();
    }
}
