// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using UnityEngine;

namespace VS.DesignSystem;

[Serializable]
public class SerializableShapes
{
    [SerializeField] private SerializableShape extraSmall = new(4);
    [SerializeField] private SerializableShape small = new(8);
    [SerializeField] private SerializableShape medium = new(12);
    [SerializeField] private SerializableShape large = new(16);
    [SerializeField] private SerializableShape extraLarge = new(28);

    public Shapes ToShapes() => new(
        ExtraSmall: extraSmall.ToShape(),
        Small: small.ToShape(),
        Medium: medium.ToShape(),
        Large: large.ToShape(),
        ExtraLarge: extraLarge.ToShape()
    );
}

