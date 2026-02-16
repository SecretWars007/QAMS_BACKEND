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
                .Include(tc => tc.Certifiers).ThenInclude(c => c.User)
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
                .Include(tc => tc.Certifiers).ThenInclude(c => c.User)
                .OrderBy(tc => tc.Title)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los casos de un proyecto con relaciones cargadas.
        /// </summary>
        public async Task<List<TestCase>> GetByProjectIdAsync(Guid projectId)
        {
            return await _dbSet
                .Where(tc => tc.ProjectId == projectId)
                .Include(tc => tc.TestSteps.OrderBy(s => s.StepOrder))
                .Include(tc => tc.Priority)
                .Include(tc => tc.CreatedBy)
                .Include(tc => tc.TestType)
                .Include(tc => tc.Certifiers).ThenInclude(c => c.User)
                .OrderBy(tc => tc.Title)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los casos de un proyecto y una suite específicos.
        /// </summary>
        public async Task<List<TestCase>> GetByProjectAndSuiteAsync(Guid projectId, Guid suiteId)
        {
            return await _dbSet
                .Where(tc => tc.ProjectId == projectId && tc.TestSuiteId == suiteId)
                .Include(tc => tc.TestSteps.OrderBy(s => s.StepOrder))
                .Include(tc => tc.Priority)
                .Include(tc => tc.CreatedBy)
                .Include(tc => tc.TestType)
                .Include(tc => tc.Certifiers).ThenInclude(c => c.User)
                .OrderBy(tc => tc.Title)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
