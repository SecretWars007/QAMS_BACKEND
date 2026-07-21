// src/QAMS.Infrastructure/Persistence/Configurations/SystemUnderTestConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class SystemUnderTestConfiguration : IEntityTypeConfiguration<SystemUnderTest>
    {
        public void Configure(EntityTypeBuilder<SystemUnderTest> builder)
        {
            builder.ToTable("systems_under_test");
            builder.HasKey(sut => sut.Id);
            builder.Property(sut => sut.Id).HasColumnName("id");
            builder.Property(sut => sut.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(sut => sut.Name).HasColumnName("name").IsRequired().HasMaxLength(150);
            builder.Property(sut => sut.Description).HasColumnName("description").HasMaxLength(1000);
            builder.Property(sut => sut.Version).HasColumnName("version").HasMaxLength(50);
            builder.Property(sut => sut.Environment).HasColumnName("environment").HasMaxLength(50);
            builder.Property(sut => sut.PlatformTypeId).HasColumnName("platform_type_id").HasDefaultValue(1);
            builder.Property(sut => sut.BaseUrl).HasColumnName("base_url").HasMaxLength(255);
            builder.Property(sut => sut.ExecutablePath).HasColumnName("executable_path").HasMaxLength(500);
            builder.Property(sut => sut.ProcessName).HasColumnName("process_name").HasMaxLength(255);
            builder.Property(sut => sut.IsActive).HasColumnName("is_active").HasDefaultValue(true);

            // Auditoría y Borrado Lógico
            builder.Property(sut => sut.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(sut => sut.DeletedAt).HasColumnName("deleted_at");
            builder.Property(sut => sut.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(sut => sut.CreatedAt).HasColumnName("created_at");
            builder.Property(sut => sut.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(sut => sut.UpdatedAt).HasColumnName("updated_at");
            builder.Property(sut => sut.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relationships
            builder.HasOne(sut => sut.Project)
                .WithMany(p => p.SystemsUnderTest)
                .HasForeignKey(sut => sut.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sut => sut.PlatformType)
                .WithMany(pt => pt.SystemsUnderTest)
                .HasForeignKey(sut => sut.PlatformTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sut => sut.CreatedBy)
                .WithMany()
                .HasForeignKey(sut => sut.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(sut => sut.UpdatedBy)
                .WithMany()
                .HasForeignKey(sut => sut.UpdatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(sut => sut.DeletedBy)
                .WithMany()
                .HasForeignKey(sut => sut.DeletedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
