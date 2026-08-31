// ReSharper disable CheckNamespace

using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace VS.UiToolkit;

[Serializable]
public class SerializableColorSchemeConfig
{
    [Tooltip("Buttons and other interactive UI components")]
    [SerializeField, BoxGroup("Primary")] private Color primary = new(0.404f, 0.314f, 0.643f, 1f);
    [Tooltip("Buttons text, icons and other interactive UI inner content")]
    [SerializeField, BoxGroup("Primary")] private Color onPrimary = new(1.000f, 1.000f, 1.000f, 1f);

    [SerializeField, BoxGroup("Surface")] private Color surface = new(1.000f, 0.984f, 0.996f, 1f);
    [SerializeField, BoxGroup("Surface")] private Color onSurface = new(0.110f, 0.106f, 0.122f, 1f);

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