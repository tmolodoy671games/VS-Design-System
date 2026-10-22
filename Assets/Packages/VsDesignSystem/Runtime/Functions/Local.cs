// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using SharpExtensions;

namespace VS.DesignSystem;

public static partial class DesignSystemComposeFunctions
{
    private static readonly ICompositionLocal<Theme> LocalTheme =
        CompositionLocalOf(() => Theme.Dark);

    public static Theme Theme
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
        var parentTheme = Theme;
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
