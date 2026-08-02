// src/QAMS.Domain/Ports/Repositories/IReviewSessionRepository.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IReviewSessionRepository : IGenericRepository<ReviewSession>
    {
        Task<ReviewSession?> GetWithDetailsAsync(Guid id);
        Task<IReadOnlyList<ReviewSession>> GetByProjectWithDetailsAsync(Guid projectId);
        Task<ReviewFinding?> GetFindingByIdAsync(Guid findingId);
        Task AddFindingAsync(ReviewFinding finding);
        void UpdateFinding(ReviewFinding finding);
        void DeleteFinding(ReviewFinding finding);
    }
}
