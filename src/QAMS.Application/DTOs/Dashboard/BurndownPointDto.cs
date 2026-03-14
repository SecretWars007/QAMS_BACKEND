// src/QAMS.Application/DTOs/Dashboard/BurndownPointDto.cs
namespace QAMS.Application.DTOs.Dashboard
{
    public class BurndownPointDto
    {
        public DateTime Date { get; set; }
        public string DateLabel { get; set; } = string.Empty;
        public decimal IdealHours { get; set; }
        public decimal ActualHours { get; set; }
    }
}
