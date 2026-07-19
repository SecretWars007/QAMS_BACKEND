// src/QAMS.Application/DTOs/Projects/CreateRequirementDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.Projects
{
    public class CreateRequirementDto
    {
        [Required(ErrorMessage = "El título del requisito es obligatorio")]
        [MaxLength(500, ErrorMessage = "El título no puede exceder los 500 caracteres")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "El código del requisito es obligatorio")]
        [MaxLength(100, ErrorMessage = "El código no puede exceder los 100 caracteres")]
        public string Code { get; set; } = string.Empty;

        public string? AcceptanceCriteria { get; set; }
        public int RequirementTypeId { get; set; } = 1; // Default: Functional
        public int RequirementPriorityId { get; set; } = 2; // Default: Medium
        public int RequirementComplexityId { get; set; } = 2; // Default: Medium
        public string? Source { get; set; }
    }
}
