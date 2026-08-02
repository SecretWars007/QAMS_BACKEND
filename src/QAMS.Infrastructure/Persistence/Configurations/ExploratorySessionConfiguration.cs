using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ExploratorySessionConfiguration : IEntityTypeConfiguration<ExploratorySession>
    {
        public void Configure(EntityTypeBuilder<ExploratorySession> builder)
        {
            builder.ToTable("exploratory_sessions");

            builder.HasKey(es => es.Id);
            builder.Property(es => es.Id).HasColumnName("id");

            builder.Property(es => es.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(es => es.TesterId).HasColumnName("tester_id").IsRequired();
            
            builder.Property(es => es.Charter).HasColumnName("charter").HasMaxLength(1000).IsRequired();
            builder.Property(es => es.StatusId).HasColumnName("status_id").HasDefaultValue(1);
            
            builder.Property(es => es.StartTime).HasColumnName("start_time");
            builder.Property(es => es.EndTime).HasColumnName("end_time");
            builder.Property(es => es.DurationMinutes).HasColumnName("duration_minutes");
            builder.Property(es => es.Notes).HasColumnName("notes").HasMaxLength(4000);

            // Relación con Project
            builder.HasOne(es => es.Project)
                .WithMany()
                .HasForeignKey(es => es.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Tester
            builder.HasOne(es => es.Tester)
                .WithMany()
                .HasForeignKey(es => es.TesterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(es => es.ProjectId);
            builder.HasIndex(es => es.TesterId);
        }
    }
}
