// src/QAMS.Application/Validators/CreateRequirementValidator.cs
using FluentValidation;
using QAMS.Application.DTOs.Projects;

namespace QAMS.Application.Validators
{
    /// <summary>
    /// Validador FluentValidation para la creación de Requisitos.
    /// ISTQB: Base fundamental para la trazabilidad (RTM).
    /// </summary>
    public class CreateRequirementValidator : AbstractValidator<CreateRequirementDto>
    {
        public CreateRequirementValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("El título del requisito es obligatorio.")
                .MinimumLength(3).WithMessage("El título debe tener al menos 3 caracteres.")
                .MaximumLength(500).WithMessage("El título no puede exceder los 500 caracteres.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código único del requisito es obligatorio (Ej: REQ-001).")
                .MaximumLength(100).WithMessage("El código no puede exceder los 100 caracteres.");

            RuleFor(x => x.RequirementTypeId)
                .GreaterThan(0).WithMessage("Se debe seleccionar un tipo de requisito válido (Funcional, No Funcional, etc.).");

            RuleFor(x => x.RequirementPriorityId)
                .GreaterThan(0).WithMessage("Se debe seleccionar una prioridad válida.");

            RuleFor(x => x.RequirementComplexityId)
                .GreaterThan(0).WithMessage("Se debe seleccionar una complejidad válida.");

            RuleFor(x => x.Description)
                .MaximumLength(3000).WithMessage("La descripción no puede exceder los 3000 caracteres.")
                .When(x => x.Description != null);

            RuleFor(x => x.AcceptanceCriteria)
                .MaximumLength(3000).WithMessage("Los criterios de aceptación no pueden exceder los 3000 caracteres.")
                .When(x => x.AcceptanceCriteria != null);
        }
    }
}
