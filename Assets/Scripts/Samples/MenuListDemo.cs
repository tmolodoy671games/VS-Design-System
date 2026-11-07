using Compose.Net;
using VS.DesignSystem;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.WithDsThemeFunctions;
using static Samples.NavigationFunctions;

namespace Samples;

public sealed class MenuListState
{
    public readonly IMutableState<int> Selected = MutableStateOf(0);
    public readonly IMutableState<int> Primary = MutableStateOf(0);
    public readonly IMutableState<int> Secondary = MutableStateOf(0);
}

public static partial class MenuListDemo
{
    private static readonly string[] Titles = { "Обзор", "Входящие", "Избранное", "Проекты", "Настройки", "Архив" };

    [Composable] public static void Content(MenuListState state)
    {
        Row(modifier: Modifier.FillMaxSize().TestTag("menu.root"), content: () =>
        {
            ProvideDsTheme(colorScheme: VS.DesignSystem.DsLightThemeFunctions.DsLightTheme.ColorScheme, content: () => Panel(state, false, Modifier.Weight(1)));
            ProvideDsTheme(colorScheme: VS.DesignSystem.DsDarkThemeFunctions.DsDarkTheme.ColorScheme, content: () => Panel(state, true, Modifier.Weight(1)));
        });
    }

    [Composable] private static void Panel(MenuListState state, bool dark, IModifier modifier)
    {
        var colors = VS.DesignSystem.DsTheme.ColorScheme;
                var tag = dark ? "dark" : "light";
        CompositionLocalProvider(LocalContentColor.Provides(colors.OnSurface), content: () =>
            Column(modifier: modifier.FillMaxHeight().Background(colors.Surface).Padding(28.Dp())
                .TestTag("menu." + tag), content: () =>
            {
                Text(dark ? "02 / ТЁМНАЯ" : "01 / СВЕТЛАЯ", fontSize: 11.Sp(), color: colors.OnSurfaceVariant);
                Spacer(Modifier.Height(12.Dp()));
                Text("Ваше пространство", fontSize: 26.Sp());
                Spacer(Modifier.Height(8.Dp()));
                Text("Меню навигации", fontSize: 14.Sp(), color: colors.OnSurfaceVariant);
                Spacer(Modifier.Height(16.Dp()));
                TabRow(new[] { "Пространство", "Команда" }, state.Primary.Value,
                    index => state.Primary.Value = index, testTag: "menu." + tag + ".primary");
                Spacer(Modifier.Height(8.Dp()));
                TabRow(state.Primary.Value == 0 ? new[] { "Личное", "Общее", "Недавнее" } : new[] { "Люди", "Роли", "Запросы" },
                    state.Secondary.Value, index => state.Secondary.Value = index,
                    level: TabLevel.Secondary, testTag: "menu." + tag + ".secondary");
                Spacer(Modifier.Height(16.Dp()));
                Menu(state, tag);
                Spacer(Modifier.Height(24.Dp()));
                Text("ОТКРЫТ РАЗДЕЛ", fontSize: 10.Sp(), color: colors.OnSurfaceVariant);
                Spacer(Modifier.Height(8.Dp()));
                Text(Titles[state.Selected.Value], fontSize: 20.Sp(), color: colors.Primary,
                    modifier: Modifier.TestTag("menu." + tag + ".selection"));
                Spacer(Modifier.Height(8.Dp()));
                Text("Выбор синхронизирован в обеих темах", fontSize: 11.Sp(), color: colors.OnSurfaceVariant);
            }));
    }

    [Composable] private static void Menu(MenuListState state, string tag)
    {
        MenuList(testTag: "menu." + tag, content: () =>
        {
            for (var i = 0; i < Titles.Length; i++)
            {
                var index = i;
                Item(state, tag, index);
                if (index < Titles.Length - 1) Spacer(Modifier.Height(4.Dp()));
            }
        });
    }

    [Composable] private static void Item(MenuListState state, string tag, int index)
    {
        var enabled = index != 5;
        var source = Remember(MutableInteractionSource);
        var hovered = source.CollectIsHoveredAsState().Value && enabled;
        var progress = AnimateFloatAsState(hovered ? 1f : 0f, NavigationDefaults.Motion).Value;
        var padding = PaddingValues(horizontal: (14f + 6f * progress).Dp(), vertical: 8.Dp());
        MenuItem(onClick: () => state.Selected.Value = index,
            content: () => Text(Titles[index], softWrap: false),
            modifier: Modifier.FillMaxWidth().TestTag("menu." + tag + ".item." + index),
            selected: state.Selected.Value == index, enabled: enabled,
            interactionSource: source, contentPadding: padding,
            leadingContent: () => Box(modifier: Modifier.Size(28.Dp()), contentAlignment: Alignment.Center,
                content: () => Text((index + 1).ToString("00"), fontSize: 12.Sp(), softWrap: false)),
            trailingContent: () => Text(index == 1 ? "12" : index == 5 ? "—" : "›",
                fontSize: 14.Sp(), softWrap: false));
    }
}
