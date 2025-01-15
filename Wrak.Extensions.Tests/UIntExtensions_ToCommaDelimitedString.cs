namespace Wrak.Extensions.Tests;

public class UIntExtensions_ToCommaDelimitedString
{
    [Theory]
    [InlineData(1U, "1")]
    [InlineData(10U, "10")]
    [InlineData(100U, "100")]
    [InlineData(1000U, "1,000")]
    [InlineData(10000U, "10,000")]
    [InlineData(100000U, "100,000")]
    [InlineData(1000000U, "1,000,000")]
    [InlineData(null, "--")]
    public void Format(uint? i, string expected)
    {
        Assert.Equal(expected, i.ToCommaDelimtedString());
    }
}
