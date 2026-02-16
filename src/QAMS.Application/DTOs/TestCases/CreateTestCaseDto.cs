// src/QAMS.Application/DTOs/TestCases/CreateTestCaseDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.TestCases
{
    public class CreateTestCaseDto
    {
        [Required(ErrorMessage = "El ProjectId es obligatorio.")]
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "El TestSuiteId es obligatorio.")]
        public Guid TestSuiteId { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "La descripción no puede exceder los 2000 caracteres.")]
        public string? Description { get; set; }

        [StringLength(1000, ErrorMessage = "Las precondiciones no pueden exceder los 1000 caracteres.")]
        public string? Preconditions { get; set; }

        [Required(ErrorMessage = "El resultado esperado es obligatorio.")]
        [StringLength(1000, ErrorMessage = "El resultado esperado no puede exceder los 1000 caracteres.")]
        public string ExpectedResult { get; set; } = string.Empty;

        [Required(ErrorMessage = "La prioridad es obligatoria.")]
        public int PriorityId { get; set; }

        [Range(0, 1000, ErrorMessage = "El tiempo estimado debe estar entre 0 y 1000 horas.")]
        public decimal EstimatedTimeHours { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "El tipo de prueba es obligatorio.")]
        public int TestTypeId { get; set; }

        public List<Guid> CertifierUserIds { get; set; } = new();
        public List<CreateTestStepDto> Steps { get; set; } = new();
    }

    public class CreateTestStepDto
    {
        [Required]
        public int StepOrder { get; set; }

        [Required(ErrorMessage = "La acción del paso es obligatoria.")]
        public string Action { get; set; } = string.Empty;

        [Required(ErrorMessage = "El resultado esperado del paso es obligatorio.")]
        public string ExpectedResult { get; set; } = string.Empty;
    }
}
