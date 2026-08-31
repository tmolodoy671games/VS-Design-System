// ReSharper disable CheckNamespace

using UnityCompose;

namespace VS.UiToolkit;

/// <summary>
/// 
/// </summary>
/// <param name="Medium">Buttons</param>
public record ShapesConfig(
    RoundedCornerShape Medium,
    RoundedCornerShape Large
)
{
    public static readonly ShapesConfig Default = new(
        Medium: new RoundedCornerShape(16.Dp()),
        Large: new RoundedCornerShape(64.Dp())
    );
}