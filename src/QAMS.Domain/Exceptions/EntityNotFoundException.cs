// src/QAMS.Domain/Exceptions/EntityNotFoundException.cs
namespace QAMS.Domain.Exceptions
{
    /// <summary>Excepción cuando una entidad no existe.</summary>
    public class EntityNotFoundException : DomainException
    {
        public string EntityName { get; }
        public object EntityId { get; }

        public EntityNotFoundException(string entityName, object entityId)
            : base($"'{entityName}' con ID '{entityId}' no fue encontrada.")
        {
            EntityName = entityName;
            EntityId = entityId;
        }
    }
}
