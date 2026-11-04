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
        protected override void Content() => WithTheme(
            theme: VS.DesignSystem.DarkTheme.Instance,
            content: SampleContent
        );

        [Composable]
        protected override void Preview() => Content();

        [Composable]
        private void SampleContent()
        {
            Box(
                modifier: Modifier.FillMaxSize()
                    .Background(CurrentTheme.ColorScheme.Surface),
                contentAlignment: Alignment.Center,
                content: () =>
                {
                    Column(
                        horizontalAlignment: Alignment.CenterHorizontally,
                        content: () =>
                        {
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
