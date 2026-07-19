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

            builder.HasOne(tp => tp.Project)
                .WithMany(p => p.TestPlans)
                .HasForeignKey(tp => tp.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(tp => !tp.IsDeleted);
        }
    }
}
