// ReSharper disable CheckNamespace

using System;
using Sirenix.OdinInspector;
using UnityCompose;
using UnityEngine;

namespace VS.UiToolkit;

[Serializable]
public class SerializableDsShapesConfig
{
    public ShapesConfig ToDsShapesConfig()
    {
        return new ShapesConfig();
    }
}

[Serializable]
public class SerializableRoundedCornerShape
{
    [SerializeField, Min(0), HorizontalGroup("Top")] private int topLeft;
    [SerializeField, Min(0), HorizontalGroup("Top")] private int topRight;
    [SerializeField, Min(0), HorizontalGroup("Bottom")] private int bottomLeft;
    [SerializeField, Min(0), HorizontalGroup("Bottom")] private int bottomRight;

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