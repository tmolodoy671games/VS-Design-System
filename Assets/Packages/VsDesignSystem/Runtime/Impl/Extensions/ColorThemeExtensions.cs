using UnityEngine;

namespace VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;

internal static class ColorThemeExtensions
{
    public static Color Disabled(this Color color)
    {
        return color
            .With(s: 0.05f)
            .With(a: 0.4f);
    }

    public static Color DisabledContent(this Color color)
    {
        return color
            .With(s: 0.05f)
            .With(a: 0.4f);
    }
}