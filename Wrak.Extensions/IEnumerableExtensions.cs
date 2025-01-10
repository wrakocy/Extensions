namespace Wrak.Extensions;

public static class IEnumerableExtensions
{
    public static string ToCommaDelimitedString(this IEnumerable<string> values)
    {
        if (values != null)
            return string.Join(", ", values).Trim().TrimEnd(',');
        return string.Empty;
    }

    public static string ToCommaDelimitedString<T>(this IEnumerable<T> values)
    {
        if (values != null)
            return values.Select(x => x?.ToString() ?? string.Empty).ToCommaDelimitedString();
        return string.Empty;
    }
}
