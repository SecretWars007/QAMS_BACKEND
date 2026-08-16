// src/QAMS.Application/DTOs/Projects/UpdateRequirementDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.Projects
{
    public class UpdateRequirementDto
    {
        [Required(ErrorMessage = "El título del requisito es obligatorio")]
        [MaxLength(500, ErrorMessage = "El título no puede exceder los 500 caracteres")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "El código del requisito es obligatorio")]
        [MaxLength(100, ErrorMessage = "El código no puede exceder los 100 caracteres")]
        public string Code { get; set; } = string.Empty;

        public string? AcceptanceCriteria { get; set; }
        
        [Required]
        public int RequirementTypeId { get; set; }
        
        [Required]
        public int RequirementPriorityId { get; set; }
        
        [Required]
        public int RequirementComplexityId { get; set; }
        
        [Required]
        public int RequirementStatusId { get; set; }
        
        public string? Source { get; set; }
    }
}
