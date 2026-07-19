// src/QAMS.Infrastructure/Persistence/Configurations/ExecutionStepResultConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ExecutionStepResultConfiguration : IEntityTypeConfiguration<ExecutionStepResult>
    {
        public void Configure(EntityTypeBuilder<ExecutionStepResult> builder)
        {
            builder.ToTable("execution_step_results");
            builder.HasKey(esr => esr.Id);
            builder.Property(esr => esr.Id).HasColumnName("id");
            builder.Property(esr => esr.TestExecutionId).HasColumnName("test_execution_id").IsRequired();
            builder.Property(esr => esr.TestStepId).HasColumnName("test_step_id").IsRequired();
            builder.Property(esr => esr.StatusId).HasColumnName("status_id").IsRequired();
            builder.Property(esr => esr.ActualResult).HasColumnName("actual_result").HasMaxLength(2000);
            builder.Property(esr => esr.Notes).HasColumnName("notes").HasMaxLength(2000);
            builder.Property(esr => esr.EvaluatedAt).HasColumnName("evaluated_at").HasDefaultValueSql("NOW()");

            builder
                .HasOne(esr => esr.TestExecution)
                .WithMany(te => te.StepResults)
                .HasForeignKey(esr => esr.TestExecutionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(esr => esr.TestStep)
                .WithMany()
                .HasForeignKey(esr => esr.TestStepId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(esr => esr.Status)
                .WithMany()
                .HasForeignKey(esr => esr.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indice único para evitar repetir resultados del mismo paso en la misma ejecución
            builder.HasIndex(esr => new { esr.TestExecutionId, esr.TestStepId }).IsUnique();
        }
    }
}
