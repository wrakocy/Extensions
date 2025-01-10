namespace Wrak.Extensions;

public static class IntExtensions
{
    public static string ToCommaDelimtedString(this int val)
    {
        return $"{val:n0}";
    }

    public static string ToCommaDelimtedString(this int? val)
    {
        return val.HasValue ? val.Value.ToCommaDelimtedString() : new string("").ToStringOrEmpty();
    }
}
