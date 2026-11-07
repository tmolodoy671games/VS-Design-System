// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using SharpExtensions;
using Unity.Scripting.LifecycleManagement;

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
[NoAutoStaticsCleanup]
public static partial class DsTabFunctions
{
    private static readonly ICompositionLocal<TabRowScope> LocalTabRow =
        CompositionLocalOf(() => new TabRowScope(null, DsTabLevel.High));

    /// <summary>A controlled tab. Its enclosing DsTabsRow supplies the size and selection indicator.</summary>
    [Composable]
    public static void DsTab(
        bool selected,
        Action onClick,
        IModifier? modifier = null,
        bool enabled = true,
        [Composable] Action? text = null,
        [Composable] Action? icon = null,
        Color selectedContentColor = default,
        Color unselectedContentColor = default,
        IMutableInteractionSource? interactionSource = null
    )
    {
        var scope = LocalTabRow.Current;
        var high = scope.Level == DsTabLevel.High;
        var colors = DsTheme.ColorScheme;
        var foreground = selected
            ? selectedContentColor.GetOrDefault(colors.Primary)
            : unselectedContentColor.GetOrDefault(colors.OnSurfaceVariant);
        if (!enabled) foreground = foreground with { Alpha = foreground.Alpha * .38f };
        var contentColor = AnimateColorAsState(foreground, Tween(180)).Value;
        var bounds = Remember(() => MutableStateOf(default(Compose.Net.Rect)));
        var owner = Remember(() => new object());
        var row = scope.State;
        if (row != null)
        {
            DisposableEffect((row, selected), () =>
            {
                if (selected) row.Selection.Value = new TabSelection(owner, bounds);
                return OnDispose(() =>
                {
                    if (ReferenceEquals(row.Selection.Value?.Owner, owner))
                        row.Selection.Value = null;
                });
            });
        }

        CompositionLocalProvider(
            LocalContentColor.Provides(contentColor),
            LocalTextStyle.Provides(high ? DsTheme.Typography.TitleSmall : DsTheme.Typography.LabelLarge),
            content: () => Row(
                modifier: modifier.OrEmpty()
                    .Height(high ? 56.Dp() : 40.Dp())
                    .OnGloballyPositioned(c => bounds.Value = new Compose.Net.Rect(c.LocalToRoot(default), c.Size))
                    .Clickable(onClick, LocalIndication.Current, interactionSource, enabled)
                    .Padding(horizontal: high ? 24.Dp() : 16.Dp()),
                horizontalArrangement: Arrangement.SpacedBy(high ? 8.Dp() : 6.Dp(), Alignment.CenterHorizontally),
                verticalAlignment: Alignment.CenterVertically,
                content: () =>
                {
                    icon?.Invoke();
                    text?.Invoke();
                }));
    }

    /// <summary>Place DsTab children here, with exactly one selected tab. Each row owns its indicator.</summary>
    /// <remarks>Use Modifier.Weight(1) on tabs for equal widths, or leave them sized to their content.</remarks>
    [Composable]
    public static void DsTabsRow(
        [Composable, RowScope] Action content,
        IModifier? modifier = null,
        DsTabLevel level = DsTabLevel.High
    )
    {
        var state = Remember(() => new TabRowState());
        Box(modifier: modifier.OrEmpty().FillMaxWidth()
                .OnGloballyPositioned(c => state.Origin.Value = c.LocalToRoot(default)),
            content: () =>
            {
                CompositionLocalProvider(LocalTabRow.Provides(new TabRowScope(state, level)),
                    content: () => Row(content: content, modifier: Modifier.FillMaxWidth(),
                        verticalAlignment: Alignment.CenterVertically));

                var selection = state.Selection.Value;
                if (selection != null && selection.Bounds.Value.Size.Width > 0f)
                {
                    var bounds = selection.Bounds.Value;
                    DsTabSelectionIndicator(bounds.Offset.X - state.Origin.Value.X,
                        bounds.Size.Width, level);
                }
            });
    }

    [Composable, BoxScope]
    private static void DsTabSelectionIndicator(float left, float width, DsTabLevel level)
    {
        var density = LocalDensity.Current;
        var motion = Tween(280, easing: EaseOutEasing);
        var x = AnimateFloatAsState(left, motion).Value;
        var w = AnimateFloatAsState(width, motion).Value;
        Box(modifier: Modifier.Align(Alignment.BottomStart)
            .Offset(x: density.ToDp(x))
            .Width(density.ToDp(w))
            .Height(level == DsTabLevel.High ? 3.Dp() : 2.Dp())
            .Background(DsTheme.ColorScheme.Primary, RoundedCornerShape(9999.Dp()))
            .TestTag("ds.tabs.indicator"));
    }

    private readonly record struct TabRowScope(TabRowState? State, DsTabLevel Level);
    private sealed record TabSelection(object Owner, IState<Compose.Net.Rect> Bounds);

    private sealed class TabRowState
    {
        public readonly IMutableState<Offset> Origin = MutableStateOf(default(Offset));
        public readonly IMutableState<TabSelection?> Selection = MutableStateOf<TabSelection?>(null);
    }
}

public enum DsTabLevel
{
    High,
    Low,
}
