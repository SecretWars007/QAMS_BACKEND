// src/QAMS.Domain/Entities/ReviewSession.cs
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Sesión de revisión estática (ISTQB Cap. 3).
    /// Soporta: Walkthrough, Inspección, Revisión Técnica, Revisión Informal.
    /// </summary>
    public class ReviewSession : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; } = null!;

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        /// <summary>Artefacto bajo revisión (nombre doc, módulo, URL, etc.)</summary>
        public string? ArtifactUnderReview { get; set; }

        /// <summary>Tipo de revisión: Walkthrough, Inspección, Revisión Técnica, Informal</summary>
        public int ReviewTypeId { get; set; }
        public virtual ReviewType? ReviewType { get; set; }

        public int StatusId { get; set; }
        public virtual ReviewStatus? Status { get; set; }

        public DateTime? ScheduledDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        /// <summary>Moderador/Facilitador de la sesión</summary>
        public Guid? ModeratorId { get; set; }
        public virtual User? Moderator { get; set; }

        /// <summary>Autor del artefacto bajo revisión</summary>
        public Guid? AuthorId { get; set; }
        public virtual User? Author { get; set; }

        /// <summary>Criterios de entrada para la sesión</summary>
        public string? EntryCriteria { get; set; }

        /// <summary>Criterios de salida de la sesión</summary>
        public string? ExitCriteria { get; set; }

        public string? Conclusions { get; set; }

        // ISoftDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }
        public virtual User? DeletedBy { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public virtual User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public virtual User? UpdatedBy { get; set; }

        public virtual ICollection<ReviewFinding> Findings { get; set; } = [];
        public virtual ICollection<ReviewParticipant> Participants { get; set; } = [];
    }
}
