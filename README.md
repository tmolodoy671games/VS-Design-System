# VS Design System

Design system for Unity UI Toolkit.

## Installation

In Unity, open **Window > Package Manager**, click **+**, select **Add package from git URL**, and paste one of the URLs below.

HTTPS:

```text
https://github.com/tmolodoy671games/VS-Design-System.git?path=/Assets/Packages/VsDesignSystem
```

SSH (requires SSH access to GitHub):

```text
git@github.com:tmolodoy671games/VS-Design-System.git?path=/Assets/Packages/VsDesignSystem
```

The package appears as **VS Design System** in Package Manager.

## Themes

Use `LightTheme.Instance` or `DarkTheme.Instance` with `WithTheme` in any `ComposeUI`:

```csharp
WithTheme(theme: LightTheme.Instance, content: () =>
{
    Text("Hello", color: CurrentTheme.ColorScheme.OnSurface);
});
```

The default is `DarkTheme.Instance`. Create a custom theme with `new Theme(colorScheme, shapes, typography)` or copy a built-in theme:

```csharp
var customTheme = DarkTheme.Instance with
{
    ColorScheme = DarkTheme.Instance.ColorScheme with { Primary = new Color(0.2f, 0.8f, 0.6f, 1f) }
};
WithTheme(theme: customTheme, content: Content);
```

Nested `WithTheme` calls inherit the current theme when `theme` is omitted. The optional `colorScheme`, `shapes`, and `typography` arguments override the selected theme. Use `CurrentTheme` inside the content callback to read the active values.

`WithTheme` also provides the shared `Compose.Net.Theming.AppTheme`. Components
from `Compose.Net.Material3.MaterialComponents` inherit the VS colors, typography
and shapes. Use `Theme.ToComposeTheme()` to obtain an immutable shared theme.
The standalone gallery is available under **Tools > Compose.Net > Material Design**.
