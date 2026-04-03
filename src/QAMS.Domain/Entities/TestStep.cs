// src/QAMS.Domain/Entities/TestStep.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    /// <summary>Paso secuencial dentro de un TestCase.</summary>
    public class TestStep : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid TestCaseId { get; set; }
        public TestCase? TestCase { get; set; }
        public int StepOrder { get; set; }
        public string Action { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;

        public ICollection<ExecutionStepResult> StepResults { get; set; } = [];

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
