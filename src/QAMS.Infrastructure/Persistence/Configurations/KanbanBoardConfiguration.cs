// src/QAMS.Infrastructure/Persistence/Configurations/KanbanBoardConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class KanbanBoardConfiguration : IEntityTypeConfiguration<KanbanBoard>
    {
        public void Configure(EntityTypeBuilder<KanbanBoard> builder)
        {
            builder.ToTable("kanban_boards");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("id");

            builder.Property(b => b.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(b => b.ProjectId).HasColumnName("project_id").IsRequired();

            // Auditoría y Borrado Lógico
            builder.Property(b => b.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(b => b.DeletedAt).HasColumnName("deleted_at");
            builder.Property(b => b.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(b => b.CreatedAt).HasColumnName("created_at");
            builder.Property(b => b.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(b => b.UpdatedAt).HasColumnName("updated_at");
            builder.Property(b => b.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relación con Project
            builder.HasOne(b => b.Project)
                .WithMany(p => p.KanbanBoards)
                .HasForeignKey(b => b.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
