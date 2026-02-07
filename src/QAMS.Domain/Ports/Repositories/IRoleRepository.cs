// src/QAMS.Domain/Ports/Repositories/IRoleRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role?> GetWithPermissionsAsync(Guid roleId);
        Task<Role?> GetByNameAsync(string name);
        Task<IReadOnlyList<Role>> GetAllWithPermissionsAsync();
    }
}
