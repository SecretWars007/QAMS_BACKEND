// src/QAMS.Domain/Ports/Repositories/IUserRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetWithRolesAsync(Guid userId);
        Task<User?> GetWithRolesAndPermissionsAsync(string username);
    }
}
