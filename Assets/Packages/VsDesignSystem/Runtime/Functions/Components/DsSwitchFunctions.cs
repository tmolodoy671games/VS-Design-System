// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using Unity.Scripting.LifecycleManagement;
using SharpExtensions;

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
public static partial class DsSwitchFunctions
{
    [Composable]
    public static void DsSwitch(
        bool value,
        Action<bool>? onValueChange,
        IModifier? modifier = null,
        [Composable] Action? thumbContent = null,
        bool enabled = true,
        DsSwitchColors colors = default,
        IMutableInteractionSource? interactionSource = null
    )
    {
        var resolvedColors = colors.IsSpecified ? colors : DsSwitchDefaults.Colors();
        interactionSource ??= Remember(MutableInteractionSource);
        modifier = modifier.OrEmpty();
        if (onValueChange != null)
        {
            modifier = modifier.SizeIn(minWidth: 60.Dp(), minHeight: 48.Dp())
                .Clickable(() => onValueChange(!value), null, interactionSource, enabled);
        }

        var track = resolvedColors.GetTrackColor(enabled, value);
        var thumb = resolvedColors.GetThumbColor(enabled, value);
        var border = resolvedColors.GetBorderColor(enabled, value);
        var icon = resolvedColors.GetIconColor(enabled, value);
        var shape = RoundedCornerShape(9999.Dp());
        var diameter = value || thumbContent != null ? 24 : 16;
        var inset = (32 - diameter) / 2;
        var localIndication = LocalIndication.Current;
        var indication = localIndication.RememberUpdatedInstance(interactionSource);
        Box(
            modifier: modifier,
            contentAlignment: Alignment.Center,
            content: () =>
            {
                Box(
                    modifier: Modifier
                        .Size(52.Dp(), 32.Dp())
                        .Background(track, shape)
                        .Border(2.Dp(), SolidColor(border), shape)
                        .Padding(inset.Dp()),
                    contentAlignment: value ? Alignment.CenterEnd : Alignment.CenterStart,
                    content: () => Box(
                        modifier: Modifier
                            .Size(diameter.Dp())
                            .Background(thumb, shape),
                        contentAlignment: Alignment.Center,
                        content: () => CompositionLocalProvider(LocalContentColor.Provides(icon),
                            () => thumbContent?.Invoke()
                        )
                    )
                );
                if (onValueChange != null && enabled)
                {
                    Box(
                        Modifier
                            .Size(40.Dp())
                            .Offset(x: (value ? 10 : -10).Dp())
                            .Clip(shape).DrawOnTop(indication.DrawIndication)
                            .TestTag("material.switch.stateLayer")
                    );
                }
            }
        );
    }
}

[NoAutoStaticsCleanup]
public static partial class DsSwitchDefaults
{
    internal static readonly AnimationSpec ThumbMotion = Tween(
        duration: 360,
        easing: Easing(progress =>
            {
                if (progress >= 1f) return 1f;
                var time = progress * .36f;
                const float decay = 22f;
                const float frequency = 30f;
                return 1f - MathF.Exp(-decay * time)
                    * (MathF.Cos(frequency * time) + decay / frequency * MathF.Sin(frequency * time));
            }
        )
    );

    [Composable]
    public static DsSwitchColors Colors(
        Color checkedThumbColor = default,
        Color checkedTrackColor = default,
        Color checkedBorderColor = default,
        Color checkedIconColor = default,
        Color uncheckedThumbColor = default,
        Color uncheckedTrackColor = default,
        Color uncheckedBorderColor = default,
        Color uncheckedIconColor = default,
        Color disabledCheckedThumbColor = default,
        Color disabledCheckedTrackColor = default,
        Color disabledCheckedBorderColor = default,
        Color disabledCheckedIconColor = default,
        Color disabledUncheckedThumbColor = default,
        Color disabledUncheckedTrackColor = default,
        Color disabledUncheckedBorderColor = default,
        Color disabledUncheckedIconColor = default
    )
    {
        var scheme = DsTheme.ColorScheme;
        var transparent = scheme.OnSurface with { Alpha = 0f };
        var disabledTrack = scheme.OnSurface with { Alpha = 0.12f };
        var disabledContent = scheme.OnSurface with { Alpha = 0.38f };

        return new DsSwitchColors(
            CheckedThumbColor: checkedThumbColor.GetOrDefault(scheme.OnPrimary),
            CheckedTrackColor: checkedTrackColor.GetOrDefault(scheme.Primary),
            CheckedBorderColor: checkedBorderColor.GetOrDefault(transparent),
            CheckedIconColor: checkedIconColor.GetOrDefault(scheme.OnPrimaryContainer),
            UncheckedThumbColor: uncheckedThumbColor.GetOrDefault(scheme.Outline),
            UncheckedTrackColor: uncheckedTrackColor.GetOrDefault(scheme.SurfaceContainerHighest),
            UncheckedBorderColor: uncheckedBorderColor.GetOrDefault(scheme.Outline),
            UncheckedIconColor: uncheckedIconColor.GetOrDefault(scheme.SurfaceContainerHighest),
            DisabledCheckedThumbColor: disabledCheckedThumbColor.GetOrDefault(scheme.Surface),
            DisabledCheckedTrackColor: disabledCheckedTrackColor.GetOrDefault(disabledTrack),
            DisabledCheckedBorderColor: disabledCheckedBorderColor.GetOrDefault(transparent),
            DisabledCheckedIconColor: disabledCheckedIconColor.GetOrDefault(disabledContent),
            DisabledUncheckedThumbColor: disabledUncheckedThumbColor.GetOrDefault(disabledContent),
            DisabledUncheckedTrackColor: disabledUncheckedTrackColor.GetOrDefault(disabledTrack),
            DisabledUncheckedBorderColor: disabledUncheckedBorderColor.GetOrDefault(disabledTrack),
            DisabledUncheckedIconColor: disabledUncheckedIconColor.GetOrDefault(scheme.Surface),
            IsSpecified: true
        );
    }
}

public readonly record struct DsSwitchColors(
    Color CheckedThumbColor,
    Color CheckedTrackColor,
    Color CheckedBorderColor,
    Color CheckedIconColor,
    Color UncheckedThumbColor,
    Color UncheckedTrackColor,
    Color UncheckedBorderColor,
    Color UncheckedIconColor,
    Color DisabledCheckedThumbColor,
    Color DisabledCheckedTrackColor,
    Color DisabledCheckedBorderColor,
    Color DisabledCheckedIconColor,
    Color DisabledUncheckedThumbColor,
    Color DisabledUncheckedTrackColor,
    Color DisabledUncheckedBorderColor,
    Color DisabledUncheckedIconColor,
    bool IsSpecified
)
{
    public Color GetThumbColor(bool enabled, bool value) => enabled
        ? (value ? CheckedThumbColor : UncheckedThumbColor)
        : (value ? DisabledCheckedThumbColor : DisabledUncheckedThumbColor);

    public Color GetTrackColor(bool enabled, bool value) => enabled
        ? (value ? CheckedTrackColor : UncheckedTrackColor)
        : (value ? DisabledCheckedTrackColor : DisabledUncheckedTrackColor);

    public Color GetBorderColor(bool enabled, bool value) => enabled
        ? (value ? CheckedBorderColor : UncheckedBorderColor)
        : (value ? DisabledCheckedBorderColor : DisabledUncheckedBorderColor);

    public Color GetIconColor(bool enabled, bool value) => enabled
        ? (value ? CheckedIconColor : UncheckedIconColor)
        : (value ? DisabledCheckedIconColor : DisabledUncheckedIconColor);
}