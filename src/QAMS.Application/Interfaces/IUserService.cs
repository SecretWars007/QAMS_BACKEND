// src/QAMS.Application/Interfaces/IUserService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QAMS.Application.DTOs.Users;
namespace QAMS.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(Guid id);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task<UserDto> UpdateAsync(Guid id, UpdateUserDto dto);
        Task DeleteAsync(Guid id);
        Task AssignRoleAsync(Guid userId, Guid roleId);
        Task RemoveAllRolesAsync(Guid userId);
        Task RemoveRoleAsync(Guid userId, Guid roleId);
        Task ResetPasswordAsync(Guid userId, string newPassword);
    }
}
