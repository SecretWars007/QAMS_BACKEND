using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ExploratoryFindingConfiguration : IEntityTypeConfiguration<ExploratoryFinding>
    {
        public void Configure(EntityTypeBuilder<ExploratoryFinding> builder)
        {
            builder.ToTable("exploratory_findings");

            builder.HasKey(ef => ef.Id);
            builder.Property(ef => ef.Id).HasColumnName("id");

            builder.Property(ef => ef.SessionId).HasColumnName("session_id").IsRequired();
            builder.Property(ef => ef.TypeId).HasColumnName("type_id").IsRequired();
            builder.Property(ef => ef.Description).HasColumnName("description").HasMaxLength(2000).IsRequired();

            // Relación con ExploratorySession
            builder.HasOne(ef => ef.Session)
                .WithMany(s => s.Findings)
                .HasForeignKey(ef => ef.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ef => ef.SessionId);
        }
    }
}
