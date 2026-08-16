// src/QAMS.Infrastructure/Persistence/Configurations/CatalogConfigurations.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAMS.Domain.Entities.Catalogs;
using QAMS.Domain.Constants;

namespace QAMS.Infrastructure.Persistence.Configurations
{
    public class ProjectPriorityConfiguration : IEntityTypeConfiguration<ProjectPriority>
    {
        public void Configure(EntityTypeBuilder<ProjectPriority> builder)
        {
            builder.ToTable("project_priorities");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            // Seed
            builder.HasData(
                new ProjectPriority { Id = 1, Code = CatalogConstants.ProjectPriority.Low, Name = "Baja", SortOrder = 1 },
                new ProjectPriority { Id = 2, Code = CatalogConstants.ProjectPriority.Medium, Name = "Media", SortOrder = 2 },
                new ProjectPriority { Id = 3, Code = CatalogConstants.ProjectPriority.High, Name = "Alta", SortOrder = 3 },
                new ProjectPriority { Id = 4, Code = CatalogConstants.ProjectPriority.Critical, Name = "Crítica", SortOrder = 4 }
            );
        }
    }

    public class RequirementTypeConfiguration : IEntityTypeConfiguration<RequirementType>
    {
        public void Configure(EntityTypeBuilder<RequirementType> builder)
        {
            builder.ToTable("requirement_types");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            // Seed
            builder.HasData(
                new RequirementType { Id = 1, Code = CatalogConstants.RequirementType.Functional, Name = "Funcional", SortOrder = 1 },
                new RequirementType { Id = 2, Code = CatalogConstants.RequirementType.NonFunctional, Name = "No Funcional", SortOrder = 2 },
                new RequirementType { Id = 3, Code = CatalogConstants.RequirementType.Technical, Name = "Técnico", SortOrder = 3 },
                new RequirementType { Id = 4, Code = CatalogConstants.RequirementType.UserStory, Name = "Historia de Usuario", SortOrder = 4 }
            );
        }
    }

    public class RequirementPriorityConfiguration : IEntityTypeConfiguration<RequirementPriority>
    {
        public void Configure(EntityTypeBuilder<RequirementPriority> builder)
        {
            builder.ToTable("requirement_priorities");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            // Seed
            builder.HasData(
                new RequirementPriority { Id = 1, Code = CatalogConstants.RequirementPriority.Low, Name = "Baja", SortOrder = 1 },
                new RequirementPriority { Id = 2, Code = CatalogConstants.RequirementPriority.Medium, Name = "Media", SortOrder = 2 },
                new RequirementPriority { Id = 3, Code = CatalogConstants.RequirementPriority.High, Name = "Alta", SortOrder = 3 },
                new RequirementPriority { Id = 4, Code = CatalogConstants.RequirementPriority.Critical, Name = "Crítica", SortOrder = 4 }
            );
        }
    }

    public class RequirementComplexityConfiguration : IEntityTypeConfiguration<RequirementComplexity>
    {
        public void Configure(EntityTypeBuilder<RequirementComplexity> builder)
        {
            builder.ToTable("requirement_complexities");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            // Seed
            builder.HasData(
                new RequirementComplexity { Id = 1, Code = CatalogConstants.RequirementComplexity.Simple, Name = "Simple", SortOrder = 1 },
                new RequirementComplexity { Id = 2, Code = CatalogConstants.RequirementComplexity.Moderate, Name = "Moderada", SortOrder = 2 },
                new RequirementComplexity { Id = 3, Code = CatalogConstants.RequirementComplexity.Complex, Name = "Compleja", SortOrder = 3 },
                new RequirementComplexity { Id = 4, Code = CatalogConstants.RequirementComplexity.VeryComplex, Name = "Muy Compleja", SortOrder = 4 }
            );
        }
    }

    public class RequirementStatusConfiguration : IEntityTypeConfiguration<RequirementStatus>
    {
        public void Configure(EntityTypeBuilder<RequirementStatus> builder)
        {
            builder.ToTable("requirement_statuses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            // Seed
            builder.HasData(
                new RequirementStatus { Id = 1, Code = CatalogConstants.RequirementStatus.Draft, Name = "Borrador", SortOrder = 1 },
                new RequirementStatus { Id = 2, Code = CatalogConstants.RequirementStatus.InReview, Name = "En Revisión", SortOrder = 2 },
                new RequirementStatus { Id = 3, Code = CatalogConstants.RequirementStatus.Approved, Name = "Aprobado", SortOrder = 3 },
                new RequirementStatus { Id = 4, Code = CatalogConstants.RequirementStatus.Rejected, Name = "Rechazado", SortOrder = 4 },
                new RequirementStatus { Id = 5, Code = CatalogConstants.RequirementStatus.Implemented, Name = "Implementado", SortOrder = 5 },
                new RequirementStatus { Id = 6, Code = CatalogConstants.RequirementStatus.Verified, Name = "Verificado", SortOrder = 6 }
            );
        }
    }

