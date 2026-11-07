using Compose.Net;

namespace VS.DesignSystem;

[Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
public static class DsTheme
{
    internal static readonly ICompositionLocal<Values> LocalTheme =
        CompositionLocalOf(() => DsDarkThemeFunctions.DsDarkTheme);

    public static ColorScheme ColorScheme { [Composable] get => LocalTheme.Current.ColorScheme; }
    public static DsShapes Shapes { [Composable] get => LocalTheme.Current.Shapes; }
    public static DsTypography Typography { [Composable] get => LocalTheme.Current.Typography; }

    public sealed record Values(ColorScheme ColorScheme, DsShapes Shapes, DsTypography Typography);
}
