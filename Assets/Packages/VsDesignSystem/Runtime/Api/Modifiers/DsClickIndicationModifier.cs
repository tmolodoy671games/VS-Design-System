// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;

namespace VS.UiToolkit;

public static partial class ModifierExtensions
{
    [Composable]
    public static IModifier DsClickIndication(
        this IModifier modifier,
        Action onClick,
        IMutableInteractionSource? interactionSource = null,
        Optional<AnimationSpec> animationSpec = default,
        bool enabled = true
    )
    {
        if (!enabled)
            return modifier;
        interactionSource ??= Remember(MutableInteractionSource);
        var containerSize = Remember(() => MutableStateOf(Vector2.zero));
        return modifier
            .Clip()
            .Hoverable(interactionSource, enabled: enabled)
            .Clickable(interactionSource, enabled: enabled)
            .OnClick(onClick, enabled: enabled)
            .OnGloballyPositioned(it => containerSize.Value = it.Size)
            .DrawAfter(() =>
            {
                var isHovered = interactionSource.CollectIsHoveredAsState().Value;
                var isPressed = interactionSource.CollectIsPressedAsState().Value;
                var hoveredVisibilityProgress = AnimateFloatAsState(isHovered.ToInt(), animationSpec).Value;
                var hoveredAlphaProgress = AnimateFloatAsState((isHovered && !isPressed).ToInt(), animationSpec).Value;
                Spacer(
                    modifier: Modifier
                        .Size(100.Percent())
                        .Clip(RoundedCornerShape(4.Dp()))
                        .Background(Color.white.With(a: hoveredAlphaProgress * 0.25f))
                        .Scale(0.76f + 0.25f * hoveredVisibilityProgress)
                        .Float()
                        .Offset(x: -50.Percent(), y: -50.Percent())
                        .Position(
                            top: 50.Percent(),
                            left: 50.Percent()
                        )
                );
                var pressPosition = Remember(() => MutableStateOf(Vector2.zero));
                DisposableEffect(interactionSource, scope =>
                {
                    var disposable = interactionSource.Interactions
                        .Collect(it =>
                        {
                            if (it is IPressInteraction.Press press)
                                pressPosition.Value = press.PressPosition;
                        });
                    return scope.OnDispose(disposable.Dispose);
                });
                var pressAnimation = RememberSingleAnimationPlayer(animationSpec);
                var releaseAnimation = RememberSingleAnimationPlayer(animationSpec);
                SideEffect(isPressed, () =>
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
                });
                var maxPressIndicatorSize = Remember((containerSize.Value, pressPosition.Value), () =>
                {
                    var containerSizeValue = containerSize.Value;
                    var pressPositionValue = pressPosition.Value;
                    var maxDistance = Mathf.Max(
                        pressPositionValue.sqrMagnitude,
                        (pressPositionValue - containerSizeValue).sqrMagnitude,
                        (pressPositionValue - new Vector2(containerSizeValue.x, 0)).sqrMagnitude,
                        (pressPositionValue - new Vector2(0, containerSizeValue.y)).sqrMagnitude
                    );
                    return Mathf.Sqrt(maxDistance) * 2;
                });
                var pressedIndicationSize = maxPressIndicatorSize.Dp() * pressAnimation.Progress;
                var pressedVisibilityProgress = pressAnimation.Progress * (1 - releaseAnimation.Progress);
                Spacer(
                    modifier: Modifier
                        .Size(pressedIndicationSize)
                        .Clip(RoundedCornerShape(pressedIndicationSize / 2))
                        .Background(Color.black.With(a: pressedVisibilityProgress * 0.5f))
                        .Offset(
                            x: -pressedIndicationSize / 2,
                            y: -pressedIndicationSize / 2
                        )
                        .Float()
                        .Position(
                            left: pressPosition.Value.x.Dp(),
                            top: pressPosition.Value.y.Dp()
                        )
                );
            });
    }
}