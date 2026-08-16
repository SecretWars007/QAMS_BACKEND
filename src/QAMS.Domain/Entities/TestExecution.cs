// src/QAMS.Domain/Entities/TestExecution.cs
using QAMS.Domain.Common;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Registro de ejecución de un caso de prueba.
    /// StatusId referencia a catálogo execution_statuses (no enum).
    /// </summary>
    public class TestExecution : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid TestCaseId { get; set; }
        public TestCase? TestCase { get; set; }
        public Guid? TestPlanId { get; set; }
        public TestPlan? TestPlan { get; set; }
        public Guid TesterId { get; set; }
        public User? Tester { get; set; }
        public int StatusId { get; set; }
        public ExecutionStatus? Status { get; set; }
        public string? Notes { get; set; }
        public decimal ActualTimeHours { get; set; } = 0m;
        public DateTime ExecutionDate { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        public int CycleNumber { get; set; }

        public ICollection<ExecutionStepResult> StepResults { get; set; } = [];
        public ICollection<Evidence> Evidences { get; set; } = [];

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
