// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static void Slider(
        float value,
        Action<float> onValueChange,
        IModifier? modifier = null,
        bool enabled = true,
        Optional<(float Min, float Max)> valueRange = default,
        int steps = 0,
        IMutableInteractionSource? interactionSource = null
    )
    {
        const float trackHeight = 10;
        const float trackWidth = 160;
        const float thumbMargin = 4;
        const float thumbWidth = 8;
        const float thumbHeight = trackHeight * 4;
        const float availableTrackWidth = trackWidth - thumbWidth - 2 * thumbMargin;

        var theme = Theme;
        var colors = theme.ColorScheme;
        var bounce = theme.AnimationSpecs.Bounce;
        interactionSource ??= Remember(MutableInteractionSource);
        var hovered = interactionSource.CollectIsHoveredAsState().Value;
        var resolvedValueRange = valueRange.GetOrDefault((0, 1f));
        var progress = (
            (value - resolvedValueRange.Min) /
            (resolvedValueRange.Max - resolvedValueRange.Min)
        ).Clamp(0f, 1f);
        var step = (steps > 0 ? 1 / steps.ToFloat() : 0.1f) / (resolvedValueRange.Max - resolvedValueRange.Min);
        Row(
            verticalAlignment: Alignment.CenterVertically,
            modifier: modifier.OrEmpty()
                .Name("slider")
                .Margin(all: 4.Dp()),
            content: () =>
            {
                SliderButton(
                    onClick: () => onValueChange((value - step).Clamp(resolvedValueRange.Min, resolvedValueRange.Max)),
                    enabled: enabled,
                    content: () => Text(
                        "<",
                        modifier: Modifier
                            .Padding(all: 0.Dp())
                            .Margin(all: 0.Dp())
                    ),
                    modifier: Modifier
                        .TransformOrigin(
                            originX: 100.Percent(),
                            originY: 50.Percent()
                        )
                );
                Row(
                    verticalAlignment: Alignment.CenterVertically,
                    modifier: Modifier
                        .Hoverable(interactionSource, enabled: enabled),
                    content: () =>
                    {
                        Row(
                            verticalAlignment: Alignment.CenterVertically,
                            modifier: Modifier
                                .Name("left-track")
                                .Background(
                                    enabled ? colors.PrimaryContainer : colors.PrimaryContainer.Disabled()
                                )
                                .Clip(
                                    RoundedCornerShape(
                                        topLeft: 4.Dp(),
                                        bottomLeft: 4.Dp(),
                                        topRight: 2.Dp(),
                                        bottomRight: 2.Dp()
                                    )
                                )
                                .Size(
                                    height: trackHeight.Dp(),
                                    width: AnimateFloatAsState(
                                        availableTrackWidth * progress
                                    ).Value.Dp()
                                ),
                            content: () => LeftSliderDots(
                                enabled: enabled,
                                steps: steps,
                                trackWidth: trackWidth
                            )
                        );
                        Box(
                            modifier: Modifier
                                .Margin(horizontal: thumbMargin.Dp()),
                            content: () =>
                            {
                                Spacer(
                                    Modifier
                                        .Size(
                                            height: thumbHeight.Dp(),
                                            width: thumbWidth.Dp()
                                        )
                                        .Scale(AnimateFloatAsState(hovered ? 1.1f : 1f, bounce).Value)
                                        .Background(
                                            enabled ? colors.Primary : colors.Primary.DisabledContent()
                                        )
                                        .Clip(RoundedCornerShape((thumbWidth / 2).Dp()))
                                        .Scale(AnimateFloatAsState(hovered ? 1.1f : 1f, bounce).Value)
                                );
                            }
                        );

                        Row(
                            verticalAlignment: Alignment.CenterVertically,
                            modifier: Modifier
                                .Name("right-track")
                                .Background(
                                    enabled ? colors.PrimaryContainer : colors.PrimaryContainer.Disabled()
                                )
                                .Clip(
                                    RoundedCornerShape(
                                        topLeft: 2.Dp(),
                                        bottomLeft: 2.Dp(),
                                        topRight: 4.Dp(),
                                        bottomRight: 4.Dp()
                                    )
                                )
                                .Size(
                                    height: trackHeight.Dp(),
                                    width: AnimateFloatAsState(
                                        availableTrackWidth * (1 - progress)
                                    ).Value.Dp()
                                ),
                            content: () => RightSliderDots(
                                enabled: enabled,
                                steps: steps,
                                trackWidth: trackWidth
                            )
                        );
                    }
                );

                SliderButton(
                    onClick: () => onValueChange((value + step).Clamp(resolvedValueRange.Min, resolvedValueRange.Max)),
                    enabled: enabled,
                    content: () => Text(
                        text: ">",
                        modifier: Modifier
                            .Padding(all: 0.Dp())
                            .Margin(all: 0.Dp())
                            .TransformOrigin(originX: 0.Percent())
                    ),
                    modifier: Modifier
                        .TransformOrigin(
                            originX: 0.Percent(),
                            originY: 50.Percent()
                        )
                );
            }
        );
    }

    [Composable]
    private static void LeftSliderDots(
        bool enabled,
        int steps,
        float trackWidth
    )
    {
        for (var i = 0; i < steps; i++)
        {
            var step = trackWidth / steps;
            SliderDot(
                enabled: enabled,
                Modifier
                    .Float()
                    .Position(left: step * i.Dp())
            );
        }
    }
    

    [Composable]
    private static void RightSliderDots(
        bool enabled,
        int steps,
        float trackWidth
    )
    {
        for (var i = 0; i < steps; i++)
        {
            var step = trackWidth / steps;
            SliderDot(
                enabled: enabled,
                Modifier
                    .Float()
                    .Position(right: step * i.Dp())
            );
        }
    }

    [Composable]
    private static void SliderDot(
        bool enabled,
        IModifier? modifier = null
    )
    {
        const float dotSize = 4;
        Spacer(
            modifier.OrEmpty()
                .Name("dot")
                .Size(dotSize.Dp())
                .Background(enabled ? Theme.ColorScheme.Primary : Theme.ColorScheme.Primary.DisabledContent())
                .Clip(RoundedCornerShape(dotSize.Dp() / 2))
        );
    }

    [Composable]
    private static void SliderButton(
        Action onClick,
        ComposableContent content,
        bool enabled,
        IModifier? modifier = null
    )
    {
        var interactionSource = Remember(MutableInteractionSource);
        SecondaryButton(
            onClick: onClick,
            interactionSource: interactionSource,
            enabled: enabled,
            contentPadding: PaddingValues(horizontal: 4.Dp(), vertical: 2.Dp()),
            shapes: new ButtonShapes(
                Shape: RoundedCornerShape(8.Dp()),
                HoveredShape: RoundedCornerShape(8.Dp())
            ),
            modifier: modifier.OrEmpty(),
            content: content
        );
    }
}