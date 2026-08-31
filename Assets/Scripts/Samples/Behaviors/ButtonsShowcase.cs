// ReSharper disable ArrangeNamespaceBody

using Sirenix.OdinInspector;
using UnityCompose;

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
                                .Background(DsTheme.ColorScheme.Surface)
                                .Padding(16.Dp())
                                .Border(16.Dp()),
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