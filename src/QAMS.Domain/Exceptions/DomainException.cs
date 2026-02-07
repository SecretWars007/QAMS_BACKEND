// src/QAMS.Domain/Exceptions/DomainException.cs
namespace QAMS.Domain.Exceptions
{
    /// <summary>Excepción para violaciones de reglas de negocio.</summary>
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
        public DomainException(string message, Exception inner) : base(message, inner) { }
    }
}
