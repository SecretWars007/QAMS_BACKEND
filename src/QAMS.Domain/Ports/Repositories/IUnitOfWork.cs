// src/QAMS.Domain/Ports/Repositories/IUnitOfWork.cs
namespace QAMS.Domain.Ports.Repositories
{
    /// <summary>Garantiza transacciones atómicas.</summary>
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
