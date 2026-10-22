using Compose.Net;
using Compose.Net.Unity;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace VS.DesignSystem;

/// <summary>Provides an editable theme in both Play Mode and the editor preview.</summary>
[ExecuteAlways]
public abstract partial class ThemedComposeUI : ComposeUI
{
    [SerializeField] private ThemeAsset? themeAsset;

    private readonly IMutableState<Theme> _theme = MutableStateOf(VS.DesignSystem.Theme.Dark);
    private ThemeAsset? _appliedAsset;
    private int _appliedRevision;
    private bool _initialized;

    public ThemeAsset? ThemeAsset
    {
        get => themeAsset;
        set
        {
            themeAsset = value;
            RefreshTheme();
        }
    }

    protected virtual void Update() => RefreshTheme();

    private void RefreshTheme()
    {
        var revision = themeAsset ? themeAsset.Revision : 0;
        if (_initialized && _appliedAsset == themeAsset && _appliedRevision == revision)
            return;

        _theme.Value = themeAsset ? themeAsset.ToTheme() : VS.DesignSystem.Theme.Dark;
        _appliedAsset = themeAsset;
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
            content: ThemedContent
        );
    }

    [Composable]
    protected sealed override void Preview() => Content();

    [Composable]
    protected abstract void ThemedContent();
}