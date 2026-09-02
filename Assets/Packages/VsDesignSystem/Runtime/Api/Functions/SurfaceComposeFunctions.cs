// ReSharper disable CheckNamespace

using SharpExtensions;
using UnityCompose;
using UnityEngine;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static void Surface(
        ComposableContent content,
        Optional<Color> color = default,
        Optional<Color> contentColor = default,
        IModifier? modifier = null
    )
    {
        var resolvedColor = color.GetOrDefault(Theme.ColorScheme.Surface);
        var resolvedContentColor = contentColor.GetOrDefault(ContentColorFor(resolvedColor));
        Box(
            modifier: modifier.OrEmpty()
                .Background(resolvedColor),
            content: () =>
            {
                CompositionLocalProvider(
                    LocalContentColor.Provides(resolvedContentColor),
                    content
                );
            }
        );
    }

    [Composable]
    private static Color ContentColorFor(Color color)
    {
        var colors = Theme.ColorScheme;
        return color.Switch()
            .Case(colors.Surface, colors.OnSurface)
            .Case(colors.SurfaceVariant, colors.OnSurfaceVariant)
            .Case(colors.Primary, colors.OnPrimary)
            .Case(colors.PrimaryContainer, colors.OnPrimaryContainer)
            .Case(colors.Secondary, colors.OnSecondary)
            .Case(colors.SecondaryContainer, colors.OnSecondaryContainer)
            .Default(colors.OnSurface)
            .Get();
    }
}