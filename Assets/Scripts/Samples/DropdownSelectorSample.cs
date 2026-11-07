using Compose.Net;
using StableCollections;
using DropdownSelectorDefaults = Samples.DropdownSelectorDefaults;
using static Compose.Net.ComposeFunctions;
using static StableCollections.StableCollectionsFactory;
using static VS.DesignSystem.WithDsThemeFunctions;
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
        protected override void Content() => Row(
            modifier: Modifier.FillMaxSize(),
            content: () =>
            {
                var panel = Modifier.Weight(1).FillMaxHeight();
                ProvideDsTheme(colorScheme: VS.DesignSystem.DsDarkThemeFunctions.DsDarkTheme.ColorScheme,
                    content: () => SampleContent("Dark theme", panel));
                ProvideDsTheme(colorScheme: VS.DesignSystem.DsLightThemeFunctions.DsLightTheme.ColorScheme,
                    content: () => SampleContent("Light theme", panel));
            });

        [Composable]
        protected override void Preview() => Content();

        [Composable]
        private static void SampleContent(string title, IModifier panel)
        {
            Box(
                modifier: panel.Background(VS.DesignSystem.DsTheme.ColorScheme.Surface),
                contentAlignment: Alignment.Center,
                content: () => Column(
                    modifier: Modifier.Padding(24.Dp()).VerticalScroll(RememberScrollState()),
                    content: () =>
                    {
                        Text("DropdownSelector / " + title, color: VS.DesignSystem.DsTheme.ColorScheme.OnSurface,
                            style: VS.DesignSystem.DsTheme.Typography.HeadlineSmall);
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
                Text(title, color: VS.DesignSystem.DsTheme.ColorScheme.OnSurface, style: VS.DesignSystem.DsTheme.Typography.LabelLarge);
                DropdownSelector(
                    expanded: expanded.Value,
                    onExpandedChange: next => expanded.Value = next,
                    content: () => Text(value.Value),
                    dropdownContent: () =>
                    {
                        foreach (var item in options)
                        {
                            global::Samples.NavigationFunctions.MenuItem(
                                onClick: () =>
                                {
                                    if (!expanded.Value) return;
                                    value.Value = item;
                                    expanded.Value = false;
                                },
                                content: () => Text(item),
                                selected: value.Value == item,
                                colors: global::Samples.MenuItemDefaults.Colors(
                                    selectedContainer: VS.DesignSystem.DsTheme.ColorScheme.PrimaryContainer,
                                    content: custom ? VS.DesignSystem.DsTheme.ColorScheme.OnPrimaryContainer : VS.DesignSystem.DsTheme.ColorScheme.OnSurface,
                                    selectedContent: VS.DesignSystem.DsTheme.ColorScheme.OnPrimaryContainer),
                                modifier: Modifier.FillMaxWidth(),
                                contentPadding: custom ? PaddingValues(horizontal: 16.Dp(), vertical: 6.Dp()) : DropdownSelectorDefaults.ContentPadding);
                        }
                    },
                    enabled: enabled && options.Size > 0,
                    modifier: Modifier.Width(300.Dp()),
                    shape: custom ? VS.DesignSystem.DsTheme.Shapes.ExtraLarge : DropdownSelectorDefaults.Shape,
                    contentPadding: custom ? PaddingValues(horizontal: 16.Dp(), vertical: 6.Dp()) : DropdownSelectorDefaults.ContentPadding,
                    colors: custom ? DropdownSelectorDefaults.Colors(
                        containerColor: VS.DesignSystem.DsTheme.ColorScheme.PrimaryContainer,
                        dropdownColor: VS.DesignSystem.DsTheme.ColorScheme.SecondaryContainer,
                        contentColor: VS.DesignSystem.DsTheme.ColorScheme.OnPrimaryContainer) : DropdownSelectorDefaults.Colors()
                );
                Text("Selected: " + value.Value, color: VS.DesignSystem.DsTheme.ColorScheme.OnSurface,
                    style: VS.DesignSystem.DsTheme.Typography.LabelSmall);
            });
        }
    }
}
