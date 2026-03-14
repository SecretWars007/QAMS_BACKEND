// src/QAMS.Domain/Entities/ProjectDevolution.cs
namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Entidad para registrar el histórico de devoluciones de un proyecto.
    /// </summary>
    public class ProjectDevolution
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public DateTime DevolutionDate { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; } = string.Empty;

        public DateTime? ResponseDate { get; set; }
        public string? ResponseNotes { get; set; }

        public int ObservationsCount { get; set; }

        public Guid CreatedByUserId { get; set; }
        public User CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
