// src/QAMS.Domain/Entities/TestSuite.cs
namespace QAMS.Domain.Entities
{
    /// <summary>Suite: contenedor lógico de casos de prueba.</summary>
    public class TestSuite
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<TestCase> TestCases { get; set; } = new List<TestCase>();
    }
}
