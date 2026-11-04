using System;
using Compose.Net;

namespace VS.DesignSystem;

public static partial class SurfaceFunctions
{
    public static readonly ICompositionLocal<float> LocalMaterialOpacity = CompositionLocalOf(() => 1f);

    public static readonly ICompositionLocal<SurfaceLighting> LocalSurfaceLighting =
        CompositionLocalOf(() => SurfaceLighting.SoftTopLeft);

    [Composable]
    public static void Surface(
        [Composable] Action content,
        SurfaceMaterial material = default,
        SurfaceDepth depth = default,
        Color? color = null,
        Shape shape = default,
        IModifier? modifier = null,
        Color? contentColor = null
    )
    {
        Surface(content, Appearances.Surface(material, depth, color, shape), modifier, contentColor);
    }

    [Composable]
    public static void Surface(
        [Composable] Action content,
        SurfaceAppearance appearance,
        IModifier? modifier = null,
        Color? contentColor = null,
        Action? onClick = null,
        bool enabled = true,
        BorderStroke border = default,
        IMutableInteractionSource? interactionSource = null,
        Alignment contentAlignment = default
    )
    {
        var theme = CurrentTheme;
        var resolvedContentColor = ContentColorFor(appearance.Color ?? theme.ColorScheme.Surface);
        var shape = appearance.Shape.GetOrDefault(theme.Shapes.Medium);
        SurfaceImpl(content, modifier.OrEmpty().Surface(appearance), contentColor ?? resolvedContentColor,
            shape, border, contentAlignment, onClick, enabled, interactionSource);
    }
}
