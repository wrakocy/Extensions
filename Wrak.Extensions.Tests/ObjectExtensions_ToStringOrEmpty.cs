namespace Wrak.Extensions.Tests;

public class ObjectExtensions_ToStringOrEmpty
{
    [Theory]
    [InlineData("foo", "foo")]
    [InlineData("", "--")]
    [InlineData("   ", "--")]
    public void ReturnStringOrEmptyFromStringOrNull(string val, string expected)
    {
        Assert.Equal(expected, val.ToStringOrEmpty());
    }

    [Fact]
    public void ReturnStringFromObject()
    {
        var o = new object();
        var expected = o.ToString();
        Assert.NotNull(expected);
        Assert.NotEmpty(expected);
        Assert.Equal(expected, o.ToStringOrEmpty());
    }

    [Fact]
    public void ReturnEmptyFromNull()
    {
        object o = null!;
        Assert.Equal("--", o.ToStringOrEmpty());
    }
}
