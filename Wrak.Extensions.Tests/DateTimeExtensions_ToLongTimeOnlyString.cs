namespace Wrak.Extensions.Tests;

public class DateTimeExtensions_ToLongTimeOnlyString
{
    [Theory]
    [InlineData("1/3/22 11:30:45", "11:30 AM")]
    [InlineData("1/3/22 12:30:45", "12:30 PM")]
    [InlineData("1/3/22 3:30:45 PM", "03:30 PM")]
    [InlineData("1/10/22 12:30:45 PM", "12:30 PM")]
    [InlineData("10/11/21 14:30:45", "02:30 PM")]
    [InlineData("", "--")]
    [InlineData(null, "--")]
    public void ReturnCorrectFormatAndHandleNulls(string? dateString, string expectedResult)
    {
        var date = dateString?.ParseNullableDateTime();
        Assert.Equal(expectedResult, date.ToLongTimeOnlyString());
    }
}



