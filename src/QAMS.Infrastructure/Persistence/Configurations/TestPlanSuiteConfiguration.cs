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

            builder.Property(tps => tps.TestPlanId).HasColumnName("test_plan_id");
            builder.Property(tps => tps.TestSuiteId).HasColumnName("test_suite_id");
            builder.Property(tps => tps.ExecutionOrder).HasColumnName("execution_order").HasDefaultValue(0);
            builder.Property(tps => tps.PlannedStartDate).HasColumnName("planned_start_date");
            builder.Property(tps => tps.PlannedEndDate).HasColumnName("planned_end_date");
            builder.Property(tps => tps.ResponsibleUserId).HasColumnName("responsible_user_id");

            builder.HasOne(tps => tps.Responsible)
                .WithMany()
                .HasForeignKey(tps => tps.ResponsibleUserId)
                .OnDelete(DeleteBehavior.SetNull);

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
