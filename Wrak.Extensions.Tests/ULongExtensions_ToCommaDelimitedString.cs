namespace Wrak.Extensions.Tests;

public class ULongExtensions_ToCommaDelimitedString
{
    [Theory]
    [InlineData(1UL, "1")]
    [InlineData(10UL, "10")]
    [InlineData(100UL, "100")]
    [InlineData(1000UL, "1,000")]
    [InlineData(10000UL, "10,000")]
    [InlineData(100000UL, "100,000")]
    [InlineData(1000000UL, "1,000,000")]
    [InlineData(null, "--")]
    public void Format(ulong? i, string expected)
    {
        Assert.Equal(expected, i.ToCommaDelimtedString());
    }
}
