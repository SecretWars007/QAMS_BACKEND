// src/QAMS.Domain/Entities/TestSuite.cs
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>Conjunto de casos de prueba.</summary>
    public class TestSuite : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }

        public int StatusId { get; set; }
        public TestSuiteStatus? Status { get; set; }

        // ISTQB Fields
        public int? ExecutionPriorityId { get; set; }
        public TestCasePriority? ExecutionPriority { get; set; }

        public int? TestLevelId { get; set; }
        public TestLevel? TestLevel { get; set; }

        public int? TestTypeId { get; set; }
        public TestType? TestType { get; set; }

        public int? AutomationStatusId { get; set; }
        public SuiteAutomationStatus? AutomationStatus { get; set; }

        public int? TestDesignTechniqueId { get; set; }
        public TestDesignTechnique? TestDesignTechnique { get; set; }

        public int? ReviewStatusId { get; set; }
        public ReviewStatus? ReviewStatus { get; set; }

        public int? TestEnvironmentId { get; set; }
        public TestPlanEnvironment? TestEnvironment { get; set; }

        public Guid? OwnerUserId { get; set; }
        public User? Owner { get; set; }

        public string? Preconditions { get; set; }
        public string? CoverageObjective { get; set; }
        public decimal EstimatedDurationHours { get; set; } = 0m;

        // ISoftDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public ICollection<TestCase> TestCases { get; set; } = [];
        public ICollection<TestPlanSuite> TestPlanSuites { get; set; } = [];
        public ICollection<TestSuiteTag> Tags { get; set; } = [];
    }
}
