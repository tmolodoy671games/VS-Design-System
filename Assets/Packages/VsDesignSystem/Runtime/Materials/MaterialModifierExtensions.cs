using System;
using Compose.Net;
using UnityEngine.UIElements;
using static VS.DesignSystem.SurfaceFunctions;
using StableCollections;

namespace VS.DesignSystem;

public static partial class MaterialModifierExtensions
{
    /// <summary>Draws a material without changing layout, hit targets, child opacity or clipping children.</summary>
    public static IModifier Surface(this IModifier modifier, SurfaceMaterial material = default,
        SurfaceDepth depth = default, Color? color = null, Shape shape = default) =>
        modifier.Surface(Appearances.Surface(material, depth, color, shape));

    public static IModifier Surface(
        this IModifier modifier,
        SurfaceAppearance appearance
    )
    {
        return modifier.Composed(appearance, () =>
        {
            var material = appearance.Material;
            // Read locals in a stable order on every composition, including opacity zero.
            var opacity = material.ResolveOpacity(SurfaceFunctions.LocalMaterialOpacity.Current);
            var density = LocalDensity.Current;
            var light = SurfaceFunctions.LocalSurfaceLighting.Current;
            var theme = CurrentTheme;
            var shape = appearance.Shape.GetOrDefault(theme.Shapes.Medium);
            var depth = appearance.Depth;
            var amount = depth.Amount.IsUnspecified ? 0.Dp() : depth.Amount;
            var distance = amount.ToPx(density);
            var offset = new Offset(-light.X * distance, -light.Y * distance);
            // Balance the two lobes by available contrast, not identical opacity.
            // Outer shadows sit on the theme surface; inset shadows sit on the face.
            var shadowBackground = depth.Kind == SurfaceDepthKind.Inset
                ? appearance.Color ?? theme.ColorScheme.Surface : theme.ColorScheme.Surface;
            var brightness = Math.Clamp(shadowBackground.Red * .2126f
                + shadowBackground.Green * .7152f + shadowBackground.Blue * .0722f, 0f, 1f);
            var contrast = Math.Min(.1f, .9f * Math.Min(brightness, 1f - brightness))
                * Math.Clamp(light.Intensity, 0f, 1f);
            var dark = Color.Black with
            {
                Alpha = opacity * Math.Clamp(contrast / Math.Max(brightness, .001f), 0f, .9f)
            };
            var bright = Color.White with
            {
                Alpha = opacity * Math.Clamp(contrast / Math.Max(1f - brightness, .001f), 0f, .9f)
            };
            var result = Modifier;
            if (distance > 0 && depth.Kind == SurfaceDepthKind.Raised)
                result = result
                    .DropShadow(shape, Shadow(amount * 2, 0.Dp(), dark, offset))
                    .DropShadow(shape, Shadow(amount * 2, 0.Dp(), bright, new Offset(-offset.X, -offset.Y)));
            else if (distance > 0 && depth.Kind == SurfaceDepthKind.Floating)
                result = result.DropShadow(shape, Shadow(amount * 2, 0.Dp(), dark, offset));

            var finish = theme.Materials[material.Kind];
            var sheen = Math.Clamp(finish.Sheen, 0f, 1f) * light.Intensity;
            var faceColor = appearance.Color ?? theme.ColorScheme.Surface;
            var lighter = Color.Lerp(faceColor, Color.White with { Alpha = faceColor.Alpha }, sheen);
            var darker = Color.Lerp(faceColor, Color.Black with { Alpha = faceColor.Alpha }, sheen);
            var reverse = (Math.Abs(light.X) > Math.Abs(light.Y) ? light.X : light.Y) > 0;
            // Broad surface lighting: a soft lit edge fading through the base color,
            // shared by ceramic and metal without a painted specular stripe.
            var colors = new[] { reverse ? darker : lighter, faceColor, reverse ? lighter : darker }
                .ToPersistentStableList();
            var face = Math.Abs(light.X) > Math.Abs(light.Y)
                ? Brush.HorizontalGradient(colors)
                : Brush.VerticalGradient(colors);
            result = result.Draw(d =>
            {
                if (d.Size.Width <= 0 || d.Size.Height <= 0) return;
                d.DrawShape(face, shape: shape, alpha: opacity);
                MaterialTexture.Draw(d, material, shape, density,
                    opacity * faceColor.Alpha * Math.Clamp(finish.TextureContrast, 0f, 1f)
                    * (material.Kind == SurfaceMaterialKind.Metal ? 0.32f : 1f), finish.TextureShadowsOnly);
            });
            if (distance > 0 && depth.Kind == SurfaceDepthKind.Inset)
                result = result
                    .InnerShadow(shape, Shadow(amount * 2, 0.Dp(), dark, offset))
                    .InnerShadow(shape, Shadow(amount * 2, 0.Dp(), bright, new Offset(-offset.X, -offset.Y)));
            if (finish.RimOpacity > 0)
                result = result.Border(0.75f.Dp(), SolidColor(Color.White with
                {
                    Alpha = opacity * faceColor.Alpha * light.Intensity * Math.Clamp(finish.RimOpacity, 0f, 1f)
                }), shape);
            return result;
        });
    }

}

internal static class MaterialTexture
{
    internal static void Draw(IDrawScope draw, SurfaceMaterial material, Shape shape, IDensity density, float opacity, bool shadowsOnly)
    {
        if (opacity <= 0 || material.TextureStrength <= 0) return;
        if (draw is IDrawScope<MeshGenerationContext> textured)
            MaterialTextures.Draw(textured, material, shape, opacity, material.TextureScale.ToPx(density), density, shadowsOnly);
    }
}