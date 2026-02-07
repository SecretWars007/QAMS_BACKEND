// src/QAMS.Infrastructure/Repositories/EvidenceRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio específico para Evidence.
    /// </summary>
    public class EvidenceRepository(QamsDbContext context)
        : GenericRepository<Evidence>(context),
            IEvidenceRepository
    {
        /// <summary>
        /// Obtiene todas las evidencias de una ejecución con su tipo de catálogo.
        /// </summary>
        public async Task<IReadOnlyList<Evidence>> GetByExecutionAsync(Guid executionId)
        {
            return await _dbSet
                .Where(e => e.TestExecutionId == executionId)
                .Include(e => e.FileType)
                .OrderByDescending(e => e.UploadedAt)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
