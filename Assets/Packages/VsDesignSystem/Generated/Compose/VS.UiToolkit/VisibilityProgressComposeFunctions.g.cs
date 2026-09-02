#nullable enable
// ReSharper disable CheckNamespace

using SharpExtensions;
using UnityCompose;
using UnityEngine;
using System;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static IState<float> __VisibilityProgress(bool visible, Optional<AnimationSpec> animationSpec = default, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var __dirty = __changed;
        if ((__changed & 0b_00_11) == 0)
            __dirty |= __composer.Changed(visible) ? 0b_00_10 : 0b_00_01;
        if ((__changed & 0b_11_00) == 0)
            __dirty |= __composer.Changed(animationSpec) ? 0b_10_00 : 0b_01_00;
        var animation = __RememberSingleAnimationPlayer(animationSpec, __composer: __composer, __changed: ((__dirty & 0b_11_00) >> 2));
        var result = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<float>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<float>>(MutableStateOf(0f)));
        __SideEffect(visible, (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_11) == 0b_00_10).Changed<global::VS.UiToolkit.ISingleAnimationPlayer>(animation!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => animation.Play(force: true, backward: !visible))), __composer: __composer, __changed: (__dirty & 0b_00_11));
        __DisposableEffect(animation, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.ISingleAnimationPlayer>(animation!).Changed<global::UnityCompose.IMutableState<float>>(result!).Get() ? __composer.RememberedValue<global::System.Func<global::UnityCompose.IDisposableEffectScope, global::UnityCompose.IDisposableEffectResult>>() : __composer.UpdateRememberedValue<global::System.Func<global::UnityCompose.IDisposableEffectScope, global::UnityCompose.IDisposableEffectResult>>(scope =>
        {
            var disposable = animation.Subscribe(it =>
            {
                result.Value = it;
            });
            return scope.OnDispose(disposable.Dispose);
        })), __composer: __composer, __changed: 0b_00_00);
        return result;
    }
}