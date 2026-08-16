// src/QAMS.Infrastructure/Persistence/Configurations/TestCaseCertifierConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestCaseCertifierConfiguration : IEntityTypeConfiguration<TestCaseCertifier>
    {
        public void Configure(EntityTypeBuilder<TestCaseCertifier> builder)
        {
            builder.ToTable("test_case_certifiers");

            // Clave compuesta
            builder.HasKey(tc => new { tc.TestCaseId, tc.UserId });

            builder.Property(tc => tc.TestCaseId).HasColumnName("test_case_id");
            builder.Property(tc => tc.UserId).HasColumnName("user_id");
            builder.Property(tc => tc.AssignedAt).HasColumnName("assigned_at").HasDefaultValueSql("NOW()");

            // Relación con TestCase
            builder.HasOne(tc => tc.TestCase)
                .WithMany()
                .HasForeignKey(tc => tc.TestCaseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con User
            builder.HasOne(tc => tc.User)
                .WithMany(u => u.CertifyingTestCases)
                .HasForeignKey(tc => tc.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
