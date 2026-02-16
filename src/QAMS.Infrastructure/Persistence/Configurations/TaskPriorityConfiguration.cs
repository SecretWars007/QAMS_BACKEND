// src/QAMS.Infrastructure/Persistence/Configurations/TaskPriorityConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TaskPriorityConfiguration : IEntityTypeConfiguration<TaskPriority>
    {
        public void Configure(EntityTypeBuilder<TaskPriority> builder)
        {
            builder.ToTable("task_priorities");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(e => e.Code).HasColumnName("code").HasMaxLength(50).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(e => e.SortOrder).HasColumnName("sort_order").HasDefaultValue(0);
            builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");

            builder.HasData(
                new TaskPriority { Id = 1, Code = "LOW", Name = "Baja", SortOrder = 1 },
                new TaskPriority { Id = 2, Code = "MEDIUM", Name = "Media", SortOrder = 2 },
                new TaskPriority { Id = 3, Code = "HIGH", Name = "Alta", SortOrder = 3 },
                new TaskPriority { Id = 4, Code = "CRITICAL", Name = "Crítica", SortOrder = 4 }
            );
        }
    }
}
