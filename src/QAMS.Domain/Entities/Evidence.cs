// src/QAMS.Domain/Entities/Evidence.cs
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Referencia a archivo de evidencia (ruta, no BLOB).
    /// FileTypeId referencia a catálogo evidence_types (no enum).
    /// </summary>
    public class Evidence
    {
        public Guid Id { get; set; }
        public Guid TestExecutionId { get; set; }
        public TestExecution TestExecution { get; set; } = null!;
        public int FileTypeId { get; set; }
        public EvidenceType FileType { get; set; } = null!;
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
