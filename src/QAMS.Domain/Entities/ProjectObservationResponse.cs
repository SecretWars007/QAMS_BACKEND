// src/QAMS.Domain/Entities/ProjectObservationResponse.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    public class ProjectObservationResponse : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid ProjectObservationId { get; set; }
        public ProjectObservation? ProjectObservation { get; set; }
        public string Response { get; set; } = string.Empty;

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
    }
}
