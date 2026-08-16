// src/QAMS.Infrastructure/Persistence/Configurations/TestSuiteConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestSuiteConfiguration : IEntityTypeConfiguration<TestSuite>
    {
        public void Configure(EntityTypeBuilder<TestSuite> builder)
        {
            builder.ToTable("test_suites");
            builder.HasKey(ts => ts.Id);
            builder.Property(ts => ts.Id).HasColumnName("id");
            builder.Property(ts => ts.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(ts => ts.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(ts => ts.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(ts => ts.StatusId).HasColumnName("status_id").HasDefaultValue(1).IsRequired();

            // ISTQB Fields
            builder.Property(ts => ts.ExecutionPriorityId).HasColumnName("execution_priority_id");
            builder.Property(ts => ts.TestLevelId).HasColumnName("test_level_id");
            builder.Property(ts => ts.TestTypeId).HasColumnName("test_type_id");
            builder.Property(ts => ts.AutomationStatusId).HasColumnName("automation_status_id");
            builder.Property(ts => ts.TestDesignTechniqueId).HasColumnName("test_design_technique_id");
            builder.Property(ts => ts.ReviewStatusId).HasColumnName("review_status_id");
            builder.Property(ts => ts.TestEnvironmentId).HasColumnName("test_environment_id");
            builder.Property(ts => ts.OwnerUserId).HasColumnName("owner_user_id");
            builder.Property(ts => ts.Preconditions).HasColumnName("preconditions");
            builder.Property(ts => ts.CoverageObjective).HasColumnName("coverage_objective").HasMaxLength(255);
            builder.Property(ts => ts.EstimatedDurationHours).HasColumnName("estimated_duration_hours").HasColumnType("decimal(18,2)").HasDefaultValue(0m);

            // Auditoría y Borrado Lógico
            builder.Property(ts => ts.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(ts => ts.DeletedAt).HasColumnName("deleted_at");
            builder.Property(ts => ts.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(ts => ts.CreatedAt).HasColumnName("created_at");
            builder.Property(ts => ts.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(ts => ts.UpdatedAt).HasColumnName("updated_at");
            builder.Property(ts => ts.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relationships
            builder.HasOne(ts => ts.ExecutionPriority)
                .WithMany()
                .HasForeignKey(ts => ts.ExecutionPriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ts => ts.TestLevel)
                .WithMany()
                .HasForeignKey(ts => ts.TestLevelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ts => ts.TestType)
                .WithMany()
                .HasForeignKey(ts => ts.TestTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ts => ts.AutomationStatus)
                .WithMany()
                .HasForeignKey(ts => ts.AutomationStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ts => ts.TestDesignTechnique)
                .WithMany()
                .HasForeignKey(ts => ts.TestDesignTechniqueId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ts => ts.ReviewStatus)
                .WithMany()
                .HasForeignKey(ts => ts.ReviewStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ts => ts.TestEnvironment)
                .WithMany()
                .HasForeignKey(ts => ts.TestEnvironmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ts => ts.Owner)
                .WithMany()
                .HasForeignKey(ts => ts.OwnerUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(ts => ts.Project)
                .WithMany(p => p.TestSuites)
                .HasForeignKey(ts => ts.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ts => ts.Status)
                .WithMany(s => s.TestSuites)
                .HasForeignKey(ts => ts.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
