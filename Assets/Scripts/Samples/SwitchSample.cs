using Compose.Net;
using Compose.Net.Unity;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.WithThemeFunctions;

// ReSharper disable ArrangeNamespaceBody

namespace Samples.Samples
{
    public partial class SwitchSample : ComposeUI
    {
        [Composable]
        protected override void Content() => WithTheme(
            theme: VS.DesignSystem.DarkTheme.Instance,
            content: SampleContent
        );

        [Composable]
        protected override void Preview() => Content();

        [Composable]
        private void SampleContent()
        {
            var value = Remember(() => MutableStateOf(false));

            Box(
                modifier: Modifier.FillMaxSize()
                    .Background(CurrentTheme.ColorScheme.Surface),
                contentAlignment: Alignment.Center,
                content: () =>
                {
                    Switch(
                        value: value.Value,
                        onValueChange: newValue => value.Value = newValue
                    );
                }
            );
        }
    }
}
