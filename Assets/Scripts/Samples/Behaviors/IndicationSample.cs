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
                            .Padding(
                                horizontal: 32.Dp(),
                                vertical: 8.Dp()
                            )
                            .Border(32.Dp())
                            .Background(Color.forestGreen)
                            .DsClickIndication(() => { }),
                        content: () =>
                        {
                            Text(
                                text: "Click me!",
                                fontSize: 64.Sp()
                            );
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