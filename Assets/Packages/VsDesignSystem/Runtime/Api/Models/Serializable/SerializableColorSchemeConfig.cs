// ReSharper disable CheckNamespace

using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace VS.UiToolkit;

[Serializable]
public class SerializableColorSchemeConfig
{
    public ColorSchemeConfig ToDsColorSchemeConfig()
    {
        return new ColorSchemeConfig();
    }
}