namespace Wrak.Extensions.Tests;

public class TimeSpanExtensions_ToHoursMinutesString
{
    [Theory]
    [InlineData(60, "01h 00m")]
    [InlineData(90, "01h 30m")]
    [InlineData(120, "02h 00m")]
    public void Format(double minutes, string expectedString)
    {
        // Act
        var result = TimeSpan.FromMinutes(minutes).ToHoursMinutesString();

        // Assert
        Assert.Equal(expectedString, result);
    }
}

