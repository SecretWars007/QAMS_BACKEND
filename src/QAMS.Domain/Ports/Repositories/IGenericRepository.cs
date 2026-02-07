// src/QAMS.Domain/Ports/Repositories/IGenericRepository.cs
using System.Linq.Expressions;

namespace QAMS.Domain.Ports.Repositories
{
    /// <summary>Repositorio genérico. Principio ISP: operaciones base.</summary>
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
