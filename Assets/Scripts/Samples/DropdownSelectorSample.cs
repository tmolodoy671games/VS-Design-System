using Compose.Net;
using StableCollections;
using DropdownSelectorDefaults = VS.DesignSystem.DropdownSelectorDefaults;
using static Compose.Net.ComposeFunctions;
using static StableCollections.StableCollectionsFactory;
using static VS.DesignSystem.WithThemeFunctions;
using Compose.Net.Unity;

namespace Samples.Samples
{
    public partial class DropdownSelectorSample : ComposeUI
    {
        private static readonly IStableList<string> Options = MutableStableListOf("Low", "Medium", "High", "Ultra");
        private static readonly IStableList<string> ManyOptions = MutableStableListOf(
            "Option 01", "Option 02", "Option 03", "Option 04", "Option 05", "Option 06",
            "Option 07", "Option 08", "Option 09", "Option 10", "Option 11", "Option 12");
        private static readonly IStableList<string> EmptyOptions = MutableStableListOf<string>();

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
            Box(
                modifier: Modifier.FillMaxSize().Background(CurrentTheme.ColorScheme.Surface),
                contentAlignment: Alignment.Center,
                content: () => Column(
                    modifier: Modifier.Padding(24.Dp()).VerticalScroll(RememberScrollState()),
                    content: () =>
                    {
                        Text("DropdownSelector", color: CurrentTheme.ColorScheme.OnSurface,
                            style: CurrentTheme.Typography.HeadlineSmall);
                        Example("Default", Options);
                        Example("Custom colors, shape and padding", Options, custom: true);
                        Example("Disabled", Options, enabled: false);
                        Example("Empty list", EmptyOptions);
                        Example("Scrollable list", ManyOptions);
                    }
                )
            );
        }

        [Composable]
        private static void Example(string title, IStableList<string> options, bool enabled = true, bool custom = false)
        {
            var value = Remember(() => MutableStateOf(options.Size > 0 ? options[0] : "No options"));
            var expanded = Remember(() => MutableStateOf(false));
            Column(modifier: Modifier.Padding(vertical: 8.Dp()), content: () =>
            {
                Text(title, color: CurrentTheme.ColorScheme.OnSurface, style: CurrentTheme.Typography.LabelLarge);
                DropdownSelector(
                    value: value.Value,
                    expanded: expanded.Value,
                    onExpandedChange: next => expanded.Value = next,
                    onValueChange: next => value.Value = next,
                    values: options,
                    content: item => Text(item),
                    enabled: enabled,
                    modifier: Modifier.Width(300.Dp()),
                    shape: custom ? CurrentTheme.Shapes.ExtraLarge : DropdownSelectorDefaults.Shape,
                    contentPadding: PaddingValues(horizontal: custom ? 24.Dp() : 16.Dp(), vertical: 12.Dp()),
                    colors: custom ? DropdownSelectorDefaults.Colors(
                        containerColor: CurrentTheme.ColorScheme.PrimaryContainer,
                        dropdownColor: CurrentTheme.ColorScheme.SecondaryContainer,
                        contentColor: CurrentTheme.ColorScheme.OnPrimaryContainer) : DropdownSelectorDefaults.Colors()
                );
                Text("Selected: " + value.Value, color: CurrentTheme.ColorScheme.OnSurface,
                    style: CurrentTheme.Typography.LabelSmall);
            });
        }
    }
}
