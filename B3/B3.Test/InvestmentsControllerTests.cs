using B3.Api;
using B3.Api.Controllers;
using B3.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace B3.Test;

public class InvestmentsControllerTests
{
    [Fact]
    public void CalculateFinalValue_ShouldReturnCorrectFinalValue()
    {
        // Arrange
        var investmentModel = new InvestmentModel
        {
            InitialValue = 1000m,
            TimeInMonths = 12
        };
        var controller = new InvestmentsController();

        // Act
        var result = controller.CalculateFinalValue(investmentModel);

        // Assert
        Assert.NotNull(result);
        var expectedFinalValue = new Investment(investmentModel.InitialValue, investmentModel.TimeInMonths).CalculateFinalValue();
        Assert.Equal(expectedFinalValue, result.Value);
    }

    [Fact]
    public void CalculateFinalValue_ShouldThrowArgumentException_WhenModelIsInvalid()
    {
        // Arrange
        var investmentModel = new InvestmentModel
        {
            InitialValue = -1000m, // Valor inválido para forçar uma exceção
            TimeInMonths = 12
        };
        var controller = new InvestmentsController();

        // Act
        var result = controller.CalculateFinalValue(investmentModel);

        // Assert
        Assert.NotNull(result);
        var objectResult = Assert.IsType<ObjectResult>(result.Result);
        Assert.Equal(500, objectResult.StatusCode);
        Assert.Equal("An error occurred while calculating the final value.", objectResult.Value);
    }

    [Fact]
    public void CalculateFinalValue_ShouldHaveValidateModelAttribute()
    {
        // Arrange
        var methodInfo = typeof(InvestmentsController).GetMethod("CalculateFinalValue");

        // Act
        var hasValidateModelAttribute = methodInfo.GetCustomAttributes(typeof(ValidateModelAttribute<>), false).Any();

        // Assert
        Assert.True(hasValidateModelAttribute, "O método CalculateFinalValue deve ter o atributo ValidateModel<InvestmentModel>.");
    }
}