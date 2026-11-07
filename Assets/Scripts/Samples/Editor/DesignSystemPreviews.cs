using System;
using Compose.Net;
using Compose.Net.Unity;
using VS.DesignSystem;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.WithDsThemeFunctions;
using Color = Compose.Net.Color;

namespace Samples.Editor;

/// <summary>Color roles and component states, always shown in both VS themes.</summary>
public static partial class DesignSystemPreviews
{
    [UnityPreview("VS / Design system — Light & Dark", 1320, 1000)]
    [Composable]
    public static void DesignSystem()
    {
        BothThemes(() =>
        {
            Heading("Components");
            ComponentCatalog();
            Heading("Color roles");
            ColorCatalog();
        });
    }

    [UnityPreview("VS / Colors — Light & Dark", 1320, 1000)]
    [Composable]
    public static void Colors()
    {
        BothThemes(ColorCatalog);
    }

    [UnityPreview("VS / Components — Light & Dark", 1320, 1000)]
    [Composable]
    public static void Components()
    {
        BothThemes(ComponentCatalog);
    }

    [Composable]
    private static void BothThemes([Composable] Action content) => Row(
        modifier: Modifier.FillMaxSize(), content: () =>
        {
            ThemePanel(false, Modifier.Weight(1), content);
            ThemePanel(true, Modifier.Weight(1), content);
        });

    [Composable]
    private static void ThemePanel(bool dark, IModifier modifier, [Composable] Action content) => ProvideDsTheme(
        colorScheme: (dark ? DsDarkThemeFunctions.DsDarkTheme : DsLightThemeFunctions.DsLightTheme).ColorScheme,
        content: () =>
        {
            var c = DsTheme.ColorScheme;
            CompositionLocalProvider(LocalContentColor.Provides(c.OnBackground), content: () =>
                Column(modifier: modifier.FillMaxHeight().Background(c.Background)
                        .VerticalScroll(RememberScrollState()).Padding(24.Dp()),
                    verticalArrangement: Arrangement.SpacedBy(16.Dp()), content: () =>
                    {
                        Text(dark ? "VS DARK" : "VS LIGHT", style: DsTheme.Typography.HeadlineMedium);
                        content();
                    }));
        });

    [Composable]
    private static void ColorCatalog()
    {
        var c = DsTheme.ColorScheme;
        ColorBlock("Background", c.Background, "OnBackground", c.OnBackground, () =>
            ColorBlock("Surface", c.Surface, "OnSurface", c.OnSurface, () =>
            {
                Accent("Primary", c.Primary, c.OnPrimary, c.PrimaryContainer, c.OnPrimaryContainer);
                Accent("Secondary", c.Secondary, c.OnSecondary, c.SecondaryContainer, c.OnSecondaryContainer);
                Accent("Tertiary", c.Tertiary, c.OnTertiary, c.TertiaryContainer, c.OnTertiaryContainer);
                Accent("Error", c.Error, c.OnError, c.ErrorContainer, c.OnErrorContainer);
            }));

        Heading("Surface hierarchy");
        ColorBlock("SurfaceDim", c.SurfaceDim, "OnSurface", c.OnSurface, () =>
            ColorBlock("SurfaceBright", c.SurfaceBright, "OnSurface", c.OnSurface, () =>
                ColorBlock("SurfaceContainerLowest", c.SurfaceContainerLowest, "OnSurface", c.OnSurface, () =>
                    ColorBlock("SurfaceContainerLow", c.SurfaceContainerLow, "OnSurface", c.OnSurface, () =>
                        ColorBlock("SurfaceContainer", c.SurfaceContainer, "OnSurface", c.OnSurface, () =>
                            ColorBlock("SurfaceContainerHigh", c.SurfaceContainerHigh, "OnSurface", c.OnSurface, () =>
                                ColorBlock("SurfaceContainerHighest", c.SurfaceContainerHighest, "OnSurface", c.OnSurface)))))));

        Heading("Variants, borders & tint");
        ColorBlock("SurfaceVariant", c.SurfaceVariant, "OnSurfaceVariant", c.OnSurfaceVariant, () =>
        {
            BorderRole("Outline", c.Outline);
            BorderRole("OutlineVariant", c.OutlineVariant);
            ColorBlock("SurfaceTint", c.SurfaceTint, "OnPrimary", c.OnPrimary);
        });

        Heading("Inverse surface");
        ColorBlock("InverseSurface", c.InverseSurface, "InverseOnSurface", c.InverseOnSurface, () =>
            Text("InversePrimary  " + Hex(c.InversePrimary), color: c.InversePrimary,
                style: DsTheme.Typography.TitleMedium));

        Heading("Scrim");
        ColorBlock("Surface behind scrim", c.Surface, "OnSurface", c.OnSurface, () =>
            Column(modifier: Modifier.FillMaxWidth().Background(Color.Lerp(c.Surface, c.Scrim, .32f), DsTheme.Shapes.Small)
                    .Padding(16.Dp()), verticalArrangement: Arrangement.SpacedBy(8.Dp()), content: () =>
                {
                    // The role label remains readable on its own surface; the surrounding layer shows the overlay.
                    ColorBlock("Scrim", c.Scrim, "On dark overlay", Color.White, () =>
                        Text("32% overlay over Surface", color: Color.White, style: DsTheme.Typography.BodySmall));
                    ColorBlock("SurfaceContainerHigh", c.SurfaceContainerHigh, "OnSurface", c.OnSurface, () =>
                        Text("Dialog above the scrim", style: DsTheme.Typography.BodyMedium));
                }));
    }

    [Composable]
    private static void Accent(string name, Color accent, Color onAccent, Color container, Color onContainer) =>
        ColorBlock(name + "Container", container, "On" + name + "Container", onContainer, () =>
            ColorBlock(name, accent, "On" + name, onAccent));

    [Composable]
    private static void ColorBlock(string name, Color fill, string onName, Color ink, [Composable] Action? content = null) =>
        CompositionLocalProvider(LocalContentColor.Provides(ink), content: () =>
            Column(modifier: Modifier.FillMaxWidth().Background(fill, DsTheme.Shapes.Small).Padding(12.Dp()),
                verticalArrangement: Arrangement.SpacedBy(8.Dp()), content: () =>
                {
                    Text(name + "  " + Hex(fill), style: DsTheme.Typography.LabelLarge);
                    Text(onName + "  " + Hex(ink), style: DsTheme.Typography.BodySmall);
                    content?.Invoke();
                }));

    [Composable]
    private static void BorderRole(string name, Color color) => Box(
        modifier: Modifier.FillMaxWidth().Border(2.Dp(), SolidColor(color), DsTheme.Shapes.Small).Padding(12.Dp()),
        content: () => Text(name + "  " + Hex(color), style: DsTheme.Typography.BodyMedium));

    [Composable]
    private static void ComponentCatalog()
    {
        var c = DsTheme.ColorScheme;
        Heading("Buttons");
        Buttons(true);
        Buttons(false);

        Heading("Surface");
        var clicks = Remember(() => MutableStateOf(0));
        DsSurface(onClick: () => clicks.Value++, color: c.PrimaryContainer, shape: DsTheme.Shapes.Medium,
            modifier: Modifier.FillMaxWidth(), content: () => Column(modifier: Modifier.Padding(20.Dp()), content: () =>
            {
                Text("DsSurface", style: DsTheme.Typography.TitleMedium);
                Text("Clickable · " + clicks.Value + " clicks");
            }));
        DsSurface(onClick: () => { }, enabled: false, color: c.SurfaceContainer,
            border: BorderStroke(1.Dp(), c.Outline), shape: DsTheme.Shapes.Medium,
            modifier: Modifier.FillMaxWidth(), content: () => Text("Disabled surface",
                modifier: Modifier.Padding(20.Dp())));

        Heading("DsSwitch");
        SwitchExample("Off → on", false);
        SwitchExample("On → off", true);
        SwitchExample("Disabled / off", false, false);
        SwitchExample("Disabled / on", true, false);
        SwitchExample("Thumb content", true, showThumb: true);

        Heading("DsTabsRow / DsTab · High");
        var high = Remember(() => MutableStateOf(0));
        DsTabsRow(content: () =>
        {
            DsTab(high.Value == 0, () => high.Value = 0, Modifier.Weight(1), text: () => Text("Overview"));
            DsTab(high.Value == 1, () => high.Value = 1, Modifier.Weight(1), text: () => Text("Projects"));
            DsTab(high.Value == 2, () => high.Value = 2, Modifier.Weight(1), enabled: false, text: () => Text("Disabled"));
        });
        Column(modifier: Modifier.FillMaxWidth().Background(c.SurfaceContainer, DsTheme.Shapes.Medium).Padding(12.Dp()),
            verticalArrangement: Arrangement.SpacedBy(12.Dp()), content: () =>
            {
                Text("Nested tabs / Low", style: DsTheme.Typography.LabelLarge);
                var low = Remember(() => MutableStateOf(0));
                DsTabsRow(level: DsTabLevel.Low, content: () =>
                {
                    DsTab(low.Value == 0, () => low.Value = 0, Modifier.Weight(1), text: () => Text("Recent"));
                    DsTab(low.Value == 1, () => low.Value = 1, Modifier.Weight(1), text: () => Text("Shared"));
                    DsTab(low.Value == 2, () => low.Value = 2, Modifier.Weight(1), text: () => Text("Saved"));
                });
                Text("Section " + (high.Value + 1) + " / subsection " + (low.Value + 1));
            });

        Heading("Tabs / content widths & icon slot");
        var natural = Remember(() => MutableStateOf(0));
        DsTabsRow(level: DsTabLevel.Low, content: () =>
        {
            DsTab(natural.Value == 0, () => natural.Value = 0, icon: () => Text("+"), text: () => Text("New"));
            DsTab(natural.Value == 1, () => natural.Value = 1, text: () => Text("All projects"));
        });
    }

    [Composable]
    private static void Buttons(bool enabled) => Row(
        modifier: Modifier.FillMaxWidth(), horizontalArrangement: Arrangement.SpacedBy(8.Dp()), content: () =>
        {
            DsButton(() => { }, () => Text("Filled"), enabled: enabled);
            DsOutlineButton(() => { }, () => Text("Outline"), enabled: enabled);
            DsTextButton(() => { }, () => Text("Text"), enabled: enabled);
        });

    [Composable]
    private static void SwitchExample(string label, bool initialValue, bool enabled = true, bool showThumb = false)
    {
        var value = Remember(() => MutableStateOf(initialValue));
        Row(modifier: Modifier.FillMaxWidth(), verticalAlignment: Alignment.CenterVertically,
            horizontalArrangement: Arrangement.SpaceBetween, content: () =>
            {
                Text(label);
                DsSwitch(value.Value, next => value.Value = next, enabled: enabled,
                    thumbContent: showThumb ? () => Text(value.Value ? "1" : "0", style: DsTheme.Typography.LabelSmall) : null);
            });
    }

    [Composable]
    private static void Heading(string title) => Text(title, style: DsTheme.Typography.TitleLarge);

    private static string Hex(Color color) => $"#{Channel(color.Red):X2}{Channel(color.Green):X2}{Channel(color.Blue):X2}";
    private static int Channel(float value) => (int)MathF.Round(Math.Clamp(value, 0f, 1f) * 255f);
}
