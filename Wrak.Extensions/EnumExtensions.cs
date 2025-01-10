using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Wrak.Extensions;

public static class EnumExtensions
{
    public static string ToDisplayName(this Enum value, bool useShortName = false)
    {
        if (value != null)
        {
            var displayName = GetDisplayName(value, useShortName);
            return string.IsNullOrEmpty(displayName) ? value.ToString() : displayName;
        }

        return string.Empty;
    }

    private static string? GetDisplayName(Enum value, bool useShortName)
    {
        var displayAttribute = value
            .GetType()
            .GetMember(value.ToString())
            .FirstOrDefault()?
            .GetCustomAttributes<DisplayAttribute>()?
            .FirstOrDefault();

        return useShortName ? displayAttribute?.GetShortName() : displayAttribute?.GetName() ?? null;
    }
}
