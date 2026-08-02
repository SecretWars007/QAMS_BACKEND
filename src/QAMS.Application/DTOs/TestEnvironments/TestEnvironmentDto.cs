// src/QAMS.Application/DTOs/TestEnvironments/TestEnvironmentDto.cs
namespace QAMS.Application.DTOs.TestEnvironments
{
    public class TestEnvironmentDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? BaseUrl { get; set; }
        public string? OperatingSystem { get; set; }
        public string? Browser { get; set; }
        public string EnvironmentType { get; set; } = "QA";
        public string? SoftwareVersion { get; set; }
        public string? AdditionalConfig { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
    }

    public class CreateTestEnvironmentDto
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? BaseUrl { get; set; }
        public string? OperatingSystem { get; set; }
        public string? Browser { get; set; }
        public string EnvironmentType { get; set; } = "QA";
        public string? SoftwareVersion { get; set; }
        public string? AdditionalConfig { get; set; }
    }

    public class UpdateTestEnvironmentDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? BaseUrl { get; set; }
        public string? OperatingSystem { get; set; }
        public string? Browser { get; set; }
        public string EnvironmentType { get; set; } = "QA";
        public string? SoftwareVersion { get; set; }
        public string? AdditionalConfig { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
