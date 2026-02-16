using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public static readonly Guid AdminUserId = new Guid("99999999-9999-9999-9999-999999999999");

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.Username).HasColumnName("username").HasMaxLength(100).IsRequired();
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.Email).HasColumnName("email").HasMaxLength(150).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.PasswordHash).HasColumnName("password_hash").IsRequired();
            builder.Property(u => u.FullName).HasColumnName("full_name").HasMaxLength(200).IsRequired();
            builder.Property(u => u.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(u => u.RefreshToken).HasColumnName("refresh_token");
            builder.Property(u => u.RefreshTokenExpiryTime).HasColumnName("refresh_token_expiry_time");
            builder.Property(u => u.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
            builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");

            builder.HasData(
                new User
                {
                    Id = AdminUserId,
                    Username = "admin",
                    Email = "admin@qams.local",
                    // Hash verified for "Admin123!" (BCrypt 60 chars)
                    PasswordHash = "$2a$12$0jdJPZWmFkqBX5PmpGsjaeXoZqGvvD1fUOifS6Foj9guzZVPZzo.C",
                    FullName = "Administrador Base",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
