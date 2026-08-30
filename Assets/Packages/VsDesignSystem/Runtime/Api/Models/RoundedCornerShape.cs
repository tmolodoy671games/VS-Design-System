// ReSharper disable CheckNamespace

using UnityCompose;

namespace VS.UiToolkit;

public readonly record struct RoundedCornerShape(
    Dp TopLeft,
    Dp TopRight,
    Dp BottomLeft,
    Dp BottomRight
)
{
    public RoundedCornerShape(Dp all) : this(all, all, all, all)
    {
    }
}