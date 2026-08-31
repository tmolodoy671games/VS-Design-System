// ReSharper disable CheckNamespace

using UnityCompose;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    private static readonly ICompositionLocal<DsThemeConfig> LocalTheme = CompositionLocalOf(() => new DsThemeConfig());

    [Composable] public static DsThemeConfig Theme => LocalTheme.Current;

    [Composable]
    public static void WithDsTheme(ComposableContent content)
    {
        CompositionLocalProvider(
            LocalTheme.Provides(DsThemeHolder.CurrentTheme),
            content
        );
    }
}