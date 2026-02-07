// src/QAMS.Infrastructure/Persistence/Configurations/ExecutionStatusConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ExecutionStatusConfiguration : IEntityTypeConfiguration<ExecutionStatus>
    {
        public void Configure(EntityTypeBuilder<ExecutionStatus> builder)
        {
            builder.ToTable("execution_statuses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(e => e.Code).HasColumnName("code").HasMaxLength(50).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(e => e.SortOrder).HasColumnName("sort_order").HasDefaultValue(0);
            builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder
                .Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("NOW()");

            builder.HasData(
                new ExecutionStatus
                {
                    Id = 1,
                    Code = "PENDING",
                    Name = "Pendiente",
                    Description = "Ejecución creada pero no iniciada.",
                    SortOrder = 1,
                },
                new ExecutionStatus
                {
                    Id = 2,
                    Code = "IN_PROGRESS",
                    Name = "En Progreso",
                    Description = "Ejecución en curso.",
                    SortOrder = 2,
                },
                new ExecutionStatus
                {
                    Id = 3,
                    Code = "PASSED",
                    Name = "Aprobado",
                    Description = "Todos los pasos exitosos.",
                    SortOrder = 3,
                },
                new ExecutionStatus
                {
                    Id = 4,
                    Code = "FAILED",
                    Name = "Fallido",
                    Description = "Al menos un paso falló.",
                    SortOrder = 4,
                },
                new ExecutionStatus
                {
                    Id = 5,
                    Code = "BLOCKED",
                    Name = "Bloqueado",
                    Description = "Impedimento externo.",
                    SortOrder = 5,
                },
                new ExecutionStatus
                {
                    Id = 6,
                    Code = "SKIPPED",
                    Name = "Omitido",
                    Description = "Omitido intencionalmente.",
                    SortOrder = 6,
                }
            );
        }
    }
}
