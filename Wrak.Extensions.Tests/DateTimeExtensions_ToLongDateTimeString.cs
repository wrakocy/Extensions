namespace Wrak.Extensions.Tests;

public class DateTimeExtensions_ToLongDateTimeString
{
    [Theory]
    [InlineData("1/3/22 11:30:45", "Monday January 3, 2022, 11:30 AM")]
    [InlineData("1/3/22 12:30:45", "Monday January 3, 2022, 12:30 PM")]
    [InlineData("1/3/22 3:30:45 PM", "Monday January 3, 2022, 03:30 PM")]
    [InlineData("1/10/22 12:30:45 PM", "Monday January 10, 2022, 12:30 PM")]
    [InlineData("10/12/21 14:30:45", "Tuesday October 11, 2021, 02:30 PM")]
    [InlineData("", "--")]
    [InlineData(null, "--")]
    public void ReturnCorrectFormatAndHandleNulls(string? dateString, string expectedResult)
    {
        var date = dateString?.ParseNullableDateTime();
        Assert.Equal(expectedResult, date.ToLongDateTimeString());
    }
}



