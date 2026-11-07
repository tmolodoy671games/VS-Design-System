using Compose.Net;
using Compose.Net.Unity;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.WithDsThemeFunctions;

// ReSharper disable ArrangeNamespaceBody

namespace Samples.Samples
{
    public partial class SwitchSample : ComposeUI
    {
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
            Column(
                modifier: panel.Background(VS.DesignSystem.DsTheme.ColorScheme.Surface)
                    .VerticalScroll(RememberScrollState()),
                content: () => SampleExamples(title));
        }

        [Composable]
        private static void SampleExamples(string title)
        {
            // Keep the inset inside the viewport so hover scaling and shadows can
            // draw into it without hitting the scroll view's clipping boundary.
            Column(
                modifier: Modifier.FillMaxWidth()
                    .Padding(24.Dp()),
                verticalArrangement: Arrangement.SpacedBy(12.Dp()),
                content: () =>
                {
                    Text("Switch / " + title, style: VS.DesignSystem.DsTheme.Typography.HeadlineSmall,
                        color: VS.DesignSystem.DsTheme.ColorScheme.OnSurface);
                    Description("Independent examples. Click to toggle; hover and hold to inspect animations.");

                    Section("1. Default states", "Each switch owns its value and starts in a different state.");
                    Example("Initially off", initialValue: false);
                    Example("Initially on", initialValue: true);

                    Section("2. Disabled states", "Both values remain visible; disabled switches ignore clicks.");
                    Example("Disabled off", initialValue: false, enabled: false);
                    Example("Disabled on", initialValue: true, enabled: false);

                    Section("3. Thumb content", "The thumb label uses the icon color supplied by Switch.");
                    Example("With 0 / 1 label", initialValue: true, showThumb: true);
                    Example("Disabled with label", initialValue: true, enabled: false, showThumb: true);

                    Section("4. Custom colors", "Secondary colors for on, tertiary colors for off, including the thumb label.");
                    Example("Custom off", initialValue: false, showThumb: true, customColors: true);
                    Example("Custom on", initialValue: true, showThumb: true, customColors: true);
                    Example("Custom disabled off", initialValue: false, enabled: false, showThumb: true, customColors: true);
                    Example("Custom disabled on", initialValue: true, enabled: false, showThumb: true, customColors: true);

                    Section("5. Settings dependency", "Turn notifications off to disable sound. The sound preference is preserved.");
                    SettingsExample();

                    Section("6. Shared state", "Two switches and a button control the same value.");
                    SharedStateExample();

                    Section("7. Interaction source", "Hover, then press and hold the switch to see its interaction state.");
                    InteractionExample();
                });
        }

        [Composable]
        private static void Section(string title, string description)
        {
            Spacer(Modifier.Height(8.Dp()));
            Text(title, style: VS.DesignSystem.DsTheme.Typography.TitleMedium, color: VS.DesignSystem.DsTheme.ColorScheme.OnSurface);
            Description(description);
        }

        [Composable]
        private static void Description(string text) => Text(text,
            style: VS.DesignSystem.DsTheme.Typography.BodySmall, color: VS.DesignSystem.DsTheme.ColorScheme.OnSurfaceVariant);

