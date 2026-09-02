#nullable enable
// ReSharper disable CheckNamespace

using System;
using System.Collections;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __Dropdown<T>(bool expanded, Action onClick, Action onDismiss, T state, ComposableContent<T> content, ComposableContent sizeContent, ComposableContent dropdownContent, IMutableInteractionSource? interactionSource = null, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__expanded, __onClick, __onDismiss, __state, __content, __sizeContent, __dropdownContent, __interactionSource, __modifier) = (expanded, onClick, onDismiss, state, content, sizeContent, dropdownContent, interactionSource, modifier);
        var __isCreated = __composer.StartRestartGroup(885399342);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(expanded) ? 0b_00_00_00_00_00_00_00_00_10 : 0b_00_00_00_00_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_00_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_00_00_00_00_00_10_00 : 0b_00_00_00_00_00_00_00_01_00;
        if ((__changed & 0b_00_00_00_00_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(onDismiss) ? 0b_00_00_00_00_00_00_10_00_00 : 0b_00_00_00_00_00_00_01_00_00;
        if ((__changed & 0b_00_00_00_00_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(state) ? 0b_00_00_00_00_00_10_00_00_00 : 0b_00_00_00_00_00_01_00_00_00;
        if ((__changed & 0b_00_00_00_00_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_00_10_00_00_00_00 : 0b_00_00_00_00_01_00_00_00_00;
        if ((__changed & 0b_00_00_00_11_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(sizeContent) ? 0b_00_00_00_10_00_00_00_00_00 : 0b_00_00_00_01_00_00_00_00_00;
        if ((__changed & 0b_00_00_11_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(dropdownContent) ? 0b_00_00_10_00_00_00_00_00_00 : 0b_00_00_01_00_00_00_00_00_00;
        if ((__changed & 0b_00_11_00_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_00_10_00_00_00_00_00_00_00 : 0b_00_01_00_00_00_00_00_00_00;
        if ((__changed & 0b_11_00_00_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00_00_00_00_00_00 : 0b_01_00_00_00_00_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01_01_01_01_01)
        {
            var theme = Theme;
            var colors = theme.ColorScheme;
            interactionSource ??= (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            var coordinates = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<global::SharpExtensions.Optional<global::UnityCompose.LayoutCoordinates>>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<global::SharpExtensions.Optional<global::UnityCompose.LayoutCoordinates>>>(MutableStateOf(Optional.Empty<LayoutCoordinates>())));
            var expandProgress = __AnimateFloatAsState(expanded.ToInt(), __composer: __composer, __changed: 0b_01_00).Value;
            __composer.StartReplaceGroup(577225486);
            if (expanded && coordinates.Value.HasValue)
            {
                __DropdownModal(onDismiss: onDismiss, dropdownContent: dropdownContent, coordinates: coordinates.Value.Value, __composer: __composer, __changed: ((__dirty & 0b_11_00_00) >> 4) | ((__dirty & 0b_11_00_00_00_00_00_00) >> 10));
            }

            __composer.EndReplaceGroup(577225486);
            __DropdownLayout(content: content, sizeContent: sizeContent, expandProgress: expandProgress, state: state, modifier: modifier.OrEmpty().__ClickIndication(onClick, interactionSource, __composer: __composer, __changed: 0b_01_01_00_00 | ((__dirty & 0b_11_00) >> 2)).OnGloballyPositioned((!__composer.Changed<global::UnityCompose.IMutableState<global::SharpExtensions.Optional<global::UnityCompose.LayoutCoordinates>>>(coordinates!) ? __composer.RememberedValue<global::System.Action<global::UnityCompose.LayoutCoordinates>>() : __composer.UpdateRememberedValue<global::System.Action<global::UnityCompose.LayoutCoordinates>>(it => coordinates.Value = it))), __composer: __composer, __changed: ((__dirty & 0b_00_11_00_00_00) >> 6) | ((__dirty & 0b_11_00_00_00_00) >> 6) | ((__dirty & 0b_11_00_00_00_00_00) >> 6));
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01_01_01_01_01;
        __composer.EndRestartGroup(885399342, __isRestarted)?.UpdateScope(() => __Dropdown(__expanded, __onClick, __onDismiss, __state, __content, __sizeContent, __dropdownContent, __interactionSource, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    public static void __DropdownItem(Action onClick, ComposableContent content, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onClick, __content, __modifier) = (onClick, content, modifier);
        var __isCreated = __composer.StartRestartGroup(1812343184);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_11) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_10 : 0b_00_00_01;
        if ((__changed & 0b_00_11_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_10_00 : 0b_00_01_00;
        if ((__changed & 0b_11_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00 : 0b_01_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01)
        {
            var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            var isPressed = interactionSource.__CollectIsPressedAsState(__composer: __composer, __changed: 0b_00).Value;
            var bounce = Theme.AnimationSpecs.Bounce;
            var coroutineScope = __RememberCoroutineScope(__composer: __composer, __changed: 0b_00);
            var dismiss = LocalDismiss.Current;
            var onDismiss = LocalOnDismiss.Current;
            var onClickCallback = (!__composer.BuildChanged().Changed<global::UnityCompose.IComposeCoroutineScope>(coroutineScope!).Changed<global::System.Action>(dismiss!).Changed<global::System.Action>(onDismiss!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
            {
                coroutineScope.StartCoroutine(OnClickCoroutine());
            }));
            __ListSelectionItem((!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).ChangedAsFlag((__dirty & 0b_11_00_00) == 0b_10_00_00).Changed<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(interactionSource!).Changed<bool>(isPressed!).Changed<global::UnityCompose.AnimationSpec>(bounce!).Changed<global::System.Action>(onClickCallback!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(item =>
            {
                var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
                __SideEffect(isHovered, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.IListSelectionItem>(item!).Changed<bool>(isHovered!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                {
                    if (isHovered)
                        item.Select();
                })), __composer: __composer, __changed: 0b_00_00);
                __Box(modifier: modifier.OrEmpty().FillMaxWidth().Padding(horizontal: 2.Dp(), vertical: 2.Dp() + 8.Dp() * item.SelectionProgress).Margin(vertical: 2.Dp()).Hoverable(interactionSource).Clip(RoundedCornerShape(8.Dp())).__ClickIndication(onClickCallback, interactionSource, __composer: __composer, __changed: 0b_01_01_00_00), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).Changed<bool>(isPressed!).Changed<global::UnityCompose.AnimationSpec>(bounce!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Box(modifier: Modifier.FillMaxSize().Scale(__AnimateFloatAsState(isPressed ? 0.8f : 1f, bounce, __composer: __composer, __changed: 0b_00_00).Value), content: content, __composer: __composer, __changed: 0b_01_00_00 | ((__dirty & 0b_11_00) >> 2));
                })), __composer: __composer, __changed: 0b_01_00_00);
            })), __composer: __composer, __changed: 0b_00);
            __dirty = 0b_01_01_01;
            __composer.EndRestartGroup(1812343184, __isRestarted)?.UpdateScope(() => __DropdownItem(__onClick, __content, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
            return;
            IEnumerator OnClickCoroutine()
            {
                dismiss();
                yield return new WaitForSeconds(0.15f);
                onClick();
                onDismiss();
            }
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01;
        __composer.EndRestartGroup(1812343184, __isRestarted)?.UpdateScope(() => __DropdownItem(__onClick, __content, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __DropdownLayout<T>(T state, ComposableContent<T> content, ComposableContent sizeContent, float expandProgress, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__state, __content, __sizeContent, __expandProgress, __modifier) = (state, content, sizeContent, expandProgress, modifier);
        var __isCreated = __composer.StartRestartGroup(1747606119);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(state) ? 0b_00_00_00_00_10 : 0b_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_10_00 : 0b_00_00_00_01_00;
        if ((__changed & 0b_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(sizeContent) ? 0b_00_00_10_00_00 : 0b_00_00_01_00_00;
        if ((__changed & 0b_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(expandProgress) ? 0b_00_10_00_00_00 : 0b_00_01_00_00_00;
        if ((__changed & 0b_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00_00 : 0b_01_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01)
        {
            var theme = Theme;
            var colors = theme.ColorScheme;
            var bounce = theme.AnimationSpecs.Bounce;
            var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
            var isPressed = interactionSource.__CollectIsPressedAsState(__composer: __composer, __changed: 0b_00).Value;
            __Box(alignment: Alignment.CenterLeft, modifier: modifier.OrEmpty().Margin(all: 2.Dp()).Hoverable(interactionSource).Clickable(interactionSource).Padding(horizontal: 8.Dp(), vertical: 4.Dp()).Clip(RoundedCornerShape(topLeft: 16.Dp(), topRight: 16.Dp(), bottomLeft: ((1 - expandProgress) * 16).Dp(), bottomRight: ((1 - expandProgress) * 16).Dp())).Background(colors.Primary), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00) == 0b_00_00_10_00_00).Changed<global::VS.UiToolkit.ThemeConfig>(theme!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Changed<global::UnityCompose.AnimationSpec>(bounce!).Changed<bool>(isHovered!).Changed<bool>(isPressed!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __CompositionLocalProvider(LocalContentColor.Provides(colors.OnPrimary), LocalTextStyle.Provides(theme.Typography.Control), (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_11_00_00) == 0b_00_00_10_00_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Row(verticalAlignment: Alignment.CenterVertically, modifier: Modifier.Alpha(0f), content: sizeContent, __composer: __composer, __changed: 0b_01_00_00 | ((__dirty & 0b_11_00_00) >> 4)))), __composer: __composer, __changed: 0b_00_00_00);
                __CompositionLocalProvider(LocalContentColor.Provides(colors.OnPrimary), LocalTextStyle.Provides(theme.Typography.Control), (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).Changed<global::UnityCompose.AnimationSpec>(bounce!).Changed<bool>(isHovered!).Changed<bool>(isPressed!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Row(verticalAlignment: Alignment.CenterVertically, modifier: Modifier.Float().Scale(__AnimateFloatAsState(isPressed ? 0.8f : isHovered ? 1.1f : 1f, bounce, __composer: __composer, __changed: 0b_00_00).Value), content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __AnimatedContent(targetState: state, transitionSpec: (!__composer.Changed() ? __composer.RememberedValue<global::System.Func<global::UnityCompose.IAnimatedContentTransitionScope<T>, global::UnityCompose.ContentTransform>>() : __composer.UpdateRememberedValue<global::System.Func<global::UnityCompose.IAnimatedContentTransitionScope<T>, global::UnityCompose.ContentTransform>>(_ => FadeIn().TogetherWith(FadeOut()).With(Tween(duration: 1f)))), content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<T, global::UnityCompose.IModifier>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<T, global::UnityCompose.IModifier>>((_, m) =>
                        {
                            __composer.StartReplaceGroup(489057240);
                            __Box(modifier: m.FillMaxSize(), content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => content(state))), __composer: __composer, __changed: 0b_01_00_00);
                            __composer.EndReplaceGroup(489057240);
                        })), __composer: __composer, __changed: 0b_01_01_00_00_00 | (__dirty & 0b_00_00_11));
                    })), __composer: __composer, __changed: 0b_01_00_00);
                })), __composer: __composer, __changed: 0b_00_00_00);
            })), __composer: __composer, __changed: 0b_00_00_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01;
        __composer.EndRestartGroup(1747606119, __isRestarted)?.UpdateScope(() => __DropdownLayout(__state, __content, __sizeContent, __expandProgress, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __DropdownModal(Action onDismiss, ComposableContent dropdownContent, LayoutCoordinates coordinates, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onDismiss, __dropdownContent, __coordinates) = (onDismiss, dropdownContent, coordinates);
        var __isCreated = __composer.StartRestartGroup(1615800600);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_11) == 0)
            __dirty |= __composer.Changed(onDismiss) ? 0b_00_00_10 : 0b_00_00_01;
        if ((__changed & 0b_00_11_00) == 0)
            __dirty |= __composer.Changed(dropdownContent) ? 0b_00_10_00 : 0b_00_01_00;
        if ((__changed & 0b_11_00_00) == 0)
            __dirty |= __composer.Changed(coordinates) ? 0b_10_00_00 : 0b_01_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01)
        {
            var theme = Theme;
            var colors = theme.ColorScheme;
            __ModalMenu((!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11) == 0b_00_00_10).ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).ChangedAsFlag((__dirty & 0b_11_00_00) == 0b_10_00_00).Changed<global::VS.UiToolkit.ThemeConfig>(theme!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __WithTheme((!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11) == 0b_00_00_10).ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).ChangedAsFlag((__dirty & 0b_11_00_00) == 0b_10_00_00).Changed<global::VS.UiToolkit.ThemeConfig>(theme!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    var isVisible = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<bool>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<bool>>(MutableStateOf(true)));
                    var visibilityProgress = __VisibilityProgress(isVisible.Value, __composer: __composer, __changed: 0b_01_00).Value;
                    __Box(modifier: Modifier.FillMaxSize().OnClick(onDismiss), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11) == 0b_00_00_10).ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).ChangedAsFlag((__dirty & 0b_11_00_00) == 0b_10_00_00).Changed<global::VS.UiToolkit.ThemeConfig>(theme!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Changed<global::UnityCompose.IMutableState<bool>>(isVisible!).Changed<float>(visibilityProgress!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __Column(modifier: Modifier.Float().Position(top: coordinates.GlobalBottom.Dp(), left: coordinates.GlobalPosition.x.Dp()), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11) == 0b_00_00_10).ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).ChangedAsFlag((__dirty & 0b_11_00_00) == 0b_10_00_00).Changed<global::VS.UiToolkit.ThemeConfig>(theme!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Changed<global::UnityCompose.IMutableState<bool>>(isVisible!).Changed<float>(visibilityProgress!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                        {
                            __ScrollableColumn(modifier: Modifier.Width(coordinates.Width.Dp()).Background(colors.PrimaryContainer).Clip(RoundedCornerShape(topLeft: 0.Dp(), topRight: 0.Dp(), bottomLeft: 16.Dp(), bottomRight: 16.Dp())).HeightIn(max: 300.Dp() * visibilityProgress), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11) == 0b_00_00_10).ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).Changed<global::VS.UiToolkit.ThemeConfig>(theme!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Changed<global::UnityCompose.IMutableState<bool>>(isVisible!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                            {
                                __CompositionLocalProvider(LocalDismiss.Provides((!__composer.Changed<global::UnityCompose.IMutableState<bool>>(isVisible!) ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => isVisible.Value = false))), LocalOnDismiss.Provides(onDismiss), LocalContentColor.Provides(colors.OnPrimaryContainer), LocalTextStyle.Provides(theme.Typography.Control), content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __ListSelection(dropdownContent, __composer: __composer, __changed: 0b_01_00 | ((__dirty & 0b_11_00) >> 2)))), __composer: __composer, __changed: 0b_00_00_00_00_00);
                            })), __composer: __composer, __changed: 0b_01_01_00);
                        })), __composer: __composer, __changed: 0b_01_01_00_00);
                    })), __composer: __composer, __changed: 0b_01_00_00);
                })), __composer: __composer, __changed: 0b_00);
            })), __composer: __composer, __changed: 0b_01_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01;
        __composer.EndRestartGroup(1615800600, __isRestarted)?.UpdateScope(() => __DropdownModal(__onDismiss, __dropdownContent, __coordinates, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}