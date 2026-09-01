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
    }
}

public readonly record struct DialogProperties(
    bool DismissOnBackPress,
    bool DismissOnClickOutside
);