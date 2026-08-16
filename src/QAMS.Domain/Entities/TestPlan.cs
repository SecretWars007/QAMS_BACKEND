// src/QAMS.Domain/Entities/TestPlan.cs
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    public class TestPlan : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Objectives { get; set; }

        // --- ISTQB Fields ---
        public string? Scope { get; set; }
        public string? OutOfScope { get; set; }

        public int? TestStrategyId { get; set; }
        public TestStrategy? TestStrategy { get; set; }

        public int? TestPlanTypeId { get; set; }
        public TestPlanType? TestPlanType { get; set; }

        public int? TestLevelId { get; set; }
        public TestLevel? TestLevel { get; set; }

        public Guid? TestManagerId { get; set; }
        public User? TestManager { get; set; }

        public int? RiskLevelId { get; set; }
        public RiskLevel? RiskLevel { get; set; }

        public int? TestEnvironmentId { get; set; }
        public TestPlanEnvironment? TestEnvironment { get; set; }

        public string? TestSchedule { get; set; }
        public decimal EstimatedEffortHours { get; set; } = 0m;
        // --------------------

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }
        public TestPlanStatus? Status { get; set; }

        public bool IsClosed { get; set; } = false;
        
        public ICollection<TestPlanApprovalLog> ApprovalLogs { get; set; } = [];

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }
        public User? DeletedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedBy { get; set; }

        public ICollection<TestPlanSuite> TestPlanSuites { get; set; } = [];
        public ICollection<TestPlanCriteria> Criteria { get; set; } = [];
        public ICollection<TestPlanMilestone> Milestones { get; set; } = [];
        public ICollection<TestPlanRisk> Risks { get; set; } = [];
    }
}
