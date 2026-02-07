// src/QAMS.Infrastructure/Repositories/PermissionRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(QamsDbContext context) : base(context) { }

        public async Task<Permission?> GetByCodeAsync(string code)
            => await _dbSet.FirstOrDefaultAsync(p => p.Code == code);

        public async Task<Dictionary<string, List<Permission>>> GetGroupedByModuleAsync()
        {
            var permissions = await _dbSet.AsNoTracking().ToListAsync();
            return permissions.GroupBy(p => p.Module)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        /// <summary>
        /// Consulta crítica del RBAC: obtiene todos los códigos de permiso
        /// de un usuario a través de la cadena User->Roles->Permissions.
        /// </summary>
        public async Task<IReadOnlyList<string>> GetPermissionCodesByUserIdAsync(Guid userId)
        {
            // Join: UserRoles -> RolePermissions -> Permissions
            var permissionCodes = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .SelectMany(ur => ur.Role.RolePermissions)
                .Select(rp => rp.Permission.Code)
                .Distinct()
                .AsNoTracking()
                .ToListAsync();

            return permissionCodes;
        }
    }
}
