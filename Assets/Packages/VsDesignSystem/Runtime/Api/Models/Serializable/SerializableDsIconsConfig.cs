// ReSharper disable CheckNamespace

using System;

namespace VS.UiToolkit;

[Serializable]
public class SerializableDsIconsConfig
{
    public IconsConfig ToDsIconsConfig()
    {
        return new IconsConfig();
    }
}