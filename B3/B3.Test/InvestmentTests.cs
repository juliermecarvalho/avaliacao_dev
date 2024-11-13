using B3.Api.Models;
using Xunit;

namespace B3.Test;

public class InvestmentTests
{
    [Theory]
    [InlineData(1000, 6, 0.225)]
    [InlineData(1000, 12, 0.2)]
    [InlineData(1000, 24, 0.175)]
    [InlineData(1000, 25, 0.15)]
    public void GetTaxPercentage_ShouldReturnCorrectTaxPercentage(decimal initialValue, int timeInMonths, decimal expectedTaxPercentage)
    {
        // Arrange
        var investment = new Investment(initialValue, timeInMonths);

        // Act
        var taxPercentage = investment.GetTaxPercentage();

        // Assert
        Assert.Equal(expectedTaxPercentage, taxPercentage);
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenTimeInMonthsIsLessThanOne()
    {
        // Arrange
        var initialValue = 1000m;
        var timeInMonths = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Investment(initialValue, timeInMonths));
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenInitialValueIsLessThanOrEqualToZero()
    {
        // Arrange
        var initialValue = 0m;
        var timeInMonths = 12;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Investment(initialValue, timeInMonths));
    }

    [Theory]
    [InlineData(1000, 6, 821.31064)]
    [InlineData(1000, 12, 898.46567)]
    public void CalculateFinalValue_ShouldReturnCorrectFinalValue(decimal initialValue, int timeInMonths, decimal expectedFinalValue)
    {
        // Arrange
        var investment = new Investment(initialValue, timeInMonths);

        // Act
        var finalValue = investment.CalculateFinalValue();

        // Assert
        Assert.Equal(expectedFinalValue, finalValue, precision: 2);
    }
}