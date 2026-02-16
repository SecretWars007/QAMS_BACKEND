// src/QAMS.Infrastructure/Persistence/Configurations/TestCasePriorityConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestCasePriorityConfiguration : IEntityTypeConfiguration<TestCasePriority>
    {
        public void Configure(EntityTypeBuilder<TestCasePriority> builder)
        {
            builder.ToTable("test_case_priorities");
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
                new TestCasePriority { Id = 1, Code = "LOW", Name = "Baja", SortOrder = 1 },
                new TestCasePriority { Id = 2, Code = "MEDIUM", Name = "Media", SortOrder = 2 },
                new TestCasePriority { Id = 3, Code = "HIGH", Name = "Alta", SortOrder = 3 },
                new TestCasePriority { Id = 4, Code = "CRITICAL", Name = "Crítica", SortOrder = 4 }
            );
        }
    }
}
