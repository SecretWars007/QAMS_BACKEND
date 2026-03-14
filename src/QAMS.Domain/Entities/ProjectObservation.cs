// src/QAMS.Domain/Entities/ProjectObservation.cs
namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Observaciones generales a nivel de proyecto (no ligadas a una ejecución específica).
    /// </summary>
    public class ProjectObservation
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public string Observation { get; set; } = string.Empty;

        // Auditoría
        public Guid CreatedByUserId { get; set; }
        public User CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Respuestas en modo hilo
        public virtual ICollection<ProjectObservationResponse> Responses { get; set; } = new List<ProjectObservationResponse>();
    }
}
