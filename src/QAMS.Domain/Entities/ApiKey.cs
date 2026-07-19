// src/QAMS.Domain/Entities/ApiKey.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Llave de API para integración de automatización y CI/CD con QAMS.
    /// </summary>
    public class ApiKey : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }

        /// <summary>Proyecto al que pertenece esta API Key.</summary>
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }

        /// <summary>Nombre descriptivo de la API Key (e.g., "Jenkins Pipeline", "Selenium Runner").</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Hash BCrypt de la llave generada. Nunca se almacena el valor plano.</summary>
        public string KeyHash { get; set; } = string.Empty;

        /// <summary>Prefijo visible de la llave (primeros 8 caracteres) para identificación.</summary>
        public string KeyPrefix { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        /// <summary>Fecha de expiración opcional. Si es null, no expira.</summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary>Última vez que se utilizó esta API Key.</summary>
        public DateTime? LastUsedAt { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedBy { get; set; }

        // ISoftDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }
        public User? DeletedBy { get; set; }
    }
}
