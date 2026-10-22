// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using SharpExtensions;

namespace VS.DesignSystem;

public static partial class DesignSystemComposeFunctions
{
    [Composable]
    public static void Switch(
        bool value,
        Action<bool> onValueChange,
        IModifier? modifier = null,
        [Composable] Action? thumbContent = null,
        bool enabled = true,
        Optional<SwitchColors> colors = default,
        IMutableInteractionSource? interactionSource = null
    )
    {
        SwitchImpl(
            value: value,
            onValueChange: onValueChange,
            modifier: modifier.OrEmpty(),
            thumbContent: thumbContent ?? (() => { }),
            enabled: enabled,
            colors: colors.GetOrDefault(SwitchDefaults.Colors()),
            interactionSource: interactionSource ?? Remember(MutableInteractionSource)
        );
    }

    [Composable, NonRestartableComposable]
    private static void SwitchImpl(
        bool value,
        Action<bool> onValueChange,
        IModifier modifier,
        [Composable] Action thumbContent,
        bool enabled,
        SwitchColors colors,
        IMutableInteractionSource interactionSource
    )
    {
        // The click handler can outlive this composition; read the latest inputs on each click.
        var currentValue = Remember(() => MutableStateOf(value));
        var currentOnValueChange = Remember(() => MutableStateOf(onValueChange));
        currentValue.Value = value;
        currentOnValueChange.Value = onValueChange;
        var onClick = Remember(() => (Action)(() =>
            currentOnValueChange.Value(!currentValue.Value))
        );

        var hovered = interactionSource.CollectIsHoveredAsState().Value;
        var pressed = interactionSource.CollectIsPressedAsState().Value;
        var thumbSize = AnimateFloatAsState(enabled && pressed ? 28f : 24f).Value;
        var thumbOffset = AnimateFloatAsState(value ? 10f : -10f).Value;
        var trackColor = AnimateColorAsState(colors.GetTrackColor(enabled, value)).Value;
        var borderColor = AnimateColorAsState(colors.GetBorderColor(enabled, value)).Value;
        var thumbColor = AnimateColorAsState(colors.GetThumbColor(enabled, value)).Value;
        var iconColor = AnimateColorAsState(colors.GetIconColor(enabled, value)).Value;
        var shape = new Shape(16.Dp(), 16.Dp(), 16.Dp(), 16.Dp());
        var innerShape = new Shape(14.Dp(), 14.Dp(), 14.Dp(), 14.Dp());

        Box(
            modifier: modifier
                .Size(width: 52.Dp(), height: 32.Dp())
                .Background(trackColor, shape)
                .Clip(shape)
                .Scale(AnimateFloatAsState(hovered ? 1.1f : 1f).Value)
                .Clickable(
                    onClick: onClick,
                    enabled: enabled,
                    interactionSource: interactionSource,
                    indication: LocalIndication.Current
                )
                .InnerShadow(
                    shape: shape,
                    shadow: Shadow(
                        radius: 4.Dp(),
                        spread: 4.Dp(),
                        color: AnimateColorAsState(hovered ? Color.Black : Color.Transparent).Value
                    )
                ),
            contentAlignment: Alignment.Center,
            content: () =>
            {
                Box(
                    modifier: Modifier.FillMaxSize().Background(borderColor, shape),
                    contentAlignment: Alignment.Center,
                    content: () => Box(
                        modifier: Modifier
                            .Size(width: 48.Dp(), height: 28.Dp())
                            .Background(trackColor, innerShape),
                        content: () => { }
                    )
                );

                Box(
                    modifier: Modifier
                        .Offset(x: thumbOffset.Dp())
                        .Size(thumbSize.Dp())
                        .Background(thumbColor, shape)
                        .Scale(AnimateFloatAsState(value ? 1f : 0.6f).Value),
                    contentAlignment: Alignment.Center,
                    content: () => CompositionLocalProvider(
                        LocalContentColor.Provides(iconColor),
                        content: thumbContent
                    )
                );
            }
        );
    }
}

public static partial class SwitchDefaults
{
    [Composable]
    public static SwitchColors Colors(
        Optional<Color> checkedThumbColor = default,
        Optional<Color> checkedTrackColor = default,
        Optional<Color> checkedBorderColor = default,
        Optional<Color> checkedIconColor = default,
        Optional<Color> uncheckedThumbColor = default,
        Optional<Color> uncheckedTrackColor = default,
        Optional<Color> uncheckedBorderColor = default,
        Optional<Color> uncheckedIconColor = default,
        Optional<Color> disabledCheckedThumbColor = default,
        Optional<Color> disabledCheckedTrackColor = default,
        Optional<Color> disabledCheckedBorderColor = default,
        Optional<Color> disabledCheckedIconColor = default,
        Optional<Color> disabledUncheckedThumbColor = default,
        Optional<Color> disabledUncheckedTrackColor = default,
        Optional<Color> disabledUncheckedBorderColor = default,
        Optional<Color> disabledUncheckedIconColor = default
    )
    {
        var scheme = DesignSystemComposeFunctions.Theme.ColorScheme;
        var transparent = scheme.OnSurface with { Alpha = 0f };
        var disabledTrack = scheme.OnSurface with { Alpha = 0.12f };
        var disabledContent = scheme.OnSurface with { Alpha = 0.38f };

        return new SwitchColors(
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
            DisabledUncheckedIconColor: disabledUncheckedIconColor.GetOrDefault(scheme.Surface)
        );
    }
}

public readonly record struct SwitchColors(
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
    Color DisabledUncheckedIconColor
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