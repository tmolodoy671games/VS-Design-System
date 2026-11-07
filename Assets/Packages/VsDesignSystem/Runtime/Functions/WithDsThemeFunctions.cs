using System;
using Compose.Net;
using SharpExtensions;

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
public static partial class WithDsThemeFunctions
{
    [Composable]
    public static void ProvideDsTheme(
        [Composable] Action content,
        Optional<ColorScheme> colorScheme = default,
        Optional<DsShapes> shapes = default,
        Optional<DsTypography> typography = default)
    {
        var parent = DsTheme.LocalTheme.Current;
        var resolved = new DsTheme.Values(
            colorScheme.GetOrDefault(parent.ColorScheme),
            shapes.GetOrDefault(parent.Shapes),
            typography.GetOrDefault(parent.Typography));
        CompositionLocalProvider(
            DsTheme.LocalTheme.Provides(resolved),
            LocalTextStyle.Provides(resolved.Typography.BodyLarge),
            content
        );
    }
}