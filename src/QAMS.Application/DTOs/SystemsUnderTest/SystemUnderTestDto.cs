// src/QAMS.Application/DTOs/SystemsUnderTest/SystemUnderTestDto.cs
using System;

namespace QAMS.Application.DTOs.SystemsUnderTest
{
    public class SystemUnderTestDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Version { get; set; }
        public string? Environment { get; set; }
        public string? BaseUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
