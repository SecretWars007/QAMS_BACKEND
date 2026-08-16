using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.TestSuites
{
    public class CreateTestSuiteDto
    {
        [Required(ErrorMessage = "El ProjectId es obligatorio.")]
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string? Description { get; set; }

        public int StatusId { get; set; } = 1; // Default: PENDIENTE

        public Guid? TestPlanId { get; set; }

        // ISTQB Fields
        public int? ExecutionPriorityId { get; set; }
        public int? TestLevelId { get; set; }
        public int? TestTypeId { get; set; }
        public int? AutomationStatusId { get; set; }
        public int? TestDesignTechniqueId { get; set; }
        public int? ReviewStatusId { get; set; }
        public int? TestEnvironmentId { get; set; }
        public Guid? OwnerUserId { get; set; }
        
        [StringLength(1000, ErrorMessage = "Las precondiciones no pueden exceder los 1000 caracteres.")]
        public string? Preconditions { get; set; }
        
        [StringLength(255, ErrorMessage = "El objetivo de cobertura no puede exceder los 255 caracteres.")]
        public string? CoverageObjective { get; set; }
        
        public decimal EstimatedDurationHours { get; set; } = 0m;
        
        public List<int> TagIds { get; set; } = new();
    }
}
