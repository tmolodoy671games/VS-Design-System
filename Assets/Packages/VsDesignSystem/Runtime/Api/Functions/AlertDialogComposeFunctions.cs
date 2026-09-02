// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static void AlertDialog(
        Action onDismiss,
        ComposableContent confirmButton,
        ComposableContent? title = null,
        ComposableContent? text = null,
        ComposableContent? actionButton = null,
        ComposableContent? dismissButton = null,
        IModifier? modifier = null,
        Optional<DialogProperties> properties = default
    )
    {
        var resolvedProperties = properties.GetOrDefault(new DialogProperties(
            DismissOnBackPress: true,
            DismissOnClickOutside: true
        ));
        var theme = LocalTheme.Current;
        var colors = theme.ColorScheme;
        var typography = theme.Typography;

        Box(
            modifier: Modifier.FillMaxSize()
                .OnClick(enabled: resolvedProperties.DismissOnClickOutside, onClick: onDismiss),
            content: () =>
            {
                Surface(
                    modifier: modifier.OrEmpty()
                        .Clip(RoundedCornerShape(16.Dp()))
                        .Padding(all: 16.Dp()),
                    content: () =>
                    {
                        Column(
                            horizontalAlignment: Alignment.CenterHorizontally,
                            content: () =>
                            {
                                if (title != null)
                                {
                                    CompositionLocalProvider(
                                        LocalTextStyle.Provides(typography.Title),
                                        content: title
                                    );
                                }
                                
                                if (text != null)
                                {
                                    CompositionLocalProvider(
                                        LocalTextStyle.Provides(typography.Body),
                                        content: text
                                    );
                                }
                            }
                        );
                    }
                );
            }
        );
    }
}

public readonly record struct DialogProperties(
    bool DismissOnBackPress,
    bool DismissOnClickOutside
);