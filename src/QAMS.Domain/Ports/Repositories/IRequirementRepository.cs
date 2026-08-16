// src/QAMS.Domain/Ports/Repositories/IRequirementRepository.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QAMS.Domain.Entities;

namespace QAMS.Domain.Ports.Repositories
{
    public interface IRequirementRepository : IGenericRepository<Requirement>
    {
        Task<List<Requirement>> GetByProjectWithCatalogsAsync(Guid projectId);
    }
}
