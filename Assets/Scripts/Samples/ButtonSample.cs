using Compose.Net;
using Compose.Net.Unity;
using UnityEngine;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.WithThemeFunctions;

// ReSharper disable ArrangeNamespaceBody

namespace Samples.Samples
{
    public partial class ButtonSample : ComposeUI
    {
        [Composable]
        protected override void Content() => Row(
            modifier: Modifier.FillMaxSize(),
            content: () =>
            {
                var panel = Modifier.Weight(1).FillMaxHeight();
                WithTheme(theme: VS.DesignSystem.DarkTheme.Instance,
                    content: () => SampleContent("Dark theme", panel));
                WithTheme(theme: VS.DesignSystem.LightTheme.Instance,
                    content: () => SampleContent("Light theme", panel));
            });

        [Composable]
        protected override void Preview() => Content();

        [Composable]
        private void SampleContent(string title, IModifier panel)
        {
            Box(
                modifier: VS.DesignSystem.MaterialModifierExtensions.Surface(panel,
                    VS.DesignSystem.Materials.Cloth(textureStrength: .16f),
                    VS.DesignSystem.Depth.Flat, CurrentTheme.ColorScheme.Background, RoundedCornerShape(0.Dp())),
                contentAlignment: Alignment.Center,
                content: () =>
                {
                    Column(
                        horizontalAlignment: Alignment.CenterHorizontally,
                        content: () =>
                        {
                            Text(title, style: CurrentTheme.Typography.TitleLarge, color: CurrentTheme.ColorScheme.OnBackground);
                            Spacer(Modifier.Height(20.Dp()));
                            Text("Enabled", color: CurrentTheme.ColorScheme.OnSurface);
                            Row(
                                modifier: Modifier.Padding(16.Dp()),
                                verticalAlignment: Alignment.CenterVertically,
                                content: () =>
                                {
                                    Button(
                                        onClick: () => Debug.Log("Button clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("Button")
                                    );
                                    OutlineButton(
                                        onClick: () => Debug.Log("OutlineButton clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("OutlineButton")
                                    );
                                    TextButton(
                                        onClick: () => Debug.Log("TextButton clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("TextButton")
                                    );
                                }
                            );

                            Text("Disabled", color: CurrentTheme.ColorScheme.OnSurface);
                            Row(
                                modifier: Modifier.Padding(16.Dp()),
                                verticalAlignment: Alignment.CenterVertically,
                                content: () =>
                                {
                                    Button(
                                        onClick: () => Debug.Log("Disabled Button clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("Button"),
                                        enabled: false
                                    );
                                    OutlineButton(
                                        onClick: () => Debug.Log("Disabled OutlineButton clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("OutlineButton"),
                                        enabled: false
                                    );
                                    TextButton(
                                        onClick: () => Debug.Log("Disabled TextButton clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("TextButton"),
                                        enabled: false
                                    );
                                }
                            );
                        }
                    );
                }
            );
        }
    }
}
