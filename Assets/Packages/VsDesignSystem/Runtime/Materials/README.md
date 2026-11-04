# Material surfaces

Materials belong to `VS.DesignSystem`. The sample is in
`SampleScene / Samples / Materials`; the standalone explorer is under
`Tools / VS Design System / Material Lab`.

```csharp
Surface(
    material: Materials.Cloth(Weaves.Linen()),
    depth: Depth.Raised(3.Dp()),
    content: () => Text("Linen"));
```

Factories: `Matte`, `Ceramic`, `Paper`, `Cloth`, `Metal`. Cloth weaves:
`Linen`, `Canvas`, `Felt`, `Twill`. `Depth.Flat`, `Raised`, `Inset` and `Floating`
control visual depth without changing layout or hit targets.

Omitted surface colors and shapes resolve from `CurrentTheme` at composition
time. The sample uses the theme's colors, typography and shapes; it has no
independent light/dark palette. The Shape control can explicitly override the
preview's theme shape to inspect a custom corner radius.

Material opacity defaults to `-1f`, resolving `LocalMaterialOpacity.Current`
(default 1) at the application site. Explicit 0–1 replaces that value and never
fades child text. Invalid opacity is rejected. `LocalSurfaceLighting` controls
light direction and intensity. `textureStrength` controls bitmap relief;
`textureScale` is the tile size in Dp (default 256).

Six PNG textures render through `IDrawScope<MeshGenerationContext>` in this
package, with cached relief textures and clipped, atlas-safe tile geometry.
Paper/linen/metal reuse ORBIT assets; canvas/felt/twill were generated for the
material experiment. Import size is 512px. Matte and ceramic reuse paper relief
at low intensity. Directional twill and metal repeat without mirroring.

The Materials scene installer reuses an existing object and panel settings.
Editor validation checks all six resources, opacity validation, scene
idempotence, material/weave changes, stable layout and actual theme color updates.
An explicit project-scoped `vs-materials/<project-folder>/scene.request` in the
OS temp directory accepts `validate`; results are written to `validation.result`.
An empty request installs and saves the sample. Ordinary imports do not alter scenes.
