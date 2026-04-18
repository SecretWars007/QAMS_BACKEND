// src/QAMS.Infrastructure/Persistence/Configurations/ProjectConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;
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
            builder.Property(p => p.WorkHoursPerDay).HasColumnName("work_hours_per_day").HasDefaultValue(7);
            builder.Property(p => p.ExecutedHours).HasColumnName("executed_hours").HasColumnType("numeric(10,2)").HasDefaultValue(0m);
            builder.Property(p => p.RemainingHours).HasColumnName("remaining_hours").HasColumnType("numeric(10,2)").HasDefaultValue(0m);
            builder.Property(p => p.ProjectPriorityId).HasColumnName("project_priority_id").HasDefaultValue(1);
            builder.Property(p => p.ProjectStatusId).HasColumnName("project_status_id").HasDefaultValue(1);

            // Nuevos Campos requeridos
            builder.Property(p => p.Version).HasColumnName("version").HasMaxLength(50).HasDefaultValue("1.0");
            builder.Property(p => p.Budget).HasColumnName("budget").HasColumnType("numeric(10,2)").HasDefaultValue(0m);
            builder.Property(p => p.Risks).HasColumnName("risks").HasColumnType("text");
            builder.Property(p => p.LeaderId).HasColumnName("leader_id");

            // Auditoría y Borrado Lógico
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(p => p.DeletedAt).HasColumnName("deleted_at");
            builder.Property(p => p.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(p => p.CreatedAt).HasColumnName("created_at");
            builder.Property(p => p.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");
            builder.Property(p => p.UpdatedByUserId).HasColumnName("updated_by_user_id");

            builder.HasOne(p => p.CreatedBy)
                .WithMany(u => u.CreatedProjects)
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Leader)
                .WithMany()
                .HasForeignKey(p => p.LeaderId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.UpdatedBy)
                .WithMany()
                .HasForeignKey(p => p.UpdatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.DeletedBy)
                .WithMany()
                .HasForeignKey(p => p.DeletedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.ProjectPriority)
                .WithMany(s => s.Projects)
                .HasForeignKey(p => p.ProjectPriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ProjectStatus)
                .WithMany(s => s.Projects)
                .HasForeignKey(p => p.ProjectStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.DevolucionesCounter).HasColumnName("devoluciones_counter").HasDefaultValue(0);
        }
    }
}
