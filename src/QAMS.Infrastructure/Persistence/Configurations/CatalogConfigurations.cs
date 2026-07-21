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
                new PlatformType { Id = 1, Code = CatalogConstants.PlatformType.Web, Name = "Aplicación Web", SortOrder = 1 },
                new PlatformType { Id = 2, Code = CatalogConstants.PlatformType.Desktop, Name = "Aplicación de Escritorio", SortOrder = 2 },
                new PlatformType { Id = 3, Code = CatalogConstants.PlatformType.DataProcessing, Name = "Procesamiento de Información", SortOrder = 3 }
            );
        }
    }
}
