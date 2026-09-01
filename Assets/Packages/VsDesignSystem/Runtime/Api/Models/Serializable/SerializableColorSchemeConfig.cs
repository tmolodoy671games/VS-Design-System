// ReSharper disable CheckNamespace

using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace VS.UiToolkit;

[Serializable]
public class SerializableColorSchemeConfig
{
    [SerializeField, BoxGroup("Primary")] private Color primary = Color.purple;
    [SerializeField, BoxGroup("Primary")] private Color primaryContainer = Color.mediumPurple;

    [SerializeField, BoxGroup("Secondary")] private Color secondary = Color.cornflowerBlue;
    [SerializeField, BoxGroup("Secondary")] private Color secondaryContainer = Color.lightBlue;

    [SerializeField, BoxGroup("Surface")] private Color surface = Color.white;
    [SerializeField, BoxGroup("Surface")] private Color surfaceVariant = Color.gray7;

    [SerializeField, BoxGroup("Outline")] private Color outline = Color.white;

    [SerializeField, BoxGroup("Content")] private Color onLight = Color.black;
    [SerializeField, BoxGroup("Content")] private Color onDark = Color.white;
    
    [SerializeField, BoxGroup("Interaction")] private Color hover = Color.white;
    [SerializeField, BoxGroup("Interaction")] private Color press = Color.white;
    
    public ColorSchemeConfig ToDsColorSchemeConfig()
    {
        return new ColorSchemeConfig(
            // Primary
            Primary: primary,
            PrimaryContainer: primaryContainer,
            OnPrimary: onDark,
            // Secondary
            Secondary: secondary,
            SecondaryContainer: secondaryContainer,
            OnSecondary: onDark,
            // Surface
            Surface: surface,
            SurfaceVariant: surfaceVariant,
            OnSurface: onLight,
            // Outline
            Outline: outline,
            // Interaction
            Hover: hover,
            Press: press
        );
    }
}