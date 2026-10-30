using Compose.Net;
using Compose.Net.Unity;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

/// <summary>Provides an editable theme in both Play Mode and the editor preview.</summary>
[ExecuteAlways]
public abstract partial class ThemedComposeUI : ComposeUI
{
    [SerializeField] private SerializableTheme? theme;

    private readonly IMutableState<Theme> _theme = MutableStateOf(VS.DesignSystem.Theme.Dark);
    private SerializableTheme? _appliedAsset;
    private int _appliedRevision;
    private bool _initialized;

    public SerializableTheme? ThemeAsset
    {
        get => theme;
        set
        {
            theme = value;
            RefreshTheme();
        }
    }

    protected virtual void Update() => RefreshTheme();

    private void RefreshTheme()
    {
        var revision = theme ? theme.Revision : 0;
        if (_initialized && _appliedAsset == theme && _appliedRevision == revision)
            return;

        _theme.Value = theme ? theme.ToTheme() : VS.DesignSystem.Theme.Dark;
        _appliedAsset = theme;
        _appliedRevision = revision;
        _initialized = true;
    }

    [Composable]
    protected sealed override void Content()
    {
        RefreshTheme();
        var theme = _theme.Value;
        WithTheme(
            colorScheme: theme.ColorScheme,
            shapes: theme.Shapes,
            typography: theme.Typography,
            content: () => Box(
                modifier: Modifier.FillMaxSize().Background(theme.ColorScheme.Surface),
                content: ThemedContent
            )
        );
    }

    [Composable]
    protected sealed override void Preview() => Content();

    [Composable]
    protected abstract void ThemedContent();
}
