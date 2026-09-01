// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using Sirenix.OdinInspector;
using UnityCompose;
using UnityEngine;
using FontStyle = UnityCompose.FontStyle;

namespace VS.UiToolkit;

[Serializable]
public class SerializableDsTypographyConfig
{
    [SerializeField] private SerializableTextStyle title = new(48);
    [SerializeField] private SerializableTextStyle control = new(24);
    [SerializeField] private SerializableTextStyle body = new(14);
    [SerializeField] private SerializableTextStyle label = new(8);

    public TypographyConfig ToDsTypographyConfig()
    {
        return new TypographyConfig(
            Title: title.ToTextStyle(),
            Control: control.ToTextStyle(),
            Body: body.ToTextStyle(),
            Label: label.ToTextStyle()
        );
    }
}

[Serializable]
public class SerializableTextStyle
{
    [SerializeField] private float fontSize;
    [SerializeField] private bool hasColor = false;
    [SerializeField, ShowIf(nameof(hasColor))] private Color color;
    [SerializeField] private FontWeight fontWeight;
    [SerializeField] private FontStyle fontStyle;

    public SerializableTextStyle(float fontSize)
    {
        this.fontSize = fontSize;
    }

    public TextStyle ToTextStyle()
    {
        return new TextStyle(
            FontSize: fontSize.Sp(),
            Color: hasColor ? color : Optional.Empty<Color>(),
            FontWeight: fontWeight,
            FontStyle: fontStyle
        );
    }
}