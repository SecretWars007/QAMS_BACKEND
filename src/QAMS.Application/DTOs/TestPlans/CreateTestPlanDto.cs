using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.TestPlans
{
    public class CreateTestPlanDto
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Objectives { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public List<Guid> TestSuiteIds { get; set; } = new();
    }
}
