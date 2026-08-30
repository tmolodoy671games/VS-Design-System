// ReSharper disable ArrangeNamespaceBody

using UnityCompose;
using UnityEngine;
using VS.UiToolkit;

namespace Samples.Samples.Behaviors
{
    internal partial class IndicationSample : ComposeUI
    {
        [Composable]
        protected override void Content()
        {
            Box(
                alignment: Alignment.Center,
                modifier: Modifier.FillMaxSize(),
                content: () =>
                {
                    Box(
                        alignment: Alignment.Center,
                        modifier: Modifier
                            .Width(100.Dp())
                            .Height(40.Dp())
                            .Border(16.Dp())
                            .Background(Color.forestGreen)
                            .DsHoverIndication(),
                        content: () =>
                        {
                            Text("Click me!");
                        }
                    );
                }
            );
        }

        [Composable]
        protected override void Preview()
        {
            Content();
        }
    }
}