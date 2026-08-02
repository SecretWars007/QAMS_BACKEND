// src/QAMS.Infrastructure/Persistence/Configurations/StaticTestingCatalogConfigurations.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ReviewTypeConfiguration : IEntityTypeConfiguration<ReviewType>
    {
        public void Configure(EntityTypeBuilder<ReviewType> builder)
        {
            builder.ToTable("review_types");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new ReviewType { Id = 1, Code = "INFORMAL", Name = "Revisión Informal", SortOrder = 1 },
                new ReviewType { Id = 2, Code = "WALKTHROUGH", Name = "Walkthrough", SortOrder = 2 },
                new ReviewType { Id = 3, Code = "TECHNICAL_REVIEW", Name = "Revisión Técnica", SortOrder = 3 },
                new ReviewType { Id = 4, Code = "INSPECTION", Name = "Inspección", SortOrder = 4 }
            );
        }
    }

    public class ReviewStatusConfiguration : IEntityTypeConfiguration<ReviewStatus>
    {
        public void Configure(EntityTypeBuilder<ReviewStatus> builder)
        {
            builder.ToTable("review_statuses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new ReviewStatus { Id = 1, Code = "PLANNED", Name = "Planificada", SortOrder = 1 },
                new ReviewStatus { Id = 2, Code = "IN_PROGRESS", Name = "En Progreso", SortOrder = 2 },
                new ReviewStatus { Id = 3, Code = "COMPLETED", Name = "Completada", SortOrder = 3 },
                new ReviewStatus { Id = 4, Code = "CANCELLED", Name = "Cancelada", SortOrder = 4 }
            );
        }
    }

    public class FindingTypeConfiguration : IEntityTypeConfiguration<FindingType>
    {
        public void Configure(EntityTypeBuilder<FindingType> builder)
        {
            builder.ToTable("finding_types");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new FindingType { Id = 1, Code = "DEFECT", Name = "Defecto", SortOrder = 1 },
                new FindingType { Id = 2, Code = "IMPROVEMENT", Name = "Mejora", SortOrder = 2 },
                new FindingType { Id = 3, Code = "QUESTION", Name = "Pregunta", SortOrder = 3 },
                new FindingType { Id = 4, Code = "COMMENT", Name = "Comentario", SortOrder = 4 }
            );
        }
    }

    public class FindingSeverityConfiguration : IEntityTypeConfiguration<FindingSeverity>
    {
        public void Configure(EntityTypeBuilder<FindingSeverity> builder)
        {
            builder.ToTable("finding_severities");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new FindingSeverity { Id = 1, Code = "BLOCKER", Name = "Bloqueante", SortOrder = 1 },
                new FindingSeverity { Id = 2, Code = "MAJOR", Name = "Mayor", SortOrder = 2 },
                new FindingSeverity { Id = 3, Code = "MINOR", Name = "Menor", SortOrder = 3 },
                new FindingSeverity { Id = 4, Code = "TRIVIAL", Name = "Trivial", SortOrder = 4 }
            );
        }
    }

    public class FindingStatusConfiguration : IEntityTypeConfiguration<FindingStatus>
    {
        public void Configure(EntityTypeBuilder<FindingStatus> builder)
        {
            builder.ToTable("finding_statuses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new FindingStatus { Id = 1, Code = "OPEN", Name = "Abierto", SortOrder = 1 },
                new FindingStatus { Id = 2, Code = "ACCEPTED", Name = "Aceptado", SortOrder = 2 },
                new FindingStatus { Id = 3, Code = "REJECTED", Name = "Rechazado", SortOrder = 3 },
                new FindingStatus { Id = 4, Code = "RESOLVED", Name = "Resuelto", SortOrder = 4 }
            );
        }
    }

    public class TestDesignTechniqueConfiguration : IEntityTypeConfiguration<TestDesignTechnique>
    {
        public void Configure(EntityTypeBuilder<TestDesignTechnique> builder)
        {
            builder.ToTable("test_design_techniques");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new TestDesignTechnique { Id = 1, Code = "EQUIVALENCE_PARTITIONING", Name = "Partición de Equivalencia (Caja Negra)", SortOrder = 1 },
                new TestDesignTechnique { Id = 2, Code = "BOUNDARY_VALUE_ANALYSIS", Name = "Análisis de Valores Límite (Caja Negra)", SortOrder = 2 },
                new TestDesignTechnique { Id = 3, Code = "DECISION_TABLE", Name = "Tabla de Decisión (Caja Negra)", SortOrder = 3 },
                new TestDesignTechnique { Id = 4, Code = "STATE_TRANSITION", Name = "Transición de Estados (Caja Negra)", SortOrder = 4 },
                new TestDesignTechnique { Id = 5, Code = "USE_CASE_TESTING", Name = "Pruebas de Casos de Uso (Caja Negra)", SortOrder = 5 },
                new TestDesignTechnique { Id = 6, Code = "STATEMENT_COVERAGE", Name = "Cobertura de Sentencias (Caja Blanca)", SortOrder = 6 },
                new TestDesignTechnique { Id = 7, Code = "BRANCH_COVERAGE", Name = "Cobertura de Ramas (Caja Blanca)", SortOrder = 7 },
                new TestDesignTechnique { Id = 8, Code = "ERROR_GUESSING", Name = "Predicción de Errores (Experiencia)", SortOrder = 8 },
                new TestDesignTechnique { Id = 9, Code = "EXPLORATORY", Name = "Prueba Exploratoria (Experiencia)", SortOrder = 9 },
                new TestDesignTechnique { Id = 10, Code = "CHECKLIST_BASED", Name = "Pruebas basadas en Lista de Comprobación (Experiencia)", SortOrder = 10 }
            );
        }
    }
}
