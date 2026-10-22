// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using UnityEngine;

namespace VS.DesignSystem;

[Serializable]
public class SerializableTypography
{
    [SerializeField] private SerializableTextStyle displayLarge = new(57);
    [SerializeField] private SerializableTextStyle displayMedium = new(45);
    [SerializeField] private SerializableTextStyle displaySmall = new(36);
    [SerializeField] private SerializableTextStyle headlineLarge = new(32);
    [SerializeField] private SerializableTextStyle headlineMedium = new(28);
    [SerializeField] private SerializableTextStyle headlineSmall = new(24);
    [SerializeField] private SerializableTextStyle titleLarge = new(22);
    [SerializeField] private SerializableTextStyle titleMedium = new(16);
    [SerializeField] private SerializableTextStyle titleSmall = new(14);
    [SerializeField] private SerializableTextStyle bodyLarge = new(16);
    [SerializeField] private SerializableTextStyle bodyMedium = new(14);
    [SerializeField] private SerializableTextStyle bodySmall = new(12);
    [SerializeField] private SerializableTextStyle labelLarge = new(14);
    [SerializeField] private SerializableTextStyle labelMedium = new(12);
    [SerializeField] private SerializableTextStyle labelSmall = new(11);

    public Typography ToTypography() => new(
        DisplayLarge: displayLarge.ToTextStyle(),
        DisplayMedium: displayMedium.ToTextStyle(),
        DisplaySmall: displaySmall.ToTextStyle(),
        HeadlineLarge: headlineLarge.ToTextStyle(),
        HeadlineMedium: headlineMedium.ToTextStyle(),
        HeadlineSmall: headlineSmall.ToTextStyle(),
        TitleLarge: titleLarge.ToTextStyle(),
        TitleMedium: titleMedium.ToTextStyle(),
        TitleSmall: titleSmall.ToTextStyle(),
        BodyLarge: bodyLarge.ToTextStyle(),
        BodyMedium: bodyMedium.ToTextStyle(),
        BodySmall: bodySmall.ToTextStyle(),
        LabelLarge: labelLarge.ToTextStyle(),
        LabelMedium: labelMedium.ToTextStyle(),
        LabelSmall: labelSmall.ToTextStyle()
    );
}

