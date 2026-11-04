using System;
using System.Collections.Generic;
using Compose.Net;
using SharpExtensions;
using StableCollections;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
public static partial class DropdownSelectorFunctions
{
    /// <summary>A controlled selector. The caller owns the selected value and expanded state.</summary>
    /// <remarks>Selecting an item invokes onValueChange, then requests that the menu close.</remarks>
    [Composable]
    public static void DropdownSelector<T>(
        T value,
        bool expanded,
        Action<bool> onExpandedChange,
        IStableList<T> values,
        [Composable] Action<T> content,
        IModifier? modifier = null,
        Optional<Shape> shape = default,
        Optional<DropdownSelectorColors> colors = default,
        Optional<PaddingValues> contentPadding = default,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true,
        Action<T>? onValueChange = null,
        SurfaceMaterial? material = null
    )
    {
        DropdownSelectorImpl(
            value: value,
            expanded: expanded,
            onExpandedChange: onExpandedChange,
            values: values,
            content: content,
            modifier: modifier.OrEmpty(),
            shape: shape.GetOrDefault(DropdownSelectorDefaults.Shape),
            colors: colors.GetOrDefault(DropdownSelectorDefaults.Colors()),
            contentPadding: contentPadding.GetOrDefault(DropdownSelectorDefaults.ContentPadding),
            interactionSource: interactionSource ?? Remember(MutableInteractionSource),
            enabled: enabled,
            onValueChange: onValueChange,
            material: material ?? Materials.Metal()
        );
    }

    [Composable, NonRestartableComposable]
    private static void DropdownSelectorImpl<T>(
        T value,
        bool expanded,
        Action<bool> onExpandedChange,
        IStableList<T> values,
        [Composable] Action<T> content,
        IModifier modifier,
        Shape shape,
        DropdownSelectorColors colors,
        PaddingValues contentPadding,
        IMutableInteractionSource interactionSource,
        bool enabled,
        Action<T>? onValueChange,
        SurfaceMaterial material
    )
    {
        var anchor = Remember(() => MutableStateOf(default(Compose.Net.Rect)));
        var viewport = Remember(() => MutableStateOf(default(Size)));
        var menuSize = Remember(() => MutableStateOf(default(Size)));
        var density = LocalDensity.Current;
        var textStyle = CurrentTheme.Typography.BodyMedium;
        var interactive = enabled && values.Size > 0;
        var hovered = interactionSource.CollectIsHoveredAsState().Value && interactive;
        var pressed = interactionSource.CollectIsPressedAsState().Value && interactive;
        var open = expanded && interactive;
        var scale = AnimateFloatAsState(!interactive ? 1f : pressed ? .99f : open ? 1.025f : hovered ? 1.015f : 1f,
            Tween(220, easing: EaseOutEasing)).Value;
        var elevation = AnimateFloatAsState(!interactive ? 0f : open ? 6f : hovered ? 4f : 1f,
            Tween(220, easing: EaseOutEasing)).Value;
        var arrowRotation = AnimateFloatAsState(open ? 180f : 0f, Tween(240, easing: EaseOutEasing)).Value;
        var arrowColor = colors.GetContentColor(enabled);
        var reveal = AnimateFloatAsState(open ? 1f : 0f,
            Tween(open ? 240 : 160, easing: EaseOutEasing)).Value;
        // Clickable retains its handler; resolve current inputs when the click arrives.
        var inputs = Remember(() => MutableStateOf((expanded, onExpandedChange, onValueChange)));
        inputs.Value = (expanded, onExpandedChange, onValueChange);
        Surface(
            onClick: () => inputs.Value.onExpandedChange(!inputs.Value.expanded),
            enabled: interactive,
            interactionSource: interactionSource,
            shape: shape,
            material: material,
            depth: pressed ? Depth.Inset(2.Dp()) : Depth.Raised(elevation.Dp()),
            contentAlignment: Alignment.CenterStart,
            color: AnimateColorAsState(colors.GetContainerColor(enabled), Tween(180)).Value,
            contentColor: colors.GetContentColor(enabled),
            // Scale is visual only; transformed corners keep the popup attached to its field.
            modifier: modifier.Scale(scale).OnGloballyPositioned(c =>
            {
                var topLeft = c.LocalToRoot(default);
                var bottomRight = c.LocalToRoot(new Offset(c.Size.Width, c.Size.Height));
                anchor.Value = new Compose.Net.Rect(topLeft,
                    new Size(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y));
            }),
            content: () => CompositionLocalProvider(
                LocalTextStyle.Provides(textStyle),
                content: () => Row(
                    modifier: Modifier.FillMaxWidth().Padding(contentPadding),
                    verticalAlignment: Alignment.CenterVertically,
                    content: () =>
                    {
                        Box(modifier: Modifier.Weight(1),
                            contentAlignment: Alignment.CenterLeft,
                            content: () => content(value));
                        Spacer(Modifier.Width(8.Dp()));
                        Spacer(Modifier.Size(18.Dp()).Rotate(arrowRotation).DrawBehind(draw =>
                        {
                            var w = draw.Size.Width;
                            var h = draw.Size.Height;
                            using var path = Path();
                            path.MoveTo(w * .17f, h * .33f)
                                .LineTo(w * .83f, h * .33f)
                                .LineTo(w * .5f, h * .67f).Close();
                            draw.DrawPath(path, arrowColor);
                        }));
                    }
                )
            )
        );

        // Keep the popup mounted through its exit transition; a quick reopen
        // retargets the same animation instead of recreating the scrolling content.
        if ((!open && reveal <= 0f) || !interactive)
            return;

        ModalDialog(content: () =>
        {
            var bounds = anchor.Value;
            var screen = viewport.Value;
            var width = Math.Min(bounds.Size.Width, screen.Width);
            var below = Math.Max(0f, screen.Height - bounds.Offset.Y - bounds.Size.Height);
            var above = Math.Max(0f, bounds.Offset.Y);
            var openAbove = below < density.ToPx(160.Dp()) && above > below;
            var height = Math.Min(density.ToPx(280.Dp()), openAbove ? above : below);
            var x = Math.Max(0f, Math.Min(bounds.Offset.X, screen.Width - width));
            var y = openAbove ? Math.Max(0f, bounds.Offset.Y - menuSize.Value.Height)
                : bounds.Offset.Y + bounds.Size.Height;
            var slide = density.ToPx(6.Dp()) * (1f - reveal) * (openAbove ? 1f : -1f);
            Box(
                modifier: Modifier.FillMaxSize().OnGloballyPositioned(c => viewport.Value = c.Size),
                content: () =>
                {
                    Box(
                        modifier: Modifier.FillMaxSize().Clickable(
                            onClick: () => inputs.Value.onExpandedChange(false),
                            indication: null, interactionSource: null),
                        content: () => { }
                    );
                    CompositionLocalProvider(
                        LocalContentColor.Provides(colors.ContentColor),
                        LocalTextStyle.Provides(textStyle),
                        content: () => Box(
                            modifier: Modifier.Offset(x: density.ToDp(x), y: density.ToDp(y + slide))
                                .TransformOrigin(density.ToDp(width * .5f), openAbove ? density.ToDp(menuSize.Value.Height) : 0.Dp())
                                .Scale(.97f + .03f * reveal).Alpha(reveal).Width(density.ToDp(width)).HeightIn(max: density.ToDp(height))
                                .Surface(material, Depth.Floating(8.Dp()), colors.DropdownColor, shape)
                                .OnGloballyPositioned(c => menuSize.Value = c.Size),
                            // Clip only the scrolling content, leaving the outer shadow visible.
                            content: () => Column(
                                modifier: Modifier.FillMaxWidth().HeightIn(max: density.ToDp(height))
                                    .Clip(shape).VerticalScroll(RememberScrollState()),
                                content: () =>
                                {
                                    var itemIndex = 0;
                                    foreach (var item in values)
                                    {
                                        var delay = Math.Min(itemIndex++, 5) * .045f;
                                        var itemReveal = Math.Clamp((reveal - delay) / (1f - delay), 0f, 1f);
                                        var currentItem = Remember(() => MutableStateOf(item));
                                        currentItem.Value = item;
                                        NavigationFunctions.MenuItem(
                                            onClick: () =>
                                            {
                                                if (!inputs.Value.expanded) return;
                                                inputs.Value.onValueChange?.Invoke(currentItem.Value);
                                                inputs.Value.onExpandedChange(false);
                                            },
                                            selected: EqualityComparer<T>.Default.Equals(value, item),
                                            colors: MenuItemDefaults.Colors(
                                                selectedContainer: CurrentTheme.ColorScheme.PrimaryContainer,
                                                content: colors.ContentColor,
                                                selectedContent: CurrentTheme.ColorScheme.OnPrimaryContainer),
                                            contentPadding: contentPadding,
                                            modifier: Modifier.FillMaxWidth().Alpha(itemReveal)
                                                .Offset(y: ((1f - itemReveal) * (openAbove ? 4f : -4f)).Dp()),
                                            content: () => content(item)
                                        );
                                    }
                                })
                        )
                    );
                }
            );
        });
    }
}

public static partial class DropdownSelectorDefaults
{
    public static PaddingValues ContentPadding => PaddingValues(horizontal: 12.Dp(), vertical: 4.Dp());

    public static Shape Shape
    {
        [Composable] get => WithThemeFunctions.CurrentTheme.Shapes.Small;
    }

    [Composable]
    public static DropdownSelectorColors Colors(
        Optional<Color> containerColor = default,
        Optional<Color> dropdownColor = default,
        Optional<Color> contentColor = default,
        Optional<Color> disabledContainerColor = default,
        Optional<Color> disabledContentColor = default
    )
    {
        var scheme = WithThemeFunctions.CurrentTheme.ColorScheme;
        return new DropdownSelectorColors(
            containerColor.GetOrDefault(scheme.SurfaceContainerHighest),
            dropdownColor.GetOrDefault(scheme.SurfaceContainerLow),
            contentColor.GetOrDefault(scheme.OnSurface),
            disabledContainerColor.GetOrDefault(scheme.OnSurface with { Alpha = 0.12f }),
            disabledContentColor.GetOrDefault(scheme.OnSurface with { Alpha = 0.38f })
        );
    }
}

public readonly record struct DropdownSelectorColors(
    Color ContainerColor,
    Color DropdownColor,
    Color ContentColor,
    Color DisabledContainerColor,
    Color DisabledContentColor
)
{
    public Color GetContainerColor(bool enabled) => enabled ? ContainerColor : DisabledContainerColor;
    public Color GetContentColor(bool enabled) => enabled ? ContentColor : DisabledContentColor;
}
