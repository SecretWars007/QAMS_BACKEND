// src/QAMS.Domain/Entities/TestPlanApprovalLog.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    public class TestPlanApprovalLog
    {
        public Guid Id { get; set; }
        public Guid TestPlanId { get; set; }
        public TestPlan? TestPlan { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public string SignatureHash { get; set; } = string.Empty;
        
        public string Verdict { get; set; } = string.Empty; // "Go", "No-Go", "Conditional"
        public string? Comments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
