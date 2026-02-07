// src/QAMS.Domain/Entities/TestExecution.cs
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Registro de ejecución de un caso de prueba.
    /// StatusId referencia a catálogo execution_statuses (no enum).
    /// </summary>
    public class TestExecution
    {
        public Guid Id { get; set; }
        public Guid TestCaseId { get; set; }
        public TestCase TestCase { get; set; } = null!;
        public Guid TesterId { get; set; }
        public User Tester { get; set; } = null!;
        public int StatusId { get; set; }
        public ExecutionStatus Status { get; set; } = null!;
        public string? Notes { get; set; }
        public DateTime ExecutionDate { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        public ICollection<ExecutionStepResult> StepResults { get; set; } = new List<ExecutionStepResult>();
        public ICollection<Evidence> Evidences { get; set; } = new List<Evidence>();
    }
}
