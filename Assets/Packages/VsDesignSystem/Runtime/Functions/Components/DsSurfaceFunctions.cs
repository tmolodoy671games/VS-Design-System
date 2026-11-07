using System;
using Compose.Net;
using SharpExtensions;
using Unity.Scripting.LifecycleManagement;
using UnityEngine.UIElements;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

[AutoStaticsCleanup]
[AutoGlobalUsingStatic]
public static partial class DsSurfaceFunctions
{
    [Composable, NonRestartableComposable]
    public static void DsSurface(
        Action onClick,
        [Composable] Action content,
        IModifier? modifier = null,
        bool enabled = true,
        Shape shape = default,
        Color color = default,
        Color contentColor = default,
        BorderStroke border = default,
        IMutableInteractionSource? interactionSource = null,
        Alignment? contentAlignment = null
    )
    {
        var theme = DsTheme.LocalTheme.Current;
        var resolvedColor = color.GetOrDefault(theme.ColorScheme.Surface);
        var foreground = contentColor.GetOrDefault(ContentColorFor(resolvedColor));
        var face = modifier.OrEmpty();
        var resolvedShape = shape;
        face = face
            .Background(resolvedColor, resolvedShape)
            .Clip(resolvedShape);

        SurfaceImpl(
            content,
            face,
            foreground,
            resolvedShape,
            border,
            contentAlignment ?? Alignment.TopStart,
            onClick,
            enabled,
            interactionSource
        );
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
                Box(
                    modifier: Modifier
                        .MatchParentSize()
                        .Clip(shape)
                        .Clickable(onClick, indication, interactionSource, enabled),
                    content: () => { });
            }
        });
    }
}