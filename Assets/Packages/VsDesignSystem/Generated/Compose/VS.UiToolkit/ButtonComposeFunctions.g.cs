#nullable enable
// ReSharper disable CheckNamespace

using System;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;
using SharpExtensions;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __Button(Action onClick, ComposableContent content, IMutableInteractionSource? interactionSource = null, bool enabled = true, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onClick, __content, __interactionSource, __enabled, __modifier) = (onClick, content, interactionSource, enabled, modifier);
        var __isCreated = __composer.StartRestartGroup(1639751062);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_00_00_10 : 0b_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_10_00 : 0b_00_00_00_01_00;
        if ((__changed & 0b_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_00_00_10_00_00 : 0b_00_00_01_00_00;
        if ((__changed & 0b_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_00_10_00_00_00 : 0b_00_01_00_00_00;
        if ((__changed & 0b_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00_00 : 0b_01_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01)
        {
            const float disabledAlpha = 0.38f;
            interactionSource ??= (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            var colors = DsTheme.ColorScheme;
            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
            var isPressed = interactionSource.__CollectIsPressedAsState(__composer: __composer, __changed: 0b_00).Value;
            var contentBackground = __AnimateColorAsState(enabled ? colors.Primary : colors.OnSurface.With(a: disabledAlpha), __composer: __composer, __changed: 0b_01_01_00).Value;
            __Box(alignment: Alignment.Center, modifier: modifier.OrEmpty().Padding(horizontal: 16.Dp(), vertical: 4.Dp()).Scale(__AnimateFloatAsState(isHovered ? 1.1f : 1f, __composer: __composer, __changed: 0b_01_01_00).Value).Border(8.Dp()).Background(contentBackground).__DsClickIndication(enabled: enabled, onClick: onClick, interactionSource: interactionSource, __composer: __composer, __changed: 0b_01_00_00 | (__dirty & 0b_00_00_11) | (__dirty & 0b_11_00_00_00)), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00) == 0b_00_10_00_00_00).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Changed<bool>(isPressed!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                var contentTint = __AnimateColorAsState(enabled ? colors.OnPrimary : colors.OnSurface.With(a: disabledAlpha), __composer: __composer, __changed: 0b_01_01_00).Value;
                __CompositionLocalProvider(LocalContentColor.Provides(contentTint), (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).Changed<bool>(isPressed!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Box(modifier: Modifier.Scale(__AnimateFloatAsState(isPressed ? 0.75f : 1f, __composer: __composer, __changed: 0b_01_01_00).Value), content: content, __composer: __composer, __changed: 0b_01_00_00 | ((__dirty & 0b_11_00) >> 2));
                })), __composer: __composer, __changed: 0b_00_00);
            })), __composer: __composer, __changed: 0b_00_00_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01;
        __composer.EndRestartGroup(1639751062, __isRestarted)?.UpdateScope(() => __Button(__onClick, __content, __interactionSource, __enabled, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}