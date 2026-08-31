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
);