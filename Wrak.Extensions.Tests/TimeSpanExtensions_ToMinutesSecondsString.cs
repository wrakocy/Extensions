namespace Wrak.Extensions.Tests;

public class TimeSpanExtensions_ToMinutesSecondsString
{
    [Theory]
    [InlineData(60, "60m 00s")]
    [InlineData(90, "90m 00s")]
    [InlineData(120, "120m 00s")]
    public void Format(double minutes, string expectedString)
    {
        // Act
        var result = TimeSpan.FromMinutes(minutes).ToMinutesSecondsString();

        // Assert
        Assert.Equal(expectedString, result);
    }
}

