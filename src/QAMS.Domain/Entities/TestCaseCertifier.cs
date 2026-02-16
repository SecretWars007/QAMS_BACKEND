// src/QAMS.Domain/Entities/TestCaseCertifier.cs
using System;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Tabla puente para la relación muchos-a-muchos entre TestCase y User (Certifiers).
    /// Permite asignar múltiples certificadores a un caso de prueba.
    /// </summary>
    public class TestCaseCertifier
    {
        public Guid TestCaseId { get; set; }
        public TestCase TestCase { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
