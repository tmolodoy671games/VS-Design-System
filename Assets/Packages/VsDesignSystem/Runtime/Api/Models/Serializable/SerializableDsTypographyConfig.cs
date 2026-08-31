// ReSharper disable CheckNamespace

using System;

namespace VS.UiToolkit;

[Serializable]
public class SerializableDsTypographyConfig
{
    public TypographyConfig ToDsTypographyConfig()
    {
        return new TypographyConfig();
    }
}