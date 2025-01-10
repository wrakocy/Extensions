namespace Wrak.Extensions.Tests;

public class IntExtensions_ToCommaDelimitedString
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(10, "10")]
    [InlineData(100, "100")]
    [InlineData(1000, "1,000")]
    [InlineData(10000, "10,000")]
    [InlineData(100000, "100,000")]
    [InlineData(1000000, "1,000,000")]
    [InlineData(null, "--")]
    public void Format(int? i, string expected)
    {
        Assert.Equal(expected, i.ToCommaDelimtedString());
    }
}
