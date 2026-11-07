// ReSharper disable CheckNamespace

using Unity.Scripting.LifecycleManagement;

namespace VS.DesignSystem;

[NoAutoStaticsCleanup]
public static class DsLightThemeFunctions
{
    public static readonly DsTheme.Values DsLightTheme = new(
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
            Background: Rgb(0xE2E2E2),
            OnBackground: Rgb(0x242424),
            Surface: Rgb(0xE8E8E8),
            OnSurface: Rgb(0x242424),
            SurfaceVariant: Rgb(0xD8D8D8),
            OnSurfaceVariant: Rgb(0x535353),
            SurfaceTint: Rgb(0x365879),
            InverseSurface: Rgb(0x252933),
            InverseOnSurface: Rgb(0xF2F3EE),
            Error: Rgb(0xBA1A1A),
            OnError: Rgb(0xFFFFFF),
            ErrorContainer: Rgb(0xFFDAD6),
            OnErrorContainer: Rgb(0x410002),
            Outline: Rgb(0x767676),
            OutlineVariant: Rgb(0xCCCCCC),
            Scrim: Rgb(0x202820),
            SurfaceBright: Rgb(0xEFEFEF),
            SurfaceDim: Rgb(0xCDCDCD),
            SurfaceContainer: Rgb(0xDFDFDF),
            SurfaceContainerHigh: Rgb(0xDADADA),
            SurfaceContainerHighest: Rgb(0xD4D4D4),
            SurfaceContainerLow: Rgb(0xE5E5E5),
            SurfaceContainerLowest: Rgb(0xF1F1F1)
        ),
        Shapes: new DsShapes(),
        Typography: new DsTypography()
    );

    private static Color Rgb(uint hex) => new(
        ((hex >> 16) & 0xFF) / 255f,
        ((hex >> 8) & 0xFF) / 255f,
        (hex & 0xFF) / 255f,
        1f
    );
}
