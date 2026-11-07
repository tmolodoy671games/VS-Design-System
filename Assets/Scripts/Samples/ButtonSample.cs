using Compose.Net;
using Compose.Net.Unity;
using UnityEngine;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.WithDsThemeFunctions;

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
                ProvideDsTheme(colorScheme: VS.DesignSystem.DsDarkThemeFunctions.DsDarkTheme.ColorScheme,
                    content: () => SampleContent("Dark theme", panel));
                ProvideDsTheme(colorScheme: VS.DesignSystem.DsLightThemeFunctions.DsLightTheme.ColorScheme,
                    content: () => SampleContent("Light theme", panel));
            });

        [Composable]
        protected override void Preview() => Content();

        [Composable]
        private void SampleContent(string title, IModifier panel)
        {
            Box(
                modifier: panel.Background(VS.DesignSystem.DsTheme.ColorScheme.Background),
                contentAlignment: Alignment.Center,
                content: () =>
                {
                    Column(
                        horizontalAlignment: Alignment.CenterHorizontally,
                        content: () =>
                        {
                            Text(title, style: VS.DesignSystem.DsTheme.Typography.TitleLarge, color: VS.DesignSystem.DsTheme.ColorScheme.OnBackground);
                            Spacer(Modifier.Height(20.Dp()));
                            Text("Enabled", color: VS.DesignSystem.DsTheme.ColorScheme.OnSurface);
                            Row(
                                modifier: Modifier.Padding(16.Dp()),
                                verticalAlignment: Alignment.CenterVertically,
                                content: () =>
                                {
                                    DsButton(
                                        onClick: () => Debug.Log("Button clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("Button")
                                    );
                                    DsOutlineButton(
                                        onClick: () => Debug.Log("OutlineButton clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("OutlineButton")
                                    );
                                    DsTextButton(
                                        onClick: () => Debug.Log("TextButton clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("TextButton")
                                    );
                                }
                            );

                            Text("Disabled", color: VS.DesignSystem.DsTheme.ColorScheme.OnSurface);
                            Row(
                                modifier: Modifier.Padding(16.Dp()),
                                verticalAlignment: Alignment.CenterVertically,
                                content: () =>
                                {
                                    DsButton(
                                        onClick: () => Debug.Log("Disabled Button clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("Button"),
                                        enabled: false
                                    );
                                    DsOutlineButton(
                                        onClick: () => Debug.Log("Disabled OutlineButton clicked", this),
                                        modifier: Modifier.Padding(8.Dp()),
                                        content: () => Text("OutlineButton"),
                                        enabled: false
                                    );
                                    DsTextButton(
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
