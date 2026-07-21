// src/QAMS.Infrastructure/Persistence/Configurations/TestPlanCriteriaConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestPlanCriteriaConfiguration : IEntityTypeConfiguration<TestPlanCriteria>
    {
        public void Configure(EntityTypeBuilder<TestPlanCriteria> builder)
        {
            builder.ToTable("test_plan_criteria");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CriteriaType)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.IsMet)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(c => c.TestPlan)
                .WithMany(tp => tp.Criteria)
                .HasForeignKey(c => c.TestPlanId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
