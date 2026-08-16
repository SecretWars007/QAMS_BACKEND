// src/QAMS.Application/Validators/CreateTestSuiteValidator.cs
using FluentValidation;
using QAMS.Application.DTOs.TestSuites;

namespace QAMS.Application.Validators
{
    public class CreateTestSuiteValidator : AbstractValidator<CreateTestSuiteDto>
    {
        public CreateTestSuiteValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("El ID del proyecto es obligatorio.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre del escenario es obligatorio.")
                .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.TestPlanId)
                .NotEmpty().WithMessage("El escenario debe estar relacionado a un plan de pruebas.");
        }
    }
}
