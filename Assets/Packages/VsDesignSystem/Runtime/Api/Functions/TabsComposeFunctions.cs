// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using StableCollections;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    private static readonly ICompositionLocal<IMutableStableDictionary<int, LayoutCoordinates>> LocalTabsCoordinates =
        CompositionLocalOf<IMutableStableDictionary<int, LayoutCoordinates>>(() =>
            throw new InvalidOperationException("No LocalTabsCoordinates provided!")
        );

    [Composable]
    public static void Tabs(
        ComposableContent content,
        Optional<AnimationSpec> animationSpec = default,
        Optional<AnimationSpec> appearAnimationSpec = default,
        IModifier? modifier = null
    )
    {
        var theme = Theme;
        var colors = theme.ColorScheme;

        animationSpec = animationSpec.GetOrDefault(
            Tween(duration: 0.25f)
        );
        appearAnimationSpec = appearAnimationSpec.GetOrDefault(
            Tween(
                delay: 0.2f,
                duration: 0.4f
            )
        );
        var visibilityProgress = VisibilityProgress(
            LocalTransitionState.Current.Phase != TransitionPhase.Exiting,
            appearAnimationSpec
        ).Value;
        Surface(
            color: colors.Primary,
            modifier: modifier.OrEmpty()
                .Clip(RoundedCornerShape(16.Dp()))
                .Offset(y: (1 - visibilityProgress) * -100.Dp())
                .Alpha(visibilityProgress),
            content: () =>
            {
                FixedSize(() =>
                    {
                        Row(
                            horizontalArrangement: Arrangement.Center,
                            verticalAlignment: Alignment.CenterVertically,
                            content: () =>
                            {
                                var selection = RememberListSelection();
                                var tabLayouts = Remember(MutableStateDictionaryOf<int, LayoutCoordinates>);
                                var selectedId = selection.SelectedId;
                                if (tabLayouts.ContainsKey(selectedId))
                                {
                                    Spacer(
                                        Modifier
                                            .Background(colors.OnPrimary)
                                            .Alpha(0.1f)
                                            .Clip(RoundedCornerShape(16.Dp()))
                                            .Size(
                                                width: AnimateFloatAsState(
                                                    key: selectedId,
                                                    targetValueFactory: () => tabLayouts[selectedId].Size.x,
                                                    animationSpec: animationSpec
                                                ).Value.Dp(),
                                                height: AnimateFloatAsState(
                                                    key: selectedId,
                                                    targetValueFactory: () => tabLayouts[selectedId].Size.y,
                                                    animationSpec: animationSpec
                                                ).Value.Dp()
                                            )
                                            .Scale(1.01f)
                                            .Float()
                                            .Position(
                                                left: AnimateFloatAsState(
                                                    key: selectedId,
                                                    targetValueFactory: () =>
                                                        tabLayouts[selectedId].LocalPosition.x,
                                                    animationSpec: animationSpec
                                                ).Value.Dp(),
                                                top: AnimateFloatAsState(
                                                    key: selectedId,
                                                    targetValueFactory: () =>
                                                        tabLayouts[selectedId].LocalPosition.y,
                                                    animationSpec: animationSpec
                                                ).Value.Dp()
                                            )
                                    );
                                }

                                CompositionLocalProvider(
                                    LocalTabsCoordinates.Provides(tabLayouts),
                                    content: () =>
                                    {
                                        ListSelection(
                                            selection: selection,
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

    [Composable]
    public static void Tab(
        ComposableContent content,
        Action onClick,
        bool selected,
        IModifier? modifier = null
    )
    {
        var theme = Theme;
        var bounce = theme.AnimationSpecs.Bounce;
        var interactionSource = Remember(MutableInteractionSource);
        var isHovered = interactionSource.CollectIsHoveredAsState().Value;
        var isPressed = interactionSource.CollectIsPressedAsState().Value;
        var tabsCoordinates = LocalTabsCoordinates.Current;
        ListSelectionItem(item =>
        {
            SideEffect(selected, () =>
            {
                if (selected)
                    item.Select();
            });
            Box(
                modifier: modifier.OrEmpty()
                    .Padding(
                        vertical: 4.Dp(),
                        horizontal: 16.Dp() + 32.Dp() * item.SelectionProgress
                    )
                    .OnGloballyPositioned(
                        onGloballyPositioned: it => tabsCoordinates[item.Id] = it
                    )
                    .Clip(RoundedCornerShape(16.Dp()))
                    .Hoverable(interactionSource)
                    .ClickIndication(
                        onClick: onClick,
                        interactionSource: interactionSource
                    ),
                content: () =>
                {
                    Box(
                        modifier: Modifier
                            .Scale(AnimateFloatAsState(isPressed ? 0.75f : isHovered ? 1.1f : 1f, bounce).Value),
                        content: () =>
                        {
                            CompositionLocalProvider(
                                LocalTextStyle.Provides(Theme.Typography.Title),
                                content: content
                            );
                        }
                    );
                }
            );
        });
    }
}