using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;
using QAMS.Domain.Constants;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        // Tester Permissions
        private static readonly string[] sourceArray =
            [
                "PROJECTS_VIEW", "REQUIREMENTS_VIEW", "TEST_CASES_VIEW",
                "EXECUTIONS_VIEW", "EXECUTIONS_CREATE", "EXECUTIONS_UPDATE", "EXECUTIONS_UPLOAD_EVIDENCE",
                "DEFECTS_VIEW", "DEFECTS_CREATE", "DEFECTS_UPDATE",
                "REVIEWS_VIEW", "KANBAN_VIEW", "KANBAN_UPDATE",
                "DASHBOARD_VIEW", "CATALOGS_VIEW",
                "SUT_VIEW", "SUT_CREATE", "SUT_UPDATE",
                "EXPLORATORY_VIEW", "EXPLORATORY_CREATE", "EXPLORATORY_UPDATE",
                "ENVIRONMENTS_VIEW"
            ];

        // Lead (Líder de Pruebas) Permissions
        private static readonly string[] sourceArray0 =
            [
                "PROJECTS_VIEW", "PROJECTS_CREATE", "PROJECTS_UPDATE",
                "USERS_VIEW",
                "REQUIREMENTS_VIEW", "REQUIREMENTS_CREATE", "REQUIREMENTS_UPDATE", "REQUIREMENTS_DELETE",
                "TEST_CASES_VIEW", "TEST_CASES_CREATE", "TEST_CASES_UPDATE", "TEST_CASES_DELETE",
                "EXECUTIONS_VIEW", "EXECUTIONS_CREATE", "EXECUTIONS_UPDATE", "EXECUTIONS_UPLOAD_EVIDENCE",
                "DEFECTS_VIEW", "DEFECTS_CREATE", "DEFECTS_UPDATE", "DEFECTS_DELETE",
                "REVIEWS_VIEW", "REVIEWS_CREATE", "REVIEWS_UPDATE", "REVIEWS_DELETE",
                "KANBAN_VIEW", "KANBAN_CREATE", "KANBAN_UPDATE", "KANBAN_DELETE",
                "DASHBOARD_VIEW", "CATALOGS_VIEW",
                "SUT_VIEW", "SUT_CREATE", "SUT_UPDATE", "SUT_DELETE",
                "EXPLORATORY_VIEW", "EXPLORATORY_CREATE", "EXPLORATORY_UPDATE", "EXPLORATORY_DELETE",
                "ENVIRONMENTS_VIEW", "ENVIRONMENTS_CREATE", "ENVIRONMENTS_UPDATE", "ENVIRONMENTS_DELETE"
            ];

        // Developer Permissions
        private static readonly string[] sourceArray1 =
            [
                "PROJECTS_VIEW", "REQUIREMENTS_VIEW", "TEST_CASES_VIEW", "EXECUTIONS_VIEW",
                "DEFECTS_VIEW", "DEFECTS_CREATE", "DEFECTS_UPDATE",
                "REVIEWS_VIEW", "KANBAN_VIEW", "KANBAN_UPDATE", "DASHBOARD_VIEW",
                "SUT_VIEW", "ENVIRONMENTS_VIEW", "EXPLORATORY_VIEW"
            ];

        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("role_permissions");
            builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.Property(rp => rp.RoleId).HasColumnName("role_id");
            builder.Property(rp => rp.PermissionId).HasColumnName("permission_id");
            builder.Property(rp => rp.AssignedAt).HasColumnName("assigned_at").IsRequired();

            builder.HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);

            var rolePermissions = PermissionSeedConfiguration.AllPermissionCodes
                .Select(code => new RolePermission
                {
                    RoleId = SystemRoles.AdminRoleId,
                    PermissionId = PermissionSeedConfiguration.P(code, "", "").Id,
                    AssignedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }).ToList();

            var testerPermissions = sourceArray.Select(code => new RolePermission
            {
                RoleId = SystemRoles.TesterRoleId,
                PermissionId = PermissionSeedConfiguration.P(code, "", "").Id,
                AssignedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });

            rolePermissions.AddRange(testerPermissions);

            var leadPermissions = sourceArray0.Select(code => new RolePermission
            {
                RoleId = SystemRoles.LeadRoleId,
                PermissionId = PermissionSeedConfiguration.P(code, "", "").Id,
                AssignedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });

            var developerPermissions = sourceArray1.Select(code => new RolePermission
            {
                RoleId = SystemRoles.DeveloperRoleId,
                PermissionId = PermissionSeedConfiguration.P(code, "", "").Id,
                AssignedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });

            rolePermissions.AddRange(leadPermissions);
            rolePermissions.AddRange(developerPermissions);

            builder.HasData([.. rolePermissions]);
        }
    }
}
