using System.Threading;
using UnityEngine;

namespace VS.DesignSystem;

[CreateAssetMenu(menuName = "VS Design System/Theme", fileName = "Theme")]
public sealed class ThemeAsset : ScriptableObject
{
    [SerializeField] private SerializableTheme theme = new();

    private int _revision;

    public int Revision => Volatile.Read(ref _revision);

    public Theme ToTheme() => theme.ToTheme();

    private void OnValidate() => Interlocked.Increment(ref _revision);
}
