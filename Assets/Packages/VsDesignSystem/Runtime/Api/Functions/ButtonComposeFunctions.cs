// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Api.Models;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using UnityEngine.UIElements;
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
        var resolvedColors = colors.GetOrDefault(ButtonDefaults.ButtonColors());
        var resolvedContentPadding = contentPadding.GetOrDefault(ButtonDefaults.ContentPadding);

        interactionSource ??= Remember(MutableInteractionSource);
        var isHovered = interactionSource.CollectIsHoveredAsState().Value;
        var resolvedShape = shapes.GetOrDefault(ButtonDefaults.Shapes).GetShape(isHovered);
        var isPressed = interactionSource.CollectIsPressedAsState().Value;
        var contentBackground = AnimateColorAsState(resolvedColors.GetContainerColor(enabled)).Value;
        Box(
            alignment: Alignment.Center,
            modifier: modifier.OrEmpty()
                .Padding(resolvedContentPadding)
                .Scale(AnimateFloatAsState(isHovered ? 1.1f : 1f).Value)
                .Clip(AnimateRoundedCornerShapeAsState(resolvedShape).Value)
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
                    LocalTextStyle.Provides(typography.LabelLarge),
                    LocalContentColor.Provides(contentTint),
                    () =>
                    {
                        Row(
                            verticalAlignment: Alignment.CenterVertically,
                            horizontalArrangement: Arrangement.Center,
                            modifier: Modifier
                                .Scale(AnimateFloatAsState(isPressed ? 0.75f : 1f).Value),
                            content: content
                        );
                    }
                );
            }
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
    private const float DisabledAlpha = 0.38f;

    [Composable]
    public static ButtonShapes Shapes => new(
        Shape: Theme.Shapes.Medium,
        HoveredShape: Theme.Shapes.Large
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
            DisabledContentColor: colors.OnSurface.With(a: DisabledAlpha)
        );
    }

    [Composable]
    public static ButtonColors ButtonColors()
    {
        var colors = Theme.ColorScheme;
        return new ButtonColors(
            ContainerColor: colors.Primary,
            ContentColor: colors.OnPrimary,
            DisabledContainerColor: colors.OnSurface.With(a: DisabledAlpha),
            DisabledContentColor: colors.OnSurface.With(a: DisabledAlpha)
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