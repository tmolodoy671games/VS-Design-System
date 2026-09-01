#nullable enable
using UnityCompose;
using UnityEngine;
using System;
using SharpExtensions;
using static UnityCompose.ComposeFunctions;

// ReSharper disable ArrangeNamespaceBody
namespace Samples.Samples.Behaviors
{
    internal partial class SwitchShowcase
    {
        protected override void __Content(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1848387198);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __WithDsTheme((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Box(alignment: Alignment.Center, modifier: Modifier.FillMaxSize(), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __Column(modifier: Modifier.Background(Theme.ColorScheme.Surface).Padding(all: 16.Dp()).Clip(RoundedCornerShape(16.Dp())), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                        {
                            var isChecked = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<bool>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<bool>>(MutableStateOf(true)));
                            __Switch(isChecked: isChecked.Value, onCheckedChange: (!__composer.Changed<global::UnityCompose.IMutableState<bool>>(isChecked!) ? __composer.RememberedValue<global::System.Action<bool>>() : __composer.UpdateRememberedValue<global::System.Action<bool>>(it => isChecked.Value = it)), __composer: __composer, __changed: 0b_01_01_01_01_01_00_00);
                            __Spacer(Modifier.Height(12.Dp()), __composer: __composer, __changed: 0b_00);
                            __Switch(isChecked: false, onCheckedChange: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action<bool>>() : __composer.UpdateRememberedValue<global::System.Action<bool>>(_ =>
                            {
                            })), __composer: __composer, __changed: 0b_01_01_01_01_01_00_01);
                            __Spacer(Modifier.Height(12.Dp()), __composer: __composer, __changed: 0b_00);
                            __Switch(isChecked: true, onCheckedChange: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action<bool>>() : __composer.UpdateRememberedValue<global::System.Action<bool>>(_ =>
                            {
                            })), enabled: false, __composer: __composer, __changed: 0b_01_01_01_01_01_00_01);
                            __Spacer(Modifier.Height(12.Dp()), __composer: __composer, __changed: 0b_00);
                            __Switch(isChecked: false, onCheckedChange: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action<bool>>() : __composer.UpdateRememberedValue<global::System.Action<bool>>(_ =>
                            {
                            })), enabled: false, __composer: __composer, __changed: 0b_01_01_01_01_01_00_01);
                        })), __composer: __composer, __changed: 0b_01_01_00_00);
                    })), __composer: __composer, __changed: 0b_00_00_00);
                })), __composer: __composer, __changed: 0b_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(1848387198, __isRestarted)?.UpdateScope(() => __Content(__composer, 0));
        }

        protected override void __Preview(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1340599508);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __Content(__composer: __composer, __changed: 0b_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(1340599508, __isRestarted)?.UpdateScope(() => __Preview(__composer, 0));
        }
    }
}