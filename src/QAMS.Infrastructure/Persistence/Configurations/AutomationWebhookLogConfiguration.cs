// src/QAMS.Infrastructure/Persistence/Configurations/AutomationWebhookLogConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class AutomationWebhookLogConfiguration : IEntityTypeConfiguration<AutomationWebhookLog>
    {
        public void Configure(EntityTypeBuilder<AutomationWebhookLog> builder)
        {
            builder.ToTable("automation_webhook_logs");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).HasColumnName("id");

            builder.Property(l => l.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(l => l.Source).HasColumnName("source").HasMaxLength(200).IsRequired();
            builder.Property(l => l.PayloadFormat).HasColumnName("payload_format").HasMaxLength(50).HasDefaultValue("junit_xml");
            builder.Property(l => l.TotalTests).HasColumnName("total_tests").HasDefaultValue(0);
            builder.Property(l => l.PassedTests).HasColumnName("passed_tests").HasDefaultValue(0);
            builder.Property(l => l.FailedTests).HasColumnName("failed_tests").HasDefaultValue(0);
            builder.Property(l => l.SkippedTests).HasColumnName("skipped_tests").HasDefaultValue(0);
            builder.Property(l => l.ProcessingStatus).HasColumnName("processing_status").HasMaxLength(20).HasDefaultValue("SUCCESS");
            builder.Property(l => l.ErrorMessage).HasColumnName("error_message").HasMaxLength(1000);
            builder.Property(l => l.RawPayload).HasColumnName("raw_payload").HasColumnType("text");

            // IAuditable
            builder.Property(l => l.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
            builder.Property(l => l.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(l => l.UpdatedAt).HasColumnName("updated_at");
            builder.Property(l => l.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relación con Project
            builder.HasOne(l => l.Project)
                .WithMany()
                .HasForeignKey(l => l.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(l => l.ProjectId);
            builder.HasIndex(l => l.CreatedAt);
        }
    }
}