    public class PlatformTypeConfiguration : IEntityTypeConfiguration<PlatformType>
    {
        public void Configure(EntityTypeBuilder<PlatformType> builder)
        {
            builder.ToTable("platform_types");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            // Seed
            builder.HasData(
                new PlatformType { Id = 1, Code = CatalogConstants.PlatformTypes.Web, Name = "Aplicación Web", SortOrder = 1 },
                new PlatformType { Id = 2, Code = CatalogConstants.PlatformTypes.Desktop, Name = "Aplicación de Escritorio", SortOrder = 2 },
                new PlatformType { Id = 3, Code = CatalogConstants.PlatformTypes.DataProcessing, Name = "Procesamiento de Información", SortOrder = 3 }
            );
        }
    }
    public class TestStrategyConfiguration : IEntityTypeConfiguration<TestStrategy>
    {
        public void Configure(EntityTypeBuilder<TestStrategy> builder)
        {
            builder.ToTable("test_strategies");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new TestStrategy { Id = 1, Code = "FUNCIONAL", Name = "Pruebas Funcionales", SortOrder = 1 },
                new TestStrategy { Id = 2, Code = "REGRESION", Name = "Pruebas de Regresión", SortOrder = 2 },
                new TestStrategy { Id = 3, Code = "SEGURIDAD", Name = "Pruebas de Seguridad", SortOrder = 3 },
                new TestStrategy { Id = 4, Code = "AUTOMATIZADA", Name = "Pruebas Automatizadas", SortOrder = 4 },
                new TestStrategy { Id = 5, Code = "RENDIMIENTO", Name = "Pruebas de Rendimiento / Carga", SortOrder = 5 },
                new TestStrategy { Id = 6, Code = "EXPLORATORIA", Name = "Pruebas Exploratorias", SortOrder = 6 },
                new TestStrategy { Id = 7, Code = "UAT", Name = "Pruebas de Aceptación (UAT)", SortOrder = 7 },
                new TestStrategy { Id = 8, Code = "INTEGRACION", Name = "Pruebas de Integración", SortOrder = 8 },
                new TestStrategy { Id = 9, Code = "MIXTA", Name = "Estrategia Mixta", SortOrder = 9 }
            );
        }
    }

    public class RiskLevelConfiguration : IEntityTypeConfiguration<RiskLevel>
    {
        public void Configure(EntityTypeBuilder<RiskLevel> builder)
        {
            builder.ToTable("risk_levels");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new RiskLevel { Id = 1, Code = "NO_RISK", Name = "Sin Riesgo Identificado", SortOrder = 1 },
                new RiskLevel { Id = 2, Code = "LOW", Name = "Riesgo Bajo", SortOrder = 2 },
                new RiskLevel { Id = 3, Code = "MEDIUM", Name = "Riesgo Medio", SortOrder = 3 },
                new RiskLevel { Id = 4, Code = "HIGH", Name = "Riesgo Alto", SortOrder = 4 },
                new RiskLevel { Id = 5, Code = "CRITICAL", Name = "Riesgo Crítico / Bloqueante", SortOrder = 5 }
            );
        }
    }

    public class TestPlanEnvironmentConfiguration : IEntityTypeConfiguration<TestPlanEnvironment>
    {
        public void Configure(EntityTypeBuilder<TestPlanEnvironment> builder)
        {
            builder.ToTable("test_plan_environments");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new TestPlanEnvironment { Id = 1, Code = "LOCAL", Name = "Entorno Local (Development)", SortOrder = 1 },
                new TestPlanEnvironment { Id = 2, Code = "QA", Name = "Entorno QA / Testing", SortOrder = 2 },
                new TestPlanEnvironment { Id = 3, Code = "STAGING", Name = "Entorno Staging / Pre-producción", SortOrder = 3 },
                new TestPlanEnvironment { Id = 4, Code = "PROD", Name = "Entorno de Producción (Smoke Testing)", SortOrder = 4 },
                new TestPlanEnvironment { Id = 5, Code = "MULTIPLATFORM", Name = "Entorno Multi-plataforma (Web + Mobile)", SortOrder = 5 },
                new TestPlanEnvironment { Id = 6, Code = "CLOUD", Name = "Ambiente Cloud (AWS / GCP / Azure)", SortOrder = 6 }
            );
        }
    }
    public class TestPlanTypeConfiguration : IEntityTypeConfiguration<TestPlanType>
    {
        public void Configure(EntityTypeBuilder<TestPlanType> builder)
        {
            builder.ToTable("test_plan_types");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new TestPlanType { Id = 1, Code = "MASTER", Name = "Plan Maestro de Pruebas", SortOrder = 1 },
                new TestPlanType { Id = 2, Code = "LEVEL", Name = "Plan de Pruebas por Nivel", SortOrder = 2 },
                new TestPlanType { Id = 3, Code = "ITERATION", Name = "Plan de Pruebas por Iteración", SortOrder = 3 }
            );
        }
    }

    public class TestLevelConfiguration : IEntityTypeConfiguration<TestLevel>
    {
        public void Configure(EntityTypeBuilder<TestLevel> builder)
        {
            builder.ToTable("test_levels");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder.HasData(
                new TestLevel { Id = 1, Code = "UNIT", Name = "Pruebas Unitarias", SortOrder = 1 },
                new TestLevel { Id = 2, Code = "INTEGRATION", Name = "Pruebas de Integración", SortOrder = 2 },
                new TestLevel { Id = 3, Code = "SYSTEM", Name = "Pruebas de Sistema", SortOrder = 3 },
                new TestLevel { Id = 4, Code = "ACCEPTANCE", Name = "Pruebas de Aceptación (UAT)", SortOrder = 4 },
                new TestLevel { Id = 5, Code = "REGRESSION", Name = "Pruebas de Regresión", SortOrder = 5 }
            );
        }
    }
}
