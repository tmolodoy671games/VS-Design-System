// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using UnityEngine;
using Compose.Net.Unity;
using SharpExtensions;
using UnityColor = UnityEngine.Color;

namespace VS.DesignSystem;

[Serializable]
public class SerializableTextStyle
{
    [SerializeField, Min(0)] private float fontSize = 14;
    [SerializeField] private bool overrideColor;
    [SerializeField] private UnityColor color = UnityColor.black;
    [SerializeField] private FontWeight fontWeight;
    [SerializeField] private Compose.Net.FontStyle fontStyle;

    public SerializableTextStyle() { }

    public SerializableTextStyle(float fontSize)
    {
        this.fontSize = fontSize;
    }

    public TextStyle ToTextStyle() => new(
        FontSize: fontSize.Sp(),
        Color: overrideColor ? Optional.Of(color.ToComposeColor()) : default,
        FontWeight: fontWeight,
        FontStyle: fontStyle
    );
}

