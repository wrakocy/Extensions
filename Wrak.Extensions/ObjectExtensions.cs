namespace Wrak.Extensions;

public static class ObjectExtensions
{
    public static string ToStringOrEmpty(this object? value)
    {
        if (value != null)
        {
            var val = value.ToString();
            if (!string.IsNullOrWhiteSpace(val)) return val;
        }

        return "--";
    }
}
