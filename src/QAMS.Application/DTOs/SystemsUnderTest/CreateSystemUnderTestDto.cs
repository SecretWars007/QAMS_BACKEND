// src/QAMS.Application/DTOs/SystemsUnderTest/CreateSystemUnderTestDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.SystemsUnderTest
{
    public class CreateSystemUnderTestDto
    {
        [Required(ErrorMessage = "El ID del proyecto es obligatorio.")]
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "El nombre del sistema es obligatorio.")]
        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Version { get; set; }

        [StringLength(50)]
        public string? Environment { get; set; }

        [Url]
        [StringLength(255)]
        public string? BaseUrl { get; set; }
    }
}
