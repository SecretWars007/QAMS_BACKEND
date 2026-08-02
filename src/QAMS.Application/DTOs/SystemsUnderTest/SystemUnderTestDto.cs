// src/QAMS.Application/DTOs/SystemsUnderTest/SystemUnderTestDto.cs
using System;

namespace QAMS.Application.DTOs.SystemsUnderTest
{
    public class SystemUnderTestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Version { get; set; }
        public string? Environment { get; set; }
        public int PlatformTypeId { get; set; }
        public string PlatformTypeName { get; set; } = string.Empty;
        public string PlatformTypeCode { get; set; } = string.Empty;
        public string? BaseUrl { get; set; }
        public string? ExecutablePath { get; set; }
        public string? ProcessName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
