// ReSharper disable CheckNamespace

using UnityCompose;

namespace VS.UiToolkit;

public static class DsThemeHolder
{
    private static readonly IMutableState<DsThemeConfig> ThemeState = MutableStateOf(DsThemeConfig.LightTheme);
    
    internal static DsThemeConfig CurrentTheme => ThemeState.Value;
    
    public static void SetDsTheme(DsThemeConfig theme) => ThemeState.Value = theme;
}