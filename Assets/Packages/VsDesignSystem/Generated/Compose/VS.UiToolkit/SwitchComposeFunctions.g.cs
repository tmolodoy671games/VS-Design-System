#nullable enable
// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __Switch(bool isChecked, Action<bool>? onCheckedChange, IModifier? modifier = null, ComposableContent? thumbContent = null, bool enabled = true, Optional<SwitchColors> colors = default, IMutableInteractionSource? interactionSource = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__isChecked, __onCheckedChange, __modifier, __thumbContent, __enabled, __colors, __interactionSource) = (isChecked, onCheckedChange, modifier, thumbContent, enabled, colors, interactionSource);
        var __isCreated = __composer.StartRestartGroup(19907779);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(isChecked) ? 0b_00_00_00_00_00_00_10 : 0b_00_00_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(onCheckedChange) ? 0b_00_00_00_00_00_10_00 : 0b_00_00_00_00_00_01_00;
        if ((__changed & 0b_00_00_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_00_00_00_00_10_00_00 : 0b_00_00_00_00_01_00_00;
        if ((__changed & 0b_00_00_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(thumbContent) ? 0b_00_00_00_10_00_00_00 : 0b_00_00_00_01_00_00_00;
        if ((__changed & 0b_00_00_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_00_00_10_00_00_00_00 : 0b_00_00_01_00_00_00_00;
        if ((__changed & 0b_00_11_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(colors) ? 0b_00_10_00_00_00_00_00 : 0b_00_01_00_00_00_00_00;
        if ((__changed & 0b_11_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_10_00_00_00_00_00_00 : 0b_01_00_00_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01_01_01)
        {
            const float trackWidth = 80;
            const float trackHeight = 32;
            const float thumbWidth = 60;
            var resolvedColors = colors.GetOrDefault(SwitchDefaults.Colors);
            interactionSource ??= (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            __DisposableEffect(interactionSource, (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11) == 0b_00_00_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_10_00).Changed<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(interactionSource!).Get() ? __composer.RememberedValue<global::System.Func<global::UnityCompose.IDisposableEffectScope, global::UnityCompose.IDisposableEffectResult>>() : __composer.UpdateRememberedValue<global::System.Func<global::UnityCompose.IDisposableEffectScope, global::UnityCompose.IDisposableEffectResult>>(scope =>
            {
                var disposable = interactionSource.Interactions.Collect(it =>
                {
                    if (it is IPressInteraction.Release)
                        onCheckedChange?.Invoke(!isChecked);
                });
                return scope.OnDispose(disposable.Dispose);
            })), __composer: __composer, __changed: 0b_00_00);
            thumbContent ??= (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11) == 0b_00_00_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_11_00_00_00_00) == 0b_00_00_10_00_00_00_00).Changed<global::VS.UiToolkit.SwitchColors>(resolvedColors!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __Spacer(Modifier.Size(width: thumbWidth.Dp(), height: trackHeight.Dp()).Background(resolvedColors.GetThumbColor(enabled, isChecked), Theme.Shapes.Medium).Margin(left: __AnimateFloatAsState((trackWidth - thumbWidth + 1) * isChecked.ToInt(), __composer: __composer, __changed: 0b_01_00).Value.Dp()), __composer: __composer, __changed: 0b_00);
            }));
            __Box(modifier: modifier.OrEmpty().Background(resolvedColors.GetTrackColor(enabled, isChecked)).Size(width: trackWidth.Dp(), height: trackHeight.Dp()).Clip(Theme.Shapes.Medium).__DsClickIndication(onClick: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11) == 0b_00_00_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_10_00).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => onCheckedChange?.Invoke(!isChecked))), interactionSource: interactionSource, enabled: enabled, __composer: __composer, __changed: 0b_01_00_00 | ((__dirty & 0b_11_00_00_00_00) >> 2)), content: (!__composer.Changed<global::UnityCompose.ComposableContent>(thumbContent!) ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __composer.StartReplaceGroup(1979691617);
                thumbContent();
                __composer.EndReplaceGroup(1979691617);
            })), __composer: __composer, __changed: 0b_01_00_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01_01_01;
        __composer.EndRestartGroup(19907779, __isRestarted)?.UpdateScope(() => __Switch(__isChecked, __onCheckedChange, __modifier, __thumbContent, __enabled, __colors, __interactionSource, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}