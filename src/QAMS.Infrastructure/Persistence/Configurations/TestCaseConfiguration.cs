// src/QAMS.Infrastructure/Persistence/Configurations/TestCaseConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestCaseConfiguration : IEntityTypeConfiguration<TestCase>
    {
        public void Configure(EntityTypeBuilder<TestCase> builder)
        {
            builder.ToTable("test_cases");

            builder.HasKey(tc => tc.Id);
            builder.Property(tc => tc.Id).HasColumnName("id");

            builder.Property(tc => tc.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(tc => tc.TestSuiteId).HasColumnName("test_suite_id").IsRequired();
            builder.Property(tc => tc.Title).HasColumnName("title").HasMaxLength(200).IsRequired();
            builder.Property(tc => tc.Description).HasColumnName("description").HasMaxLength(2000);
            builder.Property(tc => tc.Preconditions).HasColumnName("preconditions").HasMaxLength(1000);
            builder.Property(tc => tc.ExpectedResult).HasColumnName("expected_result").HasMaxLength(1000).IsRequired();
            builder.Property(tc => tc.Postconditions).HasColumnName("postconditions").HasMaxLength(1000);
            builder.Property(tc => tc.PriorityId).HasColumnName("priority_id").IsRequired();
            builder.Property(tc => tc.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(tc => tc.VersionNumber).HasColumnName("version_number").HasDefaultValue(1);
            builder.Property(tc => tc.IsLatestVersion).HasColumnName("is_latest_version").HasDefaultValue(true);
            builder.Property(tc => tc.ParentTestCaseId).HasColumnName("parent_test_case_id");
            
            builder.Property(tc => tc.IsBdd).HasColumnName("is_bdd").HasDefaultValue(false);
            builder.Property(tc => tc.BddScenario).HasColumnName("bdd_scenario");

            builder.Property(tc => tc.EstimatedTimeHours).HasColumnName("estimated_time_hours").HasColumnType("decimal(6,2)").HasDefaultValue(0);
            builder.Property(tc => tc.TestTypeId).HasColumnName("test_type_id").HasDefaultValue(1); // Default: Funcional Manual
            builder.Property(tc => tc.ImpactLevel).HasColumnName("impact_level").HasDefaultValue(3);
            builder.Property(tc => tc.LikelihoodLevel).HasColumnName("likelihood_level").HasDefaultValue(3);
            builder.Property(tc => tc.LastCycleNumber).HasColumnName("last_cycle_number");

            // Auditoría y Borrado Lógico
            builder.Property(tc => tc.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(tc => tc.DeletedAt).HasColumnName("deleted_at");
            builder.Property(tc => tc.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(tc => tc.CreatedAt).HasColumnName("created_at");
            builder.Property(tc => tc.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(tc => tc.UpdatedAt).HasColumnName("updated_at");
            builder.Property(tc => tc.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relación con Project
            builder.HasOne(tc => tc.Project)
                .WithMany(p => p.TestCases)
                .HasForeignKey(tc => tc.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con TestSuite
            builder.HasOne(tc => tc.TestSuite)
                .WithMany(ts => ts.TestCases)
                .HasForeignKey(ts => ts.TestSuiteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con Priority
            builder.HasOne(tc => tc.Priority)
                .WithMany(p => p.TestCases)
                .HasForeignKey(tc => tc.PriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con CreatedBy
            builder.HasOne(tc => tc.CreatedBy)
                .WithMany(u => u.CreatedTestCases)
                .HasForeignKey(tc => tc.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación con UpdatedBy
            builder.HasOne(tc => tc.UpdatedBy)
                .WithMany()
                .HasForeignKey(tc => tc.UpdatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación con DeletedBy
            builder.HasOne(tc => tc.DeletedBy)
                .WithMany()
                .HasForeignKey(tc => tc.DeletedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación con TestType
            builder.HasOne(tc => tc.TestType)
                .WithMany(tt => tt.TestCases)
                .HasForeignKey(tc => tc.TestTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(tc => tc.DesignTechniqueId).HasColumnName("design_technique_id");

            // Relación con TestDesignTechnique
            builder.HasOne(tc => tc.DesignTechnique)
                .WithMany()
                .HasForeignKey(tc => tc.DesignTechniqueId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con el caso de prueba padre (versiones anteriores)
            builder.HasOne(tc => tc.ParentTestCase)
                .WithMany()
                .HasForeignKey(tc => tc.ParentTestCaseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para optimizar búsquedas por proyecto, suite y versiones
            builder.HasIndex(tc => tc.ProjectId);
            builder.HasIndex(tc => tc.TestSuiteId);
            builder.HasIndex(tc => tc.ParentTestCaseId);
        }
    }
}
