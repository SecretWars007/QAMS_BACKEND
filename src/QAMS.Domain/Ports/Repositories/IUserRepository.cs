// src/QAMS.Domain/Ports/Repositories/IUserRepository.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetWithRolesAsync(Guid userId);
        Task<List<User>> GetByIdsWithRolesAsync(IEnumerable<Guid> userIds);
        Task<List<User>> GetAllWithRolesAsync();
        Task<User?> GetWithRolesAndPermissionsAsync(string username);
        Task AssignRoleAsync(Guid userId, Guid roleId);
        Task RemoveAllRolesAsync(Guid userId);
        Task RemoveRoleAsync(Guid userId, Guid roleId);
    }
}
