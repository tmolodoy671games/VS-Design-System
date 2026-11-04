// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

/// <summary>An immutable theme. Use with expressions to customize a built-in theme.</summary>
public sealed record Theme(
    ColorScheme ColorScheme,
    Shapes Shapes,
    Typography Typography
)
{
    public MaterialSettings Materials { get; init; } = MaterialSettings.Default;
}

/// <summary>Texture contrast, directional sheen and rim opacity, each from 0 to 1.</summary>
public readonly record struct MaterialFinish(float TextureContrast, float Sheen, float RimOpacity = 0,
    bool TextureShadowsOnly = false);

public sealed record MaterialSettings(
    MaterialFinish Matte,
    MaterialFinish Ceramic,
    MaterialFinish Paper,
    MaterialFinish Cloth,
    MaterialFinish Metal)
{
    public static MaterialSettings Default { get; } = new(
        // Matte has only a trace of grain; glazed ceramic is smooth. Paper
        // carries the visible fibre relief instead of sharing it with every finish.
        Matte: new(.025f, .035f),
        Ceramic: new(0f, .22f, .25f),
        Paper: new(.38f, .018f),
        Cloth: new(.38f, .025f),
        Metal: new(.38f, .32f, .25f));

    public MaterialFinish this[SurfaceMaterialKind kind] => kind switch
    {
        SurfaceMaterialKind.Ceramic => Ceramic,
        SurfaceMaterialKind.Paper => Paper,
        SurfaceMaterialKind.Cloth => Cloth,
        SurfaceMaterialKind.Metal => Metal,
        _ => Matte
    };
}
