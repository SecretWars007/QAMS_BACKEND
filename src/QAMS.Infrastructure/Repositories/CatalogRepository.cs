// src/QAMS.Infrastructure/Repositories/CatalogRepository.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    public class CatalogRepository<T> : ICatalogRepository<T>
        where T : CatalogBase
    {
        private readonly QamsDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<CatalogRepository<T>> _logger;

        public CatalogRepository(QamsDbContext context, ILogger<CatalogRepository<T>> logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<T?> GetByCodeAsync(string code) =>
            await _dbSet.FirstOrDefaultAsync(c => c.Code.ToLower() == code.ToLower());

        public async Task<IReadOnlyList<T>> GetAllActiveAsync() =>
            await _dbSet
                .Where(c => c.IsActive)
                .OrderBy(c => c.SortOrder)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllAsync() =>
            await _dbSet.OrderBy(c => c.SortOrder).AsNoTracking().ToListAsync();

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Update(T entity) => _dbSet.Update(entity);

        public async Task<bool> ExistsByCodeAsync(string code) =>
            await _dbSet.AnyAsync(c => c.Code.ToLower() == code.ToLower());
    }
}
