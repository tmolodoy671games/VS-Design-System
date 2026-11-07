using System;
using Compose.Net;
using SharpExtensions;

using VS.DesignSystem;

namespace Samples;

[AutoGlobalUsingStatic]
[Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
public static partial class NavigationFunctions
{
    [Composable]
    public static void TabRow(string[] labels, int selected, Action<int> onSelect,
        TabLevel level = TabLevel.Primary, string? testTag = null)
    {
        DsTabsRow(level: level == TabLevel.Primary ? DsTabLevel.High : DsTabLevel.Low,
            modifier: testTag == null ? Modifier : Modifier.TestTag(testTag), content: () =>
            {
                for (var i = 0; i < labels.Length; i++)
                {
                    var index = i;
                    DsTab(selected: index == selected, onClick: () => onSelect(index),
                        text: () => Text(labels[index]),
                        modifier: Modifier.Weight(1).TestTag(testTag + ".tab." + index));
                }
            });
    }

    private static readonly ICompositionLocal<MenuIndicator?> LocalMenuIndicator = CompositionLocalOf<MenuIndicator?>(() => null);
    private sealed class MenuIndicator
    {
        public readonly IMutableState<Compose.Net.Rect> Bounds = MutableStateOf(default(Compose.Net.Rect));
        public readonly IMutableState<Offset> Origin = MutableStateOf(default(Offset));
    }

    [Composable]
    public static void MenuList([Composable] Action content, string? testTag = null)
    {
        var state = Remember(() => new MenuIndicator());
        var bounds = state.Bounds.Value;
        var density = LocalDensity.Current;
        var top = AnimateFloatAsState(bounds.Offset.Y - state.Origin.Value.Y, NavigationDefaults.Motion).Value;
        var height = AnimateFloatAsState(bounds.Size.Height, NavigationDefaults.Motion).Value;
        Box(modifier: Modifier.FillMaxWidth().OnGloballyPositioned(c => state.Origin.Value = c.LocalToRoot(default)), content: () =>
        {
            Box(modifier: Modifier.FillMaxWidth().Height(density.ToDp(height)).Offset(y: density.ToDp(top))
                .Background(VS.DesignSystem.DsTheme.ColorScheme.PrimaryContainer, VS.DesignSystem.DsTheme.Shapes.Small)
                .TestTag(testTag + ".indicator"));
            CompositionLocalProvider(LocalMenuIndicator.Provides(state), content: () => Column(modifier: Modifier.FillMaxWidth(), content: content));
        });
    }

    /// <summary>A controlled navigation tab with animated selection, hover and press states.</summary>
    [Composable]
    public static void Tab(bool selected, Action onClick, [Composable] Action content,
        IModifier? modifier = null, bool enabled = true, IMutableInteractionSource? interactionSource = null)
    {
        var scheme = VS.DesignSystem.DsTheme.ColorScheme;
        var source = interactionSource ?? Remember(MutableInteractionSource);
        var hover = source.CollectIsHoveredAsState().Value;
        var pressed = source.CollectIsPressedAsState().Value;
        var amount = AnimateFloatAsState(selected ? 1f : 0f, Tween(220)).Value;
        var foreground = AnimateColorAsState(!enabled ? scheme.OnSurface with { Alpha = .38f }
            : selected ? scheme.Primary : scheme.OnSurfaceVariant, Tween(180)).Value;
        var background = AnimateColorAsState(scheme.SurfaceContainerHigh with
            { Alpha = enabled && (hover || selected) ? pressed ? .9f : .55f : 0 }, Tween(180)).Value;
        var line = scheme.Primary;
        CompositionLocalProvider(LocalContentColor.Provides(foreground),
            LocalTextStyle.Provides(VS.DesignSystem.DsTheme.Typography.LabelLarge), content: () =>
            Box(modifier: modifier.OrEmpty().Height(52.Dp()).Background(background, VS.DesignSystem.DsTheme.Shapes.Small)
                .Clickable(onClick, enabled: enabled, interactionSource: source, indication: null)
                .Draw(d => d.DrawRoundRect(line, new Offset(d.Size.Width * (1 - amount) * .5f, d.Size.Height - 3),
                    new Size(d.Size.Width * amount, 3), 1.5f)).Padding(horizontal: 22.Dp()),
                contentAlignment: Alignment.Center, content: content));
    }

    /// <summary>A controlled menu row. Slots inherit themed text and content colors.</summary>
    [Composable]
    public static void MenuItem(Action onClick, [Composable] Action content, IModifier? modifier = null,
        bool selected = false, bool enabled = true, [Composable] Action? leadingContent = null,
        [Composable] Action? supportingContent = null, [Composable] Action? trailingContent = null,
        IMutableInteractionSource? interactionSource = null, Optional<MenuItemColors> colors = default,
        PaddingValues contentPadding = default)
    {
        var scheme = VS.DesignSystem.DsTheme.ColorScheme;
        var indicator = LocalMenuIndicator.Current;
        var selection = AnimateFloatAsState(selected ? 1f : 0f, NavigationDefaults.Motion).Value;
        var palette = colors.GetOrDefault(MenuItemDefaults.Colors());
        var padding = contentPadding.GetOrDefault(PaddingValues(horizontal: 14.Dp(), vertical: 12.Dp()));
        var source = interactionSource ?? Remember(MutableInteractionSource);
        var hover = source.CollectIsHoveredAsState().Value;
        var pressed = source.CollectIsPressedAsState().Value;
        var targetBackground = selected && indicator == null ? palette.SelectedContainer : palette.Container;
        if (enabled && (hover || pressed))
        {
            var state = palette.HoverContainer;
            if (pressed) state = state with { Alpha = Math.Min(1f, state.Alpha * 2f) };
            var alpha = state.Alpha + targetBackground.Alpha * (1f - state.Alpha);
            targetBackground = alpha > 0f
                ? Color.Lerp(targetBackground, state, state.Alpha / alpha) with { Alpha = alpha }
                : Color.Transparent;
        }
        var background = AnimateColorAsState(targetBackground, Tween(180)).Value;
        var foreground = AnimateColorAsState(!enabled ? palette.Content with { Alpha = .38f }
            : selected ? palette.SelectedContent : palette.Content, Tween(180)).Value;
        var scale = AnimateFloatAsState(pressed && enabled ? .985f : 1f, Tween(120)).Value;
        CompositionLocalProvider(LocalContentColor.Provides(foreground), LocalTextStyle.Provides(VS.DesignSystem.DsTheme.Typography.BodyMedium), content: () =>
            Row(modifier: modifier.OrEmpty().Scale(scale).Padding(vertical: (selection * 4).Dp())
                .OnGloballyPositioned(c =>
                {
                    if (selected && indicator != null)
                        indicator.Bounds.Value = new Compose.Net.Rect(c.LocalToRoot(default), c.Size);
                }).Background(background, VS.DesignSystem.DsTheme.Shapes.Small)
                .Clickable(onClick, enabled: enabled, interactionSource: source, indication: null)
                .Padding(padding),
                verticalAlignment: Alignment.CenterVertically, horizontalArrangement: Arrangement.SpacedBy(12.Dp()), content: () =>
                {
                    leadingContent?.Invoke();
                    Column(modifier: Modifier.Weight(1), content: () =>
                    {
                        content();
                        if (supportingContent != null)
                            CompositionLocalProvider(LocalTextStyle.Provides(VS.DesignSystem.DsTheme.Typography.LabelSmall), content: supportingContent);
                    });
                    trailingContent?.Invoke();
                }));
    }
}

public readonly record struct MenuItemColors(Color Container, Color HoverContainer, Color SelectedContainer, Color Content, Color SelectedContent);

public static partial class MenuItemDefaults
{
    [Composable]
    public static MenuItemColors Colors(Optional<Color> container = default, Optional<Color> hoverContainer = default,
        Optional<Color> selectedContainer = default, Optional<Color> content = default, Optional<Color> selectedContent = default)
    {
        var scheme = VS.DesignSystem.DsTheme.ColorScheme;
        return new MenuItemColors(container.GetOrDefault(scheme.SurfaceContainer with { Alpha = 0 }),
            hoverContainer.GetOrDefault(content.GetOrDefault(scheme.OnSurface) with { Alpha = .08f }),
            selectedContainer.GetOrDefault(scheme.Primary with { Alpha = .12f }),
            content.GetOrDefault(scheme.OnSurface), selectedContent.GetOrDefault(scheme.Primary));
    }
}

public enum TabLevel { Primary, Secondary }
public static class NavigationDefaults
{
    public static AnimationSpec Motion => Tween(220);
}
