// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using UnityEngine;
using Compose.Net.Unity;
using UnityColor = UnityEngine.Color;

namespace VS.DesignSystem;

[Serializable]
public class SerializableColorScheme
{
    [SerializeField] private UnityColor primary = Rgb(0xA6BCE0);
    [SerializeField] private UnityColor onPrimary = Rgb(0x20324D);
    [SerializeField] private UnityColor primaryContainer = Rgb(0x344965);
    [SerializeField] private UnityColor onPrimaryContainer = Rgb(0xD8E5FA);
    [SerializeField] private UnityColor inversePrimary = Rgb(0x4C6383);
    [SerializeField] private UnityColor secondary = Rgb(0x91C7CC);
    [SerializeField] private UnityColor onSecondary = Rgb(0x19383C);
    [SerializeField] private UnityColor secondaryContainer = Rgb(0x304E53);
    [SerializeField] private UnityColor onSecondaryContainer = Rgb(0xCBECEF);
    [SerializeField] private UnityColor tertiary = Rgb(0xBCB5D1);
    [SerializeField] private UnityColor onTertiary = Rgb(0x322E43);
    [SerializeField] private UnityColor tertiaryContainer = Rgb(0x49445B);
    [SerializeField] private UnityColor onTertiaryContainer = Rgb(0xE6DFF4);
    [SerializeField] private UnityColor background = Rgb(0x111419);
    [SerializeField] private UnityColor onBackground = Rgb(0xE1E3E9);
    [SerializeField] private UnityColor surface = Rgb(0x111419);
    [SerializeField] private UnityColor onSurface = Rgb(0xE1E3E9);
    [SerializeField] private UnityColor surfaceVariant = Rgb(0x414750);
    [SerializeField] private UnityColor onSurfaceVariant = Rgb(0xC1C7D1);
    [SerializeField] private UnityColor surfaceTint = Rgb(0xA6BCE0);
    [SerializeField] private UnityColor inverseSurface = Rgb(0xE1E3E9);
    [SerializeField] private UnityColor inverseOnSurface = Rgb(0x2B3037);
    [SerializeField] private UnityColor error = Rgb(0xE3AAA6);
    [SerializeField] private UnityColor onError = Rgb(0x4A2323);
    [SerializeField] private UnityColor errorContainer = Rgb(0x633635);
    [SerializeField] private UnityColor onErrorContainer = Rgb(0xF8DAD6);
    [SerializeField] private UnityColor outline = Rgb(0x8B929D);
    [SerializeField] private UnityColor outlineVariant = Rgb(0x414750);
    [SerializeField] private UnityColor scrim = Rgb(0x000000);
    [SerializeField] private UnityColor surfaceBright = Rgb(0x373C44);
    [SerializeField] private UnityColor surfaceDim = Rgb(0x111419);
    [SerializeField] private UnityColor surfaceContainer = Rgb(0x1D2229);
    [SerializeField] private UnityColor surfaceContainerHigh = Rgb(0x282D35);
    [SerializeField] private UnityColor surfaceContainerHighest = Rgb(0x333841);
    [SerializeField] private UnityColor surfaceContainerLow = Rgb(0x191D24);
    [SerializeField] private UnityColor surfaceContainerLowest = Rgb(0x0C0F14);

    private static UnityColor Rgb(uint hex) => new Color32(
        (byte)(hex >> 16),
        (byte)(hex >> 8),
        (byte)hex,
        255
    );

    public ColorScheme ToColorSystem() => new(
        Primary: primary.ToComposeColor(),
        OnPrimary: onPrimary.ToComposeColor(),
        PrimaryContainer: primaryContainer.ToComposeColor(),
        OnPrimaryContainer: onPrimaryContainer.ToComposeColor(),
        InversePrimary: inversePrimary.ToComposeColor(),
        Secondary: secondary.ToComposeColor(),
        OnSecondary: onSecondary.ToComposeColor(),
        SecondaryContainer: secondaryContainer.ToComposeColor(),
        OnSecondaryContainer: onSecondaryContainer.ToComposeColor(),
        Tertiary: tertiary.ToComposeColor(),
        OnTertiary: onTertiary.ToComposeColor(),
        TertiaryContainer: tertiaryContainer.ToComposeColor(),
        OnTertiaryContainer: onTertiaryContainer.ToComposeColor(),
        Background: background.ToComposeColor(),
        OnBackground: onBackground.ToComposeColor(),
        Surface: surface.ToComposeColor(),
        OnSurface: onSurface.ToComposeColor(),
        SurfaceVariant: surfaceVariant.ToComposeColor(),
        OnSurfaceVariant: onSurfaceVariant.ToComposeColor(),
        SurfaceTint: surfaceTint.ToComposeColor(),
        InverseSurface: inverseSurface.ToComposeColor(),
        InverseOnSurface: inverseOnSurface.ToComposeColor(),
        Error: error.ToComposeColor(),
        OnError: onError.ToComposeColor(),
        ErrorContainer: errorContainer.ToComposeColor(),
        OnErrorContainer: onErrorContainer.ToComposeColor(),
        Outline: outline.ToComposeColor(),
        OutlineVariant: outlineVariant.ToComposeColor(),
        Scrim: scrim.ToComposeColor(),
        SurfaceBright: surfaceBright.ToComposeColor(),
        SurfaceDim: surfaceDim.ToComposeColor(),
        SurfaceContainer: surfaceContainer.ToComposeColor(),
        SurfaceContainerHigh: surfaceContainerHigh.ToComposeColor(),
        SurfaceContainerHighest: surfaceContainerHighest.ToComposeColor(),
        SurfaceContainerLow: surfaceContainerLow.ToComposeColor(),
        SurfaceContainerLowest: surfaceContainerLowest.ToComposeColor()
    );
}

