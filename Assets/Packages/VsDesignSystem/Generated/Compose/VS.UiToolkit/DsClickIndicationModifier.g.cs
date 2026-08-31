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
public static partial class ModifierExtensions
{
    public static IModifier __DsClickIndication(this IModifier modifier, Action onClick, IMutableInteractionSource? interactionSource = null, Optional<AnimationSpec> animationSpec = default, bool enabled = true, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__modifier, __onClick, __interactionSource, __animationSpec, __enabled) = (modifier, onClick, interactionSource, animationSpec, enabled);
        __composer.StartReplaceGroup(2090165684);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_00_00_00_00_10 : 0b_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_00_10_00 : 0b_00_00_00_01_00;
        if ((__changed & 0b_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_00_00_10_00_00 : 0b_00_00_01_00_00;
        if ((__changed & 0b_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(animationSpec) ? 0b_00_10_00_00_00 : 0b_00_01_00_00_00;
        if ((__changed & 0b_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_10_00_00_00_00 : 0b_01_00_00_00_00;
        if (!enabled)
        {
            __composer.EndReplaceGroup(2090165684);
            return modifier;
        }

        interactionSource ??= (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
        var containerSize = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<global::UnityEngine.Vector2>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<global::UnityEngine.Vector2>>(MutableStateOf(Vector2.zero)));
        __composer.EndReplaceGroup(2090165684);
        return modifier.Clip().Hoverable(interactionSource, enabled: enabled).Clickable(interactionSource, enabled: enabled).OnClick(onClick, enabled: enabled).OnGloballyPositioned((!__composer.Changed<global::UnityCompose.IMutableState<global::UnityEngine.Vector2>>(containerSize!) ? __composer.RememberedValue<global::System.Action<global::UnityCompose.LayoutCoordinates>>() : __composer.UpdateRememberedValue<global::System.Action<global::UnityCompose.LayoutCoordinates>>(it => containerSize.Value = it.Size))).DrawAfter((!__composer.BuildChanged().Changed<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(interactionSource!).ChangedAsFlag((__dirty & 0b_00_11_00_00_00) == 0b_00_10_00_00_00).Changed<global::UnityCompose.IMutableState<global::UnityEngine.Vector2>>(containerSize!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
        {
            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
            var isPressed = interactionSource.__CollectIsPressedAsState(__composer: __composer, __changed: 0b_00).Value;
            var hoveredVisibilityProgress = __AnimateFloatAsState(isHovered.ToInt(), animationSpec, __composer: __composer, __changed: ((__dirty & 0b_11_00_00_00) >> 4)).Value;
            var hoveredAlphaProgress = __AnimateFloatAsState((isHovered && !isPressed).ToInt(), animationSpec, __composer: __composer, __changed: ((__dirty & 0b_11_00_00_00) >> 4)).Value;
            __Spacer(modifier: Modifier.Size(100.Percent()).Clip(RoundedCornerShape(4.Dp())).Background(Color.white.With(a: hoveredAlphaProgress * 0.25f)).Scale(0.76f + 0.25f * hoveredVisibilityProgress).Float().Offset(x: -50.Percent(), y: -50.Percent()).Position(top: 50.Percent(), left: 50.Percent()), __composer: __composer, __changed: 0b_00);
            var pressPosition = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<global::UnityEngine.Vector2>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<global::UnityEngine.Vector2>>(MutableStateOf(Vector2.zero)));
            __DisposableEffect(interactionSource, (!__composer.BuildChanged().Changed<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(interactionSource!).Changed<global::UnityCompose.IMutableState<global::UnityEngine.Vector2>>(pressPosition!).Get() ? __composer.RememberedValue<global::System.Func<global::UnityCompose.IDisposableEffectScope, global::UnityCompose.IDisposableEffectResult>>() : __composer.UpdateRememberedValue<global::System.Func<global::UnityCompose.IDisposableEffectScope, global::UnityCompose.IDisposableEffectResult>>(scope =>
            {
                var disposable = interactionSource.Interactions.Collect(it =>
                {
                    if (it is IPressInteraction.Press press)
                        pressPosition.Value = press.PressPosition;
                });
                return scope.OnDispose(disposable.Dispose);
            })), __composer: __composer, __changed: 0b_00_00);
            var pressAnimation = __RememberSingleAnimationPlayer(animationSpec, __composer: __composer, __changed: ((__dirty & 0b_11_00_00_00) >> 6));
            var releaseAnimation = __RememberSingleAnimationPlayer(animationSpec, __composer: __composer, __changed: ((__dirty & 0b_11_00_00_00) >> 6));
            __SideEffect(isPressed, (!__composer.BuildChanged().Changed<bool>(isPressed!).Changed<global::VS.UiToolkit.ISingleAnimationPlayer>(pressAnimation!).Changed<global::VS.UiToolkit.ISingleAnimationPlayer>(releaseAnimation!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
            {
                if (isPressed)
                {
                    releaseAnimation.Reset();
                    pressAnimation.Play();
                }
                else
                {
                    releaseAnimation.Play();
                }
            })), __composer: __composer, __changed: 0b_00_00);
            var maxPressIndicatorSize = (!__composer.Changed<(global::UnityEngine.Vector2, global::UnityEngine.Vector2)>((containerSize.Value, pressPosition.Value)!) ? __composer.RememberedValue<float>() : __composer.UpdateRememberedValue<float>(() =>
            {
                var containerSizeValue = containerSize.Value;
                var pressPositionValue = pressPosition.Value;
                var maxDistance = Mathf.Max(pressPositionValue.sqrMagnitude, (pressPositionValue - containerSizeValue).sqrMagnitude, (pressPositionValue - new Vector2(containerSizeValue.x, 0)).sqrMagnitude, (pressPositionValue - new Vector2(0, containerSizeValue.y)).sqrMagnitude);
                return Mathf.Sqrt(maxDistance) * 2;
            }));
            var pressedIndicationSize = maxPressIndicatorSize.Dp() * pressAnimation.Progress;
            var pressedVisibilityProgress = pressAnimation.Progress * (1 - releaseAnimation.Progress);
            __Spacer(modifier: Modifier.Size(pressedIndicationSize).Clip(RoundedCornerShape(pressedIndicationSize / 2)).Background(Color.black.With(a: pressedVisibilityProgress * 0.5f)).Offset(x: -pressedIndicationSize / 2, y: -pressedIndicationSize / 2).Float().Position(left: pressPosition.Value.x.Dp(), top: pressPosition.Value.y.Dp()), __composer: __composer, __changed: 0b_00);
        })));
    }
}