using B3.Api.Models;
using Xunit;

namespace B3.Test.ModelsTests;

public class InvestmentTests
{
    [Theory]
    [InlineData(6, 0.225)]
    [InlineData(12, 0.2)]
    [InlineData(24, 0.175)]
    [InlineData(25, 0.15)]
    public void GetTaxPercentage_ShouldReturnCorrectTaxPercentage(int timeInMonths, decimal expectedTaxPercentage)
    {
        // Arrange
        IInvestment investment = new Investment();

        // Act
        var taxPercentage = investment.GetTaxPercentage(timeInMonths);

        // Assert
        Assert.Equal(expectedTaxPercentage, taxPercentage);
    }

    [Fact]
    public void CalculateFinalValues_ShouldThrowArgumentException_WhenTimeInMonthsIsLessThanOne()
    {
        // Arrange
        var initialValue = 1000m;
        var timeInMonths = 0;
        IInvestment investment = new Investment();

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => investment.CalculateFinalValues(initialValue, timeInMonths));
        Assert.Equal("O valor deve ser maior que 1. (Parameter 'timeInMonths')", exception.Message);
    }

    [Fact]
    public void CalculateFinalValues_ShouldThrowArgumentException_WhenInitialValueIsLessThanOrEqualToZero()
    {
        // Arrange
        var initialValue = 0m;
        var timeInMonths = 12;
        IInvestment investment = new Investment();

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => investment.CalculateFinalValues(initialValue, timeInMonths));
        Assert.Equal("O valor deve ser maior que 0. (Parameter 'initialValue')", exception.Message);
    }

    [Theory]
    [InlineData(1000, 6, 1059.75567, 1046.31064)]
    [InlineData(1000, 12, 1123.08209, 1098.46567)]
    public void CalculateFinalValues_ShouldReturnCorrectFinalValue(decimal initialValue, int timeInMonths, decimal grossValue, decimal netValue)
    {
        // Arrange
        IInvestment investment = new Investment();

        // Act
        var finalValue = investment.CalculateFinalValues(initialValue, timeInMonths);

        // Assert
        Assert.Equal(initialValue, finalValue.InitialValue, precision: 2);
        Assert.Equal(timeInMonths, finalValue.TimeInMonths);
        Assert.Equal(grossValue, finalValue.GrossValue, precision: 2);
        Assert.Equal(netValue, finalValue.NetValue, precision: 2);
    }

    [Theory]
    [InlineData(1000, 6, 1059.75567)]
    [InlineData(1000, 12, 1123.08209)]
    [InlineData(1000, 24, 1261.31339)]
    public void CalculateGrossValue_ValidInputs_ReturnsExpectedGrossValue(decimal initialValue, int timeInMonths, decimal expectedGrossValue)
    {
        // Arrange
        var investment = new Investment();

        // Act
        var result = investment.CalculateGrossValue(initialValue, timeInMonths);

        // Assert
        Assert.Equal(expectedGrossValue, result, 2); // Precision of 2 decimal places
    }
}

