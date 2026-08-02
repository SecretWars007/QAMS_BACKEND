using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestPlanApprovalLogConfiguration : IEntityTypeConfiguration<TestPlanApprovalLog>
    {
        public void Configure(EntityTypeBuilder<TestPlanApprovalLog> builder)
        {
            builder.ToTable("test_plan_approval_logs");
            builder.HasKey(al => al.Id);

            builder.Property(al => al.SignatureHash)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(al => al.Verdict)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(al => al.Comments)
                .HasMaxLength(1000);

            // Relación Uno a Uno con TestPlan
            builder.HasOne(al => al.TestPlan)
                .WithOne(tp => tp.ApprovalLog)
                .HasForeignKey<TestPlanApprovalLog>(al => al.TestPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con User (Firmante)
            builder.HasOne(al => al.User)
                .WithMany()
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
