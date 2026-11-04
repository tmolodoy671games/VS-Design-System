using System;
using Compose.Net;
using SharpExtensions;

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
public static partial class NavigationFunctions
{
    /// <summary>A controlled navigation tab with animated selection, hover and press states.</summary>
    [Composable]
    public static void Tab(bool selected, Action onClick, [Composable] Action content,
        IModifier? modifier = null, bool enabled = true, IMutableInteractionSource? interactionSource = null)
    {
        var theme = CurrentTheme;
        var source = interactionSource ?? Remember(MutableInteractionSource);
        var hover = source.CollectIsHoveredAsState().Value;
        var pressed = source.CollectIsPressedAsState().Value;
        var amount = AnimateFloatAsState(selected ? 1f : 0f, Tween(220)).Value;
        var foreground = AnimateColorAsState(!enabled ? theme.ColorScheme.OnSurface with { Alpha = .38f }
            : selected ? theme.ColorScheme.Primary : theme.ColorScheme.OnSurfaceVariant, Tween(180)).Value;
        var background = AnimateColorAsState(theme.ColorScheme.SurfaceContainerHigh with
            { Alpha = enabled && (hover || selected) ? pressed ? .9f : .55f : 0 }, Tween(180)).Value;
        var line = theme.ColorScheme.Primary;
        CompositionLocalProvider(LocalContentColor.Provides(foreground),
            LocalTextStyle.Provides(theme.Typography.LabelLarge), content: () =>
            Box(modifier: modifier.OrEmpty().Height(52.Dp()).Background(background, theme.Shapes.Small)
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
        Optional<PaddingValues> contentPadding = default)
    {
        var theme = CurrentTheme;
        var palette = colors.GetOrDefault(MenuItemDefaults.Colors());
        var padding = contentPadding.GetOrDefault(PaddingValues(horizontal: 14.Dp(), vertical: 12.Dp()));
        var source = interactionSource ?? Remember(MutableInteractionSource);
        var hover = source.CollectIsHoveredAsState().Value;
        var pressed = source.CollectIsPressedAsState().Value;
        var background = AnimateColorAsState(selected ? palette.SelectedContainer
            : hover && enabled ? palette.HoverContainer : palette.Container, Tween(180)).Value;
        var foreground = AnimateColorAsState(!enabled ? palette.Content with { Alpha = .38f }
            : selected ? palette.SelectedContent : palette.Content, Tween(180)).Value;
        var scale = AnimateFloatAsState(pressed && enabled ? .985f : 1f, Tween(120)).Value;
        CompositionLocalProvider(LocalContentColor.Provides(foreground), LocalTextStyle.Provides(theme.Typography.BodyMedium), content: () =>
            Row(modifier: modifier.OrEmpty().Scale(scale).Background(background, theme.Shapes.Small)
                .Clickable(onClick, enabled: enabled, interactionSource: source, indication: null)
                .Padding(padding),
                verticalAlignment: Alignment.CenterVertically, horizontalArrangement: Arrangement.SpacedBy(12.Dp()), content: () =>
                {
                    leadingContent?.Invoke();
                    Column(modifier: Modifier.Weight(1), content: () =>
                    {
                        content();
                        if (supportingContent != null)
                            CompositionLocalProvider(LocalTextStyle.Provides(theme.Typography.LabelSmall), content: supportingContent);
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
        var scheme = CurrentTheme.ColorScheme;
        return new MenuItemColors(container.GetOrDefault(scheme.SurfaceContainer with { Alpha = 0 }),
            hoverContainer.GetOrDefault(scheme.SurfaceContainerHighest), selectedContainer.GetOrDefault(scheme.PrimaryContainer),
            content.GetOrDefault(scheme.OnSurface), selectedContent.GetOrDefault(scheme.OnPrimaryContainer));
    }
}
