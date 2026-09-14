namespace Wrak.Extensions.Tests;

public class StringExtensions_IsNullOrEmpty
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData(" ", false)]
    [InlineData("test", false)]
    public void ReturnsWhetherStringIsNullOrEmpty(string? val, bool expected)
    {
        Assert.Equal(expected, val.IsNullOrEmpty());
    }
}
