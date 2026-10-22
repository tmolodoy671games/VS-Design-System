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
                    Button(
                        onClick: () => Debug.Log("ButtonSample clicked", this),
                        content: () => Text("Button Sample")
                    );
                }
            );
        }
    }
}
