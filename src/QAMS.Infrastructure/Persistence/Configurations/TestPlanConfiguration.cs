using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestPlanConfiguration : IEntityTypeConfiguration<TestPlan>
    {
        public void Configure(EntityTypeBuilder<TestPlan> builder)
        {
            builder.ToTable("test_plans");
            builder.HasKey(tp => tp.Id);

            builder.Property(tp => tp.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(tp => tp.Objectives)
                .HasMaxLength(2000);

            builder.Property(tp => tp.StartDate)
                .IsRequired();

            builder.Property(tp => tp.EndDate)
                .IsRequired();

            builder.Property(tp => tp.StatusId)
                .IsRequired();

            builder.HasOne(tp => tp.Status)
                .WithMany()
                .HasForeignKey(tp => tp.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tp => tp.Project)
                .WithMany(p => p.TestPlans)
                .HasForeignKey(tp => tp.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tp => tp.TestStrategy)
                .WithMany()
                .HasForeignKey(tp => tp.TestStrategyId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(tp => tp.RiskLevel)
                .WithMany()
                .HasForeignKey(tp => tp.RiskLevelId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(tp => tp.TestEnvironment)
                .WithMany()
                .HasForeignKey(tp => tp.TestEnvironmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(tp => tp.TestPlanType)
                .WithMany()
                .HasForeignKey(tp => tp.TestPlanTypeId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(tp => tp.TestLevel)
                .WithMany()
                .HasForeignKey(tp => tp.TestLevelId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(tp => tp.TestManager)
                .WithMany()
                .HasForeignKey(tp => tp.TestManagerId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasQueryFilter(tp => !tp.IsDeleted);
        }
    }
}
