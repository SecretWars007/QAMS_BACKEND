// src/QAMS.Infrastructure/Persistence/Configurations/Catalogs/TestPlanStatusConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations.Catalogs
{
    public class TestPlanStatusConfiguration : IEntityTypeConfiguration<TestPlanStatus>
    {
        public void Configure(EntityTypeBuilder<TestPlanStatus> builder)
        {
            builder.ToTable("test_plan_statuses");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            // ISTQB Test Plan Lifecycle
            builder.HasData(
                new TestPlanStatus { Id = 1, Code = "DRAFT", Name = "Borrador", Description = "Plan de pruebas en elaboración", IsActive = true, SortOrder = 1 },
                new TestPlanStatus { Id = 2, Code = "APPROVED", Name = "Aprobado", Description = "Plan de pruebas aprobado y listo", IsActive = true, SortOrder = 2 },
                new TestPlanStatus { Id = 3, Code = "IN_EXECUTION", Name = "En Ejecución", Description = "Pruebas en proceso de ejecución", IsActive = true, SortOrder = 3 },
                new TestPlanStatus { Id = 4, Code = "CLOSED", Name = "Cerrado", Description = "Plan de pruebas completado (criterios de salida cumplidos)", IsActive = true, SortOrder = 4 }
            );
        }
    }
}
