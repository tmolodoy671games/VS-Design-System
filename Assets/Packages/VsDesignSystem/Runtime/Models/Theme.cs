// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

/// <summary>An immutable theme. Use with expressions to customize a built-in theme.</summary>
public sealed record Theme(
    ColorScheme ColorScheme,
    Shapes Shapes,
    Typography Typography
);
