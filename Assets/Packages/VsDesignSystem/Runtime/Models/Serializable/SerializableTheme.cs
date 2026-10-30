// ReSharper disable CheckNamespace

using System.Threading;
using UnityEngine;

// ReSharper disable ArrangeNamespaceBody

namespace VS.DesignSystem
{
    [CreateAssetMenu(
        menuName = "Scriptable Objects/Theme",
        fileName = "Theme"
    )]
    public class SerializableTheme : ScriptableObject
    {
        [SerializeField] private SerializableColorScheme colorScheme = new();
        [SerializeField] private SerializableShapes shapes = new();
        [SerializeField] private SerializableTypography typography = new();

        private int _revision;

        public int Revision => Volatile.Read(ref _revision);

        private void OnValidate() => Interlocked.Increment(ref _revision);

        public Theme ToTheme() => new(
            ColorScheme: colorScheme.ToColorSystem(),
            Shapes: shapes.ToShapes(),
            Typography: typography.ToTypography()
        );
    }
}
