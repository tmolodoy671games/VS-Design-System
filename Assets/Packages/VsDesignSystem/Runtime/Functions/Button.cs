using System;
using Compose.Net;
using SharpExtensions;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

public static partial class DesignSystemComposeFunctions
{
    [Composable]
    public static void OutlineButton(
        Action onClick,
        [Composable] Action content,
        IModifier? modifier = null,
        Optional<Shape> shape = default,
        Optional<ButtonColors> colors = default,
        Optional<BorderStroke> border = default,
        Optional<PaddingValues> contentPadding = default,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true
    )
    {
        Button(
            onClick: onClick,
            content: content,
            modifier: modifier,
            shape: shape,
            colors: colors.GetOrDefault(ButtonDefaults.OutlineButtonColors()),
            border: border.GetOrDefault(ButtonDefaults.OutlineBorder(enabled)),
            contentPadding: contentPadding,
            interactionSource: interactionSource,
            enabled: enabled
        );
    }

    [Composable]
    public static void TextButton(
        Action onClick,
        [Composable] Action content,
        IModifier? modifier = null,
        Optional<Shape> shape = default,
        Optional<ButtonColors> colors = default,
        Optional<PaddingValues> contentPadding = default,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true
    )
    {
        Button(
            onClick: onClick,
            content: content,
            modifier: modifier,
            shape: shape,
            colors: colors.GetOrDefault(ButtonDefaults.TextButtonColors()),
            contentPadding: contentPadding.GetOrDefault(
                PaddingValues(horizontal: 12.Dp(), vertical: 8.Dp())
            ),
            interactionSource: interactionSource,
            enabled: enabled
        );
    }

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
        ButtonImpl(
            onClick: onClick,
            content: content,
            modifier: modifier.OrEmpty(),
            shape: shape.GetOrDefault(ButtonDefaults.Shape),
            colors: colors.GetOrDefault(ButtonDefaults.Colors()),
            border: border,
            contentPadding: contentPadding.GetOrDefault(
                PaddingValues(
                    horizontal: 24.Dp(),
                    vertical: 8.Dp()
                )
            ),
            interactionSource: interactionSource ?? Remember(MutableInteractionSource),
            enabled: enabled
        );
    }

    [Composable, NonRestartableComposable]
    private static void ButtonImpl(
        Action onClick,
        [Composable] Action content,
        IModifier modifier,
        Shape shape,
        ButtonColors colors,
        BorderStroke border,
        PaddingValues contentPadding,
        IMutableInteractionSource interactionSource,
        bool enabled
    )
    {
        var isHovered = interactionSource.CollectIsHoveredAsState().Value;
        var hovered = isHovered && enabled;
        // var resolvedShape = shape * AnimateFloatAsState(hovered ? 1.2f : 1f).Value;
        Debug.Log(hovered);
        var resolvedShape = shape;
        Box(
            // onClick: onClick,
            modifier: modifier
                .Hoverable(interactionSource, enabled)
                .Background(colors.GetContainerColor(enabled)),
            // enabled: enabled,
            // shape: resolvedShape,
            // border: border,
            // color: colors.GetContainerColor(enabled),
            // interactionSource: interactionSource,
            content: () =>
            {
                var isPressed = interactionSource.CollectIsPressedAsState().Value;
                var pressed = isPressed && enabled;
                var contentScale = CustomSwitch.Switch()
                    .Case(pressed, 0.9f)
                    .Case(hovered, 1.1f)
                    .Default(1)
                    .Get();
                CompositionLocalProvider(
                    LocalContentColor.Provides(colors.GetContentColor(enabled)),
                    LocalTextStyle.Provides(Theme.Typography.LabelLarge),
                    content: () =>
                    {
                        Row(
                            horizontalArrangement: Arrangement.Center,
                            verticalAlignment: Alignment.CenterVertically,
                            modifier: Modifier
                                .Padding(contentPadding)
                                // .Scale(AnimateFloatAsState(contentScale).Value)
                                .Alpha(AnimateFloatAsState(pressed ? 0.8f : 1f).Value),
                            content: content
                        );
                    }
                );
            }
        );
    }
}

public static partial class ButtonDefaults
{
    [Composable]
    public static BorderStroke OutlineBorder(bool enabled = true)
    {
        var scheme = DesignSystemComposeFunctions.Theme.ColorScheme;
        return BorderStroke(
            width: 1.Dp(),
            color: enabled ? scheme.Outline : scheme.OnSurface with { Alpha = 0.12f }
        );
    }

    [Composable]
    public static ButtonColors OutlineButtonColors(
        Optional<Color> containerColor = default,
        Optional<Color> contentColor = default,
        Optional<Color> disabledContainerColor = default,
        Optional<Color> disabledContentColor = default
    ) => Colors(
        containerColor: containerColor.GetOrDefault(Color.Transparent),
        contentColor: contentColor.GetOrDefault(DesignSystemComposeFunctions.Theme.ColorScheme.Primary),
        disabledContainerColor: disabledContainerColor.GetOrDefault(Color.Transparent),
        disabledContentColor: disabledContentColor
    );

    [Composable]
    public static ButtonColors TextButtonColors(
        Optional<Color> containerColor = default,
        Optional<Color> contentColor = default,
        Optional<Color> disabledContainerColor = default,
        Optional<Color> disabledContentColor = default
    ) => OutlineButtonColors(containerColor, contentColor, disabledContainerColor, disabledContentColor);

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
