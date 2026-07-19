// src/QAMS.Infrastructure/Persistence/Configurations/DefectStatusConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class DefectStatusConfiguration : IEntityTypeConfiguration<DefectStatus>
    {
        public void Configure(EntityTypeBuilder<DefectStatus> builder)
        {
            builder.ToTable("defect_statuses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(e => e.Code).HasColumnName("code").HasMaxLength(50).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(e => e.SortOrder).HasColumnName("sort_order").HasDefaultValue(0);
            builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");

            // Seed data: ciclo de vida del defecto ISTQB
            builder.HasData(
                new DefectStatus { Id = 1, Code = "OPEN", Name = "Abierto", Description = "Defecto recién reportado", SortOrder = 1 },
                new DefectStatus { Id = 2, Code = "IN_PROGRESS", Name = "En Progreso", Description = "En corrección por el equipo", SortOrder = 2 },
                new DefectStatus { Id = 3, Code = "RESOLVED", Name = "Resuelto", Description = "Corregido, pendiente verificación", SortOrder = 3 },
                new DefectStatus { Id = 4, Code = "CLOSED", Name = "Cerrado", Description = "Verificado y cerrado", SortOrder = 4 },
                new DefectStatus { Id = 5, Code = "REJECTED", Name = "Rechazado", Description = "No es un defecto válido", SortOrder = 5 }
            );
        }
    }
}
