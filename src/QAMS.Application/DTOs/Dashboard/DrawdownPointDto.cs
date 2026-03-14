// src/QAMS.Application/DTOs/Dashboard/DrawdownPointDto.cs
using System;

namespace QAMS.Application.DTOs.Dashboard
{
    public class DrawdownPointDto
    {
        public DateTime Date { get; set; }
        public string DateLabel { get; set; } = string.Empty;
        public int RemainingCases { get; set; }
        public int PassedTotal { get; set; }
        public double PercentageRemaining { get; set; }
    }
}
