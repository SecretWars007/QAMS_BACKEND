// src/QAMS.Infrastructure/Repositories/RequirementRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;
using QAMS.Infrastructure.Persistence.Configurations;

namespace QAMS.Infrastructure.Repositories
{
    public class RequirementRepository(QamsDbContext context)
        : GenericRepository<Requirement>(context), IRequirementRepository
    {
        public async Task<List<Requirement>> GetByProjectWithCatalogsAsync(Guid projectId)
        {
            return await _dbSet
                .Include(r => r.RequirementStatus)
                .Include(r => r.RequirementPriority)
                .Include(r => r.RequirementType)
                .Include(r => r.RequirementComplexity)
                .Where(r => r.ProjectId == projectId)
                .OrderBy(r => r.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
