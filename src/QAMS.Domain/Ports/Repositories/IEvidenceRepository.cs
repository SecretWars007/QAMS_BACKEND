// src/QAMS.Domain/Ports/Repositories/IEvidenceRepository.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IEvidenceRepository : IGenericRepository<Evidence>
    {
        Task<IReadOnlyList<Evidence>> GetByExecutionAsync(Guid executionId);
        Task<IReadOnlyList<Evidence>> GetByStepResultsAsync(List<Guid> stepResultIds);
    }
}
