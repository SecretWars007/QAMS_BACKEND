// src/QAMS.Domain/Entities/RequirementTestCase.cs
using QAMS.Domain.Common;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Tabla puente M:N entre Requisitos y Casos de Prueba.
    /// ISTQB: permite calcular la cobertura de requisitos (% de reqs con >= 1 test case).
    /// 4FN: relación pura sin atributos extra.
    /// </summary>
    public class RequirementTestCase : IAuditable
    {
        public Guid RequirementId { get; set; }
        public Requirement? Requirement { get; set; }

        public Guid TestCaseId { get; set; }
        public TestCase? TestCase { get; set; }

        // IAuditable
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }
    }
}
