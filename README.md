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

## DS tabs

`DsTabsRow(content, modifier, level)` moves one indicator between its `DsTab`
children. Selection is controlled by each tab's `selected` and `onClick`; no row
selection index is needed. Set exactly one tab selected. `DsTabLevel.High` uses
56 dp tabs, while `Low` uses compact 40 dp tabs for nested navigation. Each row
keeps its own selection and measurements. The indicator follows the selected
child's actual width, including after resizing; use `Modifier.Weight(1)` for
equal-width tabs.

```csharp
var selected = Remember(() => MutableStateOf(0));
DsTabsRow(content: () =>
{
    DsTab(selected.Value == 0, () => selected.Value = 0,
        modifier: Modifier.Weight(1), text: () => Text("Overview"));
    DsTab(selected.Value == 1, () => selected.Value = 1,
        modifier: Modifier.Weight(1), text: () => Text("Projects"));
});
```

## Unity previews

`Assets/Scripts/Samples/Editor/DesignSystemPreviews.cs` contains **VS / Design system —
Light & Dark**, a complete overview, plus focused **VS / Colors — Light & Dark**
and **VS / Components — Light & Dark** previews. Open their UnityPreview
entry from Unity or the Rider gutter. Both themes appear side by side with
independent scrolling. Colors are labelled with role names and hex values:
accent colors sit inside their containers, surface levels nest from lowest to
highest, and inverse, border, tint and scrim roles are shown in context.
The component preview includes all DS components, disabled controls, switch
thumb content, both tab levels and tabs with unequal widths.
