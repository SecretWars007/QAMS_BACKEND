// src/QAMS.Domain/Entities/TestStep.cs
namespace QAMS.Domain.Entities
{
    /// <summary>Paso secuencial dentro de un TestCase.</summary>
    public class TestStep
    {
        public Guid Id { get; set; }
        public Guid TestCaseId { get; set; }
        public TestCase TestCase { get; set; } = null!;
        public int StepOrder { get; set; }
        public string Action { get; set; } = string.Empty;
        public string ExpectedResult { get; set; } = string.Empty;

        public ICollection<ExecutionStepResult> StepResults { get; set; } = new List<ExecutionStepResult>();
    }
}
