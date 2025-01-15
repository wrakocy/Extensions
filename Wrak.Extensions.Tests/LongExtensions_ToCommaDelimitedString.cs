namespace Wrak.Extensions.Tests;

public class LongExtensions_ToCommaDelimitedString
{
    [Theory]
    [InlineData(1L, "1")]
    [InlineData(10L, "10")]
    [InlineData(100L, "100")]
    [InlineData(1000L, "1,000")]
    [InlineData(10000L, "10,000")]
    [InlineData(100000L, "100,000")]
    [InlineData(1000000L, "1,000,000")]
    [InlineData(null, "--")]
    public void Format(long? i, string expected)
    {
        Assert.Equal(expected, i.ToCommaDelimtedString());
    }
}
