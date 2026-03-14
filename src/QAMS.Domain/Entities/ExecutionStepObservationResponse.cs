// src/QAMS.Domain/Entities/ExecutionStepObservationResponse.cs
namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Respuestas a observaciones de pasos de ejecución.
    /// </summary>
    public class ExecutionStepObservationResponse
    {
        public Guid Id { get; set; }
        public Guid ExecutionStepObservationId { get; set; }
        public ExecutionStepObservation ExecutionStepObservation { get; set; } = null!;

        public string Response { get; set; } = string.Empty;

        // Auditoría
        public Guid CreatedByUserId { get; set; }
        public User CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
