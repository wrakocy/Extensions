namespace Wrak.Extensions;

public static class ULongExtensions
{
    public static string ToCommaDelimtedString(this ulong val)
    {
        return $"{val:n0}";
    }

    public static string ToCommaDelimtedString(this ulong? val)
    {
        return val.HasValue ? val.Value.ToCommaDelimtedString() : new string("").ToStringOrEmpty();
    }
}
