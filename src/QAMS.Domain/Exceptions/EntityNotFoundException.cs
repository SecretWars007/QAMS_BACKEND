// src/QAMS.Domain/Exceptions/EntityNotFoundException.cs
namespace QAMS.Domain.Exceptions
{
    /// <summary>Excepción cuando una entidad no existe.</summary>
    public class EntityNotFoundException(string entityName, object entityId) : DomainException($"'{entityName}' con ID '{entityId}' no fue encontrada.")
    {
        public string EntityName { get; } = entityName;
        public object EntityId { get; } = entityId;
    }
}
