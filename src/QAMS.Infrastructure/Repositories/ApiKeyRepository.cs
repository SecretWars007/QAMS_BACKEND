// src/QAMS.Infrastructure/Repositories/ApiKeyRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Application.Interfaces.Repositories;
using QAMS.Domain.Entities;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    public class ApiKeyRepository : GenericRepository<ApiKey>, IApiKeyRepository
    {
        public ApiKeyRepository(QamsDbContext context) : base(context)
        {
        }

        public async Task<List<ApiKey>> GetByProjectAsync(Guid projectId)
        {
            return await _dbSet
                .Where(k => k.ProjectId == projectId && !k.IsDeleted)
                .Include(k => k.CreatedBy)
                .OrderByDescending(k => k.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ApiKey?> GetByPrefixAsync(string prefix)
        {
            return await _dbSet
                .Include(k => k.Project)
                .FirstOrDefaultAsync(k => k.KeyPrefix == prefix && k.IsActive && !k.IsDeleted);
        }
    }
}
