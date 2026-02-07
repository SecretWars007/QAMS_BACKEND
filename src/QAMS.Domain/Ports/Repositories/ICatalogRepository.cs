// src/QAMS.Domain/Ports/Repositories/ICatalogRepository.cs
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Ports.Repositories
{
    /// <summary>Repositorio genérico para tablas catálogo.</summary>
    public interface ICatalogRepository<T> where T : CatalogBase
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByCodeAsync(string code);
        Task<IReadOnlyList<T>> GetAllActiveAsync();
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task<bool> ExistsByCodeAsync(string code);
    }
}
