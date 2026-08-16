// src/QAMS.Application/Validators/CreateTestCaseValidator.cs
using FluentValidation;
using QAMS.Application.DTOs.TestCases;

namespace QAMS.Application.Validators
{
    /// <summary>
    /// Validador FluentValidation para la creación de casos de prueba.
    /// Reglas basadas en el estándar ISTQB Cap. 4 – Técnicas de Diseño de Pruebas.
    /// </summary>
    public class CreateTestCaseValidator : AbstractValidator<CreateTestCaseDto>
    {
        public CreateTestCaseValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("El ID del proyecto es obligatorio.");

            RuleFor(x => x.TestSuiteId)
                .NotEmpty().WithMessage("El ID de la suite de pruebas es obligatorio.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("El título del caso de prueba es obligatorio.")
                .MaximumLength(200).WithMessage("El título no puede exceder los 200 caracteres.")
                .MinimumLength(5).WithMessage("El título debe tener al menos 5 caracteres.");

            RuleFor(x => x.ExpectedResult)
                .NotEmpty().WithMessage("El resultado esperado es obligatorio (ISTQB: todo caso de prueba debe tener un resultado esperado definido).")
                .MaximumLength(1000).WithMessage("El resultado esperado no puede exceder los 1000 caracteres.");

            RuleFor(x => x.PriorityId)
                .GreaterThan(0).WithMessage("Se debe seleccionar una prioridad válida.");

            RuleFor(x => x.TestTypeId)
                .GreaterThan(0).WithMessage("Se debe seleccionar un tipo de prueba válido.");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("La descripción no puede exceder los 2000 caracteres.")
                .When(x => x.Description != null);

            RuleFor(x => x.Preconditions)
                .MaximumLength(1000).WithMessage("Las precondiciones no pueden exceder los 1000 caracteres.")
                .When(x => x.Preconditions != null);

            RuleFor(x => x.EstimatedTimeHours)
                .InclusiveBetween(0, 1000)
                .WithMessage("El tiempo estimado debe estar entre 0 y 1000 horas.");

            // Regla ISTQB: Si es BDD, el escenario Gherkin es obligatorio
            RuleFor(x => x.BddScenario)
                .NotEmpty().WithMessage("El escenario BDD (Gherkin) es obligatorio cuando IsBdd = true.")
                .When(x => x.IsBdd);



            // Validar pasos si se envían
            RuleForEach(x => x.Steps)
                .SetValidator(new CreateTestStepDtoValidator());
        }
    }

    /// <summary>
    /// Validador para cada paso del caso de prueba.
    /// ISTQB: Cada paso debe tener una acción y un resultado esperado claro.
    /// </summary>
    public class CreateTestStepDtoValidator : AbstractValidator<CreateTestStepDto>
    {
        public CreateTestStepDtoValidator()
        {
            RuleFor(x => x.StepOrder)
                .GreaterThan(0).WithMessage("El orden del paso debe ser mayor a 0.");

            RuleFor(x => x.Action)
                .NotEmpty().WithMessage("La acción del paso es obligatoria.")
                .MaximumLength(1000).WithMessage("La acción no puede exceder los 1000 caracteres.");

            RuleFor(x => x.ExpectedResult)
                .NotEmpty().WithMessage("El resultado esperado del paso es obligatorio.")
                .MaximumLength(1000).WithMessage("El resultado esperado no puede exceder los 1000 caracteres.");
        }
    }
}
