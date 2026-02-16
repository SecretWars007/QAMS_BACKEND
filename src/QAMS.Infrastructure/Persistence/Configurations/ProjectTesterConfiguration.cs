// src/QAMS.Infrastructure/Persistence/Configurations/ProjectTesterConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ProjectTesterConfiguration : IEntityTypeConfiguration<ProjectTester>
    {
        public void Configure(EntityTypeBuilder<ProjectTester> builder)
        {
            builder.ToTable("project_testers");
            builder.HasKey(pt => new { pt.ProjectId, pt.UserId });

            builder.Property(pt => pt.ProjectId).HasColumnName("project_id");
            builder.Property(pt => pt.UserId).HasColumnName("user_id");
            builder.Property(pt => pt.AssignedAt).HasColumnName("assigned_at").IsRequired().HasDefaultValueSql("NOW()");

            builder.HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTesters)
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.User)
                .WithMany(u => u.ProjectAssignments)
                .HasForeignKey(pt => pt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
