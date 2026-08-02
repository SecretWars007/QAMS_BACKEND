// src/QAMS.Domain/Exceptions/DuplicateEntityException.cs
namespace QAMS.Domain.Exceptions
{
    /// <summary>Excepción lanzada cuando se intenta crear una entidad con datos que ya existen (conflicto de unicidad).</summary>
    public class DuplicateEntityException : DomainException
    {
        public DuplicateEntityException(string message) : base(message) { }
    }
}
