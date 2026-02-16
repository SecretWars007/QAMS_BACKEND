// src/QAMS.Infrastructure/Persistence/Configurations/TestCaseConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestCaseConfiguration : IEntityTypeConfiguration<TestCase>
    {
        public void Configure(EntityTypeBuilder<TestCase> builder)
        {
            builder.ToTable("test_cases");

            builder.HasKey(tc => tc.Id);
            builder.Property(tc => tc.Id).HasColumnName("id");

            builder.Property(tc => tc.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(tc => tc.TestSuiteId).HasColumnName("test_suite_id").IsRequired();
            builder.Property(tc => tc.Title).HasColumnName("title").HasMaxLength(200).IsRequired();
            builder.Property(tc => tc.Description).HasColumnName("description").HasMaxLength(2000);
            builder.Property(tc => tc.Preconditions).HasColumnName("preconditions").HasMaxLength(1000);
            builder.Property(tc => tc.ExpectedResult).HasColumnName("expected_result").HasMaxLength(1000).IsRequired();
            builder.Property(tc => tc.PriorityId).HasColumnName("priority_id").IsRequired();
            builder.Property(tc => tc.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(tc => tc.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
            builder.Property(tc => tc.UpdatedAt).HasColumnName("updated_at");

            builder.Property(tc => tc.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(tc => tc.EstimatedTimeHours).HasColumnName("estimated_time_hours").HasColumnType("decimal(6,2)").HasDefaultValue(0);
            builder.Property(tc => tc.StartDate).HasColumnName("start_date");
            builder.Property(tc => tc.EndDate).HasColumnName("end_date");
            builder.Property(tc => tc.TestTypeId).HasColumnName("test_type_id").HasDefaultValue(1); // Default: Funcional Manual

            // Relación con Project
            builder.HasOne(tc => tc.Project)
                .WithMany(p => p.TestCases)
                .HasForeignKey(tc => tc.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con TestSuite
            builder.HasOne(tc => tc.TestSuite)
                .WithMany(ts => ts.TestCases)
                .HasForeignKey(tc => tc.TestSuiteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con Priority
            builder.HasOne(tc => tc.Priority)
                .WithMany(p => p.TestCases)
                .HasForeignKey(tc => tc.PriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con CreatedBy
            builder.HasOne(tc => tc.CreatedBy)
                .WithMany(u => u.CreatedTestCases)
                .HasForeignKey(tc => tc.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación con TestType
            builder.HasOne(tc => tc.TestType)
                .WithMany(tt => tt.TestCases)
                .HasForeignKey(tc => tc.TestTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
