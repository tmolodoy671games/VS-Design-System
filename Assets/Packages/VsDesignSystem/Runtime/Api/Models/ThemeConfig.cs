// ReSharper disable CheckNamespace

namespace VS.UiToolkit;

public readonly record struct ThemeConfig(
    ColorSchemeConfig ColorScheme,
    TypographyConfig Typography,
    ShapesConfig Shapes,
    IconsConfig Icons,
    AnimationSpecConfig AnimationSpecs
);