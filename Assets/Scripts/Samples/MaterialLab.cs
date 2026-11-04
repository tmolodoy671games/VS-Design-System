using System;
using Compose.Net;
using VS.DesignSystem;
using static VS.DesignSystem.SurfaceFunctions;
using static VS.DesignSystem.WithThemeFunctions;
using static Compose.Net.ComposeFunctions;

namespace Samples;

public sealed class MaterialLabState
{
    public readonly IMutableState<int> Material = MutableStateOf(3);
    public readonly IMutableState<int> Weave = MutableStateOf(0);
    public readonly IMutableState<int> DepthKind = MutableStateOf(1);
    public readonly IMutableState<float> Amount = MutableStateOf(4f);
    public readonly IMutableState<float> Opacity = MutableStateOf(1f);
    public readonly IMutableState<bool> Inherit = MutableStateOf(true);
    public readonly IMutableState<float> Strength = MutableStateOf(0.6f);
    public readonly IMutableState<float> Scale = MutableStateOf(256f);
    public readonly IMutableState<float> Radius = MutableStateOf(20f);
    public readonly IMutableState<bool> CustomShape = MutableStateOf(false);
    public readonly IMutableState<bool> RightLight = MutableStateOf(false);
    public readonly IMutableState<int> Clicks = MutableStateOf(0);
}

public static partial class MaterialLab
{
    private static readonly string[] Names = { "Matte", "Ceramic", "Paper", "Cloth", "Metal" };
    private static readonly string[] DepthNames = { "Flat", "Raised", "Inset", "Floating" };
    private static readonly string[] WeaveNames = { "Linen", "Canvas", "Felt", "Twill" };

    public static SurfaceMaterial Material(MaterialLabState s, int kind, float opacity = -1f) => kind switch
    {
        0 => Materials.Matte(opacity, s.Strength.Value, s.Scale.Value.Dp()),
        1 => Materials.Ceramic(opacity, s.Strength.Value, s.Scale.Value.Dp()),
        2 => Materials.Paper(opacity, s.Strength.Value, s.Scale.Value.Dp()),
        3 => Materials.Cloth((ClothWeave)s.Weave.Value, opacity, s.Strength.Value, s.Scale.Value.Dp()),
        _ => Materials.Metal(opacity, s.Strength.Value, s.Scale.Value.Dp())
    };

    private static SurfaceDepth CurrentDepth(MaterialLabState s) => s.DepthKind.Value switch
    {
        1 => Depth.Raised(s.Amount.Value.Dp()),
        2 => Depth.Inset(s.Amount.Value.Dp()),
        3 => Depth.Floating(s.Amount.Value.Dp()),
        _ => Depth.Flat
    };

    [Composable] public static void Content(MaterialLabState s)
    {
        var theme = CurrentTheme;
        var colors = theme.ColorScheme;
        var shape = s.CustomShape.Value ? RoundedCornerShape(s.Radius.Value.Dp()) : theme.Shapes.Large;
        CompositionLocalProvider(LocalContentColor.Provides(colors.OnSurface),
            LocalMaterialOpacity.Provides(s.Opacity.Value),
            LocalSurfaceLighting.Provides(SurfaceLighting.Directional(s.RightLight.Value ? 1 : -1, -1)), () =>
        {
            Column(modifier: Modifier.FillMaxSize().Background(colors.Surface)
                .VerticalScroll(RememberScrollState()).Padding(32.Dp()).TestTag("materials.root"), content: () =>
            {
                Text("MATERIAL LAB", style: CurrentTheme.Typography.HeadlineLarge);
                Text("VS Design System / theme, materials and depth", style: CurrentTheme.Typography.BodyMedium);
                Gap(20);
                Choices("Material", Names, s.Material);
                Choices("Depth", DepthNames, s.DepthKind);
                Choices("Weave", WeaveNames, s.Weave);
                Row(horizontalArrangement: Arrangement.SpacedBy(12.Dp()), content: () =>
                {
                    Toggle(s.CustomShape.Value ? "Shape: custom" : "Shape: theme", () => s.CustomShape.Value = !s.CustomShape.Value, "shape");
                    Toggle(s.RightLight.Value ? "Light: right" : "Light: left", () => s.RightLight.Value = !s.RightLight.Value, "light");
                    Toggle(s.Inherit.Value ? "Opacity: local" : "Opacity: explicit 1", () => s.Inherit.Value = !s.Inherit.Value, "inherit");
                });
                Gap(10);
                Stepper("Local opacity", s.Opacity, 0.1f, 0, 1);
                Stepper("Depth dp", s.Amount, 1, 0, 12);
                Stepper("Texture strength", s.Strength, 0.1f, 0, 1);
                Stepper("Texture tile dp", s.Scale, 32, 64, 512);
                Stepper("Corner radius dp", s.Radius, 4, 0, 48);
                Gap(24);
                var material = Material(s, s.Material.Value, s.Inherit.Value ? -1f : 1f);
                // Checkerboard remains behind the surface, making inherited opacity visible.
                Box(modifier: Modifier.FillMaxWidth().Height(220.Dp()).DrawBehind(d =>
                {
                    for (var y = 0; y < d.Size.Height; y += 20)
                    for (var x = 0; x < d.Size.Width; x += 20)
                        d.DrawRect((x / 20 + y / 20) % 2 == 0 ? colors.Surface : Color.Lerp(colors.Surface, colors.OnSurface, 0.08f),
                            new Offset(x, y), new Size(Math.Min(20, d.Size.Width - x), Math.Min(20, d.Size.Height - y)));
                }).Padding(28.Dp()), content: () =>
                {
                    Surface(material: material, depth: CurrentDepth(s), color: colors.Surface,
                        shape: shape, modifier: Modifier.FillMaxSize().TestTag("materials.preview"),
                        content: () => Column(modifier: Modifier.Padding(24.Dp()), content: () =>
                        {
                            Text(Names[s.Material.Value] + " / " + DepthNames[s.DepthKind.Value], style: CurrentTheme.Typography.TitleLarge);
                            Text("Text stays opaque. Shadows do not change layout.", style: CurrentTheme.Typography.BodyMedium);
                            Text("Material opacity: " + (s.Inherit.Value ? "LocalMaterialOpacity.Current" : "1f (override)"), style: CurrentTheme.Typography.LabelMedium);
                        }));
                });
                Gap(20);
                PressSample(s, material);
                Gap(24);
                Text("SAME SETTINGS / FIVE MATERIALS", style: CurrentTheme.Typography.BodyLarge);
                Gap(12);
                for (var i = 0; i < Names.Length; i++)
                {
                    var index = i;
                    Surface(material: Material(s, index, s.Inherit.Value ? -1f : 1f), depth: CurrentDepth(s),
                        color: colors.Surface, shape: shape,
                        modifier: Modifier.FillMaxWidth().Height(80.Dp()).TestTag("materials.compare." + index),
                        content: () => Text(Names[index], style: CurrentTheme.Typography.TitleMedium, modifier: Modifier.Padding(24.Dp())));
                    Gap(28);
                }
            });
        });
    }

    [Composable] private static void PressSample(MaterialLabState s, SurfaceMaterial material)
    {
        var source = Remember(MutableInteractionSource);
        var pressed = source.CollectIsPressedAsState().Value;
        Box(modifier: Modifier.FillMaxWidth().Height(64.Dp())
            .Surface(material, pressed ? Depth.Inset(3.Dp()) : Depth.Raised(3.Dp()), CurrentTheme.ColorScheme.Surface, CurrentTheme.Shapes.Medium)
            .Clickable(() => s.Clicks.Value++, indication: null, interactionSource: source).TestTag("materials.press"),
            contentAlignment: Alignment.Center, content: () => Text("Press me · Raised → Inset · " + s.Clicks.Value, style: CurrentTheme.Typography.BodyLarge));
    }

    [Composable] private static void Choices(string label, string[] names, IMutableState<int> selected)
    {
        Text(label, style: CurrentTheme.Typography.LabelMedium);
        Row(horizontalArrangement: Arrangement.SpacedBy(8.Dp()), content: () =>
        {
            for (var i = 0; i < names.Length; i++)
            {
                var index = i;
                Toggle((selected.Value == i ? "• " : "") + names[i], () => selected.Value = index, label + "." + i);
            }
        });
        Gap(10);
    }

    [Composable] private static void Toggle(string text, Action action, string tag) =>
        Box(modifier: Modifier.Background(CurrentTheme.ColorScheme.SurfaceContainerHigh, CurrentTheme.Shapes.Small)
            .Clickable(action).Padding(10.Dp()).TestTag("materials." + tag), content: () => Text(text, style: CurrentTheme.Typography.BodyMedium));

    [Composable] private static void Stepper(string label, IMutableState<float> state, float step, float min, float max)
    {
        Row(verticalAlignment: Alignment.CenterVertically, horizontalArrangement: Arrangement.SpacedBy(8.Dp()), content: () =>
        {
            Text(label + ": " + state.Value.ToString("0.0"), style: CurrentTheme.Typography.BodyMedium, modifier: Modifier.Width(200.Dp()));
            Toggle("−", () => state.Value = Math.Max(min, state.Value - step), label + ".less");
            Toggle("+", () => state.Value = Math.Min(max, state.Value + step), label + ".more");
        });
        Gap(4);
    }

    [Composable] private static void Gap(int size) => Spacer(Modifier.Height(size.Dp()));
}
