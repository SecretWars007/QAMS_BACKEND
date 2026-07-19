using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);

            // Columnas confirmadas en la tabla física de tests (via Snapshot + migraciones)
            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.Username).HasColumnName("username").HasMaxLength(100).IsRequired();
            builder.Property(u => u.Email).HasColumnName("email").HasMaxLength(150).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnName("password_hash").IsRequired();
            builder.Property(u => u.FullName).HasColumnName("full_name").HasMaxLength(200).IsRequired();
            builder.Property(u => u.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(u => u.DocumentoIdentidad).HasColumnName("documento_identidad").HasMaxLength(20).IsRequired();
            builder.Property(u => u.FechaNacimiento).HasColumnName("fecha_nacimiento");
            builder.Property(u => u.Telefono).HasColumnName("telefono").HasMaxLength(20);
            builder.Property(u => u.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(u => u.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
            builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");
            builder.Property(u => u.RefreshToken).HasColumnName("refresh_token");
            builder.Property(u => u.RefreshTokenExpiryTime).HasColumnName("refresh_token_expiry_time");

            // IGNORAR todas las propiedades que NO existen como columnas en la tabla física de tests
            builder.Ignore(u => u.DeletedAt);           // No existe en la tabla users de tests
            builder.Ignore(u => u.DeletedByUserId);     // No existe + evita auditoría recursiva
            builder.Ignore(u => u.CreatedByUserId);     // No existe + evita auditoría recursiva
            builder.Ignore(u => u.UpdatedByUserId);     // No existe + evita auditoría recursiva
            builder.Ignore(u => u.AccessFailedCount);   // No existe en la tabla users de tests
            builder.Ignore(u => u.LockoutEnd);          // No existe en la tabla users de tests

            builder.Property(u => u.PasswordResetToken).HasColumnName("PasswordResetToken").HasMaxLength(100);
            builder.Property(u => u.PasswordResetTokenExpiryTime).HasColumnName("PasswordResetTokenExpiryTime");

            // Índices únicos
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => new { u.DocumentoIdentidad, u.FechaNacimiento }).IsUnique();

            // Relaciones con otras entidades
            builder.HasMany(u => u.UserRoles)
                   .WithOne(ur => ur.User)
                   .HasForeignKey(ur => ur.UserId);

            builder.HasMany(u => u.ResponsibleForTasks)
                   .WithOne(t => t.ResponsibleUser)
                   .HasForeignKey(t => t.AssigneeId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.TestExecutions)
                   .WithOne(te => te.Tester)
                   .HasForeignKey(te => te.TesterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.ProjectAssignments)
                   .WithOne(pt => pt.User)
                   .HasForeignKey(pt => pt.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.CreatedProjects)
                   .WithOne(p => p.CreatedBy)
                   .HasForeignKey(p => p.CreatedByUserId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.CreatedTestCases)
                   .WithOne(tc => tc.CreatedBy)
                   .HasForeignKey(tc => tc.CreatedByUserId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(u => u.CertifyingTestCases)
                   .WithOne(tcc => tcc.User)
                   .HasForeignKey(tcc => tcc.UserId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Seed Data alineado con el Snapshot (ID 99999...)
            builder.HasData(
                new
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    Username = "admin",
                    Email = "admin@qams.local",
                    PasswordHash = "$2a$12$0jdJPZWmFkqBX5PmpGsjaeXoZqGvvD1fUOifS6Foj9guzZVPZzo.C",
                    FullName = "Administrador Base",
                    DocumentoIdentidad = "00000000",
                    FechaNacimiento = new DateOnly(1990, 1, 1),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
