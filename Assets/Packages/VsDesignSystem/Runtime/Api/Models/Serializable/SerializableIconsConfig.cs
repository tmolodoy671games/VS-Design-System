// ReSharper disable CheckNamespace

using System;
using UnityEngine;

namespace VS.UiToolkit;

[Serializable]
public class SerializableIconsConfig
{
    [SerializeField] private Sprite arrowSmall = null!;

    public IconsConfig ToDsIconsConfig()
    {
        return new IconsConfig(
            ArrowSmall: arrowSmall
        );
    }
}