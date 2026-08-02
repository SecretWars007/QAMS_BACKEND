// src/QAMS.Application/Validators/CreateReviewSessionValidator.cs
using FluentValidation;
using QAMS.Application.DTOs.Reviews;

namespace QAMS.Application.Validators
{
    /// <summary>
    /// Validador FluentValidation para la creación de sesiones de revisión estática.
    /// ISTQB Cap. 3 – Pruebas Estáticas: Walkthrough, Inspección, Revisión Técnica, Informal.
    /// Toda sesión de revisión debe tener objetivo claro y moderador asignado.
    /// </summary>
    public class CreateReviewSessionValidator : AbstractValidator<CreateReviewSessionDto>
    {
        public CreateReviewSessionValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("El ID del proyecto es obligatorio.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("El título de la sesión de revisión es obligatorio.")
                .MinimumLength(5).WithMessage("El título debe tener al menos 5 caracteres.")
                .MaximumLength(300).WithMessage("El título no puede exceder los 300 caracteres.");

            RuleFor(x => x.ReviewTypeId)
                .GreaterThan(0).WithMessage("Se debe seleccionar un tipo de revisión válido (Walkthrough, Inspección, Revisión Técnica, Informal).");

            RuleFor(x => x.ArtifactUnderReview)
                .NotEmpty().WithMessage("El artefacto bajo revisión es obligatorio (nombre del documento, módulo o componente).")
                .MaximumLength(500).WithMessage("El artefacto bajo revisión no puede exceder los 500 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("La descripción no puede exceder los 2000 caracteres.")
                .When(x => x.Description != null);

            RuleFor(x => x.EntryCriteria)
                .MaximumLength(2000).WithMessage("Los criterios de entrada no pueden exceder los 2000 caracteres.")
                .When(x => x.EntryCriteria != null);

            RuleFor(x => x.ExitCriteria)
                .MaximumLength(2000).WithMessage("Los criterios de salida no pueden exceder los 2000 caracteres.")
                .When(x => x.ExitCriteria != null);

            // ISTQB: Una inspección debe tener moderador obligatorio
            RuleFor(x => x.ModeratorId)
                .NotEmpty().WithMessage("El moderador es obligatorio para una Inspección ISTQB.")
                .When(x => x.ReviewTypeId == 2); // 2 = Inspección

            // Validar fecha programada: no puede ser en el pasado
            RuleFor(x => x.ScheduledDate)
                .GreaterThan(DateTime.UtcNow.AddDays(-1))
                .WithMessage("La fecha programada no puede ser en el pasado.")
                .When(x => x.ScheduledDate.HasValue);
        }
    }
}
