// ReSharper disable ArrangeNamespaceBody

using System.Reflection.Emit;
using Sirenix.OdinInspector;
using UnityCompose;
using Label = UnityEngine.UIElements.Label;

namespace Samples.Samples.Behaviors
{
    [HideMonoScript]
    internal partial class ButtonsShowcase : ComposeUI
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
                                Button(
                                    onClick: () => { },
                                    content: () => Text("Button")
                                );
                                Spacer(Modifier.Height(12.Dp()));
                                Button(
                                    enabled: false,
                                    onClick: () => { },
                                    content: () => Text("Disabled Button")
                                );

                                Spacer(Modifier.Height(12.Dp()));
                                TextButton(
                                    onClick: () => { },
                                    content: () => Text("TextButton")
                                );
                                Spacer(Modifier.Height(12.Dp()));
                                TextButton(
                                    enabled: false,
                                    onClick: () => { },
                                    content: () => Text("Disabled TextButton")
                                );
                            }
                        );
                    }
                );
            });
        }

        [Composable]
        protected override void Preview()
        {
            Content();
        }
    }
}