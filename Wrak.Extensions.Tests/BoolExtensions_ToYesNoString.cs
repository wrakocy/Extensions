namespace Wrak.Extensions.Tests;

public class BoolExtensions_ToYesNoString
{
    [Theory]
    [InlineData(true, "Yes")]
    [InlineData(false, "No")]
    public void ReturnYesOrNoFromBool(bool val, string expected)
    {
        Assert.Equal(expected, val.ToYesNoString());
    }

    [Fact]
    public void HandleNull()
    {
        var val = (bool?)null;
        Assert.Equal(string.Empty.ToStringOrEmpty(), val.ToYesNoString());
    }
}
