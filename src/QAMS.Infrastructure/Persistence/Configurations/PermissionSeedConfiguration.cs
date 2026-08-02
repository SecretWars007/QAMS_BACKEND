using System;
using System.Collections.Generic;
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
            builder.ToTable("permissions");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("code").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(p => p.Module).HasColumnName("module").HasMaxLength(100);
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");

            var permissions = new List<Permission>
            {
                // USUARIOS
                P("USERS_VIEW", "Ver usuarios", "Users"),
                P("USERS_CREATE", "Crear usuarios", "Users"),
                P("USERS_UPDATE", "Actualizar usuarios", "Users"),
                P("USERS_DELETE", "Eliminar usuarios", "Users"),
                P("USERS_ASSIGN_ROLES", "Asignar roles a usuarios", "Users"),
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
                // REQUISITOS
                P("REQUIREMENTS_VIEW", "Ver requisitos", "Requirements"),
                P("REQUIREMENTS_CREATE", "Crear requisitos", "Requirements"),
                P("REQUIREMENTS_UPDATE", "Actualizar requisitos", "Requirements"),
                P("REQUIREMENTS_DELETE", "Eliminar requisitos", "Requirements"),
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
                // DEFECTOS
                P("DEFECTS_VIEW", "Ver defectos", "Defects"),
                P("DEFECTS_CREATE", "Crear defectos", "Defects"),
                P("DEFECTS_UPDATE", "Actualizar defectos", "Defects"),
                P("DEFECTS_DELETE", "Eliminar defectos", "Defects"),
                // REVISIONES ESTÁTICAS
                P("REVIEWS_VIEW", "Ver revisiones estáticas", "Reviews"),
                P("REVIEWS_CREATE", "Crear revisiones estáticas", "Reviews"),
                P("REVIEWS_UPDATE", "Actualizar revisiones estáticas", "Reviews"),
                P("REVIEWS_DELETE", "Eliminar revisiones estáticas", "Reviews"),
                // KANBAN
                P("KANBAN_VIEW", "Ver tableros Kanban", "Kanban"),
                P("KANBAN_CREATE", "Crear tableros/tareas", "Kanban"),
                P("KANBAN_UPDATE", "Mover tareas", "Kanban"),
                P("KANBAN_DELETE", "Eliminar tareas", "Kanban"),
                // DASHBOARD
                P("DASHBOARD_VIEW", "Ver dashboard", "Dashboard"),
                // SISTEMAS BAJO PRUEBA (SUT)
                P("SUT_VIEW", "Ver sistemas bajo prueba", "SUT"),
                P("SUT_CREATE", "Crear sistemas bajo prueba", "SUT"),
                P("SUT_UPDATE", "Actualizar sistemas bajo prueba", "SUT"),
                P("SUT_DELETE", "Eliminar sistemas bajo prueba", "SUT"),
                // SESIONES EXPLORATORIAS (ISTQB Cap. 4.4)
                P("EXPLORATORY_VIEW", "Ver sesiones exploratorias", "Exploratory"),
                P("EXPLORATORY_CREATE", "Crear sesiones exploratorias", "Exploratory"),
                P("EXPLORATORY_UPDATE", "Actualizar sesiones exploratorias", "Exploratory"),
                P("EXPLORATORY_DELETE", "Eliminar sesiones exploratorias", "Exploratory"),
                // ENTORNOS DE PRUEBA (ISTQB Cap. 5.4)
                P("ENVIRONMENTS_VIEW", "Ver entornos de prueba", "Environments"),
                P("ENVIRONMENTS_CREATE", "Crear entornos de prueba", "Environments"),
                P("ENVIRONMENTS_UPDATE", "Actualizar entornos de prueba", "Environments"),
                P("ENVIRONMENTS_DELETE", "Eliminar entornos de prueba", "Environments"),
            };

            builder.HasData(permissions);
        }

        /// <summary>Helper para crear Permission con Guid determinístico basado en código.</summary>
        public static Permission P(string code, string desc, string module)
        {
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

        public static readonly string[] AllPermissionCodes =
        [
            "USERS_VIEW", "USERS_CREATE", "USERS_UPDATE", "USERS_DELETE", "USERS_ASSIGN_ROLES",
            "ROLES_VIEW", "ROLES_CREATE", "ROLES_UPDATE", "ROLES_DELETE", "ROLES_ASSIGN_PERMISSIONS",
            "CATALOGS_VIEW", "CATALOGS_MANAGE",
            "PROJECTS_VIEW", "PROJECTS_CREATE", "PROJECTS_UPDATE", "PROJECTS_DELETE",
            "REQUIREMENTS_VIEW", "REQUIREMENTS_CREATE", "REQUIREMENTS_UPDATE", "REQUIREMENTS_DELETE",
            "TEST_CASES_VIEW", "TEST_CASES_CREATE", "TEST_CASES_UPDATE", "TEST_CASES_DELETE",
            "EXECUTIONS_VIEW", "EXECUTIONS_CREATE", "EXECUTIONS_UPDATE", "EXECUTIONS_UPLOAD_EVIDENCE",
            "DEFECTS_VIEW", "DEFECTS_CREATE", "DEFECTS_UPDATE", "DEFECTS_DELETE",
            "REVIEWS_VIEW", "REVIEWS_CREATE", "REVIEWS_UPDATE", "REVIEWS_DELETE",
            "KANBAN_VIEW", "KANBAN_CREATE", "KANBAN_UPDATE", "KANBAN_DELETE",
            "DASHBOARD_VIEW",
            "SUT_VIEW", "SUT_CREATE", "SUT_UPDATE", "SUT_DELETE",
            "EXPLORATORY_VIEW", "EXPLORATORY_CREATE", "EXPLORATORY_UPDATE", "EXPLORATORY_DELETE",
            "ENVIRONMENTS_VIEW", "ENVIRONMENTS_CREATE", "ENVIRONMENTS_UPDATE", "ENVIRONMENTS_DELETE"
        ];
    }
}
