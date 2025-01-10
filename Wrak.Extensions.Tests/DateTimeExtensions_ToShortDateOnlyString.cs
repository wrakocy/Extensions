namespace Wrak.Extensions.Tests;

public class DateTimeExtensions_ToShortDateOnlyString
{
    [Theory]
    [InlineData("1/3/22 11:30:45", "01/03/22")]
    [InlineData("1/3/22 12:30:45", "01/03/22")]
    [InlineData("1/3/22 3:30:45 PM", "01/03/22")]
    [InlineData("1/10/22 11:30:45", "01/10/22")]
    [InlineData("10/11/21 11:30:45", "10/11/21")]
    [InlineData("", "--")]
    public void ReturnCorrectFormatAndHandleNulls(string dateString, string expectedResult)
    {
        var date = dateString.ParseNullableDateTime();
        Assert.Equal(expectedResult, date.ToShortDateOnlyString());
    }
}



