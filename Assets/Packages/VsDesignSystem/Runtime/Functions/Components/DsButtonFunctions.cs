using System;
using Compose.Net;
using SharpExtensions;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
public static partial class DsButtonFunctions
{
    [Composable]
    public static void DsButton(
        Action onClick,
        [Composable] Action content,
        IModifier? modifier = null,
        Shape shape = default,
        DsButtonColors colors = default,
        BorderStroke border = default,
        PaddingValues contentPadding = default,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true
    )
    {
        DsButtonImpl(
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

    [Composable]
    public static void DsOutlineButton(
        Action onClick,
        [Composable] Action content,
        IModifier? modifier = null,
        Optional<Shape> shape = default,
        DsButtonColors colors = default,
        Optional<BorderStroke> border = default,
        PaddingValues contentPadding = default,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true
    )
    {
        DsButtonImpl(
            onClick: onClick,
            content: content,
            modifier: modifier.OrEmpty(),
            shape: shape.GetOrDefault(ButtonDefaults.Shape),
            colors: colors.GetOrDefault(ButtonDefaults.OutlineButtonColors()),
            border: border.GetOrDefault(ButtonDefaults.OutlineBorder(enabled)),
            contentPadding: contentPadding.GetOrDefault(
                PaddingValues(horizontal: 24.Dp(), vertical: 8.Dp())
            ),
            interactionSource: interactionSource ?? Remember(MutableInteractionSource),
            enabled: enabled
        );
    }

    [Composable]
    public static void DsTextButton(
        Action onClick,
        [Composable] Action content,
        IModifier? modifier = null,
        Optional<Shape> shape = default,
        DsButtonColors colors = default,
        PaddingValues contentPadding = default,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true
    )
    {
        DsButtonImpl(
            onClick: onClick,
            content: content,
            modifier: modifier.OrEmpty(),
            shape: shape.GetOrDefault(ButtonDefaults.Shape),
            colors: colors.GetOrDefault(ButtonDefaults.TextButtonColors()),
            border: default,
            contentPadding: contentPadding.GetOrDefault(
                PaddingValues(horizontal: 12.Dp(), vertical: 8.Dp())
            ),
            interactionSource: interactionSource  ?? Remember(MutableInteractionSource),
            enabled: enabled
        );
    }

    [Composable, NonRestartableComposable]
    private static void DsButtonImpl(
        Action onClick,
        [Composable] Action content,
        IModifier modifier,
        Shape shape,
        DsButtonColors colors,
        BorderStroke border,
        PaddingValues contentPadding,
        IMutableInteractionSource interactionSource,
        bool enabled
    )
    {
        var hovered = interactionSource.CollectIsHoveredAsState().Value && enabled;
        var pressed = interactionSource.CollectIsPressedAsState().Value && enabled;
        var lift = AnimateFloatAsState(hovered && !pressed ? 2f : 0f, Tween(150)).Value;
        var textStyle = DsTheme.Typography.LabelLarge;
        DsSurface(
            onClick: onClick,
            modifier: modifier.Offset(y: (-lift).Dp()),
            enabled: enabled,
            shape: shape,
            color: colors.GetContainerColor(enabled),
            contentColor: colors.GetContentColor(enabled),
            border: border,
            interactionSource: interactionSource,
            contentAlignment: Alignment.Center,
            content: () => CompositionLocalProvider(
                LocalTextStyle.Provides(textStyle),
                content: () => Row(
                    horizontalArrangement: Arrangement.Center,
                    verticalAlignment: Alignment.CenterVertically,
                    modifier: Modifier.Padding(contentPadding),
                    content: content
                )
            )
        );
    }
}

public static partial class ButtonDefaults
{
    [Composable]
    public static BorderStroke OutlineBorder(bool enabled = true)
    {
        var scheme = DsTheme.ColorScheme;
        return BorderStroke(
            width: 2.Dp(),
            color: enabled ? scheme.Outline : scheme.OnSurface with { Alpha = 0.12f }
        );
    }

    [Composable]
    public static DsButtonColors OutlineButtonColors(
        Optional<Color> containerColor = default,
        Optional<Color> contentColor = default,
        Optional<Color> disabledContainerColor = default,
        Optional<Color> disabledContentColor = default
    ) => Colors(
        containerColor: containerColor.GetOrDefault(Color.Transparent),
        contentColor: contentColor.GetOrDefault(DsTheme.ColorScheme.Primary),
        disabledContainerColor: disabledContainerColor.GetOrDefault(Color.Transparent),
        disabledContentColor: disabledContentColor
    );

    [Composable]
    public static DsButtonColors TextButtonColors(
        Optional<Color> containerColor = default,
        Optional<Color> contentColor = default,
        Optional<Color> disabledContainerColor = default,
        Optional<Color> disabledContentColor = default
    ) => OutlineButtonColors(containerColor, contentColor, disabledContainerColor, disabledContentColor);

    public static Shape Shape
    {
        [Composable] get => DsTheme.Shapes.ExtraLarge;
    }

    [Composable]
    public static DsButtonColors Colors(
        Optional<Color> containerColor = default,
        Optional<Color> contentColor = default,
        Optional<Color> disabledContainerColor = default,
        Optional<Color> disabledContentColor = default
    )
    {
        var colorScheme = DsTheme.ColorScheme;
        var onSurface = colorScheme.OnSurface;
        return new DsButtonColors(
            ContainerColor: containerColor.GetOrDefault(colorScheme.PrimaryContainer),
            ContentColor: contentColor.GetOrDefault(colorScheme.OnPrimaryContainer),
            DisabledContainerColor: disabledContainerColor.GetOrDefault(
                new Color(onSurface.Red, onSurface.Green, onSurface.Blue, 0.12f)
            ),
            DisabledContentColor: disabledContentColor.GetOrDefault(
                new Color(onSurface.Red, onSurface.Green, onSurface.Blue, 0.38f)
            )
        );
    }
}

public readonly record struct DsButtonColors(
    Color ContainerColor,
    Color ContentColor,
    Color DisabledContainerColor,
    Color DisabledContentColor,
    bool IsSpecified = true
)
{
    public bool IsUnspecified => !IsSpecified;

    public DsButtonColors GetOrDefault(DsButtonColors defaultValue) => IsSpecified ? this : defaultValue;

    public Color GetContainerColor(bool enabled) => enabled ? ContainerColor : DisabledContainerColor;
    public Color GetContentColor(bool enabled) => enabled ? ContentColor : DisabledContentColor;
}
