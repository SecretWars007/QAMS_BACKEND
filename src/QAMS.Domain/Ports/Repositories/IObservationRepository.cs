// src/QAMS.Domain/Ports/Repositories/IObservationRepository.cs
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IObservationRepository : IGenericRepository<ExecutionStepObservation>
    {
        Task<IReadOnlyList<ExecutionStepObservation>> GetByProjectAsync(List<Guid> executionIds);
    }
}