        [Composable]
        private static void Example(string title, bool initialValue, bool enabled = true,
            bool showThumb = false, bool customColors = false)
        {
            // The initial value is used only when this example enters the composition.
            var value = Remember(() => MutableStateOf(initialValue));
            var scheme = VS.DesignSystem.DsTheme.ColorScheme;
            var colors = customColors
                ? VS.DesignSystem.DsSwitchDefaults.Colors(
                    checkedTrackColor: scheme.Secondary,
                    checkedBorderColor: scheme.Secondary,
                    checkedThumbColor: scheme.OnSecondary,
                    checkedIconColor: scheme.Secondary,
                    uncheckedTrackColor: scheme.TertiaryContainer,
                    uncheckedBorderColor: scheme.Tertiary,
                    uncheckedThumbColor: scheme.OnTertiaryContainer,
                    uncheckedIconColor: scheme.TertiaryContainer,
                    disabledCheckedTrackColor: scheme.Secondary with { Alpha = .12f },
                    disabledCheckedBorderColor: scheme.Secondary with { Alpha = .12f },
                    disabledCheckedThumbColor: scheme.OnSurface with { Alpha = .38f },
                    disabledCheckedIconColor: scheme.Surface,
                    disabledUncheckedTrackColor: scheme.Tertiary with { Alpha = .12f },
                    disabledUncheckedBorderColor: scheme.Tertiary with { Alpha = .12f },
                    disabledUncheckedThumbColor: scheme.OnSurface with { Alpha = .38f },
                    disabledUncheckedIconColor: scheme.Surface)
                : VS.DesignSystem.DsSwitchDefaults.Colors();

            Row(modifier: Modifier.FillMaxWidth().Padding(vertical: 4.Dp()),
                verticalAlignment: Alignment.CenterVertically,
                horizontalArrangement: Arrangement.SpacedBy(16.Dp()),
                content: () =>
                {
                    Column(modifier: Modifier.Weight(1), content: () =>
                    {
                        Text(title, color: scheme.OnSurface, style: VS.DesignSystem.DsTheme.Typography.BodyMedium);
                        Description((value.Value ? "On" : "Off") + (enabled ? " / Enabled" : " / Disabled"));
                    });
                    DsSwitch(value: value.Value,
                        onValueChange: next => value.Value = next,
                        enabled: enabled,
                        colors: colors,
                        thumbContent: () =>
                        {
                            if (showThumb)
                                Text(value.Value ? "1" : "0", style: VS.DesignSystem.DsTheme.Typography.LabelSmall);
                        });
                });
        }

        [Composable]
        private static void SettingsExample()
        {
            var notifications = Remember(() => MutableStateOf(true));
            var sound = Remember(() => MutableStateOf(true));
            Row(verticalAlignment: Alignment.CenterVertically,
                horizontalArrangement: Arrangement.SpacedBy(16.Dp()), content: () =>
                {
                    DsSwitch(value: notifications.Value, onValueChange: next => notifications.Value = next);
                    Text("Notifications", color: VS.DesignSystem.DsTheme.ColorScheme.OnSurface);
                });
            Row(verticalAlignment: Alignment.CenterVertically,
                horizontalArrangement: Arrangement.SpacedBy(16.Dp()), content: () =>
                {
                    DsSwitch(value: sound.Value, onValueChange: next => sound.Value = next,
                        enabled: notifications.Value);
                    Text("Sound", color: VS.DesignSystem.DsTheme.ColorScheme.OnSurface);
                });
            Description(!notifications.Value ? "Notifications are off."
                : sound.Value ? "Notifications with sound." : "Silent notifications.");
        }

        [Composable]
        private static void SharedStateExample()
        {
            var value = Remember(() => MutableStateOf(false));
            var changes = Remember(() => MutableStateOf(0));
            Row(verticalAlignment: Alignment.CenterVertically,
                horizontalArrangement: Arrangement.SpacedBy(16.Dp()), content: () =>
                {
                    DsSwitch(value: value.Value, onValueChange: next =>
                    {
                        value.Value = next;
                        changes.Value++;
                    });
                    DsSwitch(value: value.Value, onValueChange: next =>
                    {
                        value.Value = next;
                        changes.Value++;
                    });
                    DsTextButton(onClick: () =>
                    {
                        value.Value = !value.Value;
                        changes.Value++;
                    }, content: () => Text("Toggle"));
                });
            Description("Shared value: " + (value.Value ? "On" : "Off") + " / Changes: " + changes.Value);
        }

        [Composable]
        private static void InteractionExample()
        {
            var value = Remember(() => MutableStateOf(false));
            // Pass the same remembered source to the switch and the state collectors.
            var source = Remember(MutableInteractionSource);
            var hovered = source.CollectIsHoveredAsState().Value;
            var pressed = source.CollectIsPressedAsState().Value;
            Row(verticalAlignment: Alignment.CenterVertically,
                horizontalArrangement: Arrangement.SpacedBy(16.Dp()), content: () =>
                {
                    DsSwitch(value: value.Value, onValueChange: next => value.Value = next,
                        interactionSource: source);
                    Column(content: () =>
                    {
                        Description("Value: " + (value.Value ? "On" : "Off"));
                        Description("Hovered: " + hovered + " / Pressed: " + pressed);
                    });
                });
        }
    }
}
