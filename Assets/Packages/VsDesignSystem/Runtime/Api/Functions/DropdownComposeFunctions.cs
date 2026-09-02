// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static void Dropdown(
        bool expanded,
        Action onClick,
        Action onDismiss,
        ComposableContent content,
        ComposableContent sizeContent,
        ComposableContent dropdownContent,
        IMutableInteractionSource? interactionSource = null,
        IModifier? modifier = null
    )
    {
        var theme = Theme;
        var colors = theme.ColorScheme;
        interactionSource ??= Remember(MutableInteractionSource);
        var coordinates = Remember(() => MutableStateOf(Optional.Empty<LayoutCoordinates>()));
        var expandProgress = AnimateFloatAsState(expanded.ToInt()).Value;
        if (expanded && coordinates.Value.HasValue)
        {
            DropdownModal(
                onDismiss: onDismiss,
                content: content,
                sizeContent: sizeContent,
                dropdownContent: dropdownContent,
                coordinates: coordinates.Value.Value
            );
        }

        DropdownLayout(
            content: content,
            sizeContent: sizeContent,
            expandProgress: expandProgress,
            modifier: modifier.OrEmpty()
                .ClickIndication(onClick, interactionSource)
                .OnGloballyPositioned(it => coordinates.Value = it)
        );
    }

    [Composable]
    public static void DropdownItem(
        Action onClick,
        ComposableContent content,
        IModifier? modifier = null
    )
    {
        var interactionSource = Remember(MutableInteractionSource);
        var isPressed = interactionSource.CollectIsPressedAsState().Value;
        var bounce = Theme.AnimationSpecs.Bounce;
        ListSelectionItem(item =>
        {
            var isHovered = interactionSource.CollectIsHoveredAsState().Value;
            SideEffect(isHovered, () =>
            {
                if (isHovered)
                    item.Select();
            });
            Box(
                modifier: modifier.OrEmpty()
                    .FillMaxWidth()
                    .Padding(
                        horizontal: 2.Dp(),
                        vertical: 2.Dp() + 8.Dp() * item.SelectionProgress
                    )
                    .Margin(vertical: 2.Dp())
                    .Hoverable(interactionSource)
                    .ClickIndication(onClick, interactionSource),
                content: () =>
                {
                    Box(
                        modifier: Modifier
                            .FillMaxSize()
                            .Scale(AnimateFloatAsState(isPressed ? 0.8f : 1f, bounce).Value),
                        content: content
                    );
                }
            );
        });
    }

    [Composable]
    private static void DropdownLayout(
        ComposableContent content,
        ComposableContent sizeContent,
        float expandProgress,
        IModifier? modifier = null
    )
    {
        var theme = Theme;
        var colors = theme.ColorScheme;
        Box(
            alignment: Alignment.CenterLeft,
            modifier: modifier.OrEmpty()
                .Padding(
                    horizontal: 8.Dp(),
                    vertical: 4.Dp()
                )
                .Clip(
                    RoundedCornerShape(
                        topLeft: 16.Dp(),
                        topRight: 16.Dp(),
                        bottomLeft: ((1 - expandProgress) * 16).Dp(),
                        bottomRight: ((1 - expandProgress) * 16).Dp()
                    )
                )
                .Background(
                    colors.Primary
                ),
            content: () =>
            {
                CompositionLocalProvider(
                    LocalContentColor.Provides(colors.OnPrimary),
                    LocalTextStyle.Provides(theme.Typography.Control),
                    () => Row(
                        verticalAlignment: Alignment.CenterVertically,
                        modifier: Modifier.Alpha(0f),
                        content: sizeContent
                    )
                );
                CompositionLocalProvider(
                    LocalContentColor.Provides(colors.OnPrimary),
                    LocalTextStyle.Provides(theme.Typography.Control),
                    () => Row(
                        verticalAlignment: Alignment.CenterVertically,
                        modifier: Modifier.Float(),
                        content: content
                    )
                );
            }
        );
    }

    [Composable]
    private static void DropdownModal(
        Action onDismiss,
        ComposableContent content,
        ComposableContent sizeContent,
        ComposableContent dropdownContent,
        LayoutCoordinates coordinates
    )
    {
        var theme = Theme;
        var colors = theme.ColorScheme;
        var bounce = theme.AnimationSpecs.Bounce;
        ModalMenu(() =>
        {
            WithTheme(() =>
            {
                var visibilityProgress = VisibilityProgress(true).Value;
                Box(
                    modifier: Modifier.FillMaxSize()
                        .OnClick(onDismiss),
                    content: () =>
                    {
                        Column(
                            modifier: Modifier
                                .Float()
                                .Position(
                                    top: coordinates.GlobalPosition.y.Dp(),
                                    left: coordinates.GlobalPosition.x.Dp()
                                ),
                            content: () =>
                            {
                                DropdownLayout(
                                    content: content,
                                    sizeContent: sizeContent,
                                    expandProgress: visibilityProgress
                                );
                                ScrollableColumn(
                                    modifier: Modifier
                                        .Width(coordinates.Width.Dp())
                                        .Background(colors.PrimaryContainer)
                                        .Clip(
                                            RoundedCornerShape(
                                                topLeft: 0.Dp(),
                                                topRight: 0.Dp(),
                                                bottomLeft: 16.Dp(),
                                                bottomRight: 16.Dp()
                                            )
                                        )
                                        .HeightIn(max: 300.Dp() * visibilityProgress),
                                    content: () =>
                                    {
                                        CompositionLocalProvider(
                                            LocalContentColor.Provides(colors.OnPrimaryContainer),
                                            content: () => ListSelection(dropdownContent)
                                        );
                                    }
                                );
                            }
                        );
                    }
                );
            });
        });
    }
}