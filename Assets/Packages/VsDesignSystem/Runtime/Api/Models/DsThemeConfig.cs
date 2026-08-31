// ReSharper disable CheckNamespace

namespace VS.UiToolkit;

public readonly record struct DsThemeConfig(
    ColorSchemeConfig ColorScheme,
    TypographyConfig Typography,
    ShapesConfig Shapes,
    IconsConfig Icons
)
{
    public static readonly DsThemeConfig LightTheme = new(
        ColorScheme: ColorSchemeConfig.LightColorScheme,
        Typography: TypographyConfig.Default,
        Shapes: new ShapesConfig(),
        Icons: new IconsConfig()
    );
}