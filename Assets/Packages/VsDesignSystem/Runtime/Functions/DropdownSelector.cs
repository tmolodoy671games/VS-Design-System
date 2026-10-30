using System;
using System.Collections.Generic;
using Compose.Net;
using SharpExtensions;
using StableCollections;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

public static partial class DesignSystemComposeFunctions
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
        Action<T>? onValueChange = null
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
            contentPadding: contentPadding.GetOrDefault(PaddingValues(horizontal: 16.Dp(), vertical: 12.Dp())),
            interactionSource: interactionSource ?? Remember(MutableInteractionSource),
            enabled: enabled,
            onValueChange: onValueChange
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
        Action<T>? onValueChange
    )
    {
        var anchor = Remember(() => MutableStateOf(default(Compose.Net.Rect)));
        var viewport = Remember(() => MutableStateOf(default(Size)));
        var menuSize = Remember(() => MutableStateOf(default(Size)));
        var density = LocalDensity.Current;
        var textStyle = Theme.Typography.BodyLarge;
        // Clickable retains its handler; resolve current inputs when the click arrives.
        var inputs = Remember(() => MutableStateOf((expanded, onExpandedChange, onValueChange)));
        inputs.Value = (expanded, onExpandedChange, onValueChange);
        Surface(
            onClick: () => inputs.Value.onExpandedChange(!inputs.Value.expanded),
            enabled: enabled && values.Size > 0,
            interactionSource: interactionSource,
            shape: shape,
            color: colors.GetContainerColor(enabled),
            contentColor: colors.GetContentColor(enabled),
            modifier: modifier.OnGloballyPositioned(c => anchor.Value = new Compose.Net.Rect(c.LocalToRoot(default), c.Size)),
            content: () => CompositionLocalProvider(
                LocalTextStyle.Provides(textStyle),
                content: () => Row(
                    modifier: Modifier.Padding(contentPadding),
                    verticalAlignment: Alignment.CenterVertically,
                    content: () =>
                    {
                        content(value);
                        Text(expanded && enabled ? "\u25B4" : "\u25BE", modifier: Modifier.Padding(left: 16.Dp()));
                    }
                )
            )
        );

        if (!expanded || !enabled || values.Size == 0)
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
                        content: () => Column(
                            modifier: Modifier.Offset(x: density.ToDp(x), y: density.ToDp(y))
                                .Width(density.ToDp(width)).HeightIn(max: density.ToDp(height))
                                .Background(colors.DropdownColor, shape).Clip(shape)
                                .OnGloballyPositioned(c => menuSize.Value = c.Size)
                                .VerticalScroll(RememberScrollState()),
                            content: () =>
                            {
                                foreach (var item in values)
                                {
                                    var currentItem = Remember(() => MutableStateOf(item));
                                    currentItem.Value = item;
                                    Surface(
                                        onClick: () =>
                                        {
                                            inputs.Value.onValueChange?.Invoke(currentItem.Value);
                                            inputs.Value.onExpandedChange(false);
                                        },
                                        color: EqualityComparer<T>.Default.Equals(value, item)
                                            ? colors.ContainerColor : colors.DropdownColor,
                                        contentColor: colors.ContentColor,
                                        modifier: Modifier.FillMaxWidth(),
                                        content: () => Row(
                                            modifier: Modifier.Padding(contentPadding),
                                            verticalAlignment: Alignment.CenterVertically,
                                            content: () => content(item))
                                    );
                                }
                            }
                        )
                    );
                }
            );
        });
    }
}

public static partial class DropdownSelectorDefaults
{
    public static Shape Shape
    {
        [Composable] get => DesignSystemComposeFunctions.Theme.Shapes.Small;
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
        var scheme = DesignSystemComposeFunctions.Theme.ColorScheme;
        return new DropdownSelectorColors(
            containerColor.GetOrDefault(scheme.SurfaceContainerHighest),
            dropdownColor.GetOrDefault(scheme.SurfaceContainer),
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
