// src/QAMS.Domain/Entities/ProjectTester.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    public class ProjectTester : IAuditable, ISoftDelete
    {
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

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
