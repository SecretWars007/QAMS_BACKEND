// src/QAMS.Infrastructure/Repositories/TestSuiteRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio específico para TestSuite.
    /// </summary>
    public class TestSuiteRepository : GenericRepository<TestSuite>, ITestSuiteRepository
    {
        public TestSuiteRepository(QamsDbContext context)
            : base(context) { }

        public override async Task<TestSuite?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(ts => ts.Status)
                .FirstOrDefaultAsync(ts => ts.Id == id);
        }

        /// <summary>
        /// Obtiene suites de un proyecto con sus casos de prueba incluidos.
        /// </summary>
        public async Task<IReadOnlyList<TestSuite>> GetByProjectWithTestCasesAsync(Guid projectId)
        {
            return await _dbSet
                .Where(ts => ts.ProjectId == projectId)
                .Include(ts => ts.Status)
                .Include(ts => ts.TestCases)
                .ThenInclude(tc => tc.Priority)
                .OrderBy(ts => ts.Name)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
