#nullable enable
// ReSharper disable CheckNamespace

using System;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using SharpExtensions;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __MenuList(ComposableContent content, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__content, __modifier) = (content, modifier);
        var __isCreated = __composer.StartRestartGroup(1048540674);
        var __dirty = __changed;
        if ((__changed & 0b_00_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_10 : 0b_00_01;
        if ((__changed & 0b_11_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00 : 0b_01_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01)
        {
            __ScrollableColumn(modifier: modifier, content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_11) == 0b_00_10).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __ListSelection(content, __composer: __composer, __changed: 0b_01_00 | (__dirty & 0b_11));
            })), __composer: __composer, __changed: 0b_01_01_00 | ((__dirty & 0b_11_00) << 4));
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01;
        __composer.EndRestartGroup(1048540674, __isRestarted)?.UpdateScope(() => __MenuList(__content, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    public static void __MenuItem(Action onClick, ComposableContent content, bool clickable = true, bool enabled = true, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onClick, __content, __clickable, __enabled, __modifier) = (onClick, content, clickable, enabled, modifier);
        var __isCreated = __composer.StartRestartGroup(815233789);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_00_00_10 : 0b_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_10_00 : 0b_00_00_00_01_00;
        if ((__changed & 0b_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(clickable) ? 0b_00_00_10_00_00 : 0b_00_00_01_00_00;
        if ((__changed & 0b_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_00_10_00_00_00 : 0b_00_01_00_00_00;
        if ((__changed & 0b_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00_00 : 0b_01_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01)
        {
            __ListSelectionItem((!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00) == 0b_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00) == 0b_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_11_00_00_00_00) == 0b_10_00_00_00_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(item =>
            {
                var theme = Theme;
                var colors = theme.ColorScheme;
                var hoverable = enabled && !clickable;
                var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
                var hovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
                __SideEffect(hovered, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.IListSelectionItem>(item!).Changed<bool>(hovered!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                {
                    if (hovered)
                        item.Select();
                })), __composer: __composer, __changed: 0b_00_00);
                __Row(modifier: modifier.OrEmpty().FillMaxWidth().__ClickIndication(enabled: clickable && enabled, onClick: onClick, interactionSource: interactionSource, __composer: __composer, __changed: 0b_01_00_00 | (__dirty & 0b_00_00_11)).__HoverIndication(enabled: hoverable, interactionSource: interactionSource, __composer: __composer, __changed: 0b_00_00).Margin(vertical: 4.Dp()).Padding(vertical: 8.Dp() + 8 * item.SelectionProgress.Dp(), horizontal: 16.Dp()).Clip(__AnimateRoundedCornerShapeAsState(hovered ? RoundedCornerShape(16.Dp()) : RoundedCornerShape(32.Dp()), __composer: __composer, __changed: 0b_01_00).Value), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).Changed<global::VS.UiToolkit.ThemeConfig>(theme!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __CompositionLocalProvider(LocalTextStyle.Provides(theme.Typography.Control), content: content, __composer: __composer, __changed: (__dirty & 0b_11_00));
                })), __composer: __composer, __changed: 0b_01_01_00_00);
            })), __composer: __composer, __changed: 0b_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01;
        __composer.EndRestartGroup(815233789, __isRestarted)?.UpdateScope(() => __MenuItem(__onClick, __content, __clickable, __enabled, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}