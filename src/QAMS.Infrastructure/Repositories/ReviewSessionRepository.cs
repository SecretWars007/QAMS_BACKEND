// src/QAMS.Infrastructure/Repositories/ReviewSessionRepository.cs
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
    public class ReviewSessionRepository(QamsDbContext context)
        : GenericRepository<ReviewSession>(context), IReviewSessionRepository
    {
        public async Task<ReviewSession?> GetWithDetailsAsync(Guid id)
        {
            return await _dbSet
                .Include(s => s.Project)
                .Include(s => s.ReviewType)
                .Include(s => s.Status)
                .Include(s => s.Moderator)
                .Include(s => s.Author)
                .Include(s => s.CreatedBy)
                .Include(s => s.Participants)
                    .ThenInclude(p => p.User)
                .Include(s => s.Findings)
                    .ThenInclude(f => f.FindingType)
                .Include(s => s.Findings)
                    .ThenInclude(f => f.Severity)
                .Include(s => s.Findings)
                    .ThenInclude(f => f.FindingStatus)
                .Include(s => s.Findings)
                    .ThenInclude(f => f.AssignedTo)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IReadOnlyList<ReviewSession>> GetByProjectWithDetailsAsync(Guid projectId)
        {
            return await _dbSet
                .Where(s => s.ProjectId == projectId)
                .Include(s => s.ReviewType)
                .Include(s => s.Status)
                .Include(s => s.Moderator)
                .Include(s => s.Author)
                .Include(s => s.CreatedBy)
                .OrderByDescending(s => s.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ReviewFinding?> GetFindingByIdAsync(Guid findingId)
        {
            return await _context.ReviewFindings
                .Include(f => f.FindingType)
                .Include(f => f.Severity)
                .Include(f => f.FindingStatus)
                .Include(f => f.AssignedTo)
                .FirstOrDefaultAsync(f => f.Id == findingId);
        }

        public async Task AddFindingAsync(ReviewFinding finding)
        {
            await _context.ReviewFindings.AddAsync(finding);
        }

        public void UpdateFinding(ReviewFinding finding)
        {
            _context.ReviewFindings.Update(finding);
        }

        public void DeleteFinding(ReviewFinding finding)
        {
            _context.ReviewFindings.Remove(finding);
        }
    }
}
