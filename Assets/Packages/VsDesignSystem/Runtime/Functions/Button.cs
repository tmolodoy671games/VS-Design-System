using System;
using Compose.Net;
using SharpExtensions;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

public static partial class DesignSystemComposeFunctions
{
    [Composable]
    public static void Button(
        Action onClick,
        [Composable] Action content,
        IModifier? modifier = null,
        Optional<Shape> shape = default,
        Optional<ButtonColors> colors = default,
        BorderStroke border = default,
        Optional<PaddingValues> contentPadding = default,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true
    )
    {
        var resolvedColors = colors.GetOrDefault(ButtonDefaults.Colors());
        var resolvedContentPadding = contentPadding.GetOrDefault(
            PaddingValues(
                horizontal: 24.Dp(),
                vertical: 8.Dp()
            )
        );
        interactionSource ??= Remember(MutableInteractionSource);
        var hovered = interactionSource.CollectIsHoveredAsState().Value;
        var resolvedShape = shape.GetOrDefault(ButtonDefaults.Shape);
        Surface(
            onClick: onClick,
            modifier: modifier.OrEmpty()
                .Scale(AnimateFloatAsState(hovered ? 1.1f : 1f).Value)
                .DropShadow(
                    shape: resolvedShape,
                    shadow: Shadow(
                        radius: 6.Dp(),
                        spread: 0.Dp(),
                        color: AnimateColorAsState(hovered ? Color.Black : Color.Black with { Alpha = 0f }).Value
                    )
                ),
            enabled: enabled,
            shape: resolvedShape,
            border: border,
            color: resolvedColors.GetContainerColor(enabled),
            interactionSource: interactionSource,
            content: () =>
            {
                var pressed = interactionSource.CollectIsPressedAsState().Value;
                CompositionLocalProvider(
                    LocalContentColor.Provides(resolvedColors.GetContentColor(enabled)),
                    LocalTextStyle.Provides(Theme.Typography.LabelLarge),
                    content: () =>
                    {
                        Row(
                            horizontalArrangement: Arrangement.Center,
                            verticalAlignment: Alignment.CenterVertically,
                            modifier: Modifier
                                .Padding(resolvedContentPadding)
                                .Scale(AnimateFloatAsState(pressed ? 0.9f : 1f).Value)
                                .Alpha(AnimateFloatAsState(pressed ? 0.8f : 1f).Value),
                            content: content
                        );
                    }
                );
            }
        );
    }
}

internal static partial class ButtonDefaults
{
    public static Shape Shape
    {
        [Composable] get => DesignSystemComposeFunctions.Theme.Shapes.ExtraLarge;
    }

    [Composable]
    public static ButtonColors Colors(
        Optional<Color> containerColor = default,
        Optional<Color> contentColor = default,
        Optional<Color> disabledContainerColor = default,
        Optional<Color> disabledContentColor = default
    )
    {
        var colorScheme = DesignSystemComposeFunctions.Theme.ColorScheme;
        var onSurface = colorScheme.OnSurface;
        return new ButtonColors(
            ContainerColor: containerColor.GetOrDefault(colorScheme.Primary),
            ContentColor: contentColor.GetOrDefault(colorScheme.OnPrimary),
            DisabledContainerColor: disabledContainerColor.GetOrDefault(
                new Color(onSurface.Red, onSurface.Green, onSurface.Blue, 0.12f)
            ),
            DisabledContentColor: disabledContentColor.GetOrDefault(
                new Color(onSurface.Red, onSurface.Green, onSurface.Blue, 0.38f)
            )
        );
    }
}

public readonly record struct ButtonColors(
    Color ContainerColor,
    Color ContentColor,
    Color DisabledContainerColor,
    Color DisabledContentColor
)
{
    public Color GetContainerColor(bool enabled) => enabled ? ContainerColor : DisabledContainerColor;

    public Color GetContentColor(bool enabled) => enabled ? ContentColor : DisabledContentColor;
}