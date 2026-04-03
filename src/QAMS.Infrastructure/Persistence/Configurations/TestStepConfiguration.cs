// src/QAMS.Infrastructure/Persistence/Configurations/TestStepConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestStepConfiguration : IEntityTypeConfiguration<TestStep>
    {
        public void Configure(EntityTypeBuilder<TestStep> builder)
        {
            builder.ToTable("test_steps");

            builder.HasKey(ts => ts.Id);
            builder.Property(ts => ts.Id).HasColumnName("id");

            builder.Property(ts => ts.TestCaseId).HasColumnName("test_case_id").IsRequired();
            builder.Property(ts => ts.StepOrder).HasColumnName("step_order").IsRequired();
            builder.Property(ts => ts.Action).HasColumnName("action").HasMaxLength(1000).IsRequired();
            builder.Property(ts => ts.ExpectedResult).HasColumnName("expected_result").HasMaxLength(1000).IsRequired();

            // Índice único compuesto para asegurar el orden de los pasos por caso de prueba
            builder.HasIndex(ts => new { ts.TestCaseId, ts.StepOrder }).IsUnique();

            builder.Property(ts => ts.CreatedByUserId).HasColumnName("created_by_user_id");

            // Relación con TestCase
            builder.HasOne(ts => ts.TestCase)
                .WithMany(tc => tc.TestSteps)
                .HasForeignKey(ts => ts.TestCaseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con Creador
            builder.HasOne(ts => ts.CreatedBy)
                .WithMany()
                .HasForeignKey(ts => ts.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
