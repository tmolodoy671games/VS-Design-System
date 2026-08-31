// ReSharper disable CheckNamespace

using System;
using Sirenix.OdinInspector;
using UnityCompose;
using UnityEngine;

namespace VS.UiToolkit;

[Serializable]
public class SerializableDsShapesConfig
{
    [SerializeField] private SerializableRoundedCornerShape medium = new(16);
    [SerializeField] private SerializableRoundedCornerShape large = new(32);

    public ShapesConfig ToDsShapesConfig()
    {
        return new ShapesConfig(
            Medium: medium.ToRoundedCornerShape(),
            Large: large.ToRoundedCornerShape()
        );
    }
}

[Serializable]
public class SerializableRoundedCornerShape
{
    [SerializeField, Min(0), HorizontalGroup("Top")]
    private int topLeft;

    [SerializeField, Min(0), HorizontalGroup("Top")]
    private int topRight;

    [SerializeField, Min(0), HorizontalGroup("Bottom")]
    private int bottomLeft;

    [SerializeField, Min(0), HorizontalGroup("Bottom")]
    private int bottomRight;

    public SerializableRoundedCornerShape(int radius)
    {
        topLeft = radius;
        topRight = radius;
        bottomLeft = radius;
        bottomRight = radius;
    }

    public RoundedCornerShape ToRoundedCornerShape()
    {
        return new RoundedCornerShape(
            TopLeft: topLeft.Dp(),
            TopRight: topRight.Dp(),
            BottomLeft: bottomLeft.Dp(),
            BottomRight: bottomRight.Dp()
        );
    }
}