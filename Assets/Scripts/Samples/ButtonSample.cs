using Compose.Net;
using Compose.Net.Unity;
using UnityEngine;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.DesignSystemComposeFunctions;

// ReSharper disable ArrangeNamespaceBody

namespace Samples.Samples
{
    public partial class ButtonSample : ComposeUI
    {
        [Composable]
        protected override void Content()
        {
            WithTheme(content: () =>
            {
                Box(
                    modifier: Modifier.FillMaxSize()
                        .Background(Theme.ColorScheme.Surface),
                    contentAlignment: Alignment.Center,
                    content: () =>
                    {
                        Button(
                            onClick: () => Debug.Log("ButtonSample clicked", this),
                            content: () => Text("Button Sample")
                        );
                    }
                );
            });
        }

        [Composable]
        protected override void Preview() => Content();
    }
}