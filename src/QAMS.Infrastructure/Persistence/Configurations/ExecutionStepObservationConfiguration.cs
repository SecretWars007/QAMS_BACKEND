// src/QAMS.Infrastructure/Persistence/Configurations/ExecutionStepObservationConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ExecutionStepObservationConfiguration : IEntityTypeConfiguration<ExecutionStepObservation>
    {
        public void Configure(EntityTypeBuilder<ExecutionStepObservation> builder)
        {
            builder.ToTable("execution_step_observations");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Observation).IsRequired();
            builder.Property(o => o.Response);

            builder.HasOne(o => o.ExecutionStepResult)
                .WithMany(r => r.Observations)
                .HasForeignKey(o => o.ExecutionStepResultId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.CreatedBy)
                .WithMany()
                .HasForeignKey(o => o.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.RespondedBy)
                .WithMany()
                .HasForeignKey(o => o.RespondedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.FileType)
                .WithMany()
                .HasForeignKey(o => o.FileTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.FileName).HasMaxLength(255);
            builder.Property(o => o.FilePath).HasMaxLength(500);
            builder.Property(o => o.ContentType).HasMaxLength(100);
        }
    }
}
