#nullable enable
// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __Dropdown(bool expanded, Action onClick, Action onDismiss, ComposableContent content, ComposableContent sizeContent, ComposableContent dropdownContent, IMutableInteractionSource? interactionSource = null, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__expanded, __onClick, __onDismiss, __content, __sizeContent, __dropdownContent, __interactionSource, __modifier) = (expanded, onClick, onDismiss, content, sizeContent, dropdownContent, interactionSource, modifier);
        var __isCreated = __composer.StartRestartGroup(372207268);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(expanded) ? 0b_00_00_00_00_00_00_00_10 : 0b_00_00_00_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_00_00_00_00_10_00 : 0b_00_00_00_00_00_00_01_00;
        if ((__changed & 0b_00_00_00_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(onDismiss) ? 0b_00_00_00_00_00_10_00_00 : 0b_00_00_00_00_00_01_00_00;
        if ((__changed & 0b_00_00_00_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_00_10_00_00_00 : 0b_00_00_00_00_01_00_00_00;
        if ((__changed & 0b_00_00_00_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(sizeContent) ? 0b_00_00_00_10_00_00_00_00 : 0b_00_00_00_01_00_00_00_00;
        if ((__changed & 0b_00_00_11_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(dropdownContent) ? 0b_00_00_10_00_00_00_00_00 : 0b_00_00_01_00_00_00_00_00;
        if ((__changed & 0b_00_11_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_00_10_00_00_00_00_00_00 : 0b_00_01_00_00_00_00_00_00;
        if ((__changed & 0b_11_00_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00_00_00_00_00 : 0b_01_00_00_00_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01_01_01_01)
        {
            var theme = Theme;
            var colors = theme.ColorScheme;
            interactionSource ??= (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            var coordinates = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<global::SharpExtensions.Optional<global::UnityCompose.LayoutCoordinates>>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<global::SharpExtensions.Optional<global::UnityCompose.LayoutCoordinates>>>(MutableStateOf(Optional.Empty<LayoutCoordinates>())));
            var expandProgress = __AnimateFloatAsState(expanded.ToInt(), __composer: __composer, __changed: 0b_01_00).Value;
            __composer.StartReplaceGroup(1967252931);
            if (expanded && coordinates.Value.HasValue)
            {
                __DropdownModal(onDismiss: onDismiss, content: content, sizeContent: sizeContent, dropdownContent: dropdownContent, coordinates: coordinates.Value.Value, __composer: __composer, __changed: ((__dirty & 0b_00_00_11_00_00) >> 4) | ((__dirty & 0b_00_11_00_00_00) >> 4) | ((__dirty & 0b_11_00_00_00_00) >> 4) | ((__dirty & 0b_11_00_00_00_00_00) >> 4));
            }

            __composer.EndReplaceGroup(1967252931);
            __DropdownLayout(content: content, sizeContent: sizeContent, expandProgress: expandProgress, modifier: modifier.OrEmpty().__ClickIndication(onClick, interactionSource, __composer: __composer, __changed: 0b_01_01_00_00 | ((__dirty & 0b_11_00) >> 2)).OnGloballyPositioned((!__composer.Changed<global::UnityCompose.IMutableState<global::SharpExtensions.Optional<global::UnityCompose.LayoutCoordinates>>>(coordinates!) ? __composer.RememberedValue<global::System.Action<global::UnityCompose.LayoutCoordinates>>() : __composer.UpdateRememberedValue<global::System.Action<global::UnityCompose.LayoutCoordinates>>(it => coordinates.Value = it))), __composer: __composer, __changed: ((__dirty & 0b_11_00_00_00) >> 6) | ((__dirty & 0b_11_00_00_00_00) >> 6));
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01_01_01_01;
        __composer.EndRestartGroup(372207268, __isRestarted)?.UpdateScope(() => __Dropdown(__expanded, __onClick, __onDismiss, __content, __sizeContent, __dropdownContent, __interactionSource, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    public static void __DropdownItem(Action onClick, ComposableContent content, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onClick, __content, __modifier) = (onClick, content, modifier);
        var __isCreated = __composer.StartRestartGroup(1787248064);
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
            __ListSelectionItem((!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11) == 0b_00_00_10).ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).ChangedAsFlag((__dirty & 0b_11_00_00) == 0b_10_00_00).Changed<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(interactionSource!).Changed<bool>(isPressed!).Changed<global::UnityCompose.AnimationSpec>(bounce!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(item =>
            {
                var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
                __SideEffect(isHovered, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.IListSelectionItem>(item!).Changed<bool>(isHovered!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                {
                    if (isHovered)
                        item.Select();
                })), __composer: __composer, __changed: 0b_00_00);
                __Box(modifier: modifier.OrEmpty().FillMaxWidth().Padding(horizontal: 2.Dp(), vertical: 2.Dp() + 8.Dp() * item.SelectionProgress).Margin(vertical: 2.Dp()).Hoverable(interactionSource).__ClickIndication(onClick, interactionSource, __composer: __composer, __changed: 0b_01_01_00_00 | (__dirty & 0b_00_11)), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).Changed<bool>(isPressed!).Changed<global::UnityCompose.AnimationSpec>(bounce!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Box(modifier: Modifier.FillMaxSize().Scale(__AnimateFloatAsState(isPressed ? 0.8f : 1f, bounce, __composer: __composer, __changed: 0b_00_00).Value), content: content, __composer: __composer, __changed: 0b_01_00_00 | ((__dirty & 0b_11_00) >> 2));
                })), __composer: __composer, __changed: 0b_01_00_00);
            })), __composer: __composer, __changed: 0b_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01;
        __composer.EndRestartGroup(1787248064, __isRestarted)?.UpdateScope(() => __DropdownItem(__onClick, __content, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __DropdownLayout(ComposableContent content, ComposableContent sizeContent, float expandProgress, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__content, __sizeContent, __expandProgress, __modifier) = (content, sizeContent, expandProgress, modifier);
        var __isCreated = __composer.StartRestartGroup(306877963);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_10 : 0b_00_00_00_01;
        if ((__changed & 0b_00_00_11_00) == 0)
            __dirty |= __composer.Changed(sizeContent) ? 0b_00_00_10_00 : 0b_00_00_01_00;
        if ((__changed & 0b_00_11_00_00) == 0)
            __dirty |= __composer.Changed(expandProgress) ? 0b_00_10_00_00 : 0b_00_01_00_00;
        if ((__changed & 0b_11_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00 : 0b_01_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01)
        {
            var theme = Theme;
            var colors = theme.ColorScheme;
            __Box(alignment: Alignment.CenterLeft, modifier: modifier.OrEmpty().Padding(horizontal: 8.Dp(), vertical: 4.Dp()).Clip(RoundedCornerShape(topLeft: 16.Dp(), topRight: 16.Dp(), bottomLeft: ((1 - expandProgress) * 16).Dp(), bottomRight: ((1 - expandProgress) * 16).Dp())).Background(colors.Primary), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_11) == 0b_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_11_00) == 0b_00_00_10_00).Changed<global::VS.UiToolkit.ThemeConfig>(theme!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __CompositionLocalProvider(LocalContentColor.Provides(colors.OnPrimary), LocalTextStyle.Provides(theme.Typography.Control), (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_11_00) == 0b_00_00_10_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Row(verticalAlignment: Alignment.CenterVertically, modifier: Modifier.Alpha(0f), content: sizeContent, __composer: __composer, __changed: 0b_01_00_00 | ((__dirty & 0b_00_11_00) >> 2)))), __composer: __composer, __changed: 0b_00_00_00);
                __CompositionLocalProvider(LocalContentColor.Provides(colors.OnPrimary), LocalTextStyle.Provides(theme.Typography.Control), (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_11) == 0b_00_00_00_10).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Row(verticalAlignment: Alignment.CenterVertically, modifier: Modifier.Float(), content: content, __composer: __composer, __changed: 0b_01_00_00 | (__dirty & 0b_00_00_11)))), __composer: __composer, __changed: 0b_00_00_00);
            })), __composer: __composer, __changed: 0b_00_00_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01;
        __composer.EndRestartGroup(306877963, __isRestarted)?.UpdateScope(() => __DropdownLayout(__content, __sizeContent, __expandProgress, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __DropdownModal(Action onDismiss, ComposableContent content, ComposableContent sizeContent, ComposableContent dropdownContent, LayoutCoordinates coordinates, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onDismiss, __content, __sizeContent, __dropdownContent, __coordinates) = (onDismiss, content, sizeContent, dropdownContent, coordinates);
        var __isCreated = __composer.StartRestartGroup(1741098241);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(onDismiss) ? 0b_00_00_00_00_10 : 0b_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_10_00 : 0b_00_00_00_01_00;
        if ((__changed & 0b_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(sizeContent) ? 0b_00_00_10_00_00 : 0b_00_00_01_00_00;
        if ((__changed & 0b_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(dropdownContent) ? 0b_00_10_00_00_00 : 0b_00_01_00_00_00;
        if ((__changed & 0b_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(coordinates) ? 0b_10_00_00_00_00 : 0b_01_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01)
        {
            var theme = Theme;
            var colors = theme.ColorScheme;
            var bounce = theme.AnimationSpecs.Bounce;
            __ModalMenu((!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00) == 0b_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00) == 0b_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_11_00_00_00_00) == 0b_10_00_00_00_00).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __WithTheme((!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00) == 0b_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00) == 0b_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_11_00_00_00_00) == 0b_10_00_00_00_00).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    var visibilityProgress = __VisibilityProgress(true, __composer: __composer, __changed: 0b_01_01).Value;
                    __Box(modifier: Modifier.FillMaxSize().OnClick(onDismiss), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00) == 0b_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00) == 0b_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_11_00_00_00_00) == 0b_10_00_00_00_00).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Changed<float>(visibilityProgress!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __Column(modifier: Modifier.Float().Position(top: coordinates.GlobalPosition.y.Dp(), left: coordinates.GlobalPosition.x.Dp()), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00) == 0b_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00) == 0b_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_11_00_00_00_00) == 0b_10_00_00_00_00).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Changed<float>(visibilityProgress!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                        {
                            __DropdownLayout(content: content, sizeContent: sizeContent, expandProgress: visibilityProgress, __composer: __composer, __changed: 0b_01_00_00_00 | ((__dirty & 0b_00_11_00) >> 2) | ((__dirty & 0b_11_00_00) >> 2));
                            __ScrollableColumn(modifier: Modifier.Width(coordinates.Width.Dp()).Background(colors.PrimaryContainer).Clip(RoundedCornerShape(topLeft: 0.Dp(), topRight: 0.Dp(), bottomLeft: 16.Dp(), bottomRight: 16.Dp())).HeightIn(max: 300.Dp() * visibilityProgress), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_11_00_00_00) == 0b_00_10_00_00_00).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                            {
                                __CompositionLocalProvider(LocalContentColor.Provides(colors.OnPrimaryContainer), content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_11_00_00_00) == 0b_00_10_00_00_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __ListSelection(dropdownContent, __composer: __composer, __changed: 0b_01_00 | ((__dirty & 0b_11_00_00_00) >> 6)))), __composer: __composer, __changed: 0b_00_00);
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

        __dirty = 0b_01_01_01_01_01;
        __composer.EndRestartGroup(1741098241, __isRestarted)?.UpdateScope(() => __DropdownModal(__onDismiss, __content, __sizeContent, __dropdownContent, __coordinates, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}