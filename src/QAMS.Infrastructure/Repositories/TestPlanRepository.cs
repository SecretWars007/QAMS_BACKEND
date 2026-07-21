using Microsoft.EntityFrameworkCore;
using QAMS.Application.Interfaces.Repositories;
using QAMS.Domain.Entities;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    public class TestPlanRepository : GenericRepository<TestPlan>, ITestPlanRepository
    {
        public TestPlanRepository(QamsDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<TestPlan>> GetByProjectAsync(Guid projectId)
        {
            return await _dbSet
                .Where(tp => tp.ProjectId == projectId)
                .Include(tp => tp.Project)
                .Include(tp => tp.Status)
                .Include(tp => tp.Criteria)
                .Include(tp => tp.TestPlanSuites)
                    .ThenInclude(tps => tps.TestSuite)
                .Include(tp => tp.CreatedBy)
                .OrderByDescending(tp => tp.StartDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TestPlan?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _dbSet
                .Include(tp => tp.Project)
                .Include(tp => tp.Status)
                .Include(tp => tp.Criteria)
                .Include(tp => tp.TestPlanSuites)
                    .ThenInclude(tps => tps.TestSuite)
                .Include(tp => tp.CreatedBy)
                .FirstOrDefaultAsync(tp => tp.Id == id);
        }
    }
}
