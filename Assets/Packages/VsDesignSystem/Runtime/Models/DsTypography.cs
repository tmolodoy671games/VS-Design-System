// ReSharper disable CheckNamespace

using Compose.Net;

namespace VS.DesignSystem;

public readonly record struct DsTypography(
    TextStyle DisplayLarge,
    TextStyle DisplayMedium,
    TextStyle DisplaySmall,
    TextStyle HeadlineLarge,
    TextStyle HeadlineMedium,
    TextStyle HeadlineSmall,
    TextStyle TitleLarge,
    TextStyle TitleMedium,
    TextStyle TitleSmall,
    TextStyle BodyLarge,
    TextStyle BodyMedium,
    TextStyle BodySmall,
    TextStyle LabelLarge,
    TextStyle LabelMedium,
    TextStyle LabelSmall
)
{
    public DsTypography() : this(new TextStyle(57.Sp()), new TextStyle(45.Sp()), new TextStyle(36.Sp()), new TextStyle(32.Sp()), new TextStyle(28.Sp()), new TextStyle(24.Sp()), new TextStyle(22.Sp()), new TextStyle(16.Sp()), new TextStyle(14.Sp()), new TextStyle(16.Sp()), new TextStyle(14.Sp()), new TextStyle(12.Sp()), new TextStyle(14.Sp()), new TextStyle(12.Sp()), new TextStyle(11.Sp())) { }
}
