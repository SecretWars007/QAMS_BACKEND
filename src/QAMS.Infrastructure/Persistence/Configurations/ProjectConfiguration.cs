// src/QAMS.Infrastructure/Persistence/Configurations/ProjectConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

using QAMS.Infrastructure.Persistence.Configurations;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("projects");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Name).HasColumnName("name").HasMaxLength(200).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
            builder.Property(p => p.Description).HasColumnName("description").HasMaxLength(1000);
            builder.Property(p => p.StartDate).HasColumnName("start_date");
            builder.Property(p => p.EndDate).HasColumnName("end_date");
            builder.Property(p => p.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
            builder.Property(p => p.WorkHoursPerDay).HasColumnName("work_hours_per_day").HasDefaultValue(7);
            builder.Property(p => p.ExecutedHours).HasColumnName("executed_hours").HasColumnType("numeric(10,2)").HasDefaultValue(0m);
            builder.Property(p => p.RemainingHours).HasColumnName("remaining_hours").HasColumnType("numeric(10,2)").HasDefaultValue(0m);

            builder.Property(p => p.CreatedByUserId).HasColumnName("created_by_user_id");
            
            builder.Property(p => p.Priority).HasColumnName("priority").HasDefaultValue(0);
            builder.Property(p => p.ProjectStatusId).HasColumnName("project_status_id").HasDefaultValue(1); // Default: Pendiente

            builder.HasOne(p => p.CreatedBy)
                .WithMany(u => u.CreatedProjects)
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.ProjectStatus)
                .WithMany(s => s.Projects)
                .HasForeignKey(p => p.ProjectStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.DevolucionesCounter).HasColumnName("devoluciones_counter").HasDefaultValue(0);
        }
    }
}
