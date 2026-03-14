// src/QAMS.Domain/Entities/ProjectObservationResponse.cs
namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Respuestas a observaciones de proyecto.
    /// </summary>
    public class ProjectObservationResponse
    {
        public Guid Id { get; set; }
        public Guid ProjectObservationId { get; set; }
        public ProjectObservation ProjectObservation { get; set; } = null!;

        public string Response { get; set; } = string.Empty;

        // Auditoría
        public Guid CreatedByUserId { get; set; }
        public User CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
