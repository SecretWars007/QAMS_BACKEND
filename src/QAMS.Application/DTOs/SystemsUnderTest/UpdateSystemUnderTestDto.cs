// src/QAMS.Application/DTOs/SystemsUnderTest/UpdateSystemUnderTestDto.cs
using System.ComponentModel.DataAnnotations;

namespace QAMS.Application.DTOs.SystemsUnderTest
{
    public class UpdateSystemUnderTestDto
    {
        [StringLength(150, MinimumLength = 3)]
        public string? Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Version { get; set; }

        [StringLength(50)]
        public string? Environment { get; set; }

        public int? PlatformTypeId { get; set; }

        [StringLength(255)]
        public string? BaseUrl { get; set; }

        [StringLength(500)]
        public string? ExecutablePath { get; set; }

        [StringLength(255)]
        public string? ProcessName { get; set; }

        public bool? IsActive { get; set; }
    }
}
