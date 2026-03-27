// src/QAMS.Application/Interfaces/IRoleService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task ToggleStatusAsync(Guid id);
        Task<RoleDto> DuplicateAsync(Guid id, string newName);
        Task AddPermissionsAsync(Guid roleId, List<Guid> permissionIds);
        Task RemovePermissionsAsync(Guid roleId, List<Guid> permissionIds);
    }
}
