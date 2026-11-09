// ReSharper disable CheckNamespace

using System;
using System.Threading.Tasks;
using Compose.Net;
using SharpExtensions;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace VS.DesignSystem;

[AutoGlobalUsingStatic]
[NoAutoStaticsCleanup]
public static partial class DsTabFunctions
{
    private static readonly ICompositionLocal<DsTabLevel> LocalLevel = CompositionLocalOf(() => DsTabLevel.High);

    private static readonly ICompositionLocal<Action<ILayoutCoordinates>> LocalSetIndicatorCallback =
        CompositionLocalOf<Action<ILayoutCoordinates>>(() => _ => { });

    private static readonly ICompositionLocal<Action<string>> LocalCurrentTabId =
        CompositionLocalOf<Action<string>>(() => _ => { });

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
        var setIndicatorCallback = LocalSetIndicatorCallback.Current;
        var setCurrentTabId = LocalCurrentTabId.Current;
        var id = Remember(Guid.NewGuid);
        var level = LocalLevel.Current;
        var textStyle = level switch
        {
            DsTabLevel.High => DsTheme.Typography.TitleSmall,
            DsTabLevel.Low => DsTheme.Typography.LabelLarge,
            _ => throw new ArgumentOutOfRangeException()
        };
        var defaultContentColor = LocalContentColor.Current;
        var contentColor = selected
            ? selectedContentColor.GetOrDefault(defaultContentColor)
            : unselectedContentColor.GetOrDefault(defaultContentColor);
        LaunchedEffect(selected, scope =>
        {
            if (selected)
                setCurrentTabId(id.ToString());
            return Task.CompletedTask;
        });
        CompositionLocalProvider(
            LocalTextStyle.Provides(textStyle),
            LocalContentColor.Provides(contentColor),
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
                        )
                        .OnGloballyPositioned(it =>
                        {
                            if (selected)
                                setIndicatorCallback(it);
                        }),
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
        var selectedTabPosition = By(Remember(() => MutableStateOf(0f)));
        var selectedTabWidth = By(Remember(() => MutableStateOf(0f)));
        var selectedTabId = By(Remember(() => MutableStateOf("")));
        CompositionLocalProvider(
            LocalContentColor.Provides(DsTheme.ColorScheme.OnPrimary),
            LocalLevel.Provides(level),
            LocalCurrentTabId.Provides(it => selectedTabId = it),
            LocalSetIndicatorCallback.Provides(it =>
            {
                var width = it.Size.Width;
                var left = it.PositionInParent().X;
                if (!float.IsFinite(width) || !float.IsFinite(left)) return;
                selectedTabWidth = width;
                selectedTabPosition = left;
            }),
            content: () =>
            {
                Box(
                    modifier: modifier.OrEmpty()
                        .Background(DsTheme.ColorScheme.Primary)
                        .Clip(RoundedCornerShape(16.Dp())),
                    content: () =>
                    {
                        Row(
                            content: content
                        );
                        DsTabSelectionIndicator(
                            left: selectedTabPosition,
                            width: selectedTabWidth,
                            id: selectedTabId
                        );
                    }
                );
            }
        );
    }

    [Composable, BoxScope]
    private static void DsTabSelectionIndicator(float left, float width, string id)
    {
        var computedWidth = By(Remember(() => MutableStateOf(width)));
        var widthValue = By(Remember(() => MutableStateOf(width)));
        widthValue = width;
        LaunchedEffect(id, async scope =>
        {
            await Animate(
                token: scope.Token,
                typeConverter: Mathf.LerpUnclamped,
                initialValue: computedWidth,
                targetValueFactory: () => widthValue,
                block: it => computedWidth = it
            );
        });
        Box(
            Modifier
                .Background(DsTheme.ColorScheme.OnPrimary with { Alpha = 0.2f }, RoundedCornerShape(12.Dp()))
                .FillMaxHeight()
                .Width(computedWidth.Dp())
                .Offset(x: AnimateFloatAsState(left).Value.Dp())
        );
    }
}

public enum DsTabLevel
{
    High,
    Low,
}
