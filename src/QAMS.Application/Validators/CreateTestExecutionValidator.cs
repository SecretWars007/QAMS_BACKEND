// src/QAMS.Application/Validators/CreateTestExecutionValidator.cs
using FluentValidation;
using QAMS.Application.DTOs.TestExecutions;

namespace QAMS.Application.Validators
{
    /// <summary>
    /// Validador FluentValidation para la creación de ejecuciones de prueba.
    /// ISTQB Cap. 5 – Gestión de Pruebas: registro de resultados por tester.
    /// </summary>
    public class CreateTestExecutionValidator : AbstractValidator<CreateTestExecutionDto>
    {
        public CreateTestExecutionValidator()
        {
            RuleFor(x => x.TestCaseId)
                .NotEmpty().WithMessage("El ID del caso de prueba es obligatorio para iniciar una ejecución.");

            RuleFor(x => x.Notes)
                .MaximumLength(2000).WithMessage("Las notas no pueden exceder los 2000 caracteres.")
                .When(x => x.Notes != null);

            RuleFor(x => x.ActualTimeHours)
                .InclusiveBetween(0, 999)
                .WithMessage("Las horas reales deben estar entre 0 y 999.")
                .When(x => x.ActualTimeHours.HasValue);

            // Validar resultados de pasos si se proveen en la creación
            RuleForEach(x => x.StepResults)
                .SetValidator(new StepResultInputValidator())
                .When(x => x.StepResults != null && x.StepResults.Count > 0);
        }
    }

    /// <summary>
    /// Validador para resultados de paso individual durante la ejecución.
    /// </summary>
    public class StepResultInputValidator : AbstractValidator<StepResultInput>
    {
        public StepResultInputValidator()
        {
            RuleFor(x => x.TestStepId)
                .NotEmpty().WithMessage("El ID del paso es obligatorio.");

            RuleFor(x => x.StatusId)
                .GreaterThan(0).WithMessage("Se debe indicar un estado válido para el resultado del paso.");

            RuleFor(x => x.ActualResult)
                .MaximumLength(2000).WithMessage("El resultado actual no puede exceder los 2000 caracteres.")
                .When(x => x.ActualResult != null);
        }
    }
}
