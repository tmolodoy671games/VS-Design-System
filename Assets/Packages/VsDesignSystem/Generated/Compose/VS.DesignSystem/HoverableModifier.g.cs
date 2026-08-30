#nullable enable
// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine.UIElements;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class ModifierExtensions
{
    public static IModifier __Hoverable(this IModifier modifier, IMutableInteractionSource interactionSource, bool enabled = true, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__modifier, __interactionSource, __enabled) = (modifier, interactionSource, enabled);
        __composer.StartReplaceGroup(730792114);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_11) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_00_00_10 : 0b_00_00_01;
        if ((__changed & 0b_00_11_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_00_10_00 : 0b_00_01_00;
        if ((__changed & 0b_11_00_00) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_10_00_00 : 0b_01_00_00;
        if (!enabled)
        {
            __composer.EndReplaceGroup(730792114);
            return modifier;
        }

        var enterInteraction = (!__composer.Changed() ? __composer.RememberedValue<global::StableCollections.IMutableStableProperty<global::SharpExtensions.Optional<global::UnityCompose.IHoverInteraction.Enter>>>() : __composer.UpdateRememberedValue<global::StableCollections.IMutableStableProperty<global::SharpExtensions.Optional<global::UnityCompose.IHoverInteraction.Enter>>>(MutableStablePropertyOf(Optional.Empty<IHoverInteraction.Enter>())));
        __composer.EndReplaceGroup(730792114);
        return modifier.OnMouseEnter((!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).Changed<global::StableCollections.IMutableStableProperty<global::SharpExtensions.Optional<global::UnityCompose.IHoverInteraction.Enter>>>(enterInteraction!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
        {
            var newEnterInteractionValue = new IHoverInteraction.Enter();
            enterInteraction.Value = newEnterInteractionValue;
            interactionSource.Emit(newEnterInteractionValue);
        }))).OnMouseLeave((!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_11_00) == 0b_00_10_00).Changed<global::StableCollections.IMutableStableProperty<global::SharpExtensions.Optional<global::UnityCompose.IHoverInteraction.Enter>>>(enterInteraction!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
        {
            if (enterInteraction.Value.HasValue)
            {
                interactionSource.Emit(enterInteraction.Value.Value);
                enterInteraction.Value = default;
            }
        })));
    }
}