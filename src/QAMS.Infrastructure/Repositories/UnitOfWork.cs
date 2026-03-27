// src/QAMS.Infrastructure/Repositories/UnitOfWork.cs
using Microsoft.Extensions.Logging;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    public class UnitOfWork(QamsDbContext context, ILogger<UnitOfWork> logger) : IUnitOfWork
    {
        private readonly QamsDbContext _context = context;
        private readonly ILogger<UnitOfWork> _logger = logger;

        public async Task<int> SaveChangesAsync()
        {
            _logger.LogDebug("Persistiendo cambios en BD.");
            var result = await _context.SaveChangesAsync();
            _logger.LogInformation("{Count} cambios persistidos.", result);
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
