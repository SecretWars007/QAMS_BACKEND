// src/QAMS.Infrastructure/Repositories/ObservationRepository.cs
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    public class ObservationRepository(QamsDbContext context)
        : GenericRepository<ExecutionStepObservation>(context), IObservationRepository
    {
        public async Task<IReadOnlyList<ExecutionStepObservation>> GetByProjectAsync(List<Guid> executionIds)
        {
            return await _dbSet
                .Include(o => o.FileType)
                .Include(o => o.CreatedBy)
                .Include(o => o.RespondedBy)
                .Include(o => o.ExecutionStepResult)
                    .ThenInclude(r => r!.TestStep)
                .Include(o => o.ExecutionStepResult)
                    .ThenInclude(r => r!.TestExecution)
                        .ThenInclude(e => e!.TestCase)
                .Where(o => o.ExecutionStepResult != null && executionIds.Contains(o.ExecutionStepResult.TestExecutionId))
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
        }

        public override async Task<ExecutionStepObservation?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .Include(o => o.FileType)
                .Include(o => o.CreatedBy)
                .Include(o => o.RespondedBy)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
