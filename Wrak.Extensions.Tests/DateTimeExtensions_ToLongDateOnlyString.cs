namespace Wrak.Extensions.Tests;

public class DateTimeExtensions_ToLongDateOnlyString
{
    [Theory]
    [InlineData("1/3/22 11:30:45", "Monday January 3, 2022")]
    [InlineData("1/3/22 12:30:45", "Monday January 3, 2022")]
    [InlineData("1/3/22 3:30:45 PM", "Monday January 3, 2022")]
    [InlineData("1/10/22 12:30:45 PM", "Monday January 10, 2022")]
    [InlineData("10/12/21 14:30:45", "Tuesday October 12, 2021")]
    [InlineData("", "--")]
    [InlineData(null, "--")]
    public void ReturnCorrectFormatAndHandleNulls(string? dateString, string expectedResult)
    {
        var date = dateString?.ParseNullableDateTime();
        Assert.Equal(expectedResult, date.ToLongDateOnlyString());
    }
}



