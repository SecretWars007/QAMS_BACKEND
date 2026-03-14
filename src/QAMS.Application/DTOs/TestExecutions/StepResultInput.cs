// src/QAMS.Application/DTOs/TestExecutions/StepResultInput.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.TestExecutions
{
    /// <summary>
    /// Resultado de un paso individual en la ejecución para entrada de datos.
    /// </summary>
    public class StepResultInput
    {
        [Required(ErrorMessage = "El TestStepId es obligatorio.")]
        public Guid TestStepId { get; set; }

        [Required(ErrorMessage = "El StatusId es obligatorio.")]
        public int StatusId { get; set; }

        [StringLength(2000, ErrorMessage = "El resultado actual no puede exceder los 2000 caracteres.")]
        public string? ActualResult { get; set; }

        [StringLength(2000, ErrorMessage = "Las notas no pueden exceder los 2000 caracteres.")]
        public string? Notes { get; set; }
    }
}
