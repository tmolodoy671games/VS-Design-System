namespace VS.DesignSystem;

/// <summary>Maps the VS theme to the shared Compose theme used by Material 3 and custom components.</summary>
public static class ComposeThemeBridge
{
    public static Compose.Net.Theming.ThemeData ToComposeTheme(this Theme theme) => new()
    {
        Colors = new Compose.Net.Theming.ColorScheme
        {
            Primary = theme.ColorScheme.Primary,
            OnPrimary = theme.ColorScheme.OnPrimary,
            PrimaryContainer = theme.ColorScheme.PrimaryContainer,
            OnPrimaryContainer = theme.ColorScheme.OnPrimaryContainer,
            Secondary = theme.ColorScheme.Secondary,
            OnSecondary = theme.ColorScheme.OnSecondary,
            SecondaryContainer = theme.ColorScheme.SecondaryContainer,
            OnSecondaryContainer = theme.ColorScheme.OnSecondaryContainer,
            Tertiary = theme.ColorScheme.Tertiary,
            OnTertiary = theme.ColorScheme.OnTertiary,
            TertiaryContainer = theme.ColorScheme.TertiaryContainer,
            OnTertiaryContainer = theme.ColorScheme.OnTertiaryContainer,
            Error = theme.ColorScheme.Error,
            OnError = theme.ColorScheme.OnError,
            ErrorContainer = theme.ColorScheme.ErrorContainer,
            OnErrorContainer = theme.ColorScheme.OnErrorContainer,
            Background = theme.ColorScheme.Background,
            OnBackground = theme.ColorScheme.OnBackground,
            Surface = theme.ColorScheme.Surface,
            OnSurface = theme.ColorScheme.OnSurface,
            SurfaceVariant = theme.ColorScheme.SurfaceVariant,
            OnSurfaceVariant = theme.ColorScheme.OnSurfaceVariant,
            SurfaceContainerLowest = theme.ColorScheme.SurfaceContainerLowest,
            SurfaceContainerLow = theme.ColorScheme.SurfaceContainerLow,
            SurfaceContainer = theme.ColorScheme.SurfaceContainer,
            SurfaceContainerHigh = theme.ColorScheme.SurfaceContainerHigh,
            SurfaceContainerHighest = theme.ColorScheme.SurfaceContainerHighest,
            Outline = theme.ColorScheme.Outline,
            OutlineVariant = theme.ColorScheme.OutlineVariant,
            InverseSurface = theme.ColorScheme.InverseSurface,
            InverseOnSurface = theme.ColorScheme.InverseOnSurface,
            InversePrimary = theme.ColorScheme.InversePrimary,
            Scrim = theme.ColorScheme.Scrim,
        },
        Typography = new Compose.Net.Theming.Typography
        {
            DisplayLarge = theme.Typography.DisplayLarge,
            DisplayMedium = theme.Typography.DisplayMedium,
            DisplaySmall = theme.Typography.DisplaySmall,
            HeadlineLarge = theme.Typography.HeadlineLarge,
            HeadlineMedium = theme.Typography.HeadlineMedium,
            HeadlineSmall = theme.Typography.HeadlineSmall,
            TitleLarge = theme.Typography.TitleLarge,
            TitleMedium = theme.Typography.TitleMedium,
            TitleSmall = theme.Typography.TitleSmall,
            BodyLarge = theme.Typography.BodyLarge,
            BodyMedium = theme.Typography.BodyMedium,
            BodySmall = theme.Typography.BodySmall,
            LabelLarge = theme.Typography.LabelLarge,
            LabelMedium = theme.Typography.LabelMedium,
            LabelSmall = theme.Typography.LabelSmall,
        },
        Shapes = new Compose.Net.Theming.ThemeShapes
        {
            ExtraSmall = theme.Shapes.ExtraSmall,
            Small = theme.Shapes.Small,
            Medium = theme.Shapes.Medium,
            Large = theme.Shapes.Large,
            ExtraLarge = theme.Shapes.ExtraLarge,
        }
    };
}
