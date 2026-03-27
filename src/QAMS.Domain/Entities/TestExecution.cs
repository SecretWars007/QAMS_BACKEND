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
        public ExecutionStatus? Status { get; set; }
        public string? Notes { get; set; }
        public decimal? ActualTimeHours { get; set; }
        public DateTime ExecutionDate { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        public ICollection<ExecutionStepResult> StepResults { get; set; } = [];
        public ICollection<Evidence> Evidences { get; set; } = [];

        public bool IsSuccessful()
        {
            var isTrulyPassed = (StatusId == 3) || (Status?.Code == "PASSED" || Status?.Name == "Aprobado");
            return isTrulyPassed || IsInReview();
        }

        public bool IsInReview()
        {
            var isEnProgreso = (StatusId == 2) || (Status?.Code == "IN_PROGRESS" || Status?.Name == "En Progreso");
            var hasResultsForAllSteps = StepResults != null && StepResults.Count > 0 && StepResults.All(sr => !string.IsNullOrEmpty(sr.ActualResult));
            return isEnProgreso && hasResultsForAllSteps;
        }

        public bool IsFailed()
        {
            return StatusId == 4 || Status?.Code == "FAILED";
        }
    }
}
