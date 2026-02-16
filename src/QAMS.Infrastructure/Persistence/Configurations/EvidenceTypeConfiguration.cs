// src/QAMS.Infrastructure/Persistence/Configurations/EvidenceTypeConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class EvidenceTypeConfiguration : IEntityTypeConfiguration<EvidenceType>
    {
        public void Configure(EntityTypeBuilder<EvidenceType> builder)
        {
            builder.ToTable("evidence_types");
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
                new EvidenceType { Id = 1, Code = "IMAGE", Name = "Imagen", SortOrder = 1 },
                new EvidenceType { Id = 2, Code = "VIDEO", Name = "Video", SortOrder = 2 },
                new EvidenceType { Id = 3, Code = "DOCUMENT", Name = "Documento", SortOrder = 3 },
                new EvidenceType { Id = 4, Code = "LOG_FILE", Name = "Archivo de Log", SortOrder = 4 }
            );
        }
    }
}
