// src/QAMS.Application/Interfaces/ICatalogService.cs
using QAMS.Application.DTOs.Catalogs;

namespace QAMS.Application.Interfaces
{
    public interface ICatalogService
    {
        Task<List<CatalogItemDto>> GetActiveByCatalogNameAsync(string catalogName);
        Task<List<CatalogItemDto>> GetAllByCatalogNameAsync(string catalogName);
        Task<CatalogItemDto> CreateAsync(string catalogName, CreateCatalogItemDto dto);
        Task<CatalogItemDto> UpdateAsync(string catalogName, int id, CreateCatalogItemDto dto);
    }
}
