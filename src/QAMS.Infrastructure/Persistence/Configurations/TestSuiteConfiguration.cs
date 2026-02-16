// src/QAMS.Infrastructure/Persistence/Configurations/TestSuiteConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestSuiteConfiguration : IEntityTypeConfiguration<TestSuite>
    {
        public void Configure(EntityTypeBuilder<TestSuite> builder)
        {
            builder.ToTable("test_suites");
            builder.HasKey(ts => ts.Id);
            builder.Property(ts => ts.Id).HasColumnName("id");
            builder.Property(ts => ts.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(ts => ts.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(ts => ts.Description).HasColumnName("description").HasMaxLength(500);
            builder.Property(ts => ts.StatusId).HasColumnName("status_id").HasDefaultValue(1).IsRequired();
            builder.Property(ts => ts.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");

            builder.HasOne(ts => ts.Project)
                .WithMany(p => p.TestSuites)
                .HasForeignKey(ts => ts.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ts => ts.Status)
                .WithMany(s => s.TestSuites)
                .HasForeignKey(ts => ts.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
