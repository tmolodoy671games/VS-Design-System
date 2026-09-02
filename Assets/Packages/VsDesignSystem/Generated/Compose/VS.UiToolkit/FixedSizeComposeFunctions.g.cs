#nullable enable
// ReSharper disable CheckNamespace

using UnityCompose;
using System;
using SharpExtensions;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __FixedSize(ComposableContent content, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__content, __modifier) = (content, modifier);
        var __isCreated = __composer.StartRestartGroup(1142608926);
        var __dirty = __changed;
        if ((__changed & 0b_00_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_10 : 0b_00_01;
        if ((__changed & 0b_11_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00 : 0b_01_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01)
        {
            __Box(alignment: Alignment.Center, modifier: modifier, content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_11) == 0b_00_10).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __WithIsActive(false, (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_11) == 0b_00_10).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Box(modifier: Modifier.Alpha(0), content: content, __composer: __composer, __changed: 0b_01_00_00 | (__dirty & 0b_00_11));
                })), __composer: __composer, __changed: 0b_00_01);
                __Spacer(Modifier.FillMaxSize().Float().OnClick((!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                {
                }))), __composer: __composer, __changed: 0b_00);
                __Box(modifier: Modifier.FillMaxSize().Float(), content: content, __composer: __composer, __changed: 0b_01_00_00 | (__dirty & 0b_00_11));
            })), __composer: __composer, __changed: (__dirty & 0b_00_11_00));
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01;
        __composer.EndRestartGroup(1142608926, __isRestarted)?.UpdateScope(() => __FixedSize(__content, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}