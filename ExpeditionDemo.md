# Fieldwork — VS Design System demo

Open `Tools > VS Design System > Expedition Demo`, or run `SampleScene` with
`Samples/Expedition` enabled. The old Materials object is disabled; Material Lab
remains available from the Tools menu for inspecting individual materials.

- Inventory: category filters, sort dropdown, selection, equipment and loadout progress.
- Map: waypoint selection, zoom and animated travel; location survives tab switches.
- Settings: quality changes drawing detail, theme changes all components, reduced
  motion shortens transitions. Sound, volume, resolution and VSync are session-only
  preferences: this silent demo does not alter the application's display/audio settings.
- State persists for the lifetime of the demo host, not across application launches.

`Tab` and `MenuItem` live in `NavigationFunctions`. They are controlled components
with optional interaction sources and composable content slots. `MenuItem` also
accepts leading, supporting and trailing content. `DropdownSelector` uses MenuItem
for its popup rows, animates opening and closes after selection or outside click.
All colors resolve through the current VS theme; all five materials use normalized
texture contrast. Layout remains independent of material relief and shadow extent.

## Validation

Run the `VS.Expedition.Tests` EditMode assembly in Unity Test Runner. It exercises
native clicks for filters, equipment, all tabs, travel, zoom, dropdown selection,
sound, theme, reset and reduced motion at desktop and 980px widths. Rendering
captures are written to the OS temporary directory under `vs-expedition`.

Compose.Net.Unity uses locally built Compose DLLs in `Assets/Plugins/Compose.Net`,
not NuGet Compose packages. VS Design System references the adjacent adapter
checkout using a relative file UPM dependency. Update DLLs with
`python3 tools/install-local-unity.py <Unity project>` in the Compose.Net repository.

## Linen texture

`Assets/Packages/VsDesignSystem/Runtime/Materials/Resources/VSMaterials/linen.png`
was replaced using the built-in imagegen tool. Mipmaps and trilinear filtering prevent
minification moiré. Generation prompt:

> Create a seamless square grayscale linen fabric material texture for a game UI,
> orthographic macro scan, plain balanced perpendicular warp and weft, fine straight
> taut threads in perfectly straight horizontal and vertical rows. Fabric completely
> flat and stretched. Uniform neutral midgray illumination and exposure over entire
> tile, no folds, no waves, no ripples, no moire, no drape, no large-scale mottling,
> no shadows or highlights except tiny thread-crossing microstructure. Subtle natural
> fiber detail. Tileable all four edges. Texture only, no objects, no border, no text.
