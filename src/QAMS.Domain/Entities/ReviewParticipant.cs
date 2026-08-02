// src/QAMS.Domain/Entities/ReviewParticipant.cs
namespace QAMS.Domain.Entities
{
    /// <summary>Participante en una sesión de revisión estática.</summary>
    public class ReviewParticipant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ReviewSessionId { get; set; }
        public virtual ReviewSession ReviewSession { get; set; } = null!;

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;

        /// <summary>Rol en la sesión: Revisor, Moderador, Autor, Secretario</summary>
        public string Role { get; set; } = "Revisor";

        public bool Attended { get; set; } = false;
        public DateTime InvitedAt { get; set; } = DateTime.UtcNow;
    }
}
