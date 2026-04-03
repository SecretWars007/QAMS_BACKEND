// src/QAMS.Infrastructure/Persistence/Configurations/KanbanColumnConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class KanbanColumnConfiguration : IEntityTypeConfiguration<KanbanColumn>
    {
        public void Configure(EntityTypeBuilder<KanbanColumn> builder)
        {
            builder.ToTable("kanban_columns");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id");

            builder.Property(c => c.BoardId).HasColumnName("board_id").IsRequired();
            builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(c => c.OrderIndex).HasColumnName("order_index").IsRequired();

            // Auditoría y Borrado Lógico
            builder.Property(c => c.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(c => c.DeletedAt).HasColumnName("deleted_at");
            builder.Property(c => c.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(c => c.CreatedAt).HasColumnName("created_at");
            builder.Property(c => c.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(c => c.UpdatedAt).HasColumnName("updated_at");
            builder.Property(c => c.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relación con KanbanBoard
            builder.HasOne(c => c.Board)
                .WithMany(b => b.Columns)
                .HasForeignKey(c => c.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con CreatedBy
            builder.HasOne(c => c.CreatedBy)
                .WithMany()
                .HasForeignKey(c => c.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación con UpdatedBy
            builder.HasOne(c => c.UpdatedBy)
                .WithMany()
                .HasForeignKey(c => c.UpdatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación con DeletedBy
            builder.HasOne(c => c.DeletedBy)
                .WithMany()
                .HasForeignKey(c => c.DeletedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
