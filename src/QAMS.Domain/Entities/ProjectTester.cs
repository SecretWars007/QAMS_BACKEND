// src/QAMS.Domain/Entities/ProjectTester.cs
using System;

namespace QAMS.Domain.Entities
{
    /// <summary>
    /// Tabla puente para la relación muchos-a-muchos entre Project y User (Testers).
    /// Permite asignar múltiples testers a un proyecto.
    /// </summary>
    public class ProjectTester
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
