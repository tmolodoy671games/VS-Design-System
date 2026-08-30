using UnityEngine;

namespace VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;

internal static class ColorExtensions
{
    public static Color With(
        this Color color,
        float r = -1,
        float g = -1,
        float b = -1,
        float a = -1,
        float h = -1,
        float s = -1,
        float v = -1
    )
    {
        if (h >= 0 || s >= 0 || v >= 0)
        {
            return Color.HSVToRGB(
                H: h > 0 ? h : color.Hue(),
                S: s > 0 ? s : color.Saturation(),
                V: v > 0 ? v : color.Value()
            ).With(a: a < 0 ? color.a : a);
        }

        return new Color(
            r: r < 0 ? color.r : r,
            g: g < 0 ? color.g : g,
            b: b < 0 ? color.b : b,
            a: a < 0 ? color.a : a
        );
    }
    
    public static float Hue(this Color color)
    {
        Color.RGBToHSV(color, out var h, out var s, out var v);
        return h;
    }
    
    public static float Value(this Color color)
    {
        Color.RGBToHSV(color, out var h, out var s, out var v);
        return v;
    }
    
    public static float Saturation(this Color color)
    {
        Color.RGBToHSV(color, out var h, out var s, out var v);
        return s;
    }
    
    public static Color Multiply(this Color color, float factor)
    {
        return new Color(
            r: color.r * factor,
            g: color.g * factor,
            b: color.b * factor,
            a: color.a
        );
    }
}