// ReSharper disable CheckNamespace

using UnityCompose;

namespace VS.UiToolkit;

/// <summary>
/// 
/// </summary>
/// <param name="LabelLarge">Buttons</param>
public readonly record struct TypographyConfig(
    TextStyle LabelLarge
)
{
    public static TypographyConfig Default = new(
        LabelLarge: new TextStyle(
            FontSize: 14.Sp()
        )
    );
}