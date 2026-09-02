// ReSharper disable CheckNamespace

using System;
using System.Collections;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static void Dropdown<T>(
        bool expanded,
        Action onClick,
        Action onDismiss,
        T state,
        ComposableContent<T> content,
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
                dropdownContent: dropdownContent,
                coordinates: coordinates.Value.Value
            );
        }

        DropdownLayout(
            content: content,
            sizeContent: sizeContent,
            expandProgress: expandProgress,
            state: state,
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
        var coroutineScope = RememberCoroutineScope();
        var dismiss = LocalDismiss.Current;
        var onDismiss = LocalOnDismiss.Current;
        var onClickCallback = () => { coroutineScope.StartCoroutine(OnClickCoroutine()); };

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
                    .Clip(RoundedCornerShape(8.Dp()))
                    .ClickIndication(onClickCallback, interactionSource),
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
        return;

        IEnumerator OnClickCoroutine()
        {
            dismiss();
            yield return new WaitForSeconds(0.15f);
            onClick();
            onDismiss();
        }
    }

    [Composable]
    private static void DropdownLayout<T>(
        T state,
        ComposableContent<T> content,
        ComposableContent sizeContent,
        float expandProgress,
        IModifier? modifier = null
    )
    {
        var theme = Theme;
        var colors = theme.ColorScheme;
        var bounce = theme.AnimationSpecs.Bounce;
        var interactionSource = Remember(MutableInteractionSource);
        var isHovered = interactionSource.CollectIsHoveredAsState().Value;
        var isPressed = interactionSource.CollectIsPressedAsState().Value;
        Box(
            alignment: Alignment.CenterLeft,
            modifier: modifier.OrEmpty()
                .Margin(all: 2.Dp())
                .Hoverable(interactionSource)
                .Clickable(interactionSource)
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
                    () =>
                    {
                        Row(
                            verticalAlignment: Alignment.CenterVertically,
                            modifier: Modifier.Float()
                                .Scale(
                                    AnimateFloatAsState(
                                        isPressed ? 0.8f : isHovered ? 1.1f : 1f,
                                        bounce
                                    ).Value
                                ),
                            content: () =>
                            {
                                AnimatedContent(
                                    targetState: state,
                                    transitionSpec: _ => FadeIn().TogetherWith(FadeOut())
                                        .With(Tween(duration: 1f)),
                                    content: (_, m) =>
                                    {
                                        Box(
                                            modifier: m.FillMaxSize(),
                                            content: () => content(state)
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

    [Composable]
    private static void DropdownModal(
        Action onDismiss,
        ComposableContent dropdownContent,
        LayoutCoordinates coordinates
    )
    {
        var theme = Theme;
        var colors = theme.ColorScheme;
        ModalMenu(() =>
        {
            WithTheme(() =>
            {
                var isVisible = Remember(() => MutableStateOf(true));
                var visibilityProgress = VisibilityProgress(isVisible.Value).Value;
                Box(
                    modifier: Modifier.FillMaxSize()
                        .OnClick(onDismiss),
                    content: () =>
                    {
                        Column(
                            modifier: Modifier
                                .Float()
                                .Position(
                                    top: coordinates.GlobalBottom.Dp(),
                                    left: coordinates.GlobalPosition.x.Dp()
                                ),
                            content: () =>
                            {
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
                                            LocalDismiss.Provides(() => isVisible.Value = false),
                                            LocalOnDismiss.Provides(onDismiss),
                                            LocalContentColor.Provides(colors.OnPrimaryContainer),
                                            LocalTextStyle.Provides(theme.Typography.Control),
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