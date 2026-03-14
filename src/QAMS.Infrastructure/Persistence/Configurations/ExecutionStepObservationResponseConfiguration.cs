// src/QAMS.Infrastructure/Persistence/Configurations/ExecutionStepObservationResponseConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ExecutionStepObservationResponseConfiguration : IEntityTypeConfiguration<ExecutionStepObservationResponse>
    {
        public void Configure(EntityTypeBuilder<ExecutionStepObservationResponse> builder)
        {
            builder.ToTable("execution_step_observation_responses");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Response).IsRequired();

            builder.HasOne(r => r.ExecutionStepObservation)
                .WithMany(o => o.Responses)
                .HasForeignKey(r => r.ExecutionStepObservationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.CreatedBy)
                .WithMany()
                .HasForeignKey(r => r.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
