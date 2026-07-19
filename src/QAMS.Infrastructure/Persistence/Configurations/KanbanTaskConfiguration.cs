// src/QAMS.Infrastructure/Persistence/Configurations/KanbanTaskConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class KanbanTaskConfiguration : IEntityTypeConfiguration<KanbanTask>
    {
        public void Configure(EntityTypeBuilder<KanbanTask> builder)
        {
            builder.ToTable("kanban_tasks");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id");

            builder.Property(t => t.KanbanColumnId).HasColumnName("kanban_column_id").IsRequired();
            builder.Property(t => t.Title).HasColumnName("title").HasMaxLength(200).IsRequired();
            builder.Property(t => t.Description).HasColumnName("description").HasMaxLength(2000);
            builder.Property(t => t.OrderIndex).HasColumnName("order_index").IsRequired();
            builder.Property(t => t.DueDate).HasColumnName("due_date");
            builder.Property(t => t.AssigneeId).HasColumnName("assignee_id");
            builder.HasIndex(t => t.AssigneeId).HasDatabaseName("ix_kanban_tasks_assignee_id");
            builder.Property(t => t.TestCaseId).HasColumnName("test_case_id");
            builder.Property(t => t.PriorityId).HasColumnName("priority_id").IsRequired();

            // Auditoría y Borrado Lógico
            builder.Property(t => t.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(t => t.DeletedAt).HasColumnName("deleted_at");
            builder.Property(t => t.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(t => t.CreatedAt).HasColumnName("created_at");
            builder.Property(t => t.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(t => t.UpdatedAt).HasColumnName("updated_at");
            builder.Property(t => t.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relación con KanbanColumn
            builder.HasOne(t => t.Column)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.KanbanColumnId)
                .OnDelete(DeleteBehavior.Cascade);

            // RELACIÓN CRÍTICA: Responsable de la tarea (ResponsibleUser)
            builder.HasOne(t => t.ResponsibleUser)
                .WithMany(u => u.ResponsibleForTasks)
                .HasForeignKey(t => t.AssigneeId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación con TestCase (Opcional)
            builder.HasOne(t => t.TestCase)
                .WithMany()
                .HasForeignKey(t => t.TestCaseId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación con Priority (Catálogo)
            builder.HasOne(t => t.Priority)
                .WithMany()
                .HasForeignKey(t => t.PriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con CreatedBy
            builder.HasOne(t => t.CreatedBy)
                .WithMany()
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación con UpdatedBy
            builder.HasOne(t => t.UpdatedBy)
                .WithMany()
                .HasForeignKey(t => t.UpdatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación con DeletedBy
            builder.HasOne(t => t.DeletedBy)
                .WithMany()
                .HasForeignKey(t => t.DeletedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
