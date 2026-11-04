// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

/// <summary>The shared light theme.</summary>
public static class LightTheme
{
    public static Theme Instance { get; } = new(
        ColorScheme: new ColorScheme(
            Primary: Rgb(0x365879),
            OnPrimary: Rgb(0xFFFFFF),
            PrimaryContainer: Rgb(0xDCE8F8),
            OnPrimaryContainer: Rgb(0x192D44),
            InversePrimary: Rgb(0xAAC4E4),
            Secondary: Rgb(0x6651AA),
            OnSecondary: Rgb(0xFFFFFF),
            SecondaryContainer: Rgb(0xE0D8FF),
            OnSecondaryContainer: Rgb(0x302746),
            Tertiary: Rgb(0x9B4825),
            OnTertiary: Rgb(0xFFFFFF),
            TertiaryContainer: Rgb(0xF8D4C0),
            OnTertiaryContainer: Rgb(0x492F24),
            Background: Rgb(0xF3F5F1),
            OnBackground: Rgb(0x202820),
            Surface: Rgb(0xFAF8F2),
            OnSurface: Rgb(0x202820),
            SurfaceVariant: Rgb(0xE5EAE1),
            OnSurfaceVariant: Rgb(0x566151),
            SurfaceTint: Rgb(0x365879),
            InverseSurface: Rgb(0x252933),
            InverseOnSurface: Rgb(0xF2F3EE),
            Error: Rgb(0xBA1A1A),
            OnError: Rgb(0xFFFFFF),
            ErrorContainer: Rgb(0xFFDAD6),
            OnErrorContainer: Rgb(0x410002),
            Outline: Rgb(0x7A8675),
            OutlineVariant: Rgb(0xCCD4C7),
            Scrim: Rgb(0x202820),
            SurfaceBright: Rgb(0xFFFEFA),
            SurfaceDim: Rgb(0xD6DDCF),
            SurfaceContainer: Rgb(0xE9EDE5),
            SurfaceContainerHigh: Rgb(0xE5EAE1),
            SurfaceContainerHighest: Rgb(0xDCE3D5),
            SurfaceContainerLow: Rgb(0xF0F2EA),
            SurfaceContainerLowest: Rgb(0xFFFFFF)
        ),
        Shapes: new SerializableShapes().ToShapes(),
        Typography: new SerializableTypography().ToTypography()
    );

    private static Color Rgb(uint hex) => new(
        ((hex >> 16) & 0xFF) / 255f,
        ((hex >> 8) & 0xFF) / 255f,
        (hex & 0xFF) / 255f,
        1f
    );
}
