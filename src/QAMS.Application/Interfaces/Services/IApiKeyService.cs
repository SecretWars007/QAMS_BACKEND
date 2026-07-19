// src/QAMS.Application/Interfaces/Services/IApiKeyService.cs
using QAMS.Application.DTOs.ApiKeys;

namespace QAMS.Application.Interfaces.Services
{
    /// <summary>
    /// Servicio para gestión de API Keys de integración CI/CD.
    /// </summary>
    public interface IApiKeyService
    {
        Task<List<ApiKeyDto>> GetByProjectAsync(Guid projectId);
        Task<ApiKeyCreatedDto> CreateAsync(CreateApiKeyDto dto);
        Task<bool> RevokeAsync(Guid id);
        Task<Guid?> ValidateAsync(string plainKey);
    }
}
