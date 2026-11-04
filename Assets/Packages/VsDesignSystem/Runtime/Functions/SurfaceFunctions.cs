using System;
using Compose.Net;
using SharpExtensions;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
public static partial class SurfaceFunctions
{
    [Composable, NonRestartableComposable]
    public static void Surface(
        Action onClick,
        [Composable] Action content,
        IModifier? modifier = null,
        bool enabled = true,
        Shape shape = default,
        Optional<Color> color = default,
        Optional<Color> contentColor = default,
        Dp shadowElevation = default,
        BorderStroke border = default,
        IMutableInteractionSource? interactionSource = null,
        SurfaceMaterial? material = null,
        SurfaceDepth depth = default,
        Alignment contentAlignment = default
    )
    {
        var theme = CurrentTheme;
        var resolvedColor = color.GetOrDefault(theme.ColorScheme.Surface);
        var foreground = contentColor.GetOrDefault(ContentColorFor(resolvedColor));
        var face = modifier.OrEmpty();
        var resolvedShape = material.HasValue ? shape.GetOrDefault(theme.Shapes.Medium) : shape;
        face = face.WithSurfaceElevation(resolvedShape, shadowElevation);
        if (material is { } finish)
            face = face.Surface(finish, depth, resolvedColor, resolvedShape);
        else
            face = face.Background(resolvedColor, resolvedShape).Clip(resolvedShape);

        SurfaceImpl(content, face, foreground, resolvedShape, border, contentAlignment,
            onClick, enabled, interactionSource);
    }

    [Composable, NonRestartableComposable]
    private static void SurfaceImpl(
        [Composable] Action content,
        IModifier face,
        Color contentColor,
        Shape shape,
        BorderStroke border,
        Alignment contentAlignment,
        Action? onClick,
        bool enabled,
        IMutableInteractionSource? interactionSource
    )
    {
        var indication = LocalIndication.Current;
        if (border.Width != default)
            face = face.Border(border, shape);

        Box(modifier: face, contentAlignment: contentAlignment, content: () =>
        {
            CompositionLocalProvider(LocalContentColor.Provides(contentColor), content);
            if (onClick != null)
            {
                // The input layer fills the face without clipping its outer shadows.
                Row(
                    modifier: Modifier.MatchParentSize().Clip(shape)
                        .Clickable(onClick, indication, interactionSource, enabled),
                    content: () => { });
            }
        });
    }
}

internal static class SurfaceModifierExtensions
{
    internal static IModifier WithSurfaceElevation(this IModifier modifier, Shape shape, Dp elevation) =>
        elevation > 0.Dp()
            ? modifier.DropShadow(shape, Shadow(radius: elevation, spread: elevation, color: Color.Black))
            : modifier;
}
