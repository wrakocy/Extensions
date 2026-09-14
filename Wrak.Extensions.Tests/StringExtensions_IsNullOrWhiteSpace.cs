namespace Wrak.Extensions.Tests;

public class StringExtensions_IsNullOrWhiteSpace
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData(" ", true)]
    [InlineData("\t", true)]
    [InlineData("test", false)]
    [InlineData(" test ", false)]
    public void ReturnsWhetherStringIsNullOrWhiteSpace(string? val, bool expected)
    {
        Assert.Equal(expected, val.IsNullOrWhiteSpace());
    }
}
