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
    }
}
