// ReSharper disable CheckNamespace

using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace VS.UiToolkit;

[Serializable]
public class SerializableColorSchemeConfig
{
    [Tooltip("Buttons and other interactive UI components")]
    [SerializeField, BoxGroup("Primary")] private Color primary = ColorSchemeConfig.LightColorScheme.Primary;
    
    [Tooltip("Buttons text, icons and other interactive UI inner content")]
    [SerializeField, BoxGroup("Primary")] private Color onPrimary = ColorSchemeConfig.LightColorScheme.OnPrimary;

    [SerializeField, BoxGroup("Surface")] private Color surface = ColorSchemeConfig.LightColorScheme.Surface;
    [SerializeField, BoxGroup("Surface")] private Color onSurface = ColorSchemeConfig.LightColorScheme.OnSurface;

    public ColorSchemeConfig ToDsColorSchemeConfig()
    {
        return new ColorSchemeConfig(
            Primary: primary,
            OnPrimary: onPrimary,
            Surface: surface,
            OnSurface: onSurface
        );
    }
}