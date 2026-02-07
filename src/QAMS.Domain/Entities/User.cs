// src/QAMS.Domain/Entities/User.cs
namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Entidad raíz de usuario. 4FN: roles en tabla puente.
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<TestExecution> TestExecutions { get; set; } = new List<TestExecution>();
        public ICollection<KanbanTask> AssignedTasks { get; set; } = new List<KanbanTask>();
    }
}
