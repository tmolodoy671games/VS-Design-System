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
            WithDsTheme(() =>
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
                                var isChecked = Remember(() => MutableStateOf(true));
                                Switch(
                                    isChecked: isChecked.Value,
                                    onCheckedChange: it => isChecked.Value = it
                                );
                                Spacer(Modifier.Height(12.Dp()));
                                Switch(
                                    isChecked: false,
                                    onCheckedChange: _ => { }
                                );
                                Spacer(Modifier.Height(12.Dp()));
                                Switch(
                                    isChecked: true,
                                    onCheckedChange: _ => { },
                                    enabled: false
                                );
                                Spacer(Modifier.Height(12.Dp()));
                                Switch(
                                    isChecked: false,
                                    onCheckedChange: _ => { },
                                    enabled: false
                                );
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