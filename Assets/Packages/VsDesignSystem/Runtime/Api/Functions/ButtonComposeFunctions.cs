// ReSharper disable CheckNamespace

using System;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
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
        IModifier? modifier = null
    )
    {
        const float disabledAlpha = 0.38f;
        interactionSource ??= Remember(MutableInteractionSource);
        var colors = DsTheme.ColorScheme;
        var isHovered = interactionSource.CollectIsHoveredAsState().Value;
        var isPressed = interactionSource.CollectIsPressedAsState().Value;
        var contentBackground = AnimateColorAsState(enabled
            ? colors.Primary
            : colors.OnSurface.With(a: disabledAlpha)
        ).Value;
        Box(
            alignment: Alignment.Center,
            modifier: modifier.OrEmpty()
                .Padding(
                    horizontal: 16.Dp(),
                    vertical: 4.Dp()
                )
                .Scale(AnimateFloatAsState(isHovered ? 1.1f : 1f).Value)
                .Border(8.Dp())
                .Background(contentBackground)
                .DsClickIndication(
                    enabled: enabled,
                    onClick: onClick,
                    interactionSource: interactionSource
                ),
            content: () =>
            {
                var contentTint = AnimateColorAsState(enabled
                    ? colors.OnPrimary
                    : colors.OnSurface.With(a: disabledAlpha)
                ).Value;
                CompositionLocalProvider(
                    LocalContentColor.Provides(contentTint),
                    () =>
                    {
                        Box(
                            modifier: Modifier
                                .Scale(AnimateFloatAsState(isPressed ? 0.75f : 1f).Value),
                            content: content
                        );
                    }
                );
            }
        );
    }
}