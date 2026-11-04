using Compose.Net;
using VS.DesignSystem;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.WithThemeFunctions;
using static VS.DesignSystem.NavigationFunctions;

namespace Samples;

public sealed class MenuListState
{
    public readonly IMutableState<int> Selected = MutableStateOf(0);
}

public static partial class MenuListDemo
{
    private static readonly string[] Titles = { "Обзор", "Входящие", "Избранное", "Проекты", "Настройки", "Архив" };
    private static readonly string[] Descriptions = { "Всё важное в одном месте", "Сообщения и обновления", "Сохранённое для вас", "Работа вашей команды", "Подстройте под себя", "Пока недоступен" };

    [Composable] public static void Content(MenuListState state)
    {
        Row(modifier: Modifier.FillMaxSize().TestTag("menu.root"), content: () =>
        {
            WithTheme(theme: LightTheme.Instance, content: () => Panel(state, false, Modifier.Weight(1)));
            WithTheme(theme: DarkTheme.Instance, content: () => Panel(state, true, Modifier.Weight(1)));
        });
    }

    [Composable] private static void Panel(MenuListState state, bool dark, IModifier modifier)
    {
        var theme = CurrentTheme;
        var colors = theme.ColorScheme;
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
                Spacer(Modifier.Height(28.Dp()));
                Column(modifier: Modifier.FillMaxWidth().Background(colors.SurfaceContainer, theme.Shapes.Large)
                    .Padding(10.Dp()), content: () =>
                {
                    for (var i = 0; i < Titles.Length; i++)
                    {
                        var index = i;
                        if (index == 4)
                            Box(modifier: Modifier.FillMaxWidth().Height(1.Dp()).Background(colors.OutlineVariant), content: () => { });
                        MenuItem(onClick: () => state.Selected.Value = index,
                            content: () => Text(Titles[index]),
                            modifier: Modifier.FillMaxWidth().TestTag("menu." + tag + ".item." + index),
                            selected: state.Selected.Value == index, enabled: index != 5,
                            leadingContent: () => Box(modifier: Modifier.Size(28.Dp()), contentAlignment: Alignment.Center,
                                content: () => Text((index + 1).ToString("00"), fontSize: 12.Sp())),
                            supportingContent: () => Text(Descriptions[index]),
                            trailingContent: () => Text(index == 1 ? "12" : index == 5 ? "—" : "›", fontSize: 14.Sp()));
                        if (index < Titles.Length - 1) Spacer(Modifier.Height(4.Dp()));
                    }
                });
                Spacer(Modifier.Height(24.Dp()));
                Text("ОТКРЫТ РАЗДЕЛ", fontSize: 10.Sp(), color: colors.OnSurfaceVariant);
                Spacer(Modifier.Height(8.Dp()));
                Text(Titles[state.Selected.Value], fontSize: 20.Sp(), color: colors.Primary,
                    modifier: Modifier.TestTag("menu." + tag + ".selection"));
                Spacer(Modifier.Height(8.Dp()));
                Text("Выбор синхронизирован в обеих темах", fontSize: 11.Sp(), color: colors.OnSurfaceVariant);
            }));
    }
}
