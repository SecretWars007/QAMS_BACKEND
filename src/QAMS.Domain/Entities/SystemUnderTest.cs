// src/QAMS.Domain/Entities/SystemUnderTest.cs
using System;
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Sistema Bajo Prueba (SUT). Representa la aplicación o sistema evaluado en un proyecto QA.
    /// </summary>
    public class SystemUnderTest : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public virtual ICollection<Project> Projects { get; set; } = [];

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Version { get; set; }
        public string? Environment { get; set; }

        public int PlatformTypeId { get; set; } = 1;
        public virtual PlatformType PlatformType { get; set; } = null!;

        public string? BaseUrl { get; set; }
        public string? ExecutablePath { get; set; }
        public string? ProcessName { get; set; }
        public bool IsActive { get; set; } = true;

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
    }
}
