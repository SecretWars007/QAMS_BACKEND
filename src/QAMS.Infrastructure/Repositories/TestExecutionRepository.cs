// src/QAMS.Infrastructure/Repositories/TestExecutionRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio específico para TestExecution.
    /// Proporciona consultas complejas con eager loading profundo.
    /// </summary>
    public class TestExecutionRepository(QamsDbContext context)
        : GenericRepository<TestExecution>(context), ITestExecutionRepository
    {

        /// <summary>
        /// Obtiene una ejecución completa con resultados de pasos,
        /// evidencias, tester, caso de prueba y estado del catálogo.
        /// </summary>
        public Task<TestExecution?> GetFullExecutionAsync(Guid executionId)
        {
            return _dbSet
                .Include(te => te.TestCase)
                .Include(te => te.TestPlan)
                .Include(te => te.Tester)
                .Include(te => te.Status)
                .Include(te => te.StepResults)
                    .ThenInclude(sr => sr.TestStep)
                .Include(te => te.StepResults)
                    .ThenInclude(sr => sr.Status)
                .Include(te => te.StepResults)
                    .ThenInclude(sr => sr.Evidences)
                        .ThenInclude(ev => ev.FileType)
                .Include(te => te.StepResults)
                    .ThenInclude(sr => sr.Observations)
                        .ThenInclude(ob => ob.CreatedBy)
                .Include(te => te.StepResults)
                    .ThenInclude(sr => sr.Observations)
                        .ThenInclude(ob => ob.RespondedBy)
                .Include(te => te.Evidences)
                    .ThenInclude(ev => ev.FileType)
                .FirstOrDefaultAsync(te => te.Id == executionId);
        }

        /// <summary>
        /// Obtiene todas las ejecuciones de un caso de prueba.
        /// </summary>
        public async Task<IReadOnlyList<TestExecution>> GetByTestCaseAsync(Guid testCaseId)
        {
            return await _dbSet
                .Where(te => te.TestCaseId == testCaseId)
                .Include(te => te.Tester)
                .Include(te => te.Status)
                .OrderByDescending(te => te.ExecutionDate)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todas las ejecuciones de un caso de prueba SIN AsNoTracking,
        /// permitiendo que EF Core rastree y persista cambios (usado para sincronización Kanban).
        /// </summary>
        public Task<List<TestExecution>> GetByTestCaseTrackedAsync(Guid testCaseId)
        {
            return _dbSet
                .Where(te => te.TestCaseId == testCaseId)
                .Include(te => te.Status)
                .OrderByDescending(te => te.ExecutionDate)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todas las ejecuciones asignadas a un tester.
        /// </summary>
        public async Task<IReadOnlyList<TestExecution>> GetByTesterAsync(Guid testerId)
        {
            return await _dbSet
                .Where(te => te.TesterId == testerId)
                .Include(te => te.TestCase)
                .Include(te => te.Status)
                .OrderByDescending(te => te.ExecutionDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<TestExecution>> GetByProjectAsync(Guid projectId)
        {
            return await _dbSet
                .Where(te => te.TestCase!.ProjectId == projectId)
                .Include(te => te.TestCase)
                .Include(te => te.Tester)
                .Include(te => te.Status)
                .Include(te => te.StepResults)
                    .ThenInclude(sr => sr.TestStep)
                .Include(te => te.StepResults)
                    .ThenInclude(sr => sr.Status)
                .Include(te => te.StepResults)
                    .ThenInclude(sr => sr.Evidences)
                .Include(te => te.Evidences)
                .OrderByDescending(te => te.ExecutionDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Dictionary<int, int>> GetStatusCountsByProjectAsync(Guid projectId)
        {
            // Navegar: TestExecution -> TestCase -> TestSuite -> Project
            return _dbSet
                .Where(te => te.TestCase!.TestSuite!.ProjectId == projectId)
                .GroupBy(te => te.StatusId)
                .Select(g => new { StatusId = g.Key, Count = g.Count() })
                .AsNoTracking()
                .ToDictionaryAsync(x => x.StatusId, x => x.Count);
        }

        /// <summary>
        /// Cuenta ejecuciones agrupadas por StatusId para un tester.
        /// </summary>
        public Task<Dictionary<int, int>> GetStatusCountsByUserAsync(Guid userId)
        {
            return _dbSet
                .Where(te => te.TesterId == userId)
                .GroupBy(te => te.StatusId)
                .Select(g => new { StatusId = g.Key, Count = g.Count() })
                .AsNoTracking()
                .ToDictionaryAsync(x => x.StatusId, x => x.Count);
        }

        public async Task<IReadOnlyList<TestExecution>> GetFilteredExecutionsAsync(Guid? testCaseId, Guid? projectId, Guid? testSuiteId, Guid? testPlanId)
        {
            var query = _dbSet.AsQueryable();

            if (testCaseId.HasValue)
            {
                query = query.Where(te => te.TestCaseId == testCaseId.Value);
            }

            if (projectId.HasValue)
            {
                query = query.Where(te => te.TestCase!.ProjectId == projectId.Value);
            }

            if (testSuiteId.HasValue)
            {
                query = query.Where(te => te.TestCase!.TestSuiteId == testSuiteId.Value);
            }

            if (testPlanId.HasValue)
            {
                query = query.Where(te => te.TestPlanId == testPlanId.Value);
            }

            return await query
                .Include(te => te.TestCase)
                .Include(te => te.TestPlan)
                .Include(te => te.Tester)
                .Include(te => te.Status)
                .OrderByDescending(te => te.ExecutionDate)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
