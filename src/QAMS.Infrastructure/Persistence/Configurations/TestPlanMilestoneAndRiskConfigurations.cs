using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestPlanMilestoneConfiguration : IEntityTypeConfiguration<TestPlanMilestone>
    {
        public void Configure(EntityTypeBuilder<TestPlanMilestone> builder)
        {
            builder.ToTable("test_plan_milestones");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(1000);
            
            builder.HasOne(m => m.TestPlan)
                .WithMany(tp => tp.Milestones)
                .HasForeignKey(m => m.TestPlanId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class TestPlanRiskConfiguration : IEntityTypeConfiguration<TestPlanRisk>
    {
        public void Configure(EntityTypeBuilder<TestPlanRisk> builder)
        {
            builder.ToTable("test_plan_risks");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).HasMaxLength(500).IsRequired();
            builder.Property(c => c.Mitigation).HasMaxLength(1000);

            builder.HasOne(r => r.TestPlan)
                .WithMany(tp => tp.Risks)
                .HasForeignKey(r => r.TestPlanId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
