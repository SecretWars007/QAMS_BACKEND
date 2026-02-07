// src/QAMS.Application/DTOs/Projects/CreateProjectDto.cs
namespace QAMS.Application.DTOs.Projects
{
    public class CreateProjectDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
