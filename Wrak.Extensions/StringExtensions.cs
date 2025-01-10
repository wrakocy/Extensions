namespace Wrak.Extensions;

public static class StringExtensions
{
    public static string TruncateIfGreaterThan(this string input, int maxLength, string prefix = "...")
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (maxLength < 0) throw new ArgumentException($"{nameof(maxLength)} cannot be negative", nameof(maxLength));

        return input.Length <= maxLength ? input : prefix + input.Substring(input.Length - maxLength);
    }

    public static DateTime? ParseNullableDateTime(this string val)
    {
        return DateTime.TryParse(val, out var date) ? date : null;
    }
}
