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
    public class TestExecutionRepository : GenericRepository<TestExecution>, ITestExecutionRepository
    {
        public TestExecutionRepository(QamsDbContext context) : base(context) { }

        /// <summary>
        /// Obtiene una ejecución completa con resultados de pasos,
        /// evidencias, tester, caso de prueba y estado del catálogo.
        /// </summary>
        public async Task<TestExecution?> GetFullExecutionAsync(Guid executionId)
        {
            return await _dbSet
                .Include(te => te.TestCase)
                .Include(te => te.Tester)
                .Include(te => te.Status)
                .Include(te => te.StepResults)
                    .ThenInclude(sr => sr.TestStep)
                .Include(te => te.StepResults)
                    .ThenInclude(sr => sr.Status)
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

        /// <summary>
        /// Cuenta ejecuciones agrupadas por StatusId para un proyecto.
        /// Retorna Dictionary con StatusId como clave y conteo como valor.
        /// Usado en el dashboard para gráficos de progreso.
        /// </summary>
        public async Task<Dictionary<int, int>> GetStatusCountsByProjectAsync(Guid projectId)
        {
            // Navegar: TestExecution -> TestCase -> TestSuite -> Project
            return await _dbSet
                .Where(te => te.TestCase.TestSuite.ProjectId == projectId)
                .GroupBy(te => te.StatusId)
                .Select(g => new { StatusId = g.Key, Count = g.Count() })
                .AsNoTracking()
                .ToDictionaryAsync(x => x.StatusId, x => x.Count);
        }
    }
}
