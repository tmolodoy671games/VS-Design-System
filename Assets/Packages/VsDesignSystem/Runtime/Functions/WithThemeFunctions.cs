// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using SharpExtensions;

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
public static partial class WithThemeFunctions
{
    private static readonly ICompositionLocal<Theme> LocalTheme =
        CompositionLocalOf(() => Theme.Dark);

    public static Theme CurrentTheme
    {
        [Composable] get => LocalTheme.Current;
    }

    [Composable]
    public static void WithTheme(
        [Composable] Action content,
        Optional<ColorScheme> colorScheme = default,
        Optional<Typography> typography = default,
        Optional<Shapes> shapes = default
    )
    {
        var parentTheme = CurrentTheme;
        CompositionLocalProvider(
            LocalTheme.Provides(
                new Theme(
                    ColorScheme: colorScheme.GetOrDefault(parentTheme.ColorScheme),
                    Shapes: shapes.GetOrDefault(parentTheme.Shapes),
                    Typography: typography.GetOrDefault(parentTheme.Typography)
                )
            ),
            content: content
        );
    }
}
