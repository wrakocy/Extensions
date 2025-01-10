namespace Wrak.Extensions.Tests;

public class DateTimeExtensions_IsWeekend
{
    [Theory]
    [InlineData("10/3/2020", true)]  // Saturday
    [InlineData("10/4/2020", true)]  // Sunday
    [InlineData("10/5/2020", false)] // Monday
    [InlineData("10/6/2020", false)] // Tuesday
    [InlineData("10/7/2020", false)] // Wedesday
    [InlineData("10/8/2020", false)] // Thursday
    [InlineData("10/9/2020", false)] // Friday
    public void IsWeekend(string dateString, bool expectedResult)
    {
        var date = DateTime.Parse(dateString);
        Assert.Equal(expectedResult, date.IsWeekend());
    }
}



