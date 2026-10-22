using System;
using Compose.Net;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

public static partial class DesignSystemComposeFunctions
{
    [Composable]
    public static void Button(
        Action onClick,
        [Composable] Action content,
        IModifier? modifier = null,
        bool enabled = true
    )
    {
        Surface(
            onClick: onClick,
            modifier: modifier,
            enabled: enabled,
            content: () =>
            {
                CompositionLocalProvider(
                    LocalContentColor.Provides(default),
                    LocalTextStyle.Provides(Theme.Typography.LabelLarge),
                    content: content
                );
            }
        );
    }
}