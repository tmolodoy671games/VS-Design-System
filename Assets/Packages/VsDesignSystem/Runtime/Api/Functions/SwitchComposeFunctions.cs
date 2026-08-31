// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
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
        const float trackWidth = 80;
        const float trackHeight = 32;
        const float thumbWidth = 60;

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

        thumbContent ??= () =>
        {
            Spacer(
                Modifier
                    .Size(
                        width: thumbWidth.Dp(),
                        height: trackHeight.Dp()
                    )
                    .Background(
                        resolvedColors.GetThumbColor(enabled, isChecked),
                        Theme.Shapes.Medium
                    )
                    .Margin(
                        left: AnimateFloatAsState((trackWidth - thumbWidth + 1) * isChecked.ToInt()).Value.Dp()
                    )
            );
        };
        Box(
            modifier: modifier.OrEmpty()
                .Background(resolvedColors.GetTrackColor(enabled, isChecked))
                .Size(
                    width: trackWidth.Dp(),
                    height: trackHeight.Dp()
                )
                .Clip(Theme.Shapes.Medium)
                .DsClickIndication(
                    onClick: () => onCheckedChange?.Invoke(!isChecked),
                    interactionSource: interactionSource,
                    enabled: enabled
                ),
            content: () => { thumbContent(); }
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
                CheckedThumbColor: colorScheme.OnPrimary,
                CheckedTrackColor: colorScheme.Primary,
                CheckedBorderColor: colorScheme.Primary,
                CheckedIconColor: colorScheme.OnPrimary,

                // Unchecked
                UncheckedThumbColor: colorScheme.Outline,
                UncheckedTrackColor: colorScheme.SurfaceContainerHighest,
                UncheckedBorderColor: colorScheme.Outline,
                UncheckedIconColor: colorScheme.OnSurfaceVariant,

                // Disabled + checked
                DisabledCheckedThumbColor: colorScheme.Surface
                    .With(a: 0.38f),
                DisabledCheckedTrackColor: colorScheme.OnSurface
                    .With(a: 0.12f),
                DisabledCheckedBorderColor: colorScheme.OnSurface
                    .With(a: 0.12f),
                DisabledCheckedIconColor: colorScheme.Surface
                    .With(a: 0.38f),

                // Disabled + unchecked
                DisabledUncheckedThumbColor: colorScheme.OnSurface
                    .With(a: 0.38f),
                DisabledUncheckedTrackColor: colorScheme.SurfaceVariant
                    .With(a: 0.12f),
                DisabledUncheckedBorderColor: colorScheme.OnSurface
                    .With(a: 0.12f),
                DisabledUncheckedIconColor: colorScheme.OnSurface
                    .With(a: 0.38f)
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