// src/QAMS.Application/Interfaces/Repositories/IApiKeyRepository.cs
using QAMS.Domain.Entities;
using QAMS.Domain.Ports.Repositories;

namespace QAMS.Application.Interfaces.Repositories
{
    public interface IApiKeyRepository : IGenericRepository<ApiKey>
    {
        Task<List<ApiKey>> GetByProjectAsync(Guid projectId);
        Task<ApiKey?> GetByPrefixAsync(string prefix);
    }
}
