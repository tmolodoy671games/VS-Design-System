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

`ProvideDsTheme` scopes colors, shapes and typography to its content. Omitted values
inherit the surrounding theme; the root defaults to the dark VS theme.

```csharp
using static VS.DesignSystem.WithDsThemeFunctions;

ProvideDsTheme(
    colorScheme: DsLightThemeFunctions.DsLightTheme.ColorScheme,
    content: () => Text("Hello", color: DsTheme.ColorScheme.OnSurface));
```

Read current tokens through `DsTheme.ColorScheme`, `DsTheme.Typography` and
`DsTheme.Shapes`. Customize immutable tokens with `with`:

```csharp
ProvideDsTheme(
    colorScheme: DsTheme.ColorScheme with { Primary = new Color(0.2f, 0.8f, 0.6f, 1f) },
    content: Content);
```

`MaterialTheme` in `Compose.Net.Material3` exposes the same three token getters and
a `MaterialTheme(content, colorScheme, shapes, typography)` composable. Its scope is
independent of VS themes; configure both explicitly when mixing their components.
The Material gallery is available under **Tools > Compose.Net > Material Design**.

## Samples

Open **Tools > VS Design System > Menu List** for tabs and a navigation menu in
synchronized light and dark themes. Showcase navigation and dropdown controls live
in the `Samples` assembly. `TabRow` has primary and secondary levels; `MenuList`
shares a moving selection indicator across its controlled `MenuItem` rows.

Surface materials, texture settings and material modifiers have been removed.
`DsSurface` draws a solid themed background. The former material gallery shows
surface and accent color roles in both themes.
