using UnityCompose;
using UnityEngine;

// ReSharper disable ArrangeNamespaceBody

namespace Samples.Samples.Behaviors
{
    internal partial class SwitchShowcase : ComposeUI
    {
        [Composable]
        protected override void Content()
        {
            WithTheme(() =>
            {
                Box(
                    alignment: Alignment.Center,
                    modifier: Modifier.FillMaxSize(),
                    content: () =>
                    {
                        Column(
                            modifier: Modifier
                                .Background(Theme.ColorScheme.Surface)
                                .Padding(all: 16.Dp())
                                .Clip(RoundedCornerShape(16.Dp())),
                            content: () =>
                            {
                      
                            }
                        );
                    }
                );
            });
        }

        [Composable]
        protected override void Preview() => Content();
    }
}