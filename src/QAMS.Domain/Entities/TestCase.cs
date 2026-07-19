// src/QAMS.Domain/Entities/TestCase.cs
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>Caso de prueba con pasos y resultados esperados.</summary>
    public class TestCase : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        public Guid TestSuiteId { get; set; }
        public TestSuite? TestSuite { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Preconditions { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;
        public int PriorityId { get; set; }
        public TestCasePriority? Priority { get; set; }
        public bool IsActive { get; set; } = true;
        public int VersionNumber { get; set; } = 1;
        public bool IsLatestVersion { get; set; } = true;

        public decimal EstimatedTimeHours { get; set; } = 0;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TestTypeId { get; set; }
        public TestType? TestType { get; set; }

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

        public ICollection<TestStep> TestSteps { get; set; } = [];
        public ICollection<TestExecution> TestExecutions { get; set; } = [];
        public ICollection<TestCaseCertifier> Certifiers { get; set; } = [];

        /// <summary>Requisitos cubiertos por este caso de prueba (M:N) — trazabilidad ISTQB</summary>
        public ICollection<RequirementTestCase> RequirementTestCases { get; set; } = [];

        /// <summary>Defectos detectados al ejecutar este caso de prueba</summary>
        public ICollection<Defect> Defects { get; set; } = [];
    }
}
