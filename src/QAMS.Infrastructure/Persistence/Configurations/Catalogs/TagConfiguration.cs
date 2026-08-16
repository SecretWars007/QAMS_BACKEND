// src/QAMS.Infrastructure/Persistence/Configurations/Catalogs/TagConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations.Catalogs
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("tags");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Code).HasColumnName("code").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(255);

            builder.HasData(
                new Tag { Id = 1, Code = "SMOKE", Name = "Smoke Test", Description = "Prueba de humo básica" },
                new Tag { Id = 2, Code = "REGRESSION", Name = "Regresión", Description = "Pruebas de regresión completa" },
                new Tag { Id = 3, Code = "SANITY", Name = "Sanity Test", Description = "Prueba de sanidad tras un bug fix" },
                new Tag { Id = 4, Code = "RELEASE", Name = "Release Readiness", Description = "Pruebas obligatorias para paso a prod" },
                new Tag { Id = 5, Code = "PERFORMANCE", Name = "Performance", Description = "Relacionado con rendimiento" },
                new Tag { Id = 6, Code = "SECURITY", Name = "Seguridad", Description = "Pruebas de seguridad" }
            );
        }
    }
}
