// src/QAMS.Infrastructure/Persistence/Configurations/TestExecutionConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestExecutionConfiguration : IEntityTypeConfiguration<TestExecution>
    {
        public void Configure(EntityTypeBuilder<TestExecution> builder)
        {
            builder.ToTable("test_executions");
            builder.HasKey(te => te.Id);
            builder.Property(te => te.Id).HasColumnName("id");
            builder.Property(te => te.TestCaseId).HasColumnName("test_case_id");
            builder.Property(te => te.TestPlanId).HasColumnName("test_plan_id");
            builder.Property(te => te.TesterId).HasColumnName("tester_id");
            builder.Property(te => te.StatusId).HasColumnName("status_id").IsRequired();
            builder.HasIndex(te => te.StatusId).HasDatabaseName("ix_test_executions_status_id");
            builder.Property(te => te.Notes).HasColumnName("notes").HasMaxLength(2000);
            builder.Property(te => te.ActualTimeHours).HasColumnName("actual_time_hours").HasColumnType("numeric(5,2)");
            builder.Property(te => te.ExecutionDate).HasColumnName("execution_date");
            builder.Property(te => te.CompletedAt).HasColumnName("completed_at");
            builder.Property(te => te.CycleNumber).HasColumnName("cycle_number").IsRequired();

            // Auditoría y Borrado Lógico
            builder.Property(te => te.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(te => te.DeletedAt).HasColumnName("deleted_at");
            builder.Property(te => te.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(te => te.CreatedAt).HasColumnName("created_at");
            builder.Property(te => te.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(te => te.UpdatedAt).HasColumnName("updated_at");
            builder.Property(te => te.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relationships
            builder.HasOne(te => te.Status)
                .WithMany(s => s.TestExecutions)
                .HasForeignKey(te => te.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(te => te.TestCase)
                .WithMany(tc => tc.TestExecutions)
                .HasForeignKey(te => te.TestCaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(te => te.TestPlan)
                .WithMany()
                .HasForeignKey(te => te.TestPlanId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(te => te.Tester)
                .WithMany(u => u.TestExecutions)
                .HasForeignKey(te => te.TesterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(te => te.CreatedBy)
                .WithMany()
                .HasForeignKey(te => te.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(te => te.UpdatedBy)
                .WithMany()
                .HasForeignKey(te => te.UpdatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(te => te.DeletedBy)
                .WithMany()
                .HasForeignKey(te => te.DeletedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
