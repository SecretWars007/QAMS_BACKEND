// src/QAMS.Application/DTOs/Dashboard/TimelineChartDto.cs
using System.Collections.Generic;

namespace QAMS.Application.DTOs.Dashboard
{
    public class TimelineChartDto
    {
        public List<string> DayLabels { get; set; } = [];
        public int MinHour { get; set; }
        public int MaxHour { get; set; }
        public List<TimelineEventDto> Events { get; set; } = [];
    }
}
