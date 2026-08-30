#nullable enable
// ReSharper disable ArrangeNamespaceBody

using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using VS.UiToolkit;
using System;
using SharpExtensions;
using static UnityCompose.ComposeFunctions;

namespace Samples.Samples.Behaviors
{
    internal partial class IndicationSample
    {
        protected override void __Content(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1542746043);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __Box(alignment: Alignment.Center, modifier: Modifier.FillMaxSize(), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
                    var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
                    var isPressed = interactionSource.__CollectIsPressedAsState(__composer: __composer, __changed: 0b_00).Value;
                    __Box(alignment: Alignment.Center, modifier: Modifier.Padding(horizontal: 32.Dp(), vertical: 8.Dp()).Scale(__AnimateFloatAsState(isHovered ? 1.1f : 1f, __composer: __composer, __changed: 0b_01_01_00).Value).Border(32.Dp()).Background(Color.forestGreen).__DsClickIndication(onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), interactionSource: interactionSource, __composer: __composer, __changed: 0b_01_01_00_00), content: (!__composer.Changed<bool>(isPressed!) ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __Text(text: "Click me!", fontSize: 64.Sp(), modifier: Modifier.Scale(__AnimateFloatAsState(isPressed ? 0.75f : 1f, __composer: __composer, __changed: 0b_01_01_00).Value), __composer: __composer, __changed: 0b_01_01_01_01_01_00_01_01);
                    })), __composer: __composer, __changed: 0b_00_00_00);
                })), __composer: __composer, __changed: 0b_00_00_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(1542746043, __isRestarted)?.UpdateScope(() => __Content(__composer, 0));
        }

        protected override void __Preview(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(866192145);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __Content(__composer: __composer, __changed: 0b_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(866192145, __isRestarted)?.UpdateScope(() => __Preview(__composer, 0));
        }
    }
}