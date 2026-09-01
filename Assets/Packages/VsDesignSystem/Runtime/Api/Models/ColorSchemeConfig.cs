// ReSharper disable CheckNamespace

using UnityEngine;

namespace VS.UiToolkit;

public readonly record struct ColorSchemeConfig(
    // Primary
    Color Primary,
    Color PrimaryContainer,
    Color OnPrimary,

    // Secondary
    Color Secondary,
    Color SecondaryContainer,
    Color OnSecondary,

    // Surface
    Color Surface,
    Color SurfaceVariant,
    Color OnSurface,

    // Outline
    Color Outline,
    
    // Interaction
    Color Hover,
    Color Press
)
{
    public Color OnPrimaryContainer => OnPrimary;
    public Color OnSecondaryContainer => OnSecondary;
    public Color OnSurfaceVariant => OnSurface;
}