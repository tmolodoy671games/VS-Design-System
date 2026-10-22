using System;
using Compose.Net;

namespace VS.UiToolkit.Packages.VsDesignSystem.Runtime;

public static partial class DesignSystemComposeFunctions
{
    [Composable]
    public static void Button(
        Action onClick,
        [Composable] Action content
    )
    {
    }
}