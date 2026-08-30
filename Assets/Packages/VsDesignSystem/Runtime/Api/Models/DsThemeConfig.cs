// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

public readonly record struct DsThemeConfig(
    DsColorSchemeConfig ColorScheme,
    DsTypographyConfig Typography,
    DsShapesConfig Shapes,
    DsIconsConfig Icons
);