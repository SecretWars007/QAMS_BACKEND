// src/QAMS.Domain/Entities/ExecutionStepResult.cs
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Resultado de un paso en una ejecución.
    /// StatusId referencia a catálogo step_result_statuses (no enum).
    /// </summary>
    public class ExecutionStepResult
    {
        public Guid Id { get; set; }
        public Guid TestExecutionId { get; set; }
        public TestExecution TestExecution { get; set; } = null!;
        public Guid TestStepId { get; set; }
        public TestStep TestStep { get; set; } = null!;
        public int StatusId { get; set; }
        public StepResultStatus Status { get; set; } = null!;
        public string? ActualResult { get; set; }
        public string? Notes { get; set; }
        public DateTime EvaluatedAt { get; set; } = DateTime.UtcNow;
    }
}
