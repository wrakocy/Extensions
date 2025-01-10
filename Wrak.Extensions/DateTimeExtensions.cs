namespace Wrak.Extensions;

public static class DateTimeExtensions
{
    public static string ToLongDateTimeString(this DateTime date)
    {
        return date.ToString("dddd MMMM d, yyyy, hh:mm tt");
    }

    public static string ToLongDateTimeString(this DateTime? date)
    {
        if (date == null) return string.Empty.ToStringOrEmpty();
        return date.Value.ToLongDateTimeString();
    }

    public static string ToShortDateTimeString(this DateTime date)
    {
        return date.ToString("MM/dd/yy, h:mm tt");
    }

    public static string ToShortDateTimeString(this DateTime? date)
    {
        if (date == null) return string.Empty.ToStringOrEmpty();
        return date.Value.ToShortDateTimeString();
    }

    public static string ToLongDateOnlyString(this DateTime date)
    {
        return date.ToString("dddd MMMM d, yyyy");
    }

    public static string ToLongDateOnlyString(this DateTime? date)
    {
        if (date == null) return string.Empty.ToStringOrEmpty();
        return date.Value.ToLongDateOnlyString();
    }

    public static string ToShortDateOnlyString(this DateTime date)
    {
        return date.ToString("MM/dd/yy");
    }

    public static string ToShortDateOnlyString(this DateTime? date)
    {
        if (date == null) return string.Empty.ToStringOrEmpty();
        return date.Value.ToShortDateOnlyString();
    }

    public static string ToLongTimeOnlyString(this DateTime date)
    {
        return date.ToString("hh:mm tt");
    }

    public static string ToLongTimeOnlyString(this DateTime? date)
    {
        if (date == null) return string.Empty.ToStringOrEmpty();
        return date.Value.ToLongTimeOnlyString();
    }

    public static string ToShortTimeOnlyString(this DateTime date)
    {
        return date.ToString("h:mm tt");
    }

    public static string ToShortTimeOnlyString(this DateTime? date)
    {
        if (date == null) return string.Empty.ToStringOrEmpty();
        return date.Value.ToShortTimeOnlyString();
    }

    public static bool IsWeekday(this DateTime value)
    {
        return !value.IsWeekend();
    }

    public static bool IsWeekend(this DateTime value)
    {
        var dayOfWeek = value.DayOfWeek;
        return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
    }
}
