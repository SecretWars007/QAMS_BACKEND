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
        
        // Proyectos a los que está asignado el usuario
        public ICollection<ProjectTester> ProjectAssignments { get; set; } = new List<ProjectTester>();

        // Proyectos creados por el usuario
        public ICollection<Project> CreatedProjects { get; set; } = new List<Project>();

        // Test cases creados por el usuario
        public ICollection<TestCase> CreatedTestCases { get; set; } = new List<TestCase>();

        // Test cases que el usuario está certificando
        public ICollection<TestCaseCertifier> CertifyingTestCases { get; set; } = new List<TestCaseCertifier>();
    }
}
