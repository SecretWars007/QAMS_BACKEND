// src/QAMS.Domain/Entities/ProjectDevolution.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    public class ProjectDevolution : IAuditable, ISoftDelete
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int ObservationsCount { get; set; }
        public DateTime DevolutionDate { get; set; } = DateTime.UtcNow;

        public string? ResponseNotes { get; set; }
        public DateTime? ResponseDate { get; set; }

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
