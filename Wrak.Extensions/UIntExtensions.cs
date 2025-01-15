namespace Wrak.Extensions;

public static class UIntExtensions
{
    public static string ToCommaDelimtedString(this uint val)
    {
        return $"{val:n0}";
    }

    public static string ToCommaDelimtedString(this uint? val)
    {
        return val.HasValue ? val.Value.ToCommaDelimtedString() : new string("").ToStringOrEmpty();
    }
}
