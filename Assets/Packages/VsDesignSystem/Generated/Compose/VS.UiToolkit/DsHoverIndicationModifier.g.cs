#nullable enable
// ReSharper disable CheckNamespace

using UnityCompose;
using UnityEngine;
using System;
using SharpExtensions;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
internal partial class DsHoverIndicationModifierImpl
{
    public override void __DrawAfter(global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var __isCreated = __composer.StartRestartGroup(554494378);
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __changed != 0b_00)
        {
            __Spacer(modifier: Modifier.Size(20.Dp()).Border(10.Dp()).Background(Color.cornflowerBlue).Alpha(0.5f).Float().Offset(x: -50.Percent(), y: -50.Percent()).Position(top: 50.Percent(), left: 50.Percent()), __composer: __composer, __changed: 0b_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __composer.EndRestartGroup(554494378, __isRestarted)?.UpdateScope(() => __DrawAfter(__composer, 0));
    }
}