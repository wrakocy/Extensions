namespace Wrak.Extensions.Tests;

public class StringExtensions_TruncateIfGreaterThan
{
    [Fact]
    public void ThrowsArgumentNullExceptionGivenNull()
    {
        string input = null!;
        Assert.Throws<ArgumentNullException>(() => input.TruncateIfGreaterThan(10));
    }

    [Fact]
    public void ThrowsArgumentExceptionGivenNegativeMaxLength()
    {
        string input = "test string";
        Assert.Throws<ArgumentException>(() => input.TruncateIfGreaterThan(-1));
    }

    [Fact]
    public void ReturnsInputWhenInputLengthLessThanOrEqualToMaxLength()
    {
        string input = "test string";
        string result = input.TruncateIfGreaterThan(20);
        Assert.Equal(input, result);
    }

    [Fact]
    public void ReturnsTruncatedStringWhenInputLengthGreaterThanMaxLength()
    {
        string input = "this is a very long test string";
        string result = input.TruncateIfGreaterThan(10);
        Assert.Equal("...est string", result);
    }

    [Fact]
    public void ReturnsTruncatedStringWithCustomPrefix()
    {
        string input = "this is a very long test string";
        string result = input.TruncateIfGreaterThan(10, "--");
        Assert.Equal("--est string", result);
    }
}
