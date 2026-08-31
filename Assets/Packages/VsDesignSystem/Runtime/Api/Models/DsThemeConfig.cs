// ReSharper disable CheckNamespace

namespace VS.UiToolkit;

public readonly record struct DsThemeConfig(
    ColorSchemeConfig ColorScheme,
    TypographyConfig Typography,
    ShapesConfig Shapes,
    IconsConfig Icons
);