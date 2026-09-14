[![NuGet](https://img.shields.io/nuget/v/Wrak.Extensions.svg)](https://www.nuget.org/packages/Wrak.Extensions) [![NuGet](https://img.shields.io/nuget/dt/Wrak.Extensions.svg)](https://www.nuget.org/packages/Wrak.Extensions)
[![Build Status](https://wrakocy.visualstudio.com/Extensions/_apis/build/status/wrakocy.Extensions?branchName=main)](https://wrakocy.visualstudio.com/Extensions/_build/latest?definitionId=3&branchName=main)

# Extensions Package

A collection of simple extension methods that I'm tired of duplicating!

# Getting Started

1. Install NuGet package

```
PM> Install-Package Wrak.Extensions
```

2. Add the following using statement:

```csharp
using Wrak.Extensions;
```

# Available Extensions

- [string](#string)
- [bool](#bool)
- [DateTime](#datetime)
- [TimeSpan](#timespan)
- [decimal](#decimal)
- [int](#int)
- [long](#long)
- [uint](#uint)
- [ulong](#ulong)
- [Enum](#enum)
- [object](#object)
- [IEnumerable\<T\>](#ienumerablet)

## string

#### `TruncateIfGreaterThan(int maxLength, string suffix = "...")`

Returns the first `maxLength` characters of the string plus `suffix` if the string is longer than `maxLength`; otherwise returns the string unchanged. Throws `ArgumentNullException` if the input is null and `ArgumentException` if `maxLength` is negative.

```csharp
"Hello, world!".TruncateIfGreaterThan(5); // "Hello..."
"Hi".TruncateIfGreaterThan(5); // "Hi"
"Hello, world!".TruncateIfGreaterThan(5, "…"); // "Hello…"
```

#### `ParseNullableDateTime()`

Parses a string to a `DateTime?`, returning `null` if the string can't be parsed instead of throwing.

```csharp
"2024-01-15".ParseNullableDateTime(); // 1/15/2024 12:00:00 AM
"not a date".ParseNullableDateTime(); // null
```

#### `IsNullOrEmpty()`

Extension form of `string.IsNullOrEmpty`.

```csharp
"".IsNullOrEmpty(); // true
"hi".IsNullOrEmpty(); // false
```

#### `IsNullOrWhiteSpace()`

Extension form of `string.IsNullOrWhiteSpace`.

```csharp
"   ".IsNullOrWhiteSpace(); // true
"hi".IsNullOrWhiteSpace(); // false
```

## bool

#### `ToYesNoString()`

Converts `true`/`false` to `"Yes"`/`"No"`. The nullable overload returns `"--"` for `null`.

```csharp
true.ToYesNoString(); // "Yes"
false.ToYesNoString(); // "No"
((bool?)null).ToYesNoString(); // "--"
```

## DateTime

Every method below has a nullable (`DateTime?`) overload that returns `"--"` for `null` and otherwise forwards to the non-nullable overload.

#### `ToLongDateTimeString()`

```csharp
new DateTime(2024, 1, 15, 14, 30, 0).ToLongDateTimeString(); // "Monday January 15, 2024, 02:30 PM"
```

#### `ToShortDateTimeString()`

```csharp
new DateTime(2024, 1, 15, 14, 30, 0).ToShortDateTimeString(); // "01/15/24, 2:30 PM"
```

#### `ToLongDateOnlyString()`

```csharp
new DateTime(2024, 1, 15).ToLongDateOnlyString(); // "Monday January 15, 2024"
```

#### `ToShortDateOnlyString()`

```csharp
new DateTime(2024, 1, 15).ToShortDateOnlyString(); // "01/15/24"
```

#### `ToLongTimeOnlyString()`

```csharp
new DateTime(2024, 1, 15, 14, 30, 0).ToLongTimeOnlyString(); // "02:30 PM"
```

#### `ToShortTimeOnlyString()`

```csharp
new DateTime(2024, 1, 15, 14, 30, 0).ToShortTimeOnlyString(); // "2:30 PM"
```

#### `IsWeekday()`

```csharp
new DateTime(2024, 1, 15).IsWeekday(); // true (Monday)
new DateTime(2024, 1, 13).IsWeekday(); // false (Saturday)
```

#### `IsWeekend()`

```csharp
new DateTime(2024, 1, 13).IsWeekend(); // true (Saturday)
new DateTime(2024, 1, 15).IsWeekend(); // false (Monday)
```

## TimeSpan

#### `ToHoursMinutesString()`

```csharp
new TimeSpan(2, 5, 30).ToHoursMinutesString(); // "02h 05m"
```

#### `ToMinutesSecondsString()`

```csharp
new TimeSpan(0, 5, 30).ToMinutesSecondsString(); // "05m 30s"
```

#### `ToHoursMinutesSecondsString()`

```csharp
new TimeSpan(2, 5, 30).ToHoursMinutesSecondsString(); // "02h 05m 30s"
```

## decimal

#### `ToUSDString()`

Formats a `decimal` as US currency, wrapping negative values in parentheses. The nullable overload returns `"--"` for `null`.

```csharp
1234.5m.ToUSDString(); // "$1,234.50"
(-1234.5m).ToUSDString(); // "($1,234.50)"
((decimal?)null).ToUSDString(); // "--"
```

## int

#### `ToCommaDelimtedString()`

Formats an `int` with thousands separators. The nullable overload returns `"--"` for `null`.

```csharp
1234567.ToCommaDelimtedString(); // "1,234,567"
((int?)null).ToCommaDelimtedString(); // "--"
```

## long

#### `ToCommaDelimtedString()`

Formats a `long` with thousands separators. The nullable overload returns `"--"` for `null`.

```csharp
1234567890L.ToCommaDelimtedString(); // "1,234,567,890"
((long?)null).ToCommaDelimtedString(); // "--"
```

## uint

#### `ToCommaDelimtedString()`

Formats a `uint` with thousands separators. The nullable overload returns `"--"` for `null`.

```csharp
1234567u.ToCommaDelimtedString(); // "1,234,567"
((uint?)null).ToCommaDelimtedString(); // "--"
```

## ulong

#### `ToCommaDelimtedString()`

Formats a `ulong` with thousands separators. The nullable overload returns `"--"` for `null`.

```csharp
1234567890UL.ToCommaDelimtedString(); // "1,234,567,890"
((ulong?)null).ToCommaDelimtedString(); // "--"
```

## Enum

#### `ToDisplayName(bool useShortName = false)`

Returns the value of `[Display(Name = "...")]` (or `[Display(ShortName = "...")]` when `useShortName` is `true`) on the enum member, falling back to `value.ToString()` when no attribute is present.

```csharp
enum Status
{
    [Display(Name = "In Progress", ShortName = "Prog.")]
    InProgress,
    Done
}

Status.InProgress.ToDisplayName(); // "In Progress"
Status.InProgress.ToDisplayName(useShortName: true); // "Prog."
Status.Done.ToDisplayName(); // "Done" (no attribute, falls back to ToString())
```

#### `ToGroupName()`

Returns the value of `[Display(GroupName = "...")]` on the enum member, or an empty string when no attribute is present.

```csharp
enum Status
{
    [Display(Name = "In Progress", GroupName = "Active")]
    InProgress
}

Status.InProgress.ToGroupName(); // "Active"
```

## object

#### `ToStringOrEmpty()`

Calls `ToString()` on any object, returning `"--"` if the object is `null` or its string representation is null/whitespace. This is the shared fallback used internally by other extensions (e.g. the nullable `DateTime`, `decimal`, and numeric formatters) for their `null` case.

```csharp
((object?)null).ToStringOrEmpty(); // "--"
"  ".ToStringOrEmpty(); // "--"
42.ToStringOrEmpty(); // "42"
```

## IEnumerable\<T\>

#### `ToCommaDelimitedString()`

Joins a sequence into a comma-delimited string. `IEnumerable<string>` joins directly; the generic `IEnumerable<T>` overload calls `ToString()` (or empty string for `null` elements) on each item first. Returns an empty string for a `null` source.

```csharp
new[] { "a", "b", "c" }.ToCommaDelimitedString(); // "a, b, c"
new[] { 1, 2, 3 }.ToCommaDelimitedString(); // "1, 2, 3"
```
