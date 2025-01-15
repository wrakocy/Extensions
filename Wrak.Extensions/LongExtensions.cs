namespace Wrak.Extensions;

public static class LongExtensions
{
    public static string ToCommaDelimtedString(this long val)
    {
        return $"{val:n0}";
    }

    public static string ToCommaDelimtedString(this long? val)
    {
        return val.HasValue ? val.Value.ToCommaDelimtedString() : new string("").ToStringOrEmpty();
    }
}
