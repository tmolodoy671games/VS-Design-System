// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

/// <summary>The shared dark theme.</summary>
public static class DarkTheme
{
    public static Theme Instance { get; } = new(
        ColorScheme: new ColorScheme(
            Primary: Rgb(0xAAC4E4),
            OnPrimary: Rgb(0x192D44),
            PrimaryContainer: Rgb(0x35465D),
            OnPrimaryContainer: Rgb(0xDCE8F8),
            InversePrimary: Rgb(0x365879),
            Secondary: Rgb(0xC6B9E2),
            OnSecondary: Rgb(0x302746),
            SecondaryContainer: Rgb(0x453E57),
            OnSecondaryContainer: Rgb(0xE8E0FF),
            Tertiary: Rgb(0xE2B59F),
            OnTertiary: Rgb(0x492F24),
            TertiaryContainer: Rgb(0x563F36),
            OnTertiaryContainer: Rgb(0xFFE1D0),
            Background: Rgb(0x1B1E25),
            OnBackground: Rgb(0xF2F3EE),
            Surface: Rgb(0x252933),
            OnSurface: Rgb(0xF2F3EE),
            SurfaceVariant: Rgb(0x414958),
            OnSurfaceVariant: Rgb(0xB0B7C5),
            SurfaceTint: Rgb(0xAAC4E4),
            InverseSurface: Rgb(0xFAF8F2),
            InverseOnSurface: Rgb(0x202820),
            Error: Rgb(0xE3AAA6),
            OnError: Rgb(0x4A2323),
            ErrorContainer: Rgb(0x633635),
            OnErrorContainer: Rgb(0xF8DAD6),
            Outline: Rgb(0x8F99A9),
            OutlineVariant: Rgb(0x414958),
            Scrim: Rgb(0x11131B),
            SurfaceBright: Rgb(0x454D5D),
            SurfaceDim: Rgb(0x1B1E25),
            SurfaceContainer: Rgb(0x2A2F3A),
            SurfaceContainerHigh: Rgb(0x303642),
            SurfaceContainerHighest: Rgb(0x3A4250),
            SurfaceContainerLow: Rgb(0x22262F),
            SurfaceContainerLowest: Rgb(0x171A20)
        ),
        Shapes: new SerializableShapes().ToShapes(),
        Typography: new SerializableTypography().ToTypography()
    )
    {
        Materials = MaterialSettings.Default with { Metal = new(.12f, .10f, .10f) }
    };

    private static Color Rgb(uint hex) => new(
        ((hex >> 16) & 0xFF) / 255f,
        ((hex >> 8) & 0xFF) / 255f,
        (hex & 0xFF) / 255f,
        1f
    );
}
