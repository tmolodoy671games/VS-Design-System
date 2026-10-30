using System;
using Compose.Net;
using SharpExtensions;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

public static partial class DesignSystemComposeFunctions
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
        IMutableInteractionSource? interactionSource = null
    )
    {
        var resolvedColor = color.GetOrDefault(Theme.ColorScheme.Surface);
        var resolvedContentColor = contentColor.GetOrDefault(ContentColorFor(resolvedColor));
        SurfaceImpl(
            onClick: onClick,
            content: content,
            modifier: modifier.OrEmpty(),
            enabled: enabled,
            shape: shape,
            color: resolvedColor,
            contentColor: resolvedContentColor,
            shadowElevation: shadowElevation,
            border: border,
            interactionSource: interactionSource
        );
    }

    [Composable]
    private static void SurfaceImpl(
        Action onClick,
        [Composable] Action content,
        IModifier modifier,
        bool enabled,
        Shape shape,
        Color color,
        Color contentColor,
        Dp shadowElevation,
        BorderStroke border,
        IMutableInteractionSource? interactionSource = null
    )
    {
        CompositionLocalProvider(
            LocalContentColor.Provides(contentColor),
            content: () =>
            {
                Box(
                    modifier: modifier
                        .Clickable(
                            onClick: onClick,
                            enabled: enabled,
                            interactionSource: interactionSource,
                            indication: LocalIndication.Current
                        )
                        .Surface(
                            shape: shape,
                            backgroundColor: color,
                            border: border,
                            shadowElevation: shadowElevation
                        ),
                    content: content
                );
            }
        );
    }
}

internal static class ModifierExtensions
{
    public static IModifier Surface(
        this IModifier modifier,
        Shape shape,
        Color backgroundColor,
        BorderStroke border,
        Dp shadowElevation
    )
    {
        return modifier
            .Then(
                shadowElevation > 0.Dp()
                    ? Modifier.DropShadow(
                        shape: shape,
                        shadow: Shadow(
                            radius: shadowElevation,
                            spread: shadowElevation,
                            color: Color.Black
                        )
                    )
                    : Modifier
            )
            .Then(border.Width != default ? Modifier.Border(border, shape) : Modifier)
            .Background(backgroundColor, shape)
            .Clip(shape);
    }
}
