using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;
using QAMS.Domain.Constants;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("id");
            builder.Property(r => r.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.HasIndex(r => r.Name).IsUnique();
            builder.Property(r => r.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(r => r.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(r => r.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");

            builder.HasData(
                new Role
                {
                    Id = QAMS.Domain.Constants.SystemRoles.AdminRoleId,
                    Name = "Administrator",
                    Description = "Acceso total al sistema",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Role
                {
                    Id = QAMS.Domain.Constants.SystemRoles.TesterRoleId,
                    Name = "Tester",
                    Description = "Ejecución y gestión de pruebas",
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
