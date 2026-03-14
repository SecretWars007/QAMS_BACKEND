// src/QAMS.Application/DTOs/TestExecutions/UpdateCompleteExecutionDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.TestExecutions
{
    public class UpdateCompleteExecutionDto
    {
        [StringLength(2000, ErrorMessage = "Las notas no pueden exceder los 2000 caracteres.")]
        public string? Notes { get; set; }

        [Range(0, 999, ErrorMessage = "Las horas reales deben estar entre 0 y 999.")]
        public decimal? ActualTimeHours { get; set; }

        public int? GlobalStatusId { get; set; }

        [Required(ErrorMessage = "Los resultados de pasos son obligatorios.")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un resultado de paso.")]
        public List<StepResultInput> StepResults { get; set; } = new();
    }
}
