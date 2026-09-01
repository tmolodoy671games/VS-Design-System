// ReSharper disable CheckNamespace

using UnityCompose;

namespace VS.UiToolkit;

public readonly record struct TypographyConfig(
    TextStyle Title,
    TextStyle Control,
    TextStyle Body,
    TextStyle Label
);