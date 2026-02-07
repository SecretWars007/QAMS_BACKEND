// src/QAMS.Application/DTOs/Dashboard/DashboardSummaryDto.cs
namespace QAMS.Application.DTOs.Dashboard
{
    public class ExecutionsByStatusDto
    {
        public string StatusName { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
