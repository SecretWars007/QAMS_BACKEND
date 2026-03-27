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
        public bool LogicallyDeleted { get; set; } = false;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiryTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = [];
        public ICollection<TestExecution> TestExecutions { get; set; } = [];
        public ICollection<KanbanTask> AssignedTasks { get; set; } = [];
        
        // Proyectos a los que está asignado el usuario
        public ICollection<ProjectTester> ProjectAssignments { get; set; } = [];

        // Proyectos creados por el usuario
        public ICollection<Project> CreatedProjects { get; set; } = [];

        // Test cases creados por el usuario
        public ICollection<TestCase> CreatedTestCases { get; set; } = [];

        // Test cases que el usuario está certificando
        public ICollection<TestCaseCertifier> CertifyingTestCases { get; set; } = [];
    }
}
