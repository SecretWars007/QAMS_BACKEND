// src/QAMS.Application/Interfaces/IReviewService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QAMS.Application.DTOs.Reviews;

namespace QAMS.Application.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewSessionDto> GetByIdAsync(Guid id);
        Task<List<ReviewSessionDto>> GetByProjectIdAsync(Guid projectId);
        Task<ReviewSessionDto> CreateAsync(CreateReviewSessionDto dto);
        Task<ReviewSessionDto> StartSessionAsync(Guid id);
        Task<ReviewSessionDto> CompleteSessionAsync(Guid id, string conclusions, string exitCriteria);
        Task<ReviewSessionDto> CancelSessionAsync(Guid id);
        Task<ReviewFindingDto> AddFindingAsync(CreateReviewFindingDto dto);
        Task<ReviewFindingDto> UpdateFindingAsync(Guid findingId, UpdateReviewFindingDto dto);
        Task DeleteFindingAsync(Guid findingId);
    }
}
