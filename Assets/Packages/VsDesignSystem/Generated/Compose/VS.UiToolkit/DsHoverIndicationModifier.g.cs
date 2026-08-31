#nullable enable
// ReSharper disable CheckNamespace

using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;
using System;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class ModifierExtensions
{
    public static IModifier __DsHoverIndication(this IModifier modifier, IMutableInteractionSource? interactionSource = null, bool enabled = true, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__modifier, __interactionSource, __enabled) = (modifier, interactionSource, enabled);
        __composer.StartReplaceGroup(1342145680);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_11) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_00_00_10 : 0b_00_00_01;
        if ((__changed & 0b_00_11_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_00_10_00 : 0b_00_01_00;
        if ((__changed & 0b_11_00_00) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_10_00_00 : 0b_01_00_00;
        if (!enabled)
        {
            __composer.EndReplaceGroup(1342145680);
            return modifier;
        }

        interactionSource ??= (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
        __composer.EndReplaceGroup(1342145680);
        return modifier.Clip().Hoverable(interactionSource, enabled).DrawAfter((!__composer.Changed<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(interactionSource!) ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
        {
            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
            var visibilityProgress = __AnimateFloatAsState(isHovered.ToInt(), __composer: __composer, __changed: 0b_01_01_00).Value;
            __Spacer(modifier: Modifier.Size(100.Percent()).Clip(RoundedCornerShape(10.Dp())).Background(Color.cornflowerBlue.With(a: visibilityProgress * 0.5f)).Scale(0.76f + 0.25f * visibilityProgress).Float().Offset(x: -50.Percent(), y: -50.Percent()).Position(top: 50.Percent(), left: 50.Percent()), __composer: __composer, __changed: 0b_00);
        })));
    }
}