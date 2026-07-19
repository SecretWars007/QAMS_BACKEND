// src/QAMS.Infrastructure/Persistence/Configurations/Catalogs/ProjectStatusConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations.Catalogs
{
    public class ProjectStatusConfiguration : IEntityTypeConfiguration<ProjectStatus>
    {
        public void Configure(EntityTypeBuilder<ProjectStatus> builder)
        {
            builder.ToTable("project_statuses");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedNever(); // IDs fijos para seeds

            builder.Property(s => s.Code).HasMaxLength(20).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(250);

            // Seed Data
            builder.HasData(
                new ProjectStatus { Id = 1, Code = "PENDIENTE", Name = "Pendiente", Description = "Proyecto registrado pero no iniciado", SortOrder = 1, IsActive = true, CreatedAt = DateTime.UtcNow },
                new ProjectStatus { Id = 2, Code = "EN_PROCESO", Name = "En Proceso", Description = "Proyecto en ejecución activa", SortOrder = 2, IsActive = true, CreatedAt = DateTime.UtcNow },
                new ProjectStatus { Id = 3, Code = "DETENIDO", Name = "Detenido", Description = "Proyecto pausado o cancelado temporalmente", SortOrder = 3, IsActive = true, CreatedAt = DateTime.UtcNow },
                new ProjectStatus { Id = 4, Code = "CERTIFICADO", Name = "Certificado", Description = "Proyecto completado y validado", SortOrder = 4, IsActive = true, CreatedAt = DateTime.UtcNow },
                new ProjectStatus { Id = 5, Code = "DEVOLUCION", Name = "Devolución", Description = "Proyecto devuelto por falta de aprobación o errores graves", SortOrder = 5, IsActive = true, CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
