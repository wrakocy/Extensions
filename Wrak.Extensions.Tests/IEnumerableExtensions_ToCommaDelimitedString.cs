namespace Wrak.Extensions.Tests;

public class IEnumerableExtensions_ToCommaDelimitedString
{
    [Fact]
    public void ReturnsCommaDelimitedString()
    {
        // Arrange
        var values = new List<string> { "one", "two", "three" };

        // Act
        var result = values.ToCommaDelimitedString();

        // Assert
        Assert.Equal("one, two, three", result);
    }

    [Fact]
    public void ReturnsEmptyStringWithNull()
    {
        // Arrange
        List<string> values = null!;

        // Act
        var result = values.ToCommaDelimitedString();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void ReturnsEmptyStringWithNullGenericValues()
    {
        // Arrange
        List<int> values = null!;

        // Act
        var result = values.ToCommaDelimitedString();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void ReturnsCommaDelimitedStringWithGenericValues()
    {
        // Arrange
        var values = new List<int> { 1, 2, 3 };

        // Act
        var result = values.ToCommaDelimitedString();

        // Assert
        Assert.Equal("1, 2, 3", result);
    }

    [Fact]
    public void ReturnsCommaDelimitedStringWithMixedValues()
    {
        // Arrange
        var values = new List<object> { 1, "two", 3.0 };

        // Act
        var result = values.ToCommaDelimitedString();

        // Assert
        Assert.Equal("1, two, 3", result);
    }
}
