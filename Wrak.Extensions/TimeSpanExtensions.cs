namespace Wrak.Extensions;

public static class TimeSpanExtensions
{
    public static string ToHoursMinutesSecondsString(this TimeSpan ts)
    {
        return $"{Truncate(ts.TotalHours)}h {Truncate(ts.Minutes)}m {Truncate(ts.Seconds)}s";
    }

    private static string Truncate(double d)
    {
        return Math.Truncate(d).ToString("00");
    }
}

