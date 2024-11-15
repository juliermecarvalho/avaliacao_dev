using B3.Api.Controllers;
using B3.Api.FilterAttribute;
using B3.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace B3.Test.ControllersTests;

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

        var expectedResult = new InvestmentResult
        {
            InitialValue = 1000m,
            TimeInMonths = 12,
            GrossValue = 1120m, // Exemplo de valor bruto
            NetValue = 1100m    // Exemplo de valor líquido
        };

        var mockInvestment = new Mock<IInvestment>();
        mockInvestment.Setup(i => i.CalculateFinalValues(investmentModel.InitialValue, investmentModel.TimeInMonths))
                      .Returns(expectedResult);

        var controller = new InvestmentsController(mockInvestment.Object);

        // Act
        var result = controller.CalculateFinalValue(investmentModel);

        // Assert
        Assert.NotNull(result);
        var objectResult = Assert.IsType<InvestmentResult>(result.Value);
        Assert.Equal(expectedResult.NetValue, objectResult.NetValue);
        Assert.Equal(expectedResult.GrossValue, objectResult.GrossValue);
    }

    [Fact]
    public void CalculateFinalValue_ShouldReturnInternalServerError_WhenExceptionIsThrown()
    {
        // Arrange
        var investmentModel = new InvestmentModel
        {
            InitialValue = -1000m, // Valor inválido para forçar uma exceção
            TimeInMonths = 12
        };

        var mockInvestment = new Mock<IInvestment>();
        mockInvestment.Setup(i => i.CalculateFinalValues(investmentModel.InitialValue, investmentModel.TimeInMonths))
                      .Throws(new ArgumentException("O valor inicial deve ser maior que 0"));

        var controller = new InvestmentsController(mockInvestment.Object);

        // Act
        var objectResult = controller.CalculateFinalValue(investmentModel);
        var result = Assert.IsType<ObjectResult>(objectResult.Result);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(500, result.StatusCode);
        Assert.Equal("An error occurred while calculating the final value.", result.Value);
    }

    [Fact]
    public void CalculateFinalValue_ShouldHaveValidateModelAttribute()
    {
        // Arrange
        var methodInfo = typeof(InvestmentsController).GetMethod("CalculateFinalValue");

        // Act
        var hasValidateModelAttribute = methodInfo != null && methodInfo.GetCustomAttributes(typeof(ValidateModelAttribute<>), false).Any();

        // Assert
        Assert.True(hasValidateModelAttribute, "O método CalculateFinalValue deve ter o atributo ValidateModel<InvestmentModel>.");
    }
}
