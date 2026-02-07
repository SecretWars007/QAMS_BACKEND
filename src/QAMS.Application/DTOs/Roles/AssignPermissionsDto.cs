// src/QAMS.Application/DTOs/Roles/AssignPermissionsDto.cs
namespace QAMS.Application.DTOs.Roles
{
    public class AssignPermissionsDto
    {
        public List<Guid> PermissionIds { get; set; } = new();
    }
}
