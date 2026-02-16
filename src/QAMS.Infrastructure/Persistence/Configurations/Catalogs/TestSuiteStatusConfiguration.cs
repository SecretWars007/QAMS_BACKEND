// src/QAMS.Infrastructure/Persistence/Configurations/Catalogs/TestSuiteStatusConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations.Catalogs
{
    public class TestSuiteStatusConfiguration : IEntityTypeConfiguration<TestSuiteStatus>
    {
        public void Configure(EntityTypeBuilder<TestSuiteStatus> builder)
        {
            builder.ToTable("test_suite_statuses");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("id");
            builder.Property(s => s.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            builder.Property(s => s.Description).HasColumnName("description").HasMaxLength(200);

            builder.HasData(
                new TestSuiteStatus { Id = 1, Code = "PENDIENTE", Name = "PENDIENTE", Description = "Suite pendiente de ejecución" },
                new TestSuiteStatus { Id = 2, Code = "EN_PROCESO", Name = "EN PROCESO", Description = "Suite en ejecución activa" },
                new TestSuiteStatus { Id = 3, Code = "COMPLETADO", Name = "COMPLETADO", Description = "Todos los casos de la suite ejecutados" },
                new TestSuiteStatus { Id = 4, Code = "DETENIDO", Name = "DETENIDO", Description = "Ejecución de la suite pausada" }
            );
        }
    }
}
