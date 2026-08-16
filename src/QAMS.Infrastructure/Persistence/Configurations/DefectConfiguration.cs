// src/QAMS.Infrastructure/Persistence/Configurations/DefectConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class DefectConfiguration : IEntityTypeConfiguration<Defect>
    {
        public void Configure(EntityTypeBuilder<Defect> builder)
        {
            builder.ToTable("defects");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id");

            builder.Property(d => d.ProjectId).HasColumnName("project_id").IsRequired();
            builder.Property(d => d.TestCaseId).HasColumnName("test_case_id");
            builder.Property(d => d.TestExecutionId).HasColumnName("test_execution_id");
            builder.Property(d => d.TestExecutionStepResultId).HasColumnName("test_execution_step_result_id");
            builder.Property(d => d.Title).HasColumnName("title").HasMaxLength(300).IsRequired();
            builder.Property(d => d.Description).HasColumnName("description").HasMaxLength(3000);
            builder.Property(d => d.StepsToReproduce).HasColumnName("steps_to_reproduce").HasMaxLength(3000);
            builder.Property(d => d.ActualResult).HasColumnName("actual_result").HasMaxLength(2000);
            builder.Property(d => d.ExpectedResult).HasColumnName("expected_result").HasMaxLength(2000);
            builder.Property(d => d.DefectPriorityId).HasColumnName("defect_priority_id").IsRequired();
            builder.Property(d => d.DefectSeverityId).HasColumnName("defect_severity_id").IsRequired();
            builder.Property(d => d.DefectStatusId).HasColumnName("defect_status_id").IsRequired();
            builder.Property(d => d.EnvironmentInfo).HasColumnName("environment_info").HasMaxLength(1000);
            builder.Property(d => d.AttachmentUrl).HasColumnName("attachment_url").HasMaxLength(1000);
            builder.Property(d => d.AttachmentFileName).HasColumnName("attachment_file_name").HasMaxLength(300);
            builder.Property(d => d.ReportedByUserId).HasColumnName("reported_by_user_id").IsRequired();
            builder.Property(d => d.AssignedToUserId).HasColumnName("assigned_to_user_id");
            builder.Property(d => d.ResolvedAt).HasColumnName("resolved_at");
            builder.Property(d => d.ResolutionNotes).HasColumnName("resolution_notes").HasMaxLength(2000);

            // Soft Delete & Auditoría
            builder.Property(d => d.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
            builder.Property(d => d.DeletedAt).HasColumnName("deleted_at");
            builder.Property(d => d.DeletedByUserId).HasColumnName("deleted_by_user_id");
            builder.Property(d => d.CreatedAt).HasColumnName("created_at");
            builder.Property(d => d.CreatedByUserId).HasColumnName("created_by_user_id");
            builder.Property(d => d.UpdatedAt).HasColumnName("updated_at");
            builder.Property(d => d.UpdatedByUserId).HasColumnName("updated_by_user_id");

            // Filtro global de soft delete
            builder.HasQueryFilter(d => !d.IsDeleted);

            // Relación: Defecto → Proyecto
            builder.HasOne(d => d.Project)
                .WithMany()
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación: Defecto → Caso de Prueba (opcional)
            builder.HasOne(d => d.TestCase)
                .WithMany(tc => tc.Defects)
                .HasForeignKey(d => d.TestCaseId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación: Defecto → Ejecución (opcional)
            builder.HasOne(d => d.TestExecution)
                .WithMany()
                .HasForeignKey(d => d.TestExecutionId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación: Defecto → Prioridad
            builder.HasOne(d => d.DefectPriority)
                .WithMany(dp => dp.Defects)
                .HasForeignKey(d => d.DefectPriorityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Defecto → Severidad
            builder.HasOne(d => d.DefectSeverity)
                .WithMany(ds => ds.Defects)
                .HasForeignKey(d => d.DefectSeverityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Defecto → Estado
            builder.HasOne(d => d.DefectStatus)
                .WithMany(ds => ds.Defects)
                .HasForeignKey(d => d.DefectStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Defecto → Reportado por
            builder.HasOne(d => d.ReportedBy)
                .WithMany()
                .HasForeignKey(d => d.ReportedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Defecto → Asignado a
            builder.HasOne(d => d.AssignedTo)
                .WithMany()
                .HasForeignKey(d => d.AssignedToUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
