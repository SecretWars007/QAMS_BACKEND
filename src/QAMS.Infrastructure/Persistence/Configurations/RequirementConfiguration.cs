// src/QAMS.Infrastructure/Persistence/Configurations/RequirementConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class RequirementConfiguration : IEntityTypeConfiguration<Requirement>
    {
        public void Configure(EntityTypeBuilder<Requirement> builder)
        {
            builder.ToTable("requirements");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("id");
            builder.Property(r => r.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(r => r.Title).HasColumnName("title").HasMaxLength(500).IsRequired();
            builder.Property(r => r.Description).HasColumnName("description");
            
            builder.Property(r => r.Code).HasColumnName("code").HasMaxLength(100).IsRequired();
            builder.HasIndex(r => r.Code).IsUnique();
            builder.Property(r => r.AcceptanceCriteria).HasColumnName("acceptance_criteria").HasColumnType("text");
            builder.Property(r => r.RequirementTypeId).HasColumnName("requirement_type_id").HasDefaultValue(1);
            builder.Property(r => r.RequirementPriorityId).HasColumnName("requirement_priority_id").HasDefaultValue(1);
            builder.Property(r => r.RequirementComplexityId).HasColumnName("requirement_complexity_id").HasDefaultValue(1);
            builder.Property(r => r.RequirementStatusId).HasColumnName("requirement_status_id").HasDefaultValue(1);
            builder.Property(r => r.Source).HasColumnName("source").HasMaxLength(255);

            // Auditoría y Borrado Lógico
            builder.Property(r => r.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(r => r.DeletedAt).HasColumnName("deleted_at");
            builder.Property(r => r.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(r => r.CreatedAt).HasColumnName("created_at");
            builder.Property(r => r.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(r => r.UpdatedAt).HasColumnName("updated_at");
            builder.Property(r => r.UpdatedByUserId).HasColumnName("updated_by_user_id");

            builder.HasOne(r => r.Project)
                .WithMany(p => p.Requirements)
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Auditoría
            builder.HasOne(r => r.CreatedBy)
                .WithMany()
                .HasForeignKey(r => r.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(r => r.UpdatedBy)
                .WithMany()
                .HasForeignKey(r => r.UpdatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(r => r.DeletedBy)
                .WithMany()
                .HasForeignKey(r => r.DeletedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relaciones de Catálogo
            builder.HasOne(r => r.RequirementType)
                .WithMany(rt => rt.Requirements)
                .HasForeignKey(r => r.RequirementTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.RequirementPriority)
                .WithMany(rp => rp.Requirements)
                .HasForeignKey(r => r.RequirementPriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.RequirementComplexity)
                .WithMany(rc => rc.Requirements)
                .HasForeignKey(r => r.RequirementComplexityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.RequirementStatus)
                .WithMany(rs => rs.Requirements)
                .HasForeignKey(r => r.RequirementStatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
