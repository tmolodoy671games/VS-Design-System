// ReSharper disable CheckNamespace

using Compose.Net;
using SharpExtensions;

namespace VS.DesignSystem;

public static class ColorSchemeExtensions
{
    public static Optional<Color> ContentColorFor(this ColorScheme colorScheme, Color backgroundColor)
    {
        if (backgroundColor == colorScheme.Primary) return Optional.Of(colorScheme.OnPrimary);
        if (backgroundColor == colorScheme.PrimaryContainer) return Optional.Of(colorScheme.OnPrimaryContainer);
        if (backgroundColor == colorScheme.Secondary) return Optional.Of(colorScheme.OnSecondary);
        if (backgroundColor == colorScheme.SecondaryContainer) return Optional.Of(colorScheme.OnSecondaryContainer);
        if (backgroundColor == colorScheme.Tertiary) return Optional.Of(colorScheme.OnTertiary);
        if (backgroundColor == colorScheme.TertiaryContainer) return Optional.Of(colorScheme.OnTertiaryContainer);
        if (backgroundColor == colorScheme.Background) return Optional.Of(colorScheme.OnBackground);
        if (backgroundColor == colorScheme.Surface) return Optional.Of(colorScheme.OnSurface);
        if (backgroundColor == colorScheme.SurfaceVariant) return Optional.Of(colorScheme.OnSurfaceVariant);
        if (backgroundColor == colorScheme.InverseSurface) return Optional.Of(colorScheme.InverseOnSurface);
        if (backgroundColor == colorScheme.Error) return Optional.Of(colorScheme.OnError);
        if (backgroundColor == colorScheme.ErrorContainer) return Optional.Of(colorScheme.OnErrorContainer);
        if (backgroundColor == colorScheme.SurfaceBright) return Optional.Of(colorScheme.OnSurface);
        if (backgroundColor == colorScheme.SurfaceDim) return Optional.Of(colorScheme.OnSurface);
        if (backgroundColor == colorScheme.SurfaceContainer) return Optional.Of(colorScheme.OnSurface);
        if (backgroundColor == colorScheme.SurfaceContainerHigh) return Optional.Of(colorScheme.OnSurface);
        if (backgroundColor == colorScheme.SurfaceContainerHighest) return Optional.Of(colorScheme.OnSurface);
        if (backgroundColor == colorScheme.SurfaceContainerLow) return Optional.Of(colorScheme.OnSurface);
        if (backgroundColor == colorScheme.SurfaceContainerLowest) return Optional.Of(colorScheme.OnSurface);
        return default;
    }
}

public static partial class DesignSystemComposeFunctions
{
    [Composable]
    public static Color ContentColorFor(Color backgroundColor) =>
        ContentColorFor(backgroundColor, Theme.ColorScheme);

    [Composable]
    public static Color ContentColorFor(Color backgroundColor, ColorScheme colorScheme)
    {
        var contentColor = colorScheme.ContentColorFor(backgroundColor);
        return contentColor.GetOrDefault(LocalContentColor.Current);
    }
}

