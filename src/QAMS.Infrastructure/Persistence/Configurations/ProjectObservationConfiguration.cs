// src/QAMS.Infrastructure/Persistence/Configurations/ProjectObservationConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ProjectObservationConfiguration : IEntityTypeConfiguration<ProjectObservation>
    {
        public void Configure(EntityTypeBuilder<ProjectObservation> builder)
        {
            builder.ToTable("project_observations");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Observation).IsRequired();

            builder.HasOne(o => o.Project)
                .WithMany(p => p.Observations)
                .HasForeignKey(o => o.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.CreatedBy)
                .WithMany()
                .HasForeignKey(o => o.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
