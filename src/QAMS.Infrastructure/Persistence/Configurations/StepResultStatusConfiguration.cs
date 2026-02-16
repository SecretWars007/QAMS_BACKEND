// src/QAMS.Infrastructure/Persistence/Configurations/StepResultStatusConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class StepResultStatusConfiguration : IEntityTypeConfiguration<StepResultStatus>
    {
        public void Configure(EntityTypeBuilder<StepResultStatus> builder)
        {
            builder.ToTable("step_result_statuses");
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
                new StepResultStatus { Id = 1, Code = "NOT_EXECUTED", Name = "No Ejecutado", SortOrder = 1 },
                new StepResultStatus { Id = 2, Code = "PASSED", Name = "Aprobado", SortOrder = 2 },
                new StepResultStatus { Id = 3, Code = "FAILED", Name = "Fallido", SortOrder = 3 },
                new StepResultStatus { Id = 4, Code = "BLOCKED", Name = "Bloqueado", SortOrder = 4 }
            );
        }
    }
}
