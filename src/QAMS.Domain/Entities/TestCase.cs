// src/QAMS.Domain/Entities/TestCase.cs
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Caso de prueba funcional manual.
    /// PriorityId referencia a catálogo test_case_priorities (no enum).
    /// </summary>
    public class TestCase
    {
        public Guid Id { get; set; }
        public Guid TestSuiteId { get; set; }
        public TestSuite TestSuite { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Preconditions { get; set; }
        public string ExpectedResult { get; set; } = string.Empty;
        public int PriorityId { get; set; }
        public TestCasePriority Priority { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<TestStep> TestSteps { get; set; } = new List<TestStep>();
        public ICollection<TestExecution> TestExecutions { get; set; } = new List<TestExecution>();
    }
}
