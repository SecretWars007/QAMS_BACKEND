// src/QAMS.Infrastructure/Persistence/Configurations/Catalogs/TestTypeConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations.Catalogs
{
    public class TestTypeConfiguration : IEntityTypeConfiguration<TestType>
    {
        public void Configure(EntityTypeBuilder<TestType> builder)
        {
            builder.ToTable("test_types");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedNever(); // IDs fijos para seeds

            builder.Property(t => t.Code).HasMaxLength(30).IsRequired();
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(250);

            // Seed Data
            builder.HasData(
                new TestType { Id = 1, Code = "FUNCTIONAL_MANUAL", Name = "Funcional Manual", Description = "Prueba funcional ejecutada manualmente", SortOrder = 1, IsActive = true, CreatedAt = DateTime.UtcNow },
                new TestType { Id = 2, Code = "FUNCTIONAL_AUTOMATED", Name = "Funcional Automatizada", Description = "Prueba funcional automatizada", SortOrder = 2, IsActive = true, CreatedAt = DateTime.UtcNow },
                new TestType { Id = 3, Code = "NON_FUNCTIONAL", Name = "No Funcional", Description = "Prueba de rendimiento, seguridad, usabilidad, etc.", SortOrder = 3, IsActive = true, CreatedAt = DateTime.UtcNow },
                new TestType { Id = 4, Code = "REGRESSION", Name = "Regresión", Description = "Prueba para verificar que cambios no rompieron funcionalidad existente", SortOrder = 4, IsActive = true, CreatedAt = DateTime.UtcNow },
                new TestType { Id = 5, Code = "SMOKE", Name = "Smoke Test", Description = "Prueba rápida de funcionalidad crítica", SortOrder = 5, IsActive = true, CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
