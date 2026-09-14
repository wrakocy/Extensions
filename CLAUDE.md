# Wrak.Extensions

A collection of general-purpose C# extension methods (string, numeric, date/time,
bool, enum, object, IEnumerable) for things the author was "tired of duplicating"
across projects. Multi-targets net6.0–net9.0, zero runtime dependencies. Published
to NuGet as `Wrak.Extensions`.

## Build & test

```
dotnet build Wrak.Extensions.sln
dotnet test Wrak.Extensions.Tests/Wrak.Extensions.Tests.csproj
```

CI today is **Azure Pipelines** (`azure-pipelines.yml`) — build + test only, on every
push to `main`. A separate GitHub Actions workflow
([.github/workflows/publish.yml](.github/workflows/publish.yml)) handles NuGet
releases and only runs on a `vX.Y.Z` tag push or manual dispatch — don't assume
Actions runs on every commit.

## Architecture

- `Wrak.Extensions/` — one `public static class <Type>Extensions` per extended type
  (`StringExtensions.cs`, `IntExtensions.cs`, `LongExtensions.cs`,
  `UIntExtensions.cs`, `ULongExtensions.cs`, `DecimalExtensions.cs`,
  `DateTimeExtensions.cs`, `TimeSpanExtensions.cs`, `BoolExtensions.cs`,
  `EnumExtensions.cs`, `ObjectExtensions.cs`, `IEnumerableExtensions.cs`), all in the
  flat `Wrak.Extensions` namespace. There's no shared marker interface or
  partial-class pattern — each extended type is its own ordinary static class. A new
  extended type gets a new `<Type>Extensions.cs` file; a new method on an
  already-extended type goes into the existing class.
- Nullable value-type overload pattern: most methods on a value type have both a `T`
  and `T?` overload, where the `T?` overload null-checks and forwards to the `T`
  overload (see [DateTimeExtensions.cs](Wrak.Extensions/DateTimeExtensions.cs),
  [IntExtensions.cs](Wrak.Extensions/IntExtensions.cs)). Follow this when adding a
  method to a value type that's meaningfully nullable.
- [ObjectExtensions.cs](Wrak.Extensions/ObjectExtensions.cs)'s `ToStringOrEmpty()` is
  the shared "stringify or placeholder" fallback other extensions call for
  null/empty values — reuse it instead of re-inlining `?? "--"` logic.

## Guardrails

- **Never** add a package dependency to `Wrak.Extensions` — it must stay
  zero-dependency (test-only packages belong in `Wrak.Extensions.Tests`).
- **Always** bump `<Version>` in
  [Wrak.Extensions.csproj](Wrak.Extensions/Wrak.Extensions.csproj) for any change to
  the public API.
- **Never** drop or narrow a `<TargetFrameworks>` entry without being asked.
- Validation is inconsistent across existing methods (`TruncateIfGreaterThan` throws
  on null input / negative length; most numeric and date formatters don't validate
  at all). Match the validation style of the method(s) you're closest to rather than
  imposing a blanket rule on unrelated code.
- `IntExtensions`/`LongExtensions`/`UIntExtensions`/`ULongExtensions` name their
  formatter `ToCommaDelimtedString` (missing the second "i"), while
  `IEnumerableExtensions` uses the correctly spelled `ToCommaDelimitedString`. This
  is existing public API — don't rename it as a side effect of unrelated work; a
  rename is a breaking change that needs its own deliberate decision.

## Tests

xUnit, one test class per method named `<Type>Extensions_<Method>` in a matching
`<Type>Extensions_<Method>.cs` file (e.g.
[StringExtensions_TruncateIfGreaterThan.cs](Wrak.Extensions.Tests/StringExtensions_TruncateIfGreaterThan.cs)).
Simple input/output cases use `[Theory]`/`[InlineData]`; exception cases get a
dedicated `[Fact]` calling `Assert.Throws<T>`.

## Release process

Publishing runs through the `Publish to NuGet` GitHub Actions workflow
([.github/workflows/publish.yml](.github/workflows/publish.yml)) using NuGet Trusted
Publishing (OIDC) — there's no API key to manage, and the agent never runs
`dotnet nuget push` directly. Pushing the release tag is what triggers the workflow.

To cut a release:
1. Bump `<Version>` in
   [Wrak.Extensions.csproj](Wrak.Extensions/Wrak.Extensions.csproj).
2. Confirm the exact version number with the user before tagging.
3. Tag (`vX.Y.Z`) and push the tag — this triggers the publish workflow.

**Never push a `vX.Y.Z` release tag without the user explicitly confirming the exact
version number first**; that push triggers an irreversible publish (a NuGet version
can never be overwritten or deleted).
