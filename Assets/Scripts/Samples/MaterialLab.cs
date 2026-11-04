using Compose.Net;
using VS.DesignSystem;
using static VS.DesignSystem.SurfaceFunctions;
using static VS.DesignSystem.WithThemeFunctions;
using static Compose.Net.ComposeFunctions;
using SurfaceMaterial = VS.DesignSystem.SurfaceMaterial;
using Materials = VS.DesignSystem.Materials;
using Depth = VS.DesignSystem.Depth;
using ClothWeave = VS.DesignSystem.ClothWeave;
using SurfaceLighting = VS.DesignSystem.SurfaceLighting;

namespace Samples;

public static partial class MaterialLab
{
    private static readonly string[] Names = { "Matte", "Ceramic", "Paper", "Cloth", "Metal" };

    private static SurfaceMaterial Material(int kind) => kind switch
    {
        0 => Materials.Matte(),
        1 => Materials.Ceramic(),
        2 => Materials.Paper(),
        3 => Materials.Cloth(ClothWeave.Linen),
        _ => Materials.Metal()
    };

    [Composable] public static void Content()
    {
        CompositionLocalProvider(
            VS.DesignSystem.SurfaceFunctions.LocalMaterialOpacity.Provides(1f),
            VS.DesignSystem.SurfaceFunctions.LocalSurfaceLighting.Provides(SurfaceLighting.Directional(-1, -1)), () =>
        {
            Row(modifier: Modifier.FillMaxSize().TestTag("materials.root"), content: () =>
            {
                ThemeColumn(false, Modifier.Weight(1));
                ThemeColumn(true, Modifier.Weight(1));
            });
        });
    }

    [Composable] private static void ThemeColumn(bool dark, IModifier modifier)
    {
        WithTheme(theme: dark ? DarkTheme.Instance : LightTheme.Instance, content: () =>
        {
            var theme = CurrentTheme;
            var colors = theme.ColorScheme;
            var tag = dark ? "dark" : "light";
            CompositionLocalProvider(LocalContentColor.Provides(colors.OnSurface), () =>
            {
                Column(modifier: modifier.FillMaxHeight().Background(colors.Surface)
                    .Padding(28.Dp()).TestTag("materials." + tag), content: () =>
                {
                    Text("MATERIALS", style: theme.Typography.HeadlineMedium);
                    Text(dark ? "Dark theme" : "Light theme", style: theme.Typography.BodyMedium);
                    Spacer(Modifier.Height(24.Dp()));
                    for (var i = 0; i < Names.Length; i++)
                    {
                        var index = i;
                        Surface(material: Material(index), depth: Depth.Raised(4.Dp()),
                            color: colors.SurfaceContainerHigh, shape: theme.Shapes.Large,
                            modifier: Modifier.FillMaxWidth().Height(72.Dp()).TestTag("materials." + tag + "." + index),
                            content: () => Text(Names[index], style: theme.Typography.TitleMedium,
                                modifier: Modifier.Padding(24.Dp())));
                        if (i < Names.Length - 1) Spacer(Modifier.Height(20.Dp()));
                    }
                });
            });
        });
    }
}
