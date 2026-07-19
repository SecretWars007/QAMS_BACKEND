// src/QAMS.Infrastructure/Persistence/Configurations/RequirementTestCaseConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class RequirementTestCaseConfiguration : IEntityTypeConfiguration<RequirementTestCase>
    {
        public void Configure(EntityTypeBuilder<RequirementTestCase> builder)
        {
            builder.ToTable("requirement_test_cases");

            // PK compuesta (4FN: relación pura sin surrogate key)
            builder.HasKey(rtc => new { rtc.RequirementId, rtc.TestCaseId });
            builder.Property(rtc => rtc.RequirementId).HasColumnName("requirement_id");
            builder.Property(rtc => rtc.TestCaseId).HasColumnName("test_case_id");

            // Auditoría
            builder.Property(rtc => rtc.CreatedAt).HasColumnName("created_at");
            builder.Property(rtc => rtc.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(rtc => rtc.UpdatedAt).HasColumnName("updated_at");
            builder.Property(rtc => rtc.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relación: Requisito → TestCases
            builder.HasOne(rtc => rtc.Requirement)
                .WithMany(r => r.RequirementTestCases)
                .HasForeignKey(rtc => rtc.RequirementId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación: TestCase → Requisitos
            builder.HasOne(rtc => rtc.TestCase)
                .WithMany(tc => tc.RequirementTestCases)
                .HasForeignKey(rtc => rtc.TestCaseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
