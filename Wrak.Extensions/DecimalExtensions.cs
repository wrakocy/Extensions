using System.Globalization;

namespace Wrak.Extensions;

public static class DecimalExtensions
{
    public static string ToUSDString(this decimal val)
    {
        var ci = CultureInfo.GetCultureInfo("en-US");

        if (val >= 0)
            return string.Format(ci, "{0:C}", val);
        return string.Format(ci, "({0:C})", Math.Abs(val));
    }

    public static string ToUSDString(this decimal? val)
    {
        return val.HasValue ? val.Value.ToUSDString() : new string("").ToStringOrEmpty();
    }
}
