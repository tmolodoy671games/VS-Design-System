// ReSharper disable CheckNamespace

namespace VS.UiToolkit;

public readonly record struct ThemeConfig(
    ColorSchemeConfig ColorScheme,
    TypographyConfig Typography,
    ShapesConfig Shapes,
    IconsConfig Icons
)
{
    public static readonly ThemeConfig LightTheme = new(
        ColorScheme: ColorSchemeConfig.LightColorScheme,
        Typography: TypographyConfig.Default,
        Shapes: ShapesConfig.Default,
        Icons: new IconsConfig()
    );
}