// src/QAMS.Infrastructure/Persistence/Configurations/DefectSeverityConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class DefectSeverityConfiguration : IEntityTypeConfiguration<DefectSeverity>
    {
        public void Configure(EntityTypeBuilder<DefectSeverity> builder)
        {
            builder.ToTable("defect_severities");
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

            // Seed data: severidades ISTQB
            builder.HasData(
                new DefectSeverity { Id = 1, Code = "MINOR", Name = "Menor", SortOrder = 1 },
                new DefectSeverity { Id = 2, Code = "MAJOR", Name = "Mayor", SortOrder = 2 },
                new DefectSeverity { Id = 3, Code = "CRITICAL", Name = "Crítica", SortOrder = 3 },
                new DefectSeverity { Id = 4, Code = "BLOCKER", Name = "Bloqueante", SortOrder = 4 }
            );
        }
    }
}
