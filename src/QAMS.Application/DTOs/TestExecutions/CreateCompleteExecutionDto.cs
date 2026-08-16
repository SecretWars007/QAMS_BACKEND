// src/QAMS.Application/DTOs/TestExecutions/CreateCompleteExecutionDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.TestExecutions
{
    /// <summary>
    /// DTO para crear una ejecución completa con todos los resultados de pasos.
    /// </summary>
    public class CreateCompleteExecutionDto
    {
        [Required(ErrorMessage = "El TestCaseId es obligatorio.")]
        public Guid TestCaseId { get; set; }

        public Guid? TesterId { get; set; }

        [StringLength(2000, ErrorMessage = "Las notas no pueden exceder los 2000 caracteres.")]
        public string? Notes { get; set; }

        /// <summary>
        /// Opcional: Horas reales invertidas en esta ejecución.
        /// </summary>
        [Range(0, 999, ErrorMessage = "Las horas reales deben estar entre 0 y 999.")]
        public decimal? ActualTimeHours { get; set; }

        /// <summary>
        /// Opcional: ID del plan de pruebas asociado a este ciclo de ejecución.
        /// </summary>
        public Guid? TestPlanId { get; set; }

        /// <summary>
        /// Resultados de cada paso del test case.
        /// Cada resultado debe corresponder a un TestStepId válido del caso de prueba.
        /// </summary>
        [Required(ErrorMessage = "Los resultados de pasos son obligatorios.")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un resultado de paso.")]
        public List<StepResultInput> StepResults { get; set; } = [];
    }
}
