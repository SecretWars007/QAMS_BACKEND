// src/QAMS.Infrastructure/Persistence/Configurations/ApiKeyConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
    {
        public void Configure(EntityTypeBuilder<ApiKey> builder)
        {
            builder.ToTable("api_keys");

            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).HasColumnName("id");

            builder.Property(k => k.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(k => k.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(k => k.KeyHash).HasColumnName("key_hash").HasMaxLength(256).IsRequired();
            builder.Property(k => k.KeyPrefix).HasColumnName("key_prefix").HasMaxLength(16).IsRequired();
            builder.Property(k => k.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(k => k.ExpiresAt).HasColumnName("expires_at");
            builder.Property(k => k.LastUsedAt).HasColumnName("last_used_at");

            // Auditoría
            builder.Property(k => k.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(k => k.DeletedAt).HasColumnName("deleted_at");
            builder.Property(k => k.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(k => k.CreatedAt).HasColumnName("created_at");
            builder.Property(k => k.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(k => k.UpdatedAt).HasColumnName("updated_at");
            builder.Property(k => k.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relaciones
            builder.HasOne(k => k.Project)
                .WithMany(p => p.ApiKeys)
                .HasForeignKey(k => k.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(k => k.CreatedBy)
                .WithMany()
                .HasForeignKey(k => k.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(k => k.UpdatedBy)
                .WithMany()
                .HasForeignKey(k => k.UpdatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(k => k.DeletedBy)
                .WithMany()
                .HasForeignKey(k => k.DeletedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Índice único en KeyPrefix para búsquedas rápidas
            builder.HasIndex(k => k.KeyPrefix).HasDatabaseName("IX_api_keys_key_prefix");
            builder.HasIndex(k => new { k.ProjectId, k.IsActive }).HasDatabaseName("IX_api_keys_project_active");
        }
    }
}
