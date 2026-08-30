// ReSharper disable CheckNamespace

namespace VS.UiToolkit;

public readonly record struct DsThemeConfig(
    DsColorSchemeConfig ColorScheme,
    DsTypographyConfig Typography,
    DsShapesConfig Shapes,
    DsIconsConfig Icons
);