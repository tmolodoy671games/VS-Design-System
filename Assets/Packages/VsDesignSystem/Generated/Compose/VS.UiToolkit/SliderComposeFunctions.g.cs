#nullable enable
// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __Slider(float value, Action<float> onValueChange, IModifier? modifier = null, bool enabled = true, Optional<(float Min, float Max)> valueRange = default, int steps = 0, IMutableInteractionSource? interactionSource = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__value, __onValueChange, __modifier, __enabled, __valueRange, __steps, __interactionSource) = (value, onValueChange, modifier, enabled, valueRange, steps, interactionSource);
        var __isCreated = __composer.StartRestartGroup(69681045);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(value) ? 0b_00_00_00_00_00_00_10 : 0b_00_00_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(onValueChange) ? 0b_00_00_00_00_00_10_00 : 0b_00_00_00_00_00_01_00;
        if ((__changed & 0b_00_00_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_00_00_00_00_10_00_00 : 0b_00_00_00_00_01_00_00;
        if ((__changed & 0b_00_00_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_00_00_00_10_00_00_00 : 0b_00_00_00_01_00_00_00;
        if ((__changed & 0b_00_00_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(valueRange) ? 0b_00_00_10_00_00_00_00 : 0b_00_00_01_00_00_00_00;
        if ((__changed & 0b_00_11_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(steps) ? 0b_00_10_00_00_00_00_00 : 0b_00_01_00_00_00_00_00;
        if ((__changed & 0b_11_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_10_00_00_00_00_00_00 : 0b_01_00_00_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01_01_01)
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
            interactionSource ??= (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            var hovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
            var resolvedValueRange = valueRange.GetOrDefault((0, 1f));
            var progress = ((value - resolvedValueRange.Min) / (resolvedValueRange.Max - resolvedValueRange.Min)).Clamp(0f, 1f);
            var step = (steps > 0 ? 1 / steps.ToFloat() : 0.1f) / (resolvedValueRange.Max - resolvedValueRange.Min);
            __Row(verticalAlignment: Alignment.CenterVertically, modifier: modifier.OrEmpty().Name("slider").Margin(all: 4.Dp()), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11) == 0b_00_00_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_00_11_00_00_00) == 0b_00_00_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00_00_00) == 0b_00_10_00_00_00_00_00).Changed<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(interactionSource!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Changed<global::UnityCompose.AnimationSpec>(bounce!).Changed<bool>(hovered!).Changed<(float Min, float Max)>(resolvedValueRange!).Changed<float>(progress!).Changed<float>(step!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __SliderButton(onClick: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11) == 0b_00_00_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_10_00).Changed<(float Min, float Max)>(resolvedValueRange!).Changed<float>(step!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => onValueChange((value - step).Clamp(resolvedValueRange.Min, resolvedValueRange.Max)))), enabled: enabled, content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("<", modifier: Modifier.Padding(all: 0.Dp()).Margin(all: 0.Dp()), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01))), modifier: Modifier.TransformOrigin(originX: 100.Percent(), originY: 50.Percent()), __composer: __composer, __changed: ((__dirty & 0b_11_00_00_00) >> 2));
                __Row(verticalAlignment: Alignment.CenterVertically, modifier: Modifier.Hoverable(interactionSource, enabled: enabled), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_11_00_00_00) == 0b_00_00_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00_00_00) == 0b_00_10_00_00_00_00_00).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Changed<global::UnityCompose.AnimationSpec>(bounce!).Changed<bool>(hovered!).Changed<float>(progress!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Row(verticalAlignment: Alignment.CenterVertically, modifier: Modifier.Name("left-track").Background(enabled ? colors.PrimaryContainer : colors.PrimaryContainer.Disabled()).Clip(RoundedCornerShape(topLeft: 4.Dp(), bottomLeft: 4.Dp(), topRight: 2.Dp(), bottomRight: 2.Dp())).Size(height: trackHeight.Dp(), width: __AnimateFloatAsState(availableTrackWidth * progress, __composer: __composer, __changed: 0b_01_00).Value.Dp()), content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_11_00_00_00) == 0b_00_00_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00_00_00) == 0b_00_10_00_00_00_00_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __LeftSliderDots(enabled: enabled, steps: steps, trackWidth: trackWidth, __composer: __composer, __changed: 0b_01_00_00 | ((__dirty & 0b_11_00_00_00) >> 6) | ((__dirty & 0b_11_00_00_00_00_00) >> 8)))), __composer: __composer, __changed: 0b_01_00_00);
                    __Box(modifier: Modifier.Margin(horizontal: thumbMargin.Dp()), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_11_00_00_00) == 0b_00_00_00_10_00_00_00).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Changed<global::UnityCompose.AnimationSpec>(bounce!).Changed<bool>(hovered!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __Spacer(Modifier.Size(height: thumbHeight.Dp(), width: thumbWidth.Dp()).Scale(__AnimateFloatAsState(hovered ? 1.1f : 1f, bounce, __composer: __composer, __changed: 0b_00_00).Value).Background(enabled ? colors.Primary : colors.Primary.DisabledContent()).Clip(RoundedCornerShape((thumbWidth / 2).Dp())).Scale(__AnimateFloatAsState(hovered ? 1.1f : 1f, bounce, __composer: __composer, __changed: 0b_00_00).Value), __composer: __composer, __changed: 0b_00);
                    })), __composer: __composer, __changed: 0b_01_00_00);
                    __Row(verticalAlignment: Alignment.CenterVertically, modifier: Modifier.Name("right-track").Background(enabled ? colors.PrimaryContainer : colors.PrimaryContainer.Disabled()).Clip(RoundedCornerShape(topLeft: 2.Dp(), bottomLeft: 2.Dp(), topRight: 4.Dp(), bottomRight: 4.Dp())).Size(height: trackHeight.Dp(), width: __AnimateFloatAsState(availableTrackWidth * (1 - progress), __composer: __composer, __changed: 0b_01_00).Value.Dp()), content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_11_00_00_00) == 0b_00_00_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00_00_00) == 0b_00_10_00_00_00_00_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __RightSliderDots(enabled: enabled, steps: steps, trackWidth: trackWidth, __composer: __composer, __changed: 0b_01_00_00 | ((__dirty & 0b_11_00_00_00) >> 6) | ((__dirty & 0b_11_00_00_00_00_00) >> 8)))), __composer: __composer, __changed: 0b_01_00_00);
                })), __composer: __composer, __changed: 0b_01_00_00);
                __SliderButton(onClick: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11) == 0b_00_00_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_10_00).Changed<(float Min, float Max)>(resolvedValueRange!).Changed<float>(step!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => onValueChange((value + step).Clamp(resolvedValueRange.Min, resolvedValueRange.Max)))), enabled: enabled, content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text(text: ">", modifier: Modifier.Padding(all: 0.Dp()).Margin(all: 0.Dp()).TransformOrigin(originX: 0.Percent()), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01))), modifier: Modifier.TransformOrigin(originX: 0.Percent(), originY: 50.Percent()), __composer: __composer, __changed: ((__dirty & 0b_11_00_00_00) >> 2));
            })), __composer: __composer, __changed: 0b_01_00_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01_01_01;
        __composer.EndRestartGroup(69681045, __isRestarted)?.UpdateScope(() => __Slider(__value, __onValueChange, __modifier, __enabled, __valueRange, __steps, __interactionSource, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __LeftSliderDots(bool enabled, int steps, float trackWidth, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__enabled, __steps, __trackWidth) = (enabled, steps, trackWidth);
        var __isCreated = __composer.StartRestartGroup(847291634);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_11) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_00_00_10 : 0b_00_00_01;
        if ((__changed & 0b_00_11_00) == 0)
            __dirty |= __composer.Changed(steps) ? 0b_00_10_00 : 0b_00_01_00;
        if ((__changed & 0b_11_00_00) == 0)
            __dirty |= __composer.Changed(trackWidth) ? 0b_10_00_00 : 0b_01_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01)
        {
            __composer.StartReplaceGroup(602095214);
            for (var i = 0; i < steps; i++)
            {
                var step = trackWidth / steps;
                __SliderDot(enabled: enabled, Modifier.Float().Position(left: step * i.Dp()), __composer: __composer, __changed: (__dirty & 0b_00_11));
            }

            __composer.EndReplaceGroup(602095214);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01;
        __composer.EndRestartGroup(847291634, __isRestarted)?.UpdateScope(() => __LeftSliderDots(__enabled, __steps, __trackWidth, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __RightSliderDots(bool enabled, int steps, float trackWidth, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__enabled, __steps, __trackWidth) = (enabled, steps, trackWidth);
        var __isCreated = __composer.StartRestartGroup(1662916915);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_11) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_00_00_10 : 0b_00_00_01;
        if ((__changed & 0b_00_11_00) == 0)
            __dirty |= __composer.Changed(steps) ? 0b_00_10_00 : 0b_00_01_00;
        if ((__changed & 0b_11_00_00) == 0)
            __dirty |= __composer.Changed(trackWidth) ? 0b_10_00_00 : 0b_01_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01)
        {
            __composer.StartReplaceGroup(1738719060);
            for (var i = 0; i < steps; i++)
            {
                var step = trackWidth / steps;
                __SliderDot(enabled: enabled, Modifier.Float().Position(right: step * i.Dp()), __composer: __composer, __changed: (__dirty & 0b_00_11));
            }

            __composer.EndReplaceGroup(1738719060);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01;
        __composer.EndRestartGroup(1662916915, __isRestarted)?.UpdateScope(() => __RightSliderDots(__enabled, __steps, __trackWidth, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __SliderDot(bool enabled, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__enabled, __modifier) = (enabled, modifier);
        var __isCreated = __composer.StartRestartGroup(26794938);
        var __dirty = __changed;
        if ((__changed & 0b_00_11) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_00_10 : 0b_00_01;
        if ((__changed & 0b_11_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00 : 0b_01_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01)
        {
            const float dotSize = 4;
            __Spacer(modifier.OrEmpty().Name("dot").Size(dotSize.Dp()).Background(enabled ? Theme.ColorScheme.Primary : Theme.ColorScheme.Primary.DisabledContent()).Clip(RoundedCornerShape(dotSize.Dp() / 2)), __composer: __composer, __changed: 0b_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01;
        __composer.EndRestartGroup(26794938, __isRestarted)?.UpdateScope(() => __SliderDot(__enabled, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __SliderButton(Action onClick, ComposableContent content, bool enabled, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onClick, __content, __enabled, __modifier) = (onClick, content, enabled, modifier);
        var __isCreated = __composer.StartRestartGroup(1632521713);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_11) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_00_10 : 0b_00_00_00_01;
        if ((__changed & 0b_00_00_11_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_10_00 : 0b_00_00_01_00;
        if ((__changed & 0b_00_11_00_00) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_00_10_00_00 : 0b_00_01_00_00;
        if ((__changed & 0b_11_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00 : 0b_01_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01)
        {
            var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            __SecondaryButton(onClick: onClick, interactionSource: interactionSource, enabled: enabled, contentPadding: PaddingValues(horizontal: 4.Dp(), vertical: 2.Dp()), shapes: new ButtonShapes(Shape: RoundedCornerShape(8.Dp()), HoveredShape: RoundedCornerShape(8.Dp())), modifier: modifier.OrEmpty(), content: content, __composer: __composer, __changed: 0b_01_00_01_00_01_00_00_00_00 | (__dirty & 0b_00_00_00_00_00_00_11) | (__dirty & 0b_00_00_00_00_00_11_00) | ((__dirty & 0b_00_00_00_00_11_00_00) << 2));
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01;
        __composer.EndRestartGroup(1632521713, __isRestarted)?.UpdateScope(() => __SliderButton(__onClick, __content, __enabled, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}