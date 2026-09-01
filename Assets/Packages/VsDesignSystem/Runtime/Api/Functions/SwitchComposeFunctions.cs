// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using UnityEngine.UIElements;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static void Switch(
        bool isChecked,
        Action<bool>? onCheckedChange,
        IModifier? modifier = null,
        ComposableContent? thumbContent = null,
        bool enabled = true,
        Optional<SwitchColors> colors = default,
        IMutableInteractionSource? interactionSource = null
    )
    {
        const float trackWidth = 120;
        const float trackHeight = 48;
        const float thumbWidth = trackWidth * 0.6f;
        const float padding = 8;

        var resolvedColors = colors.GetOrDefault(SwitchDefaults.Colors);
        interactionSource ??= Remember(MutableInteractionSource);
        DisposableEffect(interactionSource, scope =>
        {
            var disposable = interactionSource.Interactions
                .Collect(it =>
                {
                    if (it is IPressInteraction.Release)
                        onCheckedChange?.Invoke(!isChecked);
                });
            return scope.OnDispose(disposable.Dispose);
        });
        var bounceAnimationSpec = Theme.AnimationSpecs.Bounce;
        var isHovered = interactionSource.CollectIsHoveredAsState().Value;
        Box(
            modifier: modifier.OrEmpty()
                .Background(resolvedColors.GetTrackColor(enabled, isChecked))
                .Size(
                    width: trackWidth.Dp(),
                    height: trackHeight.Dp()
                )
                .Scale(AnimateFloatAsState(isHovered ? 1.1f : 1f, bounceAnimationSpec).Value)
                .Clip(
                    RoundedCornerShape(trackHeight.Dp() / 2)
                )
                .Padding(all: padding.Dp())
                .DsClickIndication(
                    onClick: () => onCheckedChange?.Invoke(!isChecked),
                    interactionSource: interactionSource,
                    enabled: enabled
                ),
            content: () =>
            {
                var currentTrackDistance = (trackWidth - thumbWidth - padding * 2) * isChecked.ToInt() +
                                           padding * (!isChecked).ToInt();
                Box(
                    alignment: Alignment.Center,
                    modifier: Modifier
                        .Size(width: thumbWidth.Dp())
                        .FillMaxHeight()
                        .Background(
                            resolvedColors.GetThumbColor(enabled, isChecked),
                            RoundedCornerShape((trackHeight - 2 * padding).Dp() / 2)
                        )
                        .Margin(left: AnimateFloatAsState(currentTrackDistance, bounceAnimationSpec).Value.Dp())
                        .TransformOrigin(
                            originX: 0.Percent(),
                            originY: 50.Percent()
                        )
                        .Scale(AnimateFloatAsState(isChecked ? 1f : 0.7f, bounceAnimationSpec).Value),
                    content: () => { thumbContent?.Invoke(); }
                );
            }
        );
    }
}

internal static partial class SwitchDefaults
{
    [Composable]
    public static SwitchColors Colors
    {
        get
        {
            var colorScheme = Theme.ColorScheme;
            return new SwitchColors(
                // Checked
                CheckedThumbColor: colorScheme.Primary,
                CheckedTrackColor: colorScheme.PrimaryContainer,
                CheckedBorderColor: colorScheme.PrimaryContainer,
                CheckedIconColor: colorScheme.OnPrimary,

                // Unchecked
                UncheckedThumbColor: colorScheme.PrimaryContainer,
                UncheckedTrackColor: colorScheme.Primary,
                UncheckedBorderColor: colorScheme.Primary,
                UncheckedIconColor: colorScheme.OnPrimary,

                // Disabled + checked
                DisabledCheckedThumbColor: colorScheme.Primary.Disabled(),
                DisabledCheckedTrackColor: colorScheme.PrimaryContainer.Disabled(),
                DisabledCheckedBorderColor: colorScheme.PrimaryContainer.Disabled(),
                DisabledCheckedIconColor: colorScheme.OnPrimary.Disabled(),

                // Disabled + unchecked
                DisabledUncheckedThumbColor: colorScheme.PrimaryContainer.Disabled(),
                DisabledUncheckedTrackColor: colorScheme.Primary.Disabled(),
                DisabledUncheckedBorderColor: colorScheme.Primary.Disabled(),
                DisabledUncheckedIconColor: colorScheme.OnPrimary.Disabled()
            );
        }
    }
}

public readonly record struct SwitchColors(
    // Checked
    Color CheckedThumbColor,
    Color CheckedTrackColor,
    Color CheckedBorderColor,
    Color CheckedIconColor,
    // Unchecked
    Color UncheckedThumbColor,
    Color UncheckedTrackColor,
    Color UncheckedBorderColor,
    Color UncheckedIconColor,
    // Disabled + checked
    Color DisabledCheckedThumbColor,
    Color DisabledCheckedTrackColor,
    Color DisabledCheckedBorderColor,
    Color DisabledCheckedIconColor,
    // Disabled + unchecked
    Color DisabledUncheckedThumbColor,
    Color DisabledUncheckedTrackColor,
    Color DisabledUncheckedBorderColor,
    Color DisabledUncheckedIconColor
)
{
    internal Color GetThumbColor(bool enabled, bool isChecked)
    {
        if (enabled)
            return isChecked ? CheckedThumbColor : UncheckedThumbColor;
        return isChecked ? DisabledCheckedThumbColor : DisabledUncheckedThumbColor;
    }

    internal Color GetTrackColor(bool enabled, bool isChecked)
    {
        if (enabled)
            return isChecked ? CheckedTrackColor : UncheckedTrackColor;
        return isChecked ? DisabledCheckedTrackColor : DisabledUncheckedTrackColor;
    }

    internal Color GetBorderColor(bool enabled, bool isChecked)
    {
        if (enabled)
            return isChecked ? CheckedBorderColor : UncheckedBorderColor;
        return isChecked ? DisabledCheckedBorderColor : DisabledUncheckedBorderColor;
    }

    internal Color GetIconColor(bool enabled, bool isChecked)
    {
        if (enabled)
            return isChecked ? CheckedIconColor : UncheckedIconColor;
        return isChecked ? DisabledCheckedIconColor : DisabledUncheckedIconColor;
    }
}