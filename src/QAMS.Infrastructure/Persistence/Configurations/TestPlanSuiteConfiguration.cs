using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestPlanSuiteConfiguration : IEntityTypeConfiguration<TestPlanSuite>
    {
        public void Configure(EntityTypeBuilder<TestPlanSuite> builder)
        {
            builder.ToTable("test_plan_suites");
            builder.HasKey(tps => new { tps.TestPlanId, tps.TestSuiteId });

            builder.HasOne(tps => tps.TestPlan)
                .WithMany(tp => tp.TestPlanSuites)
                .HasForeignKey(tps => tps.TestPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tps => tps.TestSuite)
                .WithMany(ts => ts.TestPlanSuites)
                .HasForeignKey(tps => tps.TestSuiteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
