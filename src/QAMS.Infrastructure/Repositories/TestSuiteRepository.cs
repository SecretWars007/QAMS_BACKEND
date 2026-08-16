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
    public class TestSuiteRepository(QamsDbContext context)
        : GenericRepository<TestSuite>(context), ITestSuiteRepository
    {

        public override async Task<TestSuite?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(ts => ts.Status)
                .Include(ts => ts.ExecutionPriority)
                .Include(ts => ts.TestLevel)
                .Include(ts => ts.TestType)
                .Include(ts => ts.AutomationStatus)
                .Include(ts => ts.Owner)
                .Include(ts => ts.Tags).ThenInclude(t => t.Tag)
                .Include(ts => ts.TestPlanSuites)
                .FirstOrDefaultAsync(ts => ts.Id == id && !ts.IsDeleted);
        }

        /// <summary>
        /// Obtiene suites de un proyecto con sus casos de prueba incluidos.
        /// </summary>
        public async Task<IReadOnlyList<TestSuite>> GetByProjectWithTestCasesAsync(Guid projectId)
        {
            return await _dbSet
                .Where(ts => ts.ProjectId == projectId && !ts.IsDeleted)
                .Include(ts => ts.Status)
                .Include(ts => ts.ExecutionPriority)
                .Include(ts => ts.TestLevel)
                .Include(ts => ts.TestType)
                .Include(ts => ts.AutomationStatus)
                .Include(ts => ts.Owner)
                .Include(ts => ts.Tags).ThenInclude(t => t.Tag)
                .Include(ts => ts.TestPlanSuites)
                .Include(ts => ts.TestCases)
                    .ThenInclude(tc => tc.TestExecutions)
                        .ThenInclude(te => te.Status)
                .OrderBy(ts => ts.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene suites de un plan de pruebas con sus casos de prueba incluidos.
        /// </summary>
        public async Task<IReadOnlyList<TestSuite>> GetByTestPlanWithTestCasesAsync(Guid testPlanId)
        {
            return await _dbSet
                .Where(ts => ts.TestPlanSuites.Any(tps => tps.TestPlanId == testPlanId) && !ts.IsDeleted)
                .Include(ts => ts.Status)
                .Include(ts => ts.ExecutionPriority)
                .Include(ts => ts.TestLevel)
                .Include(ts => ts.TestType)
                .Include(ts => ts.AutomationStatus)
                .Include(ts => ts.Owner)
                .Include(ts => ts.Tags).ThenInclude(t => t.Tag)
                .Include(ts => ts.TestPlanSuites)
                .Include(ts => ts.TestCases)
                    .ThenInclude(tc => tc.TestExecutions)
                        .ThenInclude(te => te.Status)
                .OrderBy(ts => ts.Name)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
