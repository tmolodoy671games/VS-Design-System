// ReSharper disable CheckNamespace

using System;
using UnityCompose;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    private static readonly ICompositionLocal<DsThemeConfig> LocalTheme =
        CompositionLocalOf<DsThemeConfig>(() => throw new InvalidOperationException("No LocalTheme provided!"));

    [Composable] public static DsThemeConfig DsTheme => LocalTheme.Current;

    [Composable]
    public static void WithDsTheme(ComposableContent content)
    {
        CompositionLocalProvider(
            LocalTheme.Provides(DsThemeHolder.CurrentTheme),
            content
        );
    }
}