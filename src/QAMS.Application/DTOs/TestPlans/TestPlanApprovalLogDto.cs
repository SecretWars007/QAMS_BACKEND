using System;

namespace QAMS.Application.DTOs.TestPlans
{
    public class TestPlanApprovalLogDto
    {
        public Guid Id { get; set; }
        public Guid TestPlanId { get; set; }
        public Guid UserId { get; set; }
        
        // Información del firmante
        public string UserFullName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        public DateTime SignatureDate { get; set; }
        public string SignatureHash { get; set; } = string.Empty;
        public string Verdict { get; set; } = string.Empty;
        public string? Comments { get; set; }
    }
}
