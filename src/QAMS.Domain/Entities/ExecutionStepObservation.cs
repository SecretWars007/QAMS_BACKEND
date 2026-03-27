// src/QAMS.Domain/Entities/ExecutionStepObservation.cs
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Entidad para registrar observaciones y respuestas en un paso de ejecución.
    /// </summary>
    public class ExecutionStepObservation
    {
        public Guid Id { get; set; }
        public Guid ExecutionStepResultId { get; set; }
        public ExecutionStepResult ExecutionStepResult { get; set; } = null!;

        public string Observation { get; set; } = string.Empty;
        public string? Response { get; set; }

        public int? FileTypeId { get; set; }
        public EvidenceType? FileType { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public long? FileSize { get; set; }
        public string? ContentType { get; set; }

        // Auditoría
        public Guid CreatedByUserId { get; set; }
        public User CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid? RespondedByUserId { get; set; }
        public User? RespondedBy { get; set; }
        public DateTime? RespondedAt { get; set; }

        public virtual ICollection<ExecutionStepObservationResponse> Responses { get; set; } = [];
    }
}
