// src/QAMS.Domain/Entities/ExecutionStepObservation.cs
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    public class ExecutionStepObservation : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid ExecutionStepResultId { get; set; }
        public ExecutionStepResult? ExecutionStepResult { get; set; }
        
        public string Observation { get; set; } = string.Empty;
        
        // Adjuntos
        public int? FileTypeId { get; set; }
        public EvidenceType? FileType { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public long? FileSize { get; set; }
        public string? ContentType { get; set; }

        // Respuesta integrada (si aplica)
        public string? Response { get; set; }
        public Guid? RespondedByUserId { get; set; }
        public User? RespondedBy { get; set; }
        public DateTime? RespondedAt { get; set; }

        // ISoftDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }
        public User? DeletedBy { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
