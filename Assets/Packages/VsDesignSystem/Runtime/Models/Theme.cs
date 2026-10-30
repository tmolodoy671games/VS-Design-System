// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

public readonly record struct Theme(
    ColorScheme ColorScheme,
    Shapes Shapes,
    Typography Typography
)
{
    public static Theme Dark { get; } = new(
        ColorScheme: new SerializableColorScheme().ToColorSystem(),
        Shapes: new SerializableShapes().ToShapes(),
        Typography: new SerializableTypography().ToTypography()
    );
}
