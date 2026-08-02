// src/QAMS.Domain/Entities/ReviewFinding.cs
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Hallazgo encontrado durante una revisión estática (ISTQB Cap. 3).
    /// Un finding puede ser un defecto, mejora, pregunta o comentario.
    /// </summary>
    public class ReviewFinding : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ReviewSessionId { get; set; }
        public virtual ReviewSession ReviewSession { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        /// <summary>Ubicación del hallazgo (línea, sección, página)</summary>
        public string? Location { get; set; }

        /// <summary>Tipo: Defecto, Mejora, Pregunta, Comentario</summary>
        public int FindingTypeId { get; set; }
        public virtual FindingType? FindingType { get; set; }

        /// <summary>Severidad: Bloqueante, Mayor, Menor, Trivial</summary>
        public int SeverityId { get; set; }
        public virtual FindingSeverity? Severity { get; set; }

        /// <summary>Estado: Abierto, Aceptado, Rechazado, Resuelto</summary>
        public int FindingStatusId { get; set; }
        public virtual FindingStatus? FindingStatus { get; set; }

        public Guid? AssignedToId { get; set; }
        public virtual User? AssignedTo { get; set; }

        public string? Resolution { get; set; }
        public DateTime? ResolvedAt { get; set; }

        // ISoftDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public virtual User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
    }
}
