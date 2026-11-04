// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using SharpExtensions;

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
public static partial class WithThemeFunctions
{
    private static readonly ICompositionLocal<Theme> LocalTheme =
        CompositionLocalOf(() => DarkTheme.Instance);

    public static Theme CurrentTheme
    {
        [Composable] get => LocalTheme.Current;
    }

    [Composable]
    public static void WithTheme(
        [Composable] Action content,
        Optional<ColorScheme> colorScheme = default,
        Optional<Typography> typography = default,
        Optional<Shapes> shapes = default,
        Theme? theme = null,
        Optional<MaterialSettings> materials = default
    )
    {
        var parentTheme = theme ?? CurrentTheme;
        CompositionLocalProvider(
            LocalTheme.Provides(
                parentTheme with
                {
                    ColorScheme = colorScheme.GetOrDefault(parentTheme.ColorScheme),
                    Shapes = shapes.GetOrDefault(parentTheme.Shapes),
                    Typography = typography.GetOrDefault(parentTheme.Typography),
                    Materials = materials.GetOrDefault(parentTheme.Materials)
                }
            ),
            content: content
        );
    }
}
