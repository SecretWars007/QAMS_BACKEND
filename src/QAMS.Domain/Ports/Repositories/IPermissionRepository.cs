// src/QAMS.Domain/Ports/Repositories/IPermissionRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Task<Permission?> GetByCodeAsync(string code);
        Task<Dictionary<string, List<Permission>>> GetGroupedByModuleAsync();
        Task<IReadOnlyList<string>> GetPermissionCodesByUserIdAsync(Guid userId);
    }
}
