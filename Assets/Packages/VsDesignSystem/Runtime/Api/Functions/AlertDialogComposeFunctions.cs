// ReSharper disable CheckNamespace

using System;
using System.Collections;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    private enum AlertDialogButtonType
    {
        Confirm,
        Action,
        Dismiss,
    }

    private static readonly ICompositionLocal<AlertDialogButtonType> LocalAlertDialogButtonType =
        CompositionLocalOf(() => AlertDialogButtonType.Confirm);

    private static readonly ICompositionLocal<Action> LocalDismiss = CompositionLocalOf<Action>(() => () => { });
    private static readonly ICompositionLocal<Action> LocalOnDismiss = CompositionLocalOf<Action>(() => () => { });
    private static readonly ICompositionLocal<bool> LocalVisibility = CompositionLocalOf(() => true);
    private static readonly ICompositionLocal<float> LocalDelay = CompositionLocalOf(() => 0f);

    private const float AlertButtonPadding = 20;

    [Composable]
    public static void AlertDialog(
        Action onDismiss,
        ComposableContent confirmButton,
        ComposableContent? title = null,
        ComposableContent? text = null,
        ComposableContent? actionButton = null,
        ComposableContent? dismissButton = null,
        IModifier? modifier = null,
        Optional<DialogProperties> properties = default
    )
    {
        var resolvedProperties = properties.GetOrDefault(new DialogProperties(
            DismissOnBackPress: true,
            DismissOnClickOutside: true
        ));
        var theme = LocalTheme.Current;
        var colors = theme.ColorScheme;
        var isVisible = Remember(() => MutableStateOf(true));
        var surfaceAlpha = VisibilityProgress(
            isVisible.Value
        ).Value;
        var surfaceScale = VisibilityProgress(
            isVisible.Value,
            Theme.AnimationSpecs.Bounce
        ).Value;
        var coroutineScope = RememberCoroutineScope();
        var bounce = Theme.AnimationSpecs.Bounce;
        var onContainerClick = () => { coroutineScope.StartCoroutine(OnContainerClickCoroutine()); };

        Box(
            alignment: Alignment.Center,
            modifier: Modifier.FillMaxSize()
                .Background(colors.ScrimDark
                    .With(a: colors.ScrimDark.a * surfaceAlpha)
                )
                .OnClick(enabled: resolvedProperties.DismissOnClickOutside, onClick: onContainerClick),
            content: () =>
            {
                Surface(
                    modifier: modifier.OrEmpty()
                        .Clip(RoundedCornerShape(16.Dp()))
                        .Padding(all: 16.Dp())
                        .Scale(0.5f + surfaceScale / 2f)
                        .Alpha(surfaceAlpha)
                        .OnClick(() => { }),
                    content: () =>
                    {
                        Column(
                            horizontalAlignment: Alignment.CenterHorizontally,
                            content: () =>
                            {
                                if (title != null)
                                {
                                    AlertDialogTitle(
                                        title: title,
                                        visibility: isVisible.Value
                                    );
                                    Spacer(Modifier.Height(4.Dp()));
                                }

                                if (text != null)
                                {
                                    AlertDialogText(
                                        text: text,
                                        visibility: isVisible.Value
                                    );
                                    Spacer(Modifier.Height(4.Dp()));
                                }

                                CompositionLocalProvider(
                                    LocalDismiss.Provides(() => isVisible.Value = false),
                                    LocalVisibility.Provides(isVisible.Value),
                                    LocalOnDismiss.Provides(onDismiss),
                                    () =>
                                    {
                                        FixedSize(
                                            modifier: Modifier.Align(Alignment.Right),
                                            content: () =>
                                            {
                                                AlertDialogButtons(
                                                    confirmButton: confirmButton,
                                                    actionButton: actionButton,
                                                    dismissButton: dismissButton,
                                                    visible: isVisible.Value,
                                                    modifier: Modifier
                                                );
                                            }
                                        );
                                    }
                                );
                            }
                        );
                    }
                );
            }
        );
        return;

        IEnumerator OnContainerClickCoroutine()
        {
            isVisible.Value = false;
            yield return new WaitForSeconds(bounce.TotalDuration);
            onDismiss();
        }
    }

    [Composable]
    private static void AlertDialogTitle(
        bool visibility,
        ComposableContent title
    )
    {
        var theme = Theme;
        var colors = theme.ColorScheme;
        var typography = theme.Typography;
        var visibilityProgress = VisibilityProgress(
            visibility,
            theme.AnimationSpecs.Bounce
                .With(delay: 0.1f)
        ).Value;
        Surface(
            color: colors.SurfaceVariant,
            alignment: Alignment.Center,
            modifier: Modifier
                .Scale(visibilityProgress)
                .Alpha(visibilityProgress)
                .Padding(
                    horizontal: 16.Dp(),
                    vertical: 4.Dp()
                )
                .Clip(RoundedCornerShape(16.Dp())),
            content: () =>
            {
                CompositionLocalProvider(
                    LocalTextStyle.Provides(typography.Title),
                    content: title
                );
            }
        );
    }

    [Composable]
    private static void AlertDialogText(
        ComposableContent text,
        bool visibility
    )
    {
        var theme = Theme;
        var typography = theme.Typography;
        var visibilityProgress = VisibilityProgress(
            visibility,
            theme.AnimationSpecs.Bounce
                .With(delay: 0.2f)
        ).Value;
        Box(
            modifier: Modifier
                .Scale(visibilityProgress)
                .Alpha(visibilityProgress)
                .Margin(left: 6.Dp()),
            content: () =>
            {
                CompositionLocalProvider(
                    LocalTextStyle.Provides(typography.Body),
                    content: text
                );
            }
        );
    }

    [Composable]
    public static void AlertDialogButton(
        Action onClick,
        ComposableContent content,
        IMutableInteractionSource? interactionSource = null,
        IModifier? modifier = null
    )
    {
        var theme = Theme;
        var item = LocalListSelectionItem.Current;
        var paddingValues = PaddingValues(
            horizontal: 16.Dp() + AlertButtonPadding.Dp() * item.SelectionProgress,
            vertical: 2.Dp()
        );
        interactionSource ??= Remember(MutableInteractionSource);
        var isHovered = interactionSource.CollectIsHoveredAsState().Value;
        var visibility = LocalVisibility.Current;
        var delay = LocalDelay.Current;
        var visibilityProgress = VisibilityProgress(
            visibility,
            theme.AnimationSpecs.Bounce
                .With(delay: delay)
        ).Value;
        SideEffect(isHovered, () =>
        {
            if (isHovered)
                item.Select();
            else
                item.Deselect();
        });
        var shapes = new ButtonShapes(
            Shape: RoundedCornerShape(12.Dp()),
            HoveredShape: RoundedCornerShape(20.Dp())
        );

        var bounce = Theme.AnimationSpecs.Bounce;
        var dismiss = LocalDismiss.Current;
        var onDismiss = LocalOnDismiss.Current;
        var coroutineScope = RememberCoroutineScope();
        var resolvedOnClick = () => { coroutineScope.StartCoroutine(OnClickCoroutine()); };
        modifier = modifier.OrEmpty()
            .Scale(visibilityProgress)
            .Alpha(visibilityProgress);

        Box(
            modifier: Modifier
                .Margin(horizontal: 4.Dp())
                .Hoverable(interactionSource),
            content: () =>
            {
                switch (LocalAlertDialogButtonType.Current)
                {
                    case AlertDialogButtonType.Confirm:
                        Button(
                            onClick: resolvedOnClick,
                            contentPadding: paddingValues,
                            margins: PaddingValues(0.Dp()),
                            shapes: shapes,
                            scale: false,
                            content: content,
                            modifier: modifier
                        );
                        break;
                    case AlertDialogButtonType.Action:
                        SecondaryButton(
                            onClick: resolvedOnClick,
                            contentPadding: paddingValues,
                            margins: PaddingValues(0.Dp()),
                            shapes: shapes,
                            scale: false,
                            content: content,
                            modifier: modifier
                        );
                        break;
                    case AlertDialogButtonType.Dismiss:
                        TextButton(
                            onClick: resolvedOnClick,
                            contentPadding: paddingValues,
                            margins: PaddingValues(0.Dp()),
                            shapes: shapes,
                            scale: false,
                            content: content,
                            modifier: modifier
                        );
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        );


        return;

        IEnumerator OnClickCoroutine()
        {
            dismiss();
            yield return new WaitForSeconds(bounce.With(delay: delay).TotalDuration);
            onClick();
            onDismiss();
        }
    }

    [Composable]
    private static void AlertDialogButtons(
        ComposableContent confirmButton,
        ComposableContent? actionButton,
        ComposableContent? dismissButton,
        bool visible,
        IModifier? modifier = null
    )
    {
        var visibilityProgress = VisibilityProgress(
            visible,
            Tween(
                delay: 0.1f,
                duration: 0.2f
            )
        ).Value;
        Row(
            verticalAlignment: Alignment.CenterVertically,
            modifier: modifier.OrEmpty()
                .Padding(right: 8.Dp())
                .Offset(x: 100 * (1 - visibilityProgress).Dp())
                .Alpha(visibilityProgress),
            content: () =>
            {
                ListSelection(
                    content: () =>
                    {
                        ListSelectionItem(item =>
                        {
                            Spacer(
                                Modifier
                                    .FillMaxHeight()
                                    .Width(8.Dp() + AlertButtonPadding.Dp() * item.SelectionProgress)
                            );
                        });
                        ListSelectionItem(_ =>
                        {
                            CompositionLocalProvider(
                                LocalAlertDialogButtonType.Provides(AlertDialogButtonType.Confirm),
                                LocalDelay.Provides(0.3f),
                                content: confirmButton
                            );
                        });
                        if (actionButton != null)
                        {
                            ListSelectionItem(_ =>
                            {
                                CompositionLocalProvider(
                                    LocalAlertDialogButtonType.Provides(AlertDialogButtonType.Action),
                                    LocalDelay.Provides(0.2f),
                                    content: actionButton
                                );
                            });
                        }

                        if (dismissButton != null)
                        {
                            ListSelectionItem(_ =>
                            {
                                CompositionLocalProvider(
                                    LocalAlertDialogButtonType.Provides(AlertDialogButtonType.Dismiss),
                                    LocalDelay.Provides(0.4f),
                                    content: dismissButton
                                );
                            });
                        }
                    }
                );
            }
        );
    }
}

public readonly record struct DialogProperties(
    bool DismissOnBackPress,
    bool DismissOnClickOutside
);