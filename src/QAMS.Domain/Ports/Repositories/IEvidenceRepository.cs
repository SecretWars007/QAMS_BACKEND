// src/QAMS.Domain/Ports/Repositories/IEvidenceRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IEvidenceRepository : IGenericRepository<Evidence>
    {
        Task<IReadOnlyList<Evidence>> GetByExecutionAsync(Guid executionId);
    }
}
