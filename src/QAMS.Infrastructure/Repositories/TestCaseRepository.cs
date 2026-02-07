// src/QAMS.Infrastructure/Repositories/TestCaseRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio específico para TestCase.
    /// Incluye consultas con pasos y prioridad del catálogo.
    /// </summary>
    public class TestCaseRepository : GenericRepository<TestCase>, ITestCaseRepository
    {
        public TestCaseRepository(QamsDbContext context) : base(context) { }

        /// <summary>
        /// Obtiene un caso de prueba con todos sus pasos ordenados
        /// y la prioridad del catálogo cargada.
        /// </summary>
        public async Task<TestCase?> GetWithStepsAsync(Guid testCaseId)
        {
            return await _dbSet
                .Include(tc => tc.TestSteps.OrderBy(s => s.StepOrder))
                .Include(tc => tc.Priority)
                .FirstOrDefaultAsync(tc => tc.Id == testCaseId);
        }

        /// <summary>
        /// Obtiene todos los casos de una suite con pasos y prioridad.
        /// </summary>
        public async Task<IReadOnlyList<TestCase>> GetBySuiteWithStepsAsync(Guid suiteId)
        {
            return await _dbSet
                .Where(tc => tc.TestSuiteId == suiteId)
                .Include(tc => tc.TestSteps.OrderBy(s => s.StepOrder))
                .Include(tc => tc.Priority)
                .OrderBy(tc => tc.Title)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
