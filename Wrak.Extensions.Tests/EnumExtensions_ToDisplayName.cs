using System.ComponentModel.DataAnnotations;

namespace Wrak.Extensions.Tests;

public class EnumExtensions_ToDisplayName
{
    [Theory]
    [InlineData(FakeDisplayNameEnum.Foo, "Foo", false)]
    [InlineData(FakeDisplayNameEnum.Foo, "Foo", true)]
    [InlineData(FakeDisplayNameEnum.FooBar, "Foo Bar", false)]
    [InlineData(FakeDisplayNameEnum.FooBar, "FB", true)]
    public void ReturnNameWithOrWithoutDisplayAnnotation(FakeDisplayNameEnum enumVal, string expectedResult, bool useShortName)
    {
        Assert.Equal(expectedResult, enumVal.ToDisplayName(useShortName));
    }

    [Fact]
    public void ReturnLongNameByDefault()
    {
        Assert.Equal("Foo Bar", FakeDisplayNameEnum.FooBar.ToDisplayName());
    }

    public enum FakeDisplayNameEnum
    {
        Foo,

        [Display(Name = "Foo Bar", ShortName = "FB")]
        FooBar
    }
}
