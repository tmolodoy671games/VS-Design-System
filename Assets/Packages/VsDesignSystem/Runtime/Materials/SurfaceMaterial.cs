using System;
using Compose.Net;

namespace VS.DesignSystem;

public enum SurfaceMaterialKind { Matte, Ceramic, Paper, Cloth, Metal }
public enum ClothWeave { Linen, Canvas, Felt, Twill }

public static class Weaves
{
    public static ClothWeave Linen() => ClothWeave.Linen;
    public static ClothWeave Canvas() => ClothWeave.Canvas;
    public static ClothWeave Felt() => ClothWeave.Felt;
    public static ClothWeave Twill() => ClothWeave.Twill;
}

/// <summary>Immutable recipe. Default is matte with inherited opacity; no composition is read by factories.</summary>
public readonly record struct SurfaceMaterial
{
    private readonly bool _specified;
    private readonly float _opacity;
    private readonly float _textureStrength;
    private readonly Dp _textureScale;
    public SurfaceMaterialKind Kind { get; }
    public ClothWeave Weave { get; }
    public float Opacity => _specified ? _opacity : -1f;
    public float TextureStrength => _specified ? _textureStrength : 0.35f;
    public Dp TextureScale => _specified ? _textureScale : 256.Dp();

    internal SurfaceMaterial(SurfaceMaterialKind kind, float opacity, float textureStrength, Dp textureScale, ClothWeave weave = default)
    {
        ValidateOpacity(opacity, true);
        ValidateUnit(textureStrength, nameof(textureStrength));
        textureScale = textureScale.IsUnspecified ? 256.Dp() : textureScale;
        if (textureScale <= 0.Dp() || !float.IsFinite(textureScale.ToPx(Density.Default)))
            throw new ArgumentOutOfRangeException(nameof(textureScale));
        if ((uint)weave > (uint)ClothWeave.Twill) throw new ArgumentOutOfRangeException(nameof(weave));
        _specified = true; _opacity = opacity; _textureStrength = textureStrength; _textureScale = textureScale;
        Kind = kind; Weave = weave;
    }

    internal float ResolveOpacity(float inherited)
    {
        var value = Opacity == -1f ? inherited : Opacity;
        ValidateOpacity(value, false);
        return value;
    }

    internal static void ValidateUnit(float value, string name)
    {
        if (!float.IsFinite(value) || value < 0 || value > 1) throw new ArgumentOutOfRangeException(name);
    }

    private static void ValidateOpacity(float value, bool allowInherited)
    {
        if (allowInherited && value == -1f) return;
        ValidateUnit(value, "opacity");
    }
}

public static class Materials
{
    public static SurfaceMaterial Matte(float opacity = -1f, float textureStrength = 0.35f, Dp textureScale = default) => new(SurfaceMaterialKind.Matte, opacity, textureStrength, textureScale);
    public static SurfaceMaterial Ceramic(float opacity = -1f, float textureStrength = 0.35f, Dp textureScale = default) => new(SurfaceMaterialKind.Ceramic, opacity, textureStrength, textureScale);
    public static SurfaceMaterial Paper(float opacity = -1f, float textureStrength = 0.35f, Dp textureScale = default) =>
        new(SurfaceMaterialKind.Paper, opacity, textureStrength, textureScale);
    public static SurfaceMaterial Cloth(ClothWeave weave = ClothWeave.Linen, float opacity = -1f,
        float textureStrength = 0.35f, Dp textureScale = default) =>
        new(SurfaceMaterialKind.Cloth, opacity, textureStrength, textureScale, weave);
    public static SurfaceMaterial Metal(float opacity = -1f, float textureStrength = 0.35f, Dp textureScale = default) =>
        new(SurfaceMaterialKind.Metal, opacity, textureStrength, textureScale);
}

public enum SurfaceDepthKind { Flat, Raised, Inset, Floating }

public readonly record struct SurfaceDepth
{
    public SurfaceDepthKind Kind { get; }
    public Dp Amount { get; }
    internal SurfaceDepth(SurfaceDepthKind kind, Dp amount)
    {
        if (amount.IsUnspecified || amount < 0.Dp() || !float.IsFinite(amount.ToPx(Density.Default)))
            throw new ArgumentOutOfRangeException(nameof(amount));
        Kind = kind; Amount = amount;
    }
}

public static class Depth
{
    public static SurfaceDepth Flat => default;
    public static SurfaceDepth Raised(Dp amount) => new(SurfaceDepthKind.Raised, amount);
    public static SurfaceDepth Inset(Dp amount) => new(SurfaceDepthKind.Inset, amount);
    public static SurfaceDepth Floating(Dp amount) => new(SurfaceDepthKind.Floating, amount);
}

public readonly record struct SurfaceLighting
{
    public float X { get; }
    public float Y { get; }
    public float Intensity { get; }
    private SurfaceLighting(float x, float y, float intensity) { X = x; Y = y; Intensity = intensity; }
    public static SurfaceLighting SoftTopLeft => Directional(-1, -1);
    /// <summary>Direction towards the light, normalized by the factory.</summary>
    public static SurfaceLighting Directional(float x, float y, float intensity = 0.65f)
    {
        SurfaceMaterial.ValidateUnit(intensity, nameof(intensity));
        var length = Math.Sqrt((double)x * x + (double)y * y);
        if (!double.IsFinite(length) || length == 0) throw new ArgumentOutOfRangeException(nameof(x));
        return new((float)(x / length), (float)(y / length), intensity);
    }
}

public readonly record struct SurfaceAppearance(SurfaceMaterial Material, SurfaceDepth Depth, Color? Color, Shape Shape);

public static class Appearances
{
    public static SurfaceAppearance Surface(SurfaceMaterial material = default, SurfaceDepth depth = default,
        Color? color = null, Shape shape = default) => new(material, depth, color, shape);
}
