// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static void MenuList(
        ComposableContent content,
        IModifier? modifier = null
    )
    {
        ScrollableColumn(
            modifier: modifier,
            content: () => { ListSelection(content); }
        );
    }

    [Composable]
    public static void MenuItem(
        Action onClick,
        ComposableContent content,
        bool clickable = true,
        bool enabled = true,
        IModifier? modifier = null
    )
    {
        ListSelectionItem(item =>
            {
                var theme = Theme;
                var colors = theme.ColorScheme;
                var hoverable = enabled && !clickable;
                var interactionSource = Remember(MutableInteractionSource);
                var hovered = interactionSource.CollectIsHoveredAsState().Value;
                var pressed = interactionSource.CollectIsPressedAsState().Value;
                SideEffect(hovered, () =>
                {
                    if (hovered)
                        item.Select();
                });
                Row(
                    verticalAlignment: Alignment.CenterVertically,
                    modifier: modifier.OrEmpty(),
                    content: () =>
                    {
                        Box(
                            modifier: Modifier
                                .Background(
                                    AnimateColorAsState(
                                        item.IsSelected ? colors.ElementLow : colors.ElementLow
                                    ).Value
                                )
                                .FillMaxWidth()
                                .ClickIndication(
                                    enabled: clickable && enabled,
                                    onClick: onClick,
                                    interactionSource: interactionSource
                                )
                                .HoverIndication(
                                    enabled: hoverable,
                                    interactionSource: interactionSource
                                )
                                .Margin(vertical: 4.Dp())
                                .FillMaxWidth()
                                .Padding(
                                    vertical: 8.Dp() + 8 * item.SelectionProgress.Dp(),
                                    horizontal: 16.Dp()
                                )
                                .Clip(
                                    AnimateRoundedCornerShapeAsState(
                                        hovered
                                            ? RoundedCornerShape(16.Dp())
                                            : RoundedCornerShape(8.Dp())
                                    ).Value
                                ),
                            content: () =>
                            {
                                Row(
                                    verticalAlignment: Alignment.CenterVertically,
                                    modifier: Modifier.FillMaxSize()
                                        .Scale(
                                            AnimateFloatAsState(pressed ? 0.75f : 1f).Value
                                        ),
                                    content: () =>
                                    {
                                        CompositionLocalProvider(
                                            LocalTextStyle.Provides(theme.Typography.Control),
                                            content: content
                                        );
                                    }
                                );
                            }
                        );
                    }
                );
            }
        );
    }
}