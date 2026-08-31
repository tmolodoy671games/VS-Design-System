// ReSharper disable CheckNamespace

using UnityEngine;

namespace VS.UiToolkit;

public readonly record struct ColorSchemeConfig(
    // Primary
    Color Primary,
    Color OnPrimary,

    // Surface
    Color Surface,
    Color OnSurface,
    Color SurfaceVariant,
    Color OnSurfaceVariant,
    Color SurfaceContainerHighest,

    // Outline
    Color Outline
)
{
    public static readonly ColorSchemeConfig LightColorScheme = new(
        // Primary
        Primary: new Color(0.404f, 0.314f, 0.643f, 1f),              // #6750A4
        OnPrimary: new Color(1.000f, 1.000f, 1.000f, 1f),            // #FFFFFF

        // Surface
        Surface: new Color(1.000f, 0.984f, 0.996f, 1f),             // #FFFBFE
        OnSurface: new Color(0.110f, 0.106f, 0.122f, 1f),            // #1C1B1F
        SurfaceVariant: new Color(0.906f, 0.878f, 0.925f, 1f),      // #E7E0EC
        OnSurfaceVariant: new Color(0.290f, 0.275f, 0.310f, 1f),    // #49454F
        SurfaceContainerHighest: new Color(0.918f, 0.898f, 0.929f, 1f), // #E6E0E9

        // Outline
        Outline: new Color(0.467f, 0.443f, 0.486f, 1f)             // #79747E
    );
}