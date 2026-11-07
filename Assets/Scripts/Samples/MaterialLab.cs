using Compose.Net;
using VS.DesignSystem;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.WithDsThemeFunctions;

namespace Samples;

public static partial class MaterialLab
{
    [Composable] public static void Content() => Row(modifier: Modifier.FillMaxSize().TestTag("materials.root"), content: () =>
    {
        ThemeColumn(false, Modifier.Weight(1));
        ThemeColumn(true, Modifier.Weight(1));
    });

    [Composable] private static void ThemeColumn(bool dark, IModifier modifier) => ProvideDsTheme(
        colorScheme: dark ? DsDarkThemeFunctions.DsDarkTheme.ColorScheme : DsLightThemeFunctions.DsLightTheme.ColorScheme,
        content: () =>
        {
            var colors = VS.DesignSystem.DsTheme.ColorScheme;
            var tag = dark ? "dark" : "light";
            Column(modifier: modifier.FillMaxHeight().Background(colors.Surface).Padding(28.Dp()).TestTag("materials." + tag), content: () =>
            {
                Text(dark ? "Dark theme" : "Light theme", color: colors.OnSurface, style: VS.DesignSystem.DsTheme.Typography.HeadlineMedium);
                var names = new[] { "Surface", "Surface container", "Primary", "Secondary", "Tertiary" };
                var fills = new[] { colors.Surface, colors.SurfaceContainer, colors.PrimaryContainer, colors.SecondaryContainer, colors.TertiaryContainer };
                for (var i = 0; i < names.Length; i++)
                {
                    var index = i;
                    Spacer(Modifier.Height(20.Dp()));
                    Box(modifier: Modifier.FillMaxWidth().Height(72.Dp()).Background(fills[index], VS.DesignSystem.DsTheme.Shapes.Large)
                        .TestTag("materials." + tag + "." + index), content: () => Text(names[index],
                        color: colors.ContentColorFor(fills[index]).GetOrDefault(colors.OnSurface),
                        style: VS.DesignSystem.DsTheme.Typography.TitleMedium, modifier: Modifier.Padding(24.Dp())));
                }
            });
        });
}
