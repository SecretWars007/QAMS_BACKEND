// src/QAMS.Infrastructure/Repositories/DefectRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    public class DefectRepository(QamsDbContext context)
        : GenericRepository<Defect>(context), IDefectRepository
    {
        public async Task<IReadOnlyList<Defect>> GetByProjectAsync(Guid projectId)
            => await _dbSet
                .Include(d => d.DefectPriority)
                .Include(d => d.DefectStatus)
                .Include(d => d.ReportedBy)
                .Include(d => d.AssignedTo)
                .Include(d => d.TestCase)
                .Where(d => d.ProjectId == projectId)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IReadOnlyList<Defect>> GetByTestCaseAsync(Guid testCaseId)
            => await _dbSet
                .Include(d => d.DefectPriority)
                .Include(d => d.DefectStatus)
                .Include(d => d.ReportedBy)
                .Where(d => d.TestCaseId == testCaseId)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IReadOnlyList<Defect>> GetByTestExecutionAsync(Guid testExecutionId)
            => await _dbSet
                .Include(d => d.DefectPriority)
                .Include(d => d.DefectStatus)
                .Where(d => d.TestExecutionId == testExecutionId)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IReadOnlyList<Defect>> GetAssignedToUserAsync(Guid userId)
            => await _dbSet
                .Include(d => d.DefectPriority)
                .Include(d => d.DefectStatus)
                .Include(d => d.Project)
                .Where(d => d.AssignedToUserId == userId)
                .AsNoTracking()
                .ToListAsync();

        public async Task<int> CountOpenDefectsByProjectAsync(Guid projectId)
            => await _dbSet
                .Where(d => d.ProjectId == projectId && d.DefectStatus != null && d.DefectStatus.Code == "OPEN")
                .CountAsync();
    }
}
