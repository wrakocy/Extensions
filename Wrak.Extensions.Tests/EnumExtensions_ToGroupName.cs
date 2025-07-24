using System.ComponentModel.DataAnnotations;

namespace Wrak.Extensions.Tests;

public class EnumExtensions_ToGroupName
{
    [Theory]
    [InlineData(FakeEnum.Foo, "")]
    [InlineData(FakeEnum.Bar, "")]
    [InlineData(FakeEnum.FooBar, "Bars")]
    public void ReturnNameWithOrWithoutDisplayAnnotation(FakeEnum enumVal, string expectedResult)
    {
        Assert.Equal(expectedResult, enumVal.ToGroupName());
    }

    public enum FakeEnum
    {
        Foo,

        [Display(Name = "Bar")]
        Bar,

        [Display(GroupName = "Bars")]
        FooBar
    }
}
