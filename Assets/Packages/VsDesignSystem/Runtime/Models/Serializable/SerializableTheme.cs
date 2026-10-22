// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using UnityEngine;
using UnityEngine.Serialization;
// ReSharper disable ArrangeNamespaceBody

namespace VS.DesignSystem
{
    [Serializable]
    public class SerializableTheme
    {
        [SerializeField] private SerializableColorScheme colorScheme = new();
        [SerializeField] private SerializableShapes shapes = new();
        [SerializeField] private SerializableTypography typography = new();

        public Theme ToTheme() => new(
            ColorScheme: colorScheme.ToColorSystem(),
            Shapes: shapes.ToShapes(),
            Typography: typography.ToTypography()
        );
    }
}