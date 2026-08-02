// src/QAMS.Infrastructure/Persistence/Configurations/TestEnvironmentConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestEnvironmentConfiguration : IEntityTypeConfiguration<TestEnvironment>
    {
        public void Configure(EntityTypeBuilder<TestEnvironment> builder)
        {
            builder.ToTable("test_environments");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(200).IsRequired();
            builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(1000);
            builder.Property(e => e.BaseUrl).HasColumnName("base_url").HasMaxLength(500);
            builder.Property(e => e.OperatingSystem).HasColumnName("operating_system").HasMaxLength(200);
            builder.Property(e => e.Browser).HasColumnName("browser").HasMaxLength(200);
            builder.Property(e => e.EnvironmentType).HasColumnName("environment_type").HasMaxLength(50).HasDefaultValue("QA");
            builder.Property(e => e.SoftwareVersion).HasColumnName("software_version").HasMaxLength(100);
            builder.Property(e => e.AdditionalConfig).HasColumnName("additional_config").HasMaxLength(2000);
            builder.Property(e => e.IsActive).HasColumnName("is_active").HasDefaultValue(true);

            // ISoftDelete
            builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            builder.Property(e => e.DeletedByUserId).HasColumnName("deleted_by_user_id");

            // IAuditable
            builder.Property(e => e.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
            builder.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            builder.Property(e => e.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relación con Project
            builder.HasOne(e => e.Project)
                .WithMany()
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(e => e.ProjectId);
            builder.HasIndex(e => new { e.ProjectId, e.Name }).IsUnique();
        }
    }
}
