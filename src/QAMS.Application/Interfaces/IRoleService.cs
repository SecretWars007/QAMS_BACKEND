// src/QAMS.Application/Interfaces/IRoleService.cs
using QAMS.Application.DTOs.Roles;
namespace QAMS.Application.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDto> GetByIdAsync(Guid id);
        Task<List<RoleDto>> GetAllAsync();
        Task<RoleDto> CreateAsync(CreateRoleDto dto);
        Task<RoleDto> UpdateAsync(Guid id, CreateRoleDto dto);
        Task DeleteAsync(Guid id);
        Task AssignPermissionsAsync(Guid roleId, AssignPermissionsDto dto);
        Task<List<PermissionDto>> GetAllPermissionsAsync();
    }
}
