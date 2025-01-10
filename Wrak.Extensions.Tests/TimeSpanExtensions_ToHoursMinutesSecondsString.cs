namespace Wrak.Extensions.Tests;

public class TimeSpanExtensions_ToHoursMinutesSecondsString
{
    [Theory]
    [InlineData(60, "01h 00m 00s")]
    [InlineData(90, "01h 30m 00s")]
    [InlineData(120, "02h 00m 00s")]
    public void Format(double minutes, string expectedString)
    {
        // Act
        var result = TimeSpan.FromMinutes(minutes).ToHoursMinutesSecondsString();

        // Assert
        Assert.Equal(expectedString, result);
    }
}

