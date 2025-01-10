namespace Wrak.Extensions.Tests;

public class DateTimeExtensions_IsWeekday
{
    [Theory]
    [InlineData("10/3/2020", false)] // Saturday
    [InlineData("10/4/2020", false)] // Sunday
    [InlineData("10/5/2020", true)]  // Monday
    [InlineData("10/6/2020", true)]  // Tuesday
    [InlineData("10/7/2020", true)]  // Wedesday
    [InlineData("10/8/2020", true)]  // Thursday
    [InlineData("10/9/2020", true)]  // Friday
    public void IsWeekday(string dateString, bool expectedResult)
    {
        var date = DateTime.Parse(dateString);
        Assert.Equal(expectedResult, date.IsWeekday());
    }
}



