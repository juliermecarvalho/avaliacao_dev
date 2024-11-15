using B3.Api.Extensions;
using Xunit;

namespace B3.Test.ExtensionsTests;

public class ArgumentValidationExtensionsTests
{
    [Fact]
    public void ThrowIfNotGreaterThanZero_ValueGreaterThanZero_DoesNotThrow()
    {
        // Arrange
        decimal value = 1;

        // Act
        var exception = Record.Exception(() => ArgumentValidationExtensions.ThrowIfNotGreaterThanZero(value));

        // Assert
        Assert.Null(exception);
    }


    [Fact]
    public void ThrowIfNotGreaterThanZero_ValueLessThanOrEqualToZero_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        decimal value = 0;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => ArgumentValidationExtensions.ThrowIfNotGreaterThanZero(value));
        Assert.Equal("O valor deve ser maior que 0. (Parameter 'value')", exception.Message);
    }

    [Fact]
    public void ThrowIfNotGreaterThanOne_ValueGreaterThanOne_DoesNotThrow()
    {
        // Arrange
        decimal value = 2;

        // Act
        var exception = Record.Exception(() => ArgumentValidationExtensions.ThrowIfNotGreaterThanOne(value));

        // Assert
        Assert.Null(exception);
    }


    [Fact]
    public void ThrowIfNotGreaterThanOne_ValueLessThanOrEqualToOne_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        decimal value = 1;

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => ArgumentValidationExtensions.ThrowIfNotGreaterThanOne(value));
        Assert.Equal("O valor deve ser maior que 1. (Parameter 'value')", exception.Message);
    }
}