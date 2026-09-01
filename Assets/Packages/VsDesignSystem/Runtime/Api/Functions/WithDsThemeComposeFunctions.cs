// ReSharper disable CheckNamespace

using System;
using UnityCompose;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    private static readonly ICompositionLocal<ThemeConfig> LocalTheme =
        CompositionLocalOf<ThemeConfig>(() => throw new InvalidOperationException("No LocalTheme provided!"));

    [Composable] public static ThemeConfig Theme => LocalTheme.Current;

    [Composable]
    public static void WithTheme(ComposableContent content)
    {
        CompositionLocalProvider(
            LocalTheme.Provides(DsThemeHolder.CurrentTheme),
            content
        );
    }
}