namespace Wrak.Extensions;

public static class BoolExtensions
{
    public static string ToYesNoString(this bool val)
    {
        return val ? "Yes" : "No";
    }

    public static string ToYesNoString(this bool? val)
    {
        return val.HasValue ? val.Value.ToYesNoString() : "--";
    }
}
