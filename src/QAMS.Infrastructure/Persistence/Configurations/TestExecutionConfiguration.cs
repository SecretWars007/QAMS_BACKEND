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
            builder.Property(te => te.TesterId).HasColumnName("tester_id");
            builder.Property(te => te.StatusId).HasColumnName("status_id").IsRequired();
            builder.Property(te => te.Notes).HasColumnName("notes").HasMaxLength(2000);
            builder
                .Property(te => te.ExecutionDate)
                .HasColumnName("execution_date")
                .HasDefaultValueSql("NOW()");
            builder.Property(te => te.CompletedAt).HasColumnName("completed_at");

            // FK hacia catálogo (Restrict: no eliminar status si hay ejecuciones)
            builder
                .HasOne(te => te.Status)
                .WithMany(s => s.TestExecutions)
                .HasForeignKey(te => te.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(te => te.TestCase)
                .WithMany(tc => tc.TestExecutions)
                .HasForeignKey(te => te.TestCaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(te => te.Tester)
                .WithMany(u => u.TestExecutions)
                .HasForeignKey(te => te.TesterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
