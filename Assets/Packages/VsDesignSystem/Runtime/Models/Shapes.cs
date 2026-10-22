// ReSharper disable CheckNamespace

using Compose.Net;

namespace VS.DesignSystem;

public readonly record struct Shapes(
    Shape ExtraSmall,
    Shape Small,
    Shape Medium,
    Shape Large,
    Shape ExtraLarge
);
