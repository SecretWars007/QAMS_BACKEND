// src/QAMS.Infrastructure/Persistence/Configurations/TestSuiteTagConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class TestSuiteTagConfiguration : IEntityTypeConfiguration<TestSuiteTag>
    {
        public void Configure(EntityTypeBuilder<TestSuiteTag> builder)
        {
            builder.ToTable("test_suite_tags");
            
            builder.HasKey(tst => new { tst.TestSuiteId, tst.TagId });

            builder.Property(tst => tst.TestSuiteId).HasColumnName("test_suite_id");
            builder.Property(tst => tst.TagId).HasColumnName("tag_id");

            builder.HasOne(tst => tst.TestSuite)
                .WithMany(ts => ts.Tags)
                .HasForeignKey(tst => tst.TestSuiteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tst => tst.Tag)
                .WithMany()
                .HasForeignKey(tst => tst.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
