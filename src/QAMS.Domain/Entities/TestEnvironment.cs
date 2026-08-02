// src/QAMS.Domain/Entities/TestEnvironment.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Entorno de prueba formal (ISTQB Cap. 5.4 — Gestión del entorno de pruebas).
    /// Registra la configuración de hardware, software y datos para reproducir pruebas.
    /// </summary>
    public class TestEnvironment : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; } = null!;

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        /// <summary>URL base del sistema en este entorno (ej: https://staging.app.com)</summary>
        public string? BaseUrl { get; set; }

        /// <summary>Sistema Operativo (ej: Windows 11, Ubuntu 22.04)</summary>
        public string? OperatingSystem { get; set; }

        /// <summary>Navegador y versión (ej: Chrome 120, Firefox 121)</summary>
        public string? Browser { get; set; }

        /// <summary>Tipo de entorno: Development, Staging, QA, UAT, Production</summary>
        public string EnvironmentType { get; set; } = "QA";

        /// <summary>Versión del software desplegado en este entorno</summary>
        public string? SoftwareVersion { get; set; }

        /// <summary>Configuración adicional (ej: API endpoints, feature flags, BD)</summary>
        public string? AdditionalConfig { get; set; }

        public bool IsActive { get; set; } = true;

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

        // Planes de prueba que usan este entorno
        public virtual ICollection<TestPlan> TestPlans { get; set; } = [];
    }
}
