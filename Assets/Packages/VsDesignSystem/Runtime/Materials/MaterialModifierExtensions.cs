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

    public static IModifier Surface(this IModifier modifier, SurfaceAppearance appearance) =>
        modifier.Composed(appearance, () =>
        {
            var material = appearance.Material;
            // Read locals in a stable order on every composition, including opacity zero.
            var opacity = material.ResolveOpacity(VS.DesignSystem.SurfaceFunctions.LocalMaterialOpacity.Current);
            var density = LocalDensity.Current;
            var light = VS.DesignSystem.SurfaceFunctions.LocalSurfaceLighting.Current;
            var theme = CurrentTheme;
            var shape = appearance.Shape.GetOrDefault(theme.Shapes.Medium);
            var depth = appearance.Depth;
            var amount = depth.Amount.IsUnspecified ? 0.Dp() : depth.Amount;
            var distance = amount.ToPx(density);
            var offset = new Offset(-light.X * distance, -light.Y * distance);
            var dark = Color.Lerp(theme.ColorScheme.Scrim, theme.ColorScheme.Secondary, 0.12f)
                with { Alpha = opacity * (0.24f + light.Intensity * 0.3f) };
            var bright = Color.Lerp(Color.Lerp(theme.ColorScheme.SurfaceBright, Color.White, 0.35f), theme.ColorScheme.Primary, 0.1f)
                with { Alpha = opacity * light.Intensity * 0.45f };
            var result = Modifier;
            if (distance > 0 && depth.Kind == SurfaceDepthKind.Raised)
                result = result
                    .DropShadow(shape, Shadow(amount * 2, 0.Dp(), dark, offset))
                    .DropShadow(shape, Shadow(amount * 2, 0.Dp(), bright, new Offset(-offset.X, -offset.Y)));
            else if (distance > 0 && depth.Kind == SurfaceDepthKind.Floating)
                result = result.DropShadow(shape, Shadow(amount * 2, 0.Dp(), dark, offset));

            var sheen = material.Kind switch
            {
                SurfaceMaterialKind.Ceramic => 0.22f,
                SurfaceMaterialKind.Metal => 0.32f,
                SurfaceMaterialKind.Cloth => 0.025f,
                SurfaceMaterialKind.Paper => 0.04f,
                _ => 0.07f
            } * light.Intensity;
            var faceColor = appearance.Color ?? theme.ColorScheme.Surface;
            var lighter = Color.Lerp(faceColor, Color.White with { Alpha = faceColor.Alpha }, sheen);
            var darker = Color.Lerp(faceColor, Color.Black with { Alpha = faceColor.Alpha }, sheen);
            var reverse = (Math.Abs(light.X) > Math.Abs(light.Y) ? light.X : light.Y) > 0;
            var colors = new[] { reverse ? darker : lighter, faceColor, reverse ? lighter : darker }.ToPersistentStableList();
            var face = Math.Abs(light.X) > Math.Abs(light.Y) ? Brush.HorizontalGradient(colors) : Brush.VerticalGradient(colors);
            result = result.Draw(d =>
            {
                if (d.Size.Width <= 0 || d.Size.Height <= 0) return;
                d.DrawShape(face, shape: shape, alpha: opacity);
                MaterialTexture.Draw(d, material, shape, density, opacity * faceColor.Alpha);
            });
            if (distance > 0 && depth.Kind == SurfaceDepthKind.Inset)
                result = result
                    .InnerShadow(shape, Shadow(amount * 2, 0.Dp(), dark, offset))
                    .InnerShadow(shape, Shadow(amount * 2, 0.Dp(), bright, new Offset(-offset.X, -offset.Y)));
            // Ceramic and metal retain a crisp lip even when flat; cloth has no hard specular rim.
            if (material.Kind == SurfaceMaterialKind.Ceramic || material.Kind == SurfaceMaterialKind.Metal)
                result = result.Border(0.75f.Dp(), SolidColor(Color.White with { Alpha = opacity * light.Intensity * 0.25f }), shape);
            return result;
        });
}

internal static class MaterialTexture
{
    internal static void Draw(IDrawScope draw, SurfaceMaterial material, Shape shape, IDensity density, float opacity)
    {
        if (opacity <= 0 || material.TextureStrength <= 0) return;
        if (draw is IDrawScope<MeshGenerationContext> textured)
            MaterialTextures.Draw(textured, material, shape, opacity, material.TextureScale.ToPx(density), density);
    }
}
