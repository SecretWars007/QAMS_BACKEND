using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    public class ExploratoryFinding : IAuditable
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public ExploratorySession? Session { get; set; }

        public int TypeId { get; set; } // 1: Bug, 2: Note, 3: Question
        public string Description { get; set; } = string.Empty;

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedBy { get; set; }
    }
}
