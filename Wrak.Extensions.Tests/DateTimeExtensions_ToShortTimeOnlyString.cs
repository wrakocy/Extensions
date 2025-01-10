namespace Wrak.Extensions.Tests;

public class DateTimeExtensions_ToShortTimeOnlyString
{
    [Theory]
    [InlineData("1/3/22 11:30:45", "11:30 AM")]
    [InlineData("1/3/22 12:30:45", "12:30 PM")]
    [InlineData("1/3/22 3:30:45 PM", "3:30 PM")]
    [InlineData("1/10/22 11:30:45", "11:30 AM")]
    [InlineData("10/11/22 11:30:45", "11:30 AM")]
    [InlineData("", "--")]
    public void ReturnCorrectFormatAndHandleNulls(string dateString, string expectedResult)
    {
        var date = dateString.ParseNullableDateTime();
        Assert.Equal(expectedResult, date.ToShortTimeOnlyString());
    }
}



