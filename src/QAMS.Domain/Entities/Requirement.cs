// src/QAMS.Domain/Entities/Requirement.cs
using System;
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    /// <summary>Requisito funcional asociado a un proyecto.</summary>
    public class Requirement : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? AcceptanceCriteria { get; set; }
        // Tipo de requisito
        public int RequirementTypeId { get; set; }
        public virtual QAMS.Domain.Entities.Catalogs.RequirementType? RequirementType { get; set; }

        // Prioridad
        public int RequirementPriorityId { get; set; }
        public virtual QAMS.Domain.Entities.Catalogs.RequirementPriority? RequirementPriority { get; set; }

        // Complejidad
        public int RequirementComplexityId { get; set; }
        public virtual QAMS.Domain.Entities.Catalogs.RequirementComplexity? RequirementComplexity { get; set; }

        // Estado del requisito
        public int RequirementStatusId { get; set; }
        public virtual QAMS.Domain.Entities.Catalogs.RequirementStatus? RequirementStatus { get; set; }

        public string? Source { get; set; }

        // ISoftDelete implementation
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }

        // IAuditable implementation
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public virtual User? CreatedBy { get; set; }
        public virtual User? UpdatedBy { get; set; }
        public virtual User? DeletedBy { get; set; }

        /// <summary>Casos de prueba vinculados a este requisito (M:N) — trazabilidad ISTQB</summary>
        public virtual ICollection<RequirementTestCase> RequirementTestCases { get; set; } = [];
    }
}
