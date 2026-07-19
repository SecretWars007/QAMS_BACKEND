// src/QAMS.Application/DTOs/ApiKeys/ApiKeyDto.cs
namespace QAMS.Application.DTOs.ApiKeys
{
    public class ApiKeyDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string KeyPrefix { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? LastUsedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedByUserName { get; set; }
    }

    public class CreateApiKeyDto
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? ExpiresAt { get; set; }
    }

    /// <summary>
    /// Devuelto únicamente en la creación — incluye el valor plano (solo se muestra una vez).
    /// </summary>
    public class ApiKeyCreatedDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string KeyPrefix { get; set; } = string.Empty;

        /// <summary>Valor plano de la API Key — solo visible en el momento de creación.</summary>
        public string PlainKey { get; set; } = string.Empty;
        public DateTime? ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
