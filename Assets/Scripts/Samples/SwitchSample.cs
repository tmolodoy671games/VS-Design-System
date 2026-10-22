using Compose.Net;
using ThemedComposeUI = VS.DesignSystem.ThemedComposeUI;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.DesignSystemComposeFunctions;

// ReSharper disable ArrangeNamespaceBody

namespace Samples.Samples
{
    public partial class SwitchSample : ThemedComposeUI
    {
        [Composable]
        protected override void ThemedContent()
        {
            var value = Remember(() => MutableStateOf(false));

            Box(
                modifier: Modifier.FillMaxSize()
                    .Background(Theme.ColorScheme.Surface),
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
