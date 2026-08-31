// ReSharper disable CheckNamespace

using UnityEngine;

namespace VS.UiToolkit;

public readonly record struct ColorSchemeConfig(
    // Primary
    Color Primary,
    Color OnPrimary,
    // Surface
    Color Surface,
    Color OnSurface
)
{
    public static readonly ColorSchemeConfig LightColorScheme = new(
        Primary: new(0.404f, 0.314f, 0.643f, 1f),
        OnPrimary: new(1.000f, 1.000f, 1.000f, 1f),
        Surface: new(1.000f, 0.984f, 0.996f, 1f),
        OnSurface: new(0.110f, 0.106f, 0.122f, 1f)
    );
}