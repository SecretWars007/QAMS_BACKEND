// src/QAMS.Application/Validators/CreateDefectValidator.cs
using FluentValidation;
using QAMS.Application.DTOs.Defects;

namespace QAMS.Application.Validators
{
    /// <summary>
    /// Validador FluentValidation para la creación de Defectos.
    /// ISTQB Cap. 5 – Gestión de Defectos: registro de incidentes y problemas encontrados.
    /// </summary>
    public class CreateDefectValidator : AbstractValidator<CreateDefectDto>
    {
        public CreateDefectValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("El ID del proyecto es obligatorio para registrar un defecto.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("El título del defecto es obligatorio.")
                .MinimumLength(5).WithMessage("El título debe tener al menos 5 caracteres.")
                .MaximumLength(300).WithMessage("El título no puede exceder los 300 caracteres.");

            RuleFor(x => x.DefectPriorityId)
                .GreaterThan(0).WithMessage("Se debe seleccionar una prioridad válida (Ej. Crítico, Alta, Media, Baja).");

            RuleFor(x => x.Description)
                .MaximumLength(3000).WithMessage("La descripción no puede exceder los 3000 caracteres.")
                .When(x => x.Description != null);

            RuleFor(x => x.StepsToReproduce)
                .MaximumLength(3000).WithMessage("Los pasos para reproducir no pueden exceder los 3000 caracteres.")
                .When(x => x.StepsToReproduce != null);

            RuleFor(x => x.ActualResult)
                .MaximumLength(2000).WithMessage("El resultado actual no puede exceder los 2000 caracteres.")
                .When(x => x.ActualResult != null);

            RuleFor(x => x.ExpectedResult)
                .MaximumLength(2000).WithMessage("El resultado esperado no puede exceder los 2000 caracteres.")
                .When(x => x.ExpectedResult != null);
        }
    }
}
