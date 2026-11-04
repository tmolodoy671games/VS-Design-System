using System;
using Compose.Net;
using SharpExtensions;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
public static partial class ButtonFunctions
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
        bool enabled = true,
        SurfaceMaterial? material = null
    ) => ButtonWithDefaults(onClick, content, modifier, shape, colors, border, contentPadding,
        interactionSource, enabled, material ?? Materials.Metal());

    [Composable]
    private static void ButtonWithDefaults(
        Action onClick,
        [Composable] Action content,
        IModifier? modifier = null,
        Optional<Shape> shape = default,
        Optional<ButtonColors> colors = default,
        BorderStroke border = default,
        Optional<PaddingValues> contentPadding = default,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true,
        SurfaceMaterial? material = null
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
            enabled: enabled,
            material: material
        );
    }
    
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
        ButtonWithDefaults(
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
        ButtonWithDefaults(
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
        bool enabled,
        SurfaceMaterial? material
    )
    {
        var hovered = interactionSource.CollectIsHoveredAsState().Value && enabled;
        var pressed = interactionSource.CollectIsPressedAsState().Value && enabled;
        var targetScale = pressed ? 0.8f : hovered ? 1.2f : 1f;
        var animatedScale = AnimateFloatAsState(targetScale).Value;
        var animatedAlpha = AnimateFloatAsState(pressed ? 0.8f : 1f).Value;
        var color = colors.GetContainerColor(enabled);
        var indication = LocalIndication.Current;
        var textStyle = CurrentTheme.Typography.LabelLarge;
        var face = material is { } finish
            ? modifier.Surface(finish, enabled ? pressed ? Depth.Inset(2.Dp()) : Depth.Raised(2.Dp()) : Depth.Flat,
                color, shape).Then(border.Width != default ? Modifier.Border(border, shape) : Modifier)
            : modifier.Surface(shape, color, border, shadowElevation: default);
        Box(modifier: face, contentAlignment: Alignment.Center, content: () =>
        {
            CompositionLocalProvider(
                LocalContentColor.Provides(colors.GetContentColor(enabled)),
                LocalTextStyle.Provides(textStyle),
                content: () => Row(
                    horizontalArrangement: Arrangement.Center,
                    verticalAlignment: Alignment.CenterVertically,
                    modifier: Modifier.Padding(contentPadding).Scale(animatedScale).Alpha(animatedAlpha),
                    content: content));
            // Keep the hit target as large as the face without clipping its outer shadows.
            Box(modifier: Modifier.MatchParentSize().Clip(shape)
                .Clickable(onClick, indication, interactionSource, enabled), content: () => { });
        });
    }
}

public static partial class ButtonDefaults
{
    [Composable]
    public static BorderStroke OutlineBorder(bool enabled = true)
    {
        var scheme = WithThemeFunctions.CurrentTheme.ColorScheme;
        return BorderStroke(
            width: 2.Dp(),
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
        contentColor: contentColor.GetOrDefault(CurrentTheme.ColorScheme.Primary),
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
        [Composable] get => CurrentTheme.Shapes.ExtraLarge;
    }

    [Composable]
    public static ButtonColors Colors(
        Optional<Color> containerColor = default,
        Optional<Color> contentColor = default,
        Optional<Color> disabledContainerColor = default,
        Optional<Color> disabledContentColor = default
    )
    {
        var colorScheme = CurrentTheme.ColorScheme;
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
