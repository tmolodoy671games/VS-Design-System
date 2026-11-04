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
public readonly record struct MaterialFinish(float TextureContrast, float Sheen, float RimOpacity = 0);

public sealed record MaterialSettings(
    MaterialFinish Matte,
    MaterialFinish Ceramic,
    MaterialFinish Paper,
    MaterialFinish Cloth,
    MaterialFinish Metal)
{
    public static MaterialSettings Default { get; } = new(
        Matte: new(.38f, .07f),
        Ceramic: new(.38f, .22f, .25f),
        Paper: new(.38f, .04f),
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
