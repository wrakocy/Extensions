using System.ComponentModel.DataAnnotations;

namespace Wrak.Extensions.Tests;

public class EnumExtensions_ToDisplayName
{
    [Theory]
    [InlineData(FakeEnum.Foo, "Foo", false)]
    [InlineData(FakeEnum.Foo, "Foo", true)]
    [InlineData(FakeEnum.FooBar, "Foo Bar", false)]
    [InlineData(FakeEnum.FooBar, "FB", true)]
    public void ReturnNameWithOrWithoutDisplayAnnotation(FakeEnum enumVal, string expectedResult, bool useShortName)
    {
        Assert.Equal(expectedResult, enumVal.ToDisplayName(useShortName));
    }

    [Fact]
    public void ReturnLongNameByDefault()
    {
        Assert.Equal("Foo Bar", FakeEnum.FooBar.ToDisplayName());
    }

    public enum FakeEnum
    {
        Foo,

        [Display(Name = "Foo Bar", ShortName = "FB")]
        FooBar
    }
}
