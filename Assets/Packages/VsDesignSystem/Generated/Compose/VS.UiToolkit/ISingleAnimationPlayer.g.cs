#nullable enable
using System;
using System.Collections;
using SharpExtensions;
using StableCollections;
using UnityCompose;
using UnityEngine;
using static UnityCompose.ComposeFunctions;

// ReSharper disable CheckNamespace
namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static ISingleAnimationPlayer __RememberSingleAnimationPlayer(Optional<AnimationSpec> animationSpec = default, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var __dirty = __changed;
        if ((__changed & 0b_11) == 0)
            __dirty |= __composer.Changed(animationSpec) ? 0b_10 : 0b_01;
        var coroutineScope = __RememberCoroutineScope(__composer: __composer, __changed: 0b_00);
        var result = (!__composer.Changed<global::UnityCompose.IComposeCoroutineScope>(coroutineScope!) ? __composer.RememberedValue<global::VS.UiToolkit.SingleAnimationPlayerImpl>() : __composer.UpdateRememberedValue<global::VS.UiToolkit.SingleAnimationPlayerImpl>(new SingleAnimationPlayerImpl(coroutineScope)));
        __SideEffect(animationSpec, (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_11) == 0b_10).Changed<global::VS.UiToolkit.SingleAnimationPlayerImpl>(result!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => result.SetAnimationSpec(animationSpec.GetOrDefault()))), __composer: __composer, __changed: (__dirty & 0b_00_11));
        return result;
    }
}