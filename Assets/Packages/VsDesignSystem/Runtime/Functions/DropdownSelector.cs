using System;
using Compose.Net;
using SharpExtensions;
using StableCollections;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

public static partial class DesignSystemComposeFunctions
{
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
        bool enabled = true
    )
    {
        DropdownSelectorImpl<T>(
            value: value,
            expanded: expanded,
            onExpandedChange: onExpandedChange,
            values: values,
            content: content,
            modifier: modifier,
            shape: shape.GetOrDefault(),
            colors: colors.GetOrDefault(),
            contentPadding: contentPadding.GetOrDefault(),
            interactionSource: interactionSource ?? Remember(MutableInteractionSource),
            enabled: enabled
        );
    }

    [Composable, NonRestartableComposable]
    private static void DropdownSelectorImpl<T>(
        T value,
        bool expanded,
        Action<bool> onExpandedChange,
        IStableList<T> values,
        [Composable] Action<T> content,
        IModifier? modifier,
        Shape shape,
        DropdownSelectorColors colors,
        PaddingValues contentPadding,
        IMutableInteractionSource interactionSource,
        bool enabled
    )
    {
        // ModalMenu
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