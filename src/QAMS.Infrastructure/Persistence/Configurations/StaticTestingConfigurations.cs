// src/QAMS.Infrastructure/Persistence/Configurations/StaticTestingConfigurations.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ReviewSessionConfiguration : IEntityTypeConfiguration<ReviewSession>
    {
        public void Configure(EntityTypeBuilder<ReviewSession> builder)
        {
            builder.ToTable("review_sessions");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("id");
            builder.Property(s => s.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(s => s.Title).HasColumnName("title").HasMaxLength(200).IsRequired();
            builder.Property(s => s.Description).HasColumnName("description").HasMaxLength(2000);
            builder.Property(s => s.ArtifactUnderReview).HasColumnName("artifact_under_review").HasMaxLength(500);
            builder.Property(s => s.ReviewTypeId).HasColumnName("review_type_id").IsRequired();
            builder.Property(s => s.StatusId).HasColumnName("status_id").IsRequired();
            builder.Property(s => s.ScheduledDate).HasColumnName("scheduled_date");
            builder.Property(s => s.CompletedDate).HasColumnName("completed_date");
            builder.Property(s => s.ModeratorId).HasColumnName("moderator_id");
            builder.Property(s => s.AuthorId).HasColumnName("author_id");
            builder.Property(s => s.EntryCriteria).HasColumnName("entry_criteria").HasMaxLength(1000);
            builder.Property(s => s.ExitCriteria).HasColumnName("exit_criteria").HasMaxLength(1000);
            builder.Property(s => s.Conclusions).HasColumnName("conclusions").HasMaxLength(2000);

            // Auditoría y Borrado Lógico
            builder.Property(s => s.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(s => s.DeletedAt).HasColumnName("deleted_at");
            builder.Property(s => s.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(s => s.CreatedAt).HasColumnName("created_at");
            builder.Property(s => s.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(s => s.UpdatedAt).HasColumnName("updated_at");
            builder.Property(s => s.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relaciones
            builder.HasOne(s => s.Project)
                .WithMany()
                .HasForeignKey(s => s.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.ReviewType)
                .WithMany()
                .HasForeignKey(s => s.ReviewTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Status)
                .WithMany()
                .HasForeignKey(s => s.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Moderator)
                .WithMany()
                .HasForeignKey(s => s.ModeratorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.Author)
                .WithMany()
                .HasForeignKey(s => s.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }

    public class ReviewFindingConfiguration : IEntityTypeConfiguration<ReviewFinding>
    {
        public void Configure(EntityTypeBuilder<ReviewFinding> builder)
        {
            builder.ToTable("review_findings");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).HasColumnName("id");
            builder.Property(f => f.ReviewSessionId).HasColumnName("review_session_id").IsRequired();
            builder.Property(f => f.Description).HasColumnName("description").HasMaxLength(2000).IsRequired();
            builder.Property(f => f.Location).HasColumnName("location").HasMaxLength(250);
            builder.Property(f => f.FindingTypeId).HasColumnName("finding_type_id").IsRequired();
            builder.Property(f => f.SeverityId).HasColumnName("severity_id").IsRequired();
            builder.Property(f => f.FindingStatusId).HasColumnName("finding_status_id").IsRequired();
            builder.Property(f => f.AssignedToId).HasColumnName("assigned_to_id");
            builder.Property(f => f.Resolution).HasColumnName("resolution").HasMaxLength(2000);
            builder.Property(f => f.ResolvedAt).HasColumnName("resolved_at");

            // Auditoría y Borrado Lógico
            builder.Property(f => f.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(f => f.DeletedAt).HasColumnName("deleted_at");
            builder.Property(f => f.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(f => f.CreatedAt).HasColumnName("created_at");
            builder.Property(f => f.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(f => f.UpdatedAt).HasColumnName("updated_at");
            builder.Property(f => f.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Relaciones
            builder.HasOne(f => f.ReviewSession)
                .WithMany(s => s.Findings)
                .HasForeignKey(f => f.ReviewSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.FindingType)
                .WithMany()
                .HasForeignKey(f => f.FindingTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Severity)
                .WithMany()
                .HasForeignKey(f => f.SeverityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.FindingStatus)
                .WithMany()
                .HasForeignKey(f => f.FindingStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.AssignedTo)
                .WithMany()
                .HasForeignKey(f => f.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }

    public class ReviewParticipantConfiguration : IEntityTypeConfiguration<ReviewParticipant>
    {
        public void Configure(EntityTypeBuilder<ReviewParticipant> builder)
        {
            builder.ToTable("review_participants");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ReviewSessionId).HasColumnName("review_session_id").IsRequired();
            builder.Property(p => p.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(p => p.Role).HasColumnName("role").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Attended).HasColumnName("attended").HasDefaultValue(false);
            builder.Property(p => p.InvitedAt).HasColumnName("invited_at").IsRequired();

            // Relaciones
            builder.HasOne(p => p.ReviewSession)
                .WithMany(s => s.Participants)
                .HasForeignKey(p => p.ReviewSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
