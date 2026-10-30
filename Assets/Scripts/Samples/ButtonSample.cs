using Compose.Net;
using ThemedComposeUI = VS.DesignSystem.ThemedComposeUI;
using UnityEngine;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.DesignSystemComposeFunctions;

// ReSharper disable ArrangeNamespaceBody

namespace Samples.Samples
{
    public partial class ButtonSample : ThemedComposeUI
    {
        [Composable]
        protected override void ThemedContent()
        {
            Box(
                modifier: Modifier.FillMaxSize()
                    .Background(Theme.ColorScheme.Surface),
                contentAlignment: Alignment.Center,
                content: () =>
                {
                    Column(
                        horizontalAlignment: Alignment.CenterHorizontally,
                        content: () =>
                        {
                            Text("Enabled", color: Theme.ColorScheme.OnSurface);
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

                            Text("Disabled", color: Theme.ColorScheme.OnSurface);
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
