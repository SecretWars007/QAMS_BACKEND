// src/QAMS.Infrastructure/Persistence/Configurations/EvidenceConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class EvidenceConfiguration : IEntityTypeConfiguration<Evidence>
    {
        public void Configure(EntityTypeBuilder<Evidence> builder)
        {
            builder.ToTable("evidences");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.TestExecutionId).HasColumnName("test_execution_id").IsRequired();
            builder.Property(e => e.ExecutionStepResultId).HasColumnName("execution_step_result_id");
            builder.Property(e => e.FileTypeId).HasColumnName("file_type_id").IsRequired();
            builder.Property(e => e.FileName).HasColumnName("file_name").HasMaxLength(255).IsRequired();
            builder.Property(e => e.FilePath).HasColumnName("file_path").HasMaxLength(1000).IsRequired();
            builder.Property(e => e.FileSize).HasColumnName("file_size");
            builder.Property(e => e.ContentType).HasColumnName("content_type").HasMaxLength(100);
            builder.Property(e => e.Description).HasColumnName("description").HasMaxLength(2000);
            builder.Property(e => e.UploadedAt).HasColumnName("uploaded_at").HasDefaultValueSql("NOW()");

            builder
                .HasOne(e => e.TestExecution)
                .WithMany(te => te.Evidences)
                .HasForeignKey(e => e.TestExecutionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.ExecutionStepResult)
                .WithMany(esr => esr.Evidences)
                .HasForeignKey(e => e.ExecutionStepResultId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(e => e.FileType)
                .WithMany()
                .HasForeignKey(e => e.FileTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
