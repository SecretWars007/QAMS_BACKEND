// src/QAMS.Infrastructure/Persistence/Configurations/PermissionSeedConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Seed data para permisos del sistema RBAC.
    /// Cada controlador usa [HasPermission("CODE")] que debe existir aquí.
    /// </summary>
    public class PermissionSeedConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            var permissions = new List<Permission>
            {
                // USUARIOS
                P("USERS_VIEW", "Ver usuarios", "Users"),
                P("USERS_CREATE", "Crear usuarios", "Users"),
                P("USERS_UPDATE", "Actualizar usuarios", "Users"),
                P("USERS_DELETE", "Eliminar usuarios", "Users"),
                // ROLES
                P("ROLES_VIEW", "Ver roles", "Roles"),
                P("ROLES_CREATE", "Crear roles", "Roles"),
                P("ROLES_UPDATE", "Actualizar roles", "Roles"),
                P("ROLES_DELETE", "Eliminar roles", "Roles"),
                P("ROLES_ASSIGN_PERMISSIONS", "Asignar permisos a roles", "Roles"),
                // CATÁLOGOS
                P("CATALOGS_VIEW", "Ver catálogos", "Catalogs"),
                P("CATALOGS_MANAGE", "Administrar catálogos", "Catalogs"),
                // PROYECTOS
                P("PROJECTS_VIEW", "Ver proyectos", "Projects"),
                P("PROJECTS_CREATE", "Crear proyectos", "Projects"),
                P("PROJECTS_UPDATE", "Actualizar proyectos", "Projects"),
                P("PROJECTS_DELETE", "Eliminar proyectos", "Projects"),
                // CASOS DE PRUEBA
                P("TEST_CASES_VIEW", "Ver casos de prueba", "TestCases"),
                P("TEST_CASES_CREATE", "Crear casos de prueba", "TestCases"),
                P("TEST_CASES_UPDATE", "Actualizar casos de prueba", "TestCases"),
                P("TEST_CASES_DELETE", "Eliminar casos de prueba", "TestCases"),
                // EJECUCIONES
                P("EXECUTIONS_VIEW", "Ver ejecuciones", "Executions"),
                P("EXECUTIONS_CREATE", "Crear ejecuciones", "Executions"),
                P("EXECUTIONS_UPDATE", "Actualizar ejecuciones", "Executions"),
                P("EXECUTIONS_UPLOAD_EVIDENCE", "Subir evidencia", "Executions"),
                // KANBAN
                P("KANBAN_VIEW", "Ver tableros Kanban", "Kanban"),
                P("KANBAN_CREATE", "Crear tableros/tareas", "Kanban"),
                P("KANBAN_UPDATE", "Mover tareas", "Kanban"),
                P("KANBAN_DELETE", "Eliminar tareas", "Kanban"),
                // DASHBOARD
                P("DASHBOARD_VIEW", "Ver dashboard", "Dashboard"),
            };

            builder.HasData(permissions);
        }

        /// <summary>Helper para crear Permission con Guid determinístico basado en código.</summary>
        private static Permission P(string code, string desc, string module)
        {
            // Generar GUID determinístico basado en el código para consistencia
            var guidBytes = new byte[16];
            var codeBytes = System.Text.Encoding.UTF8.GetBytes(code.PadRight(16, '\0'));
            Array.Copy(codeBytes, guidBytes, Math.Min(codeBytes.Length, 16));

            return new Permission
            {
                Id = new Guid(guidBytes),
                Code = code,
                Description = desc,
                Module = module,
                CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
            };
        }
    }
}
