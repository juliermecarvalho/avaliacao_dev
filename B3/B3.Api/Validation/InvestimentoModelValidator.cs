using B3.Api.Models;
using FluentValidation;

namespace B3.Api.Validation;

public class InvestimentoModelValidator : AbstractValidator<InvestmentModel>
{
    public InvestimentoModelValidator()
    {
        // Valida se o valor inicial é positivo e maior que zero
        RuleFor(x => x.InitialValue)
            .GreaterThan(0).WithMessage("O valor inicial deve ser positivo e maior que zero.");

        // Valida se o prazo em meses é maior que 1
        RuleFor(x => x.TimeInMonths)
            .GreaterThan(1).WithMessage("O prazo em meses deve ser maior que 1.");
    }
}