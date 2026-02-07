// src/QAMS.Application/DTOs/Roles/RoleDto.cs
namespace QAMS.Application.DTOs.Roles
{
    public class PermissionDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
    }
}
