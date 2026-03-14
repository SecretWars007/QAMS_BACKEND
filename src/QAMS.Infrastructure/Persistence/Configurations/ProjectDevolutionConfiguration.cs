// src/QAMS.Infrastructure/Persistence/Configurations/ProjectDevolutionConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ProjectDevolutionConfiguration : IEntityTypeConfiguration<ProjectDevolution>
    {
        public void Configure(EntityTypeBuilder<ProjectDevolution> builder)
        {
            builder.ToTable("project_devolutions");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Notes).IsRequired();
            builder.Property(d => d.ResponseNotes);

            builder.HasOne(d => d.Project)
                .WithMany(p => p.HistoricDevolutions)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.CreatedBy)
                .WithMany()
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.ObservationsCount).HasDefaultValue(0);
        }
    }
}
