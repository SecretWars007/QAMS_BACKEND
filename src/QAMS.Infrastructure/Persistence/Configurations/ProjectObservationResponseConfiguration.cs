// src/QAMS.Infrastructure/Persistence/Configurations/ProjectObservationResponseConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ProjectObservationResponseConfiguration : IEntityTypeConfiguration<ProjectObservationResponse>
    {
        public void Configure(EntityTypeBuilder<ProjectObservationResponse> builder)
        {
            builder.ToTable("project_observation_responses");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Response).IsRequired();

            builder.HasOne(r => r.ProjectObservation)
                .WithMany(o => o.Responses)
                .HasForeignKey(r => r.ProjectObservationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.CreatedBy)
                .WithMany()
                .HasForeignKey(r => r.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
