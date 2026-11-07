// ReSharper disable CheckNamespace

using Compose.Net;

namespace VS.DesignSystem;

public readonly record struct DsShapes(
    Shape ExtraSmall,
    Shape Small,
    Shape Medium,
    Shape Large,
    Shape ExtraLarge
)
{
    public DsShapes() : this(RoundedCornerShape(4.Dp()), RoundedCornerShape(8.Dp()), RoundedCornerShape(12.Dp()),
        RoundedCornerShape(16.Dp()), RoundedCornerShape(28.Dp())) { }
}
