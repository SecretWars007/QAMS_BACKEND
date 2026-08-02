// src/QAMS.Infrastructure/Repositories/PermissionRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;
using QAMS.Domain.Constants;

namespace QAMS.Infrastructure.Repositories
{
    public class PermissionRepository(QamsDbContext context)
        : GenericRepository<Permission>(context), IPermissionRepository
    {

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
            var userRoles = await _context.UserRoles
                .Include(ur => ur.Role)
                .Where(ur => ur.UserId == userId)
                .AsNoTracking()
                .ToListAsync();

            var isAdmin = userRoles.Any(ur =>
                ur.RoleId == SystemRoles.AdminRoleId ||
                (ur.Role != null && (
                    string.Equals(ur.Role.Name, "Admin", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(ur.Role.Name, "Administrador", StringComparison.OrdinalIgnoreCase)
                ))
            );

            if (isAdmin)
            {
                var dbPermissions = await _context.Permissions
                    .Select(p => p.Code)
                    .Distinct()
                    .AsNoTracking()
                    .ToListAsync();

                var defaultFullList = new[]
                {
                    "USERS_VIEW", "USERS_CREATE", "USERS_UPDATE", "USERS_DELETE", "USERS_ASSIGN_ROLES",
                    "ROLES_VIEW", "ROLES_CREATE", "ROLES_UPDATE", "ROLES_DELETE", "ROLES_ASSIGN_PERMISSIONS",
                    "CATALOGS_VIEW", "CATALOGS_MANAGE",
                    "PROJECTS_VIEW", "PROJECTS_CREATE", "PROJECTS_UPDATE", "PROJECTS_DELETE",
                    "TEST_CASES_VIEW", "TEST_CASES_CREATE", "TEST_CASES_UPDATE", "TEST_CASES_DELETE",
                    "EXECUTIONS_VIEW", "EXECUTIONS_CREATE", "EXECUTIONS_UPDATE", "EXECUTIONS_UPLOAD_EVIDENCE",
                    "KANBAN_VIEW", "KANBAN_CREATE", "KANBAN_UPDATE", "KANBAN_DELETE",
                    "DASHBOARD_VIEW",
                    "SUT_VIEW", "SUT_CREATE", "SUT_UPDATE", "SUT_DELETE"
                };

                return dbPermissions.Union(defaultFullList, StringComparer.OrdinalIgnoreCase).ToList();
            }

            var permissionCodes = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .SelectMany(ur => ur.Role!.RolePermissions)
                .Select(rp => rp.Permission!.Code)
                .Distinct()
                .AsNoTracking()
                .ToListAsync();

            return permissionCodes;
        }
    }
}
