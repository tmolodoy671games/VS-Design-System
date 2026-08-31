// ReSharper disable CheckNamespace

using System;
using UnityEngine;

// ReSharper disable ArrangeNamespaceBody

namespace VS.UiToolkit
{
    [CreateAssetMenu(
        menuName = "Scriptable Objects/Ds Theme Config",
        fileName = "Ds Theme Config"
    )]
    public class SerializableDsThemeConfig : ScriptableObject
    {
        [SerializeField] private SerializableColorSchemeConfig colorScheme = new();
        [SerializeField] private SerializableDsTypographyConfig typography = new();
        [SerializeField] private SerializableDsShapesConfig shapes = new();
        [SerializeField] private SerializableDsIconsConfig icons = new();

        public DsThemeConfig ToDsThemeConfig()
        {
            return new DsThemeConfig(
                ColorScheme: colorScheme.ToDsColorSchemeConfig(),
                Typography: typography.ToDsTypographyConfig(),
                Shapes: shapes.ToDsShapesConfig(),
                Icons: icons.ToDsIconsConfig()
            );
        }
    }
}