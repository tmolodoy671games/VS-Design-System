// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using UnityEngine;

namespace VS.DesignSystem;

[Serializable]
public class SerializableShape
{
    [SerializeField, Min(0)] private float topLeft;
    [SerializeField, Min(0)] private float topRight;
    [SerializeField, Min(0)] private float bottomLeft;
    [SerializeField, Min(0)] private float bottomRight;

    public SerializableShape() { }

    public SerializableShape(float radius)
    {
        topLeft = topRight = bottomLeft = bottomRight = radius;
    }

    public Shape ToShape() => new(
        TopLeft: topLeft.Dp(),
        TopRight: topRight.Dp(),
        BottomLeft: bottomLeft.Dp(),
        BottomRight: bottomRight.Dp()
    );
}

