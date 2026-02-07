// src/QAMS.Infrastructure/Repositories/RoleRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio específico para Role.
    /// Extiende GenericRepository con consultas que incluyen eager loading
    /// de permisos asociados al rol.
    /// </summary>
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(QamsDbContext context)
            : base(context) { }

        /// <summary>
        /// Obtiene un rol con todos sus permisos cargados.
        /// Usa Include para navegar Role -> RolePermissions -> Permission.
        /// </summary>
        public async Task<Role?> GetWithPermissionsAsync(Guid roleId)
        {
            // Incluir la cadena completa de navegación hacia permisos
            return await _dbSet
                .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(r => r.Id == roleId);
        }

        /// <summary>
        /// Busca un rol por su nombre exacto.
        /// </summary>
        public async Task<Role?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Obtiene todos los roles con sus permisos para la vista de administración.
        /// </summary>
        public async Task<IReadOnlyList<Role>> GetAllWithPermissionsAsync()
        {
            return await _dbSet
                .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .OrderBy(r => r.Name)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
