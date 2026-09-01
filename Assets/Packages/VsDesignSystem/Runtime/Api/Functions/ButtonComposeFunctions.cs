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
    public static void Button(
        Action onClick,
        ComposableContent content,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true,
        Optional<ButtonShapes> shapes = default,
        Optional<ButtonColors> colors = default,
        Optional<PaddingValues> contentPadding = default,
        IModifier? modifier = null
    )
    {
        var typography = Theme.Typography;
        var resolvedColors = colors.GetOrDefault(ButtonDefaults.PrimaryButtonColors());
        var resolvedContentPadding = contentPadding.GetOrDefault(ButtonDefaults.ContentPadding);

        interactionSource ??= Remember(MutableInteractionSource);
        var isHovered = interactionSource.CollectIsHoveredAsState().Value;
        var resolvedShape = shapes.GetOrDefault(ButtonDefaults.Shapes).GetShape(isHovered);
        var isPressed = interactionSource.CollectIsPressedAsState().Value;
        var contentBackground = AnimateColorAsState(resolvedColors.GetContainerColor(enabled)).Value;
        var bounceAnimationSpec = Theme.AnimationSpecs.Bounce;
        Box(
            alignment: Alignment.Center,
            modifier: modifier.OrEmpty()
                .Padding(resolvedContentPadding)
                .Scale(AnimateFloatAsState(isHovered ? 1.1f : 1f, bounceAnimationSpec).Value)
                .Clip(AnimateRoundedCornerShapeAsState(resolvedShape, bounceAnimationSpec).Value)
                .Background(contentBackground)
                .DsClickIndication(
                    enabled: enabled,
                    onClick: onClick,
                    interactionSource: interactionSource
                ),
            content: () =>
            {
                var contentTint = AnimateColorAsState(resolvedColors.GetContentColor(enabled)).Value;
                CompositionLocalProvider(
                    LocalTextStyle.Provides(typography.Control),
                    LocalContentColor.Provides(contentTint),
                    () =>
                    {
                        Row(
                            verticalAlignment: Alignment.CenterVertically,
                            horizontalArrangement: Arrangement.Center,
                            modifier: Modifier
                                .Scale(AnimateFloatAsState(isPressed ? 0.75f : 1f, bounceAnimationSpec).Value),
                            content: content
                        );
                    }
                );
            }
        );
    }

    [Composable]
    public static void SecondaryButton(
        Action onClick,
        ComposableContent content,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true,
        Optional<ButtonShapes> shapes = default,
        Optional<ButtonColors> colors = default,
        Optional<PaddingValues> contentPadding = default,
        IModifier? modifier = null
    )
    {
        Button(
            onClick: onClick,
            content: content,
            interactionSource: interactionSource,
            enabled: enabled,
            shapes: shapes,
            colors: colors.GetOrDefault(ButtonDefaults.SecondaryButtonColors()),
            contentPadding: contentPadding,
            modifier: modifier
        );
    }

    [Composable]
    public static void TextButton(
        Action onClick,
        ComposableContent content,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true,
        Optional<ButtonShapes> shapes = default,
        Optional<ButtonColors> colors = default,
        Optional<PaddingValues> contentPadding = default,
        IModifier? modifier = null
    )
    {
        var resolvedColors = colors.GetOrDefault(ButtonDefaults.TextButtonColors());
        Button(
            onClick: onClick,
            content: content,
            interactionSource: interactionSource,
            enabled: enabled,
            shapes: shapes,
            colors: resolvedColors,
            contentPadding: contentPadding,
            modifier: modifier
        );
    }
}

internal static partial class ButtonDefaults
{
    [Composable]
    public static ButtonShapes Shapes => new(
        Shape: RoundedCornerShape(16.Dp()),
        HoveredShape: RoundedCornerShape(24.Dp())
    );

    public static readonly PaddingValues ContentPadding = new(
        Horizontal: 24.Dp(),
        Vertical: 8.Dp()
    );

    [Composable]
    public static ButtonColors TextButtonColors()
    {
        var colors = Theme.ColorScheme;
        return new ButtonColors(
            ContainerColor: new Color(),
            ContentColor: colors.Primary,
            DisabledContainerColor: new Color(),
            DisabledContentColor: colors.OnSurface.Disabled()
        );
    }

    [Composable]
    public static ButtonColors PrimaryButtonColors()
    {
        var colors = Theme.ColorScheme;
        return new ButtonColors(
            ContainerColor: colors.Primary,
            ContentColor: colors.OnPrimary,
            DisabledContainerColor: colors.Primary.Disabled(),
            DisabledContentColor: colors.OnPrimary.DisabledContent()
        );
    }

    [Composable]
    public static ButtonColors SecondaryButtonColors()
    {
        var colors = Theme.ColorScheme;
        return new ButtonColors(
            ContainerColor: colors.Secondary,
            ContentColor: colors.OnSecondary,
            DisabledContainerColor: colors.Secondary.Disabled(),
            DisabledContentColor: colors.OnSecondary.DisabledContent()
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
    internal Color GetContainerColor(bool enabled)
    {
        return enabled ? ContainerColor : DisabledContainerColor;
    }

    internal Color GetContentColor(bool enabled)
    {
        return enabled ? ContentColor : DisabledContentColor;
    }
}

public readonly record struct ButtonShapes(
    RoundedCornerShape Shape,
    RoundedCornerShape HoveredShape
)
{
    internal RoundedCornerShape GetShape(bool hovered)
    {
        return hovered ? HoveredShape : Shape;
    }
}