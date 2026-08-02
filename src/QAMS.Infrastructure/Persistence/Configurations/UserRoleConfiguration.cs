using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("user_roles");
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.Property(ur => ur.UserId).HasColumnName("user_id");
            builder.Property(ur => ur.RoleId).HasColumnName("role_id");
            builder.Property(ur => ur.AssignedAt).HasColumnName("assigned_at").IsRequired();

            // ISoftDelete mapping (Matching PascalCase columns in DB for this specific table)
            builder.Property(ur => ur.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(ur => ur.DeletedAt).HasColumnName("DeletedAt");
            builder.Property(ur => ur.DeletedByUserId).HasColumnName("DeletedByUserId");

            // IAuditable mapping (Matching PascalCase columns in DB for this specific table)
            builder.Property(ur => ur.CreatedAt).HasColumnName("CreatedAt").HasDefaultValueSql("NOW()");
            builder.Property(ur => ur.CreatedByUserId).HasColumnName("CreatedByUserId");
            builder.Property(ur => ur.UpdatedAt).HasColumnName("UpdatedAt");
            builder.Property(ur => ur.UpdatedByUserId).HasColumnName("UpdatedByUserId");

            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new UserRole
                {
                    UserId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    RoleId = QAMS.Domain.Constants.SystemRoles.AdminRoleId,
                    AssignedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new UserRole
                {
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    RoleId = QAMS.Domain.Constants.SystemRoles.TesterRoleId,
                    AssignedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new UserRole
                {
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    RoleId = QAMS.Domain.Constants.SystemRoles.TesterRoleId,
                    AssignedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new UserRole
                {
                    UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    RoleId = QAMS.Domain.Constants.SystemRoles.DeveloperRoleId,
                    AssignedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new UserRole
                {
                    UserId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    RoleId = QAMS.Domain.Constants.SystemRoles.DeveloperRoleId,
                    AssignedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
