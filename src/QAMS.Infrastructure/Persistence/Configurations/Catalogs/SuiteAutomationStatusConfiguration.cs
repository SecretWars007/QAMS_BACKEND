// src/QAMS.Infrastructure/Persistence/Configurations/Catalogs/SuiteAutomationStatusConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations.Catalogs
{
    public class SuiteAutomationStatusConfiguration : IEntityTypeConfiguration<SuiteAutomationStatus>
    {
        public void Configure(EntityTypeBuilder<SuiteAutomationStatus> builder)
        {
            builder.ToTable("suite_automation_statuses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Code).HasColumnName("code").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(255);

            builder.HasData(
                new SuiteAutomationStatus { Id = 1, Code = "MANUAL", Name = "MANUAL", Description = "Ejecución totalmente manual" },
                new SuiteAutomationStatus { Id = 2, Code = "PARTIAL", Name = "PARCIALMENTE AUTOMATIZADA", Description = "Ejecución con soporte de scripts/herramientas" },
                new SuiteAutomationStatus { Id = 3, Code = "AUTOMATED", Name = "TOTALMENTE AUTOMATIZADA", Description = "Ejecución desatendida vía pipeline" }
            );
        }
    }
}
