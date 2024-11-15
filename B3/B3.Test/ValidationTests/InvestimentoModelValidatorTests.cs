using B3.Api.Models;
using B3.Api.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace B3.Test.ValidationTests;

public class InvestimentoModelValidatorTests
{
    private readonly InvestimentoModelValidator _validator;

    public InvestimentoModelValidatorTests()
    {
        _validator = new InvestimentoModelValidator();
    }

    [Fact]
    public void Should_Have_Error_When_InitialValue_Is_Less_Than_Or_Equal_To_Zero()
    {
        // Arrange
        var model = new InvestmentModel { InitialValue = 0, TimeInMonths = 10 };

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.InitialValue)
            .WithErrorMessage("O valor inicial deve ser positivo e maior que zero.");
    }

    [Fact]
    public void Should_Not_Have_Error_When_InitialValue_Is_Greater_Than_Zero()
    {
        // Arrange
        var model = new InvestmentModel { InitialValue = 100, TimeInMonths = 10 };

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.InitialValue);
    }

    [Fact]
    public void Should_Have_Error_When_TimeInMonths_Is_Less_Than_Or_Equal_To_One()
    {
        // Arrange
        var model = new InvestmentModel { InitialValue = 100, TimeInMonths = 1 };

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.TimeInMonths)
            .WithErrorMessage("O prazo em meses deve ser maior que 1.");
    }

    [Fact]
    public void Should_Not_Have_Error_When_TimeInMonths_Is_Greater_Than_One()
    {
        // Arrange
        var model = new InvestmentModel { InitialValue = 100, TimeInMonths = 10 };

        // Act & Assert
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.TimeInMonths);
    }
}