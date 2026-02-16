// src/QAMS.Application/DTOs/TestExecutions/CreateTestExecutionDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.TestExecutions
{
    public class CreateTestExecutionDto
    {
        [Required(ErrorMessage = "El TestCaseId es obligatorio.")]
        public Guid TestCaseId { get; set; }

        [StringLength(2000, ErrorMessage = "Las notas no pueden exceder los 2000 caracteres.")]
        public string? Notes { get; set; }
    }
}
