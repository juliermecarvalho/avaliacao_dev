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
    [InlineData(1000, 6, 1059.75567, 1046.31064)]
    [InlineData(1000, 12, 1123.08209, 1098.46567)]
    public void CalculateFinalValue_ShouldReturnCorrectFinalValue(decimal initialValue, int timeInMonths, decimal grossValue, decimal netValue)
    {
        // Arrange
        var investment = new Investment(initialValue, timeInMonths);

        // Act
        var finalValue = investment.CalculateFinalValues();

        // Assert
        Assert.Equal(initialValue, finalValue.InitialValue, precision: 2);
        Assert.Equal(timeInMonths, finalValue.TimeInMonths);
        Assert.Equal(grossValue, finalValue.GrossValue, precision: 2);
        Assert.Equal(netValue, finalValue.NetValue, precision: 2);
    }
}