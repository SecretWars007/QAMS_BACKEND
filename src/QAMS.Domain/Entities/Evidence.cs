// src/QAMS.Domain/Entities/Evidence.cs
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    public class Evidence : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid TestExecutionId { get; set; }
        public TestExecution? TestExecution { get; set; }

        public Guid? ExecutionStepResultId { get; set; }
        public ExecutionStepResult? ExecutionStepResult { get; set; }

        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string? ContentType { get; set; }
        public long FileSize { get; set; }
        public string? Description { get; set; }

        public int FileTypeId { get; set; }
        public EvidenceType? FileType { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

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
