// ReSharper disable CheckNamespace

using System;
using Compose.Net;
using SharpExtensions;
using Unity.Scripting.LifecycleManagement;
using UnityEngine.UIElements;

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
[NoAutoStaticsCleanup]
public static partial class DsTabFunctions
{
    private static readonly ICompositionLocal<DsTabLevel> LocalLevel = CompositionLocalOf(() => DsTabLevel.High);

    private static readonly ICompositionLocal<Action<ILayoutCoordinates>> LocalOnGeometryChanged =
        CompositionLocalOf<Action<ILayoutCoordinates>>(() => _ => { });
    
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
        var level = LocalLevel.Current;
        var textStyle = level switch
        {
            DsTabLevel.High => DsTheme.Typography.TitleSmall,
            DsTabLevel.Low => DsTheme.Typography.LabelLarge,
            _ => throw new ArgumentOutOfRangeException()
        };
        CompositionLocalProvider(
            LocalTextStyle.Provides(textStyle),
            content: () =>
            {
                Row(
                    modifier: modifier.OrEmpty()
                        .Clickable(
                            onClick: onClick,
                            enabled: enabled,
                            indication: LocalIndication.Current,
                            interactionSource: interactionSource
                        )
                        .Clip(RoundedCornerShape(12.Dp()))
                        .Padding(
                            vertical: 4.Dp(),
                            horizontal: AnimateFloatAsState(selected ? 40 : 16).Value.Dp()
                        ),
                    content: () =>
                    {
                        icon?.Invoke();
                        text?.Invoke();
                    }
                );
            }
        );
    }

    [Composable]
    public static void DsTabsRow(
        [Composable, RowScope] Action content,
        IModifier? modifier = null,
        DsTabLevel level = DsTabLevel.High
    )
    {
        CompositionLocalProvider(
            LocalContentColor.Provides(DsTheme.ColorScheme.OnPrimary),
            LocalLevel.Provides(level),
            content: () =>
            {
                Row(
                    modifier: modifier.OrEmpty()
                        .Background(DsTheme.ColorScheme.Primary)
                        .Clip(RoundedCornerShape(16.Dp())),
                    content: content
                );
            }
        );
    }

    [Composable, BoxScope]
    private static void DsTabSelectionIndicator(float left, float width, DsTabLevel level)
    {
        Box(
            Modifier
                .FillMaxHeight()
                .Width(width.Dp())
                .Offset(x: left.Dp())
        );
    }
}

public enum DsTabLevel
{
    High,
    Low,
}