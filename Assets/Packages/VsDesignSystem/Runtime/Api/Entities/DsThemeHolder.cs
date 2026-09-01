// ReSharper disable CheckNamespace

using UnityCompose;

namespace VS.UiToolkit;

public static class DsThemeHolder
{
    private static readonly IMutableState<ThemeConfig> ThemeState = MutableStateOf(new ThemeConfig());
    
    internal static ThemeConfig CurrentTheme => ThemeState.Value;
    
    public static void SetDsTheme(ThemeConfig theme) => ThemeState.Value = theme;
}