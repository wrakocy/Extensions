namespace Wrak.Extensions.Tests;

public class DecimalExtensions_ToUSDString
{
    [Theory]
    [InlineData(1.0, "$1.00")]
    [InlineData(1.5, "$1.50")]
    [InlineData(1.55, "$1.55")]
    [InlineData(1.551, "$1.55")]
    [InlineData(1.555, "$1.56")]
    [InlineData(1.559, "$1.56")]
    [InlineData(10.55, "$10.55")]
    [InlineData(100.55, "$100.55")]
    [InlineData(1000.55, "$1,000.55")]
    [InlineData(100000.55, "$100,000.55")]
    [InlineData(1000000.55, "$1,000,000.55")]
    [InlineData(-1.0, "($1.00)")]
    [InlineData(null, "--")]
    public void Format(double? d, string expected)
    {
        Assert.Equal(expected, ((decimal?)d).ToUSDString());
    }
}
