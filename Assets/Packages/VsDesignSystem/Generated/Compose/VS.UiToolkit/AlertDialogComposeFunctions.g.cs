#nullable enable
// ReSharper disable CheckNamespace

using System;
using System.Collections;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __AlertDialog(Action onDismiss, ComposableContent confirmButton, ComposableContent? title = null, ComposableContent? text = null, ComposableContent? actionButton = null, ComposableContent? dismissButton = null, IModifier? modifier = null, Optional<DialogProperties> properties = default, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onDismiss, __confirmButton, __title, __text, __actionButton, __dismissButton, __modifier, __properties) = (onDismiss, confirmButton, title, text, actionButton, dismissButton, modifier, properties);
        var __isCreated = __composer.StartRestartGroup(1643827968);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(onDismiss) ? 0b_00_00_00_00_00_00_00_10 : 0b_00_00_00_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(confirmButton) ? 0b_00_00_00_00_00_00_10_00 : 0b_00_00_00_00_00_00_01_00;
        if ((__changed & 0b_00_00_00_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(title) ? 0b_00_00_00_00_00_10_00_00 : 0b_00_00_00_00_00_01_00_00;
        if ((__changed & 0b_00_00_00_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(text) ? 0b_00_00_00_00_10_00_00_00 : 0b_00_00_00_00_01_00_00_00;
        if ((__changed & 0b_00_00_00_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(actionButton) ? 0b_00_00_00_10_00_00_00_00 : 0b_00_00_00_01_00_00_00_00;
        if ((__changed & 0b_00_00_11_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(dismissButton) ? 0b_00_00_10_00_00_00_00_00 : 0b_00_00_01_00_00_00_00_00;
        if ((__changed & 0b_00_11_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_00_10_00_00_00_00_00_00 : 0b_00_01_00_00_00_00_00_00;
        if ((__changed & 0b_11_00_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(properties) ? 0b_10_00_00_00_00_00_00_00 : 0b_01_00_00_00_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01_01_01_01)
        {
            var resolvedProperties = properties.GetOrDefault(new DialogProperties(DismissOnBackPress: true, DismissOnClickOutside: true));
            var theme = LocalTheme.Current;
            var colors = theme.ColorScheme;
            var isVisible = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<bool>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<bool>>(MutableStateOf(true)));
            var surfaceAlpha = __VisibilityProgress(isVisible.Value, __composer: __composer, __changed: 0b_01_00).Value;
            var surfaceScale = __VisibilityProgress(isVisible.Value, Theme.AnimationSpecs.Bounce, __composer: __composer, __changed: 0b_00_00).Value;
            var coroutineScope = __RememberCoroutineScope(__composer: __composer, __changed: 0b_00);
            var bounce = Theme.AnimationSpecs.Bounce;
            var onContainerClick = (!__composer.BuildChanged().Changed<global::UnityCompose.IMutableState<bool>>(isVisible!).Changed<global::UnityCompose.IComposeCoroutineScope>(coroutineScope!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
            {
                coroutineScope.StartCoroutine(OnContainerClickCoroutine());
            }));
            __Box(alignment: Alignment.Center, modifier: Modifier.FillMaxSize().Background(colors.ScrimDark.With(a: colors.ScrimDark.a * surfaceAlpha)).OnClick(enabled: resolvedProperties.DismissOnClickOutside, onClick: onContainerClick), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_00_11) == 0b_00_00_00_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00_00) == 0b_00_00_00_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_00_00_00_11_00_00_00) == 0b_00_00_00_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_00_00_00_11_00_00_00_00) == 0b_00_00_00_10_00_00_00_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00_00_00_00) == 0b_00_00_10_00_00_00_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00_00_00_00) == 0b_00_10_00_00_00_00_00_00).Changed<global::UnityCompose.IMutableState<bool>>(isVisible!).Changed<float>(surfaceAlpha!).Changed<float>(surfaceScale!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __Surface(modifier: modifier.OrEmpty().Clip(RoundedCornerShape(16.Dp())).Padding(all: 16.Dp()).Scale(0.5f + surfaceScale / 2f).Alpha(surfaceAlpha).OnClick((!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                {
                }))), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_00_11) == 0b_00_00_00_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00_00) == 0b_00_00_00_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_00_00_00_11_00_00_00) == 0b_00_00_00_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_00_00_00_11_00_00_00_00) == 0b_00_00_00_10_00_00_00_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00_00_00_00) == 0b_00_00_10_00_00_00_00_00).Changed<global::UnityCompose.IMutableState<bool>>(isVisible!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Column(horizontalAlignment: Alignment.CenterHorizontally, content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_00_11) == 0b_00_00_00_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00_00) == 0b_00_00_00_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_00_00_00_11_00_00_00) == 0b_00_00_00_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_00_00_00_11_00_00_00_00) == 0b_00_00_00_10_00_00_00_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00_00_00_00) == 0b_00_00_10_00_00_00_00_00).Changed<global::UnityCompose.IMutableState<bool>>(isVisible!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __composer.StartReplaceGroup(1130940499);
                        if (title != null)
                        {
                            __AlertDialogTitle(title: title, visibility: isVisible.Value, __composer: __composer, __changed: ((__dirty & 0b_11_00_00) >> 2));
                            __Spacer(Modifier.Height(4.Dp()), __composer: __composer, __changed: 0b_00);
                        }

                        __composer.EndReplaceGroup(1130940499);
                        __composer.StartReplaceGroup(859535280);
                        if (text != null)
                        {
                            __AlertDialogText(text: text, visibility: isVisible.Value, __composer: __composer, __changed: ((__dirty & 0b_11_00_00_00) >> 6));
                            __Spacer(Modifier.Height(4.Dp()), __composer: __composer, __changed: 0b_00);
                        }

                        __composer.EndReplaceGroup(859535280);
                        __CompositionLocalProvider(LocalDismiss.Provides((!__composer.Changed<global::UnityCompose.IMutableState<bool>>(isVisible!) ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => isVisible.Value = false))), LocalVisibility.Provides(isVisible.Value), LocalOnDismiss.Provides(onDismiss), (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_00_11_00_00_00_00) == 0b_00_00_00_10_00_00_00_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00_00_00_00) == 0b_00_00_10_00_00_00_00_00).Changed<global::UnityCompose.IMutableState<bool>>(isVisible!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                        {
                            __FixedSize(modifier: Modifier.Align(Alignment.Right), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_00_11_00_00_00_00) == 0b_00_00_00_10_00_00_00_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00_00_00_00) == 0b_00_00_10_00_00_00_00_00).Changed<global::UnityCompose.IMutableState<bool>>(isVisible!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                            {
                                __AlertDialogButtons(confirmButton: confirmButton, actionButton: actionButton, dismissButton: dismissButton, visible: isVisible.Value, modifier: Modifier, __composer: __composer, __changed: ((__dirty & 0b_00_00_00_11_00) >> 2) | ((__dirty & 0b_11_00_00_00_00) >> 6) | ((__dirty & 0b_11_00_00_00_00_00) >> 6));
                            })), __composer: __composer, __changed: 0b_00_00);
                        })), __composer: __composer, __changed: 0b_00_00_00_00);
                    })), __composer: __composer, __changed: 0b_01_00_01_00);
                })), __composer: __composer, __changed: 0b_01_01_01_00);
            })), __composer: __composer, __changed: 0b_00_00_00);
            __dirty = 0b_01_01_01_01_01_01_01_01;
            __composer.EndRestartGroup(1643827968, __isRestarted)?.UpdateScope(() => __AlertDialog(__onDismiss, __confirmButton, __title, __text, __actionButton, __dismissButton, __modifier, __properties, __composer, __composer.UpdateChangedFlags(__changed)));
            return;
            IEnumerator OnContainerClickCoroutine()
            {
                isVisible.Value = false;
                yield return new WaitForSeconds(bounce.TotalDuration);
                onDismiss();
            }
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01_01_01_01;
        __composer.EndRestartGroup(1643827968, __isRestarted)?.UpdateScope(() => __AlertDialog(__onDismiss, __confirmButton, __title, __text, __actionButton, __dismissButton, __modifier, __properties, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __AlertDialogTitle(bool visibility, ComposableContent title, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__visibility, __title) = (visibility, title);
        var __isCreated = __composer.StartRestartGroup(35630445);
        var __dirty = __changed;
        if ((__changed & 0b_00_11) == 0)
            __dirty |= __composer.Changed(visibility) ? 0b_00_10 : 0b_00_01;
        if ((__changed & 0b_11_00) == 0)
            __dirty |= __composer.Changed(title) ? 0b_10_00 : 0b_01_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01)
        {
            var theme = Theme;
            var colors = theme.ColorScheme;
            var typography = theme.Typography;
            var visibilityProgress = __VisibilityProgress(visibility, theme.AnimationSpecs.Bounce.With(delay: 0.1f), __composer: __composer, __changed: (__dirty & 0b_00_11)).Value;
            __Surface(color: colors.SurfaceVariant, alignment: Alignment.Center, modifier: Modifier.Scale(visibilityProgress).Alpha(visibilityProgress).Padding(horizontal: 16.Dp(), vertical: 4.Dp()).Clip(RoundedCornerShape(16.Dp())), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_11_00) == 0b_10_00).Changed<global::VS.UiToolkit.TypographyConfig>(typography!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __CompositionLocalProvider(LocalTextStyle.Provides(typography.Title), content: title, __composer: __composer, __changed: (__dirty & 0b_11_00));
            })), __composer: __composer, __changed: 0b_01_00_00_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01;
        __composer.EndRestartGroup(35630445, __isRestarted)?.UpdateScope(() => __AlertDialogTitle(__visibility, __title, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __AlertDialogText(ComposableContent text, bool visibility, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__text, __visibility) = (text, visibility);
        var __isCreated = __composer.StartRestartGroup(1636732634);
        var __dirty = __changed;
        if ((__changed & 0b_00_11) == 0)
            __dirty |= __composer.Changed(text) ? 0b_00_10 : 0b_00_01;
        if ((__changed & 0b_11_00) == 0)
            __dirty |= __composer.Changed(visibility) ? 0b_10_00 : 0b_01_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01)
        {
            var theme = Theme;
            var typography = theme.Typography;
            var visibilityProgress = __VisibilityProgress(visibility, theme.AnimationSpecs.Bounce.With(delay: 0.2f), __composer: __composer, __changed: ((__dirty & 0b_11_00) >> 2)).Value;
            __Box(modifier: Modifier.Scale(visibilityProgress).Alpha(visibilityProgress).Margin(left: 6.Dp()), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_11) == 0b_00_10).Changed<global::VS.UiToolkit.TypographyConfig>(typography!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __CompositionLocalProvider(LocalTextStyle.Provides(typography.Body), content: text, __composer: __composer, __changed: ((__dirty & 0b_00_11) << 2));
            })), __composer: __composer, __changed: 0b_01_00_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01;
        __composer.EndRestartGroup(1636732634, __isRestarted)?.UpdateScope(() => __AlertDialogText(__text, __visibility, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    public static void __AlertDialogButton(Action onClick, ComposableContent content, IMutableInteractionSource? interactionSource = null, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onClick, __content, __interactionSource, __modifier) = (onClick, content, interactionSource, modifier);
        var __isCreated = __composer.StartRestartGroup(1225070605);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_11) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_00_10 : 0b_00_00_00_01;
        if ((__changed & 0b_00_00_11_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_10_00 : 0b_00_00_01_00;
        if ((__changed & 0b_00_11_00_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_00_10_00_00 : 0b_00_01_00_00;
        if ((__changed & 0b_11_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00 : 0b_01_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01)
        {
            var theme = Theme;
            var item = LocalListSelectionItem.Current;
            var paddingValues = PaddingValues(horizontal: 16.Dp() + AlertButtonPadding.Dp() * item.SelectionProgress, vertical: 2.Dp());
            interactionSource ??= (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
            var visibility = LocalVisibility.Current;
            var delay = LocalDelay.Current;
            var visibilityProgress = __VisibilityProgress(visibility, theme.AnimationSpecs.Bounce.With(delay: delay), __composer: __composer, __changed: 0b_00_00).Value;
            __SideEffect(isHovered, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.IListSelectionItem>(item!).Changed<bool>(isHovered!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
            {
                if (isHovered)
                    item.Select();
                else
                    item.Deselect();
            })), __composer: __composer, __changed: 0b_00_00);
            var shapes = new ButtonShapes(Shape: RoundedCornerShape(12.Dp()), HoveredShape: RoundedCornerShape(20.Dp()));
            var bounce = Theme.AnimationSpecs.Bounce;
            var dismiss = LocalDismiss.Current;
            var onDismiss = LocalOnDismiss.Current;
            var coroutineScope = __RememberCoroutineScope(__composer: __composer, __changed: 0b_00);
            var resolvedOnClick = (!__composer.BuildChanged().Changed<float>(delay!).Changed<global::System.Action>(dismiss!).Changed<global::System.Action>(onDismiss!).Changed<global::UnityCompose.IComposeCoroutineScope>(coroutineScope!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
            {
                coroutineScope.StartCoroutine(OnClickCoroutine());
            }));
            modifier = modifier.OrEmpty().Scale(visibilityProgress).Alpha(visibilityProgress);
            __Box(modifier: Modifier.Margin(horizontal: 4.Dp()).Hoverable(interactionSource), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11_00) == 0b_00_00_10_00).Changed<global::UnityCompose.IModifier>(modifier!).Changed<global::UnityCompose.PaddingValues>(paddingValues!).Changed<global::VS.UiToolkit.ButtonShapes>(shapes!).Changed<global::System.Action>(resolvedOnClick!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                switch (LocalAlertDialogButtonType.Current)
                {
                    case AlertDialogButtonType.Confirm:
                        __composer.StartReplaceGroup(325589472);
                        __Button(onClick: resolvedOnClick, contentPadding: paddingValues, margins: PaddingValues(0.Dp()), shapes: shapes, scale: false, content: content, modifier: modifier, __composer: __composer, __changed: 0b_01_00_01_01_01_00_00 | (__dirty & 0b_00_00_00_00_00_11_00));
                        __composer.EndReplaceGroup(325589472);
                        break;
                    case AlertDialogButtonType.Action:
                        __composer.StartReplaceGroup(177056523);
                        __SecondaryButton(onClick: resolvedOnClick, contentPadding: paddingValues, margins: PaddingValues(0.Dp()), shapes: shapes, scale: false, content: content, modifier: modifier, __composer: __composer, __changed: 0b_01_00_01_01_01_00_00 | (__dirty & 0b_00_00_00_00_00_11_00));
                        __composer.EndReplaceGroup(177056523);
                        break;
                    case AlertDialogButtonType.Dismiss:
                        __composer.StartReplaceGroup(1447968013);
                        __TextButton(onClick: resolvedOnClick, contentPadding: paddingValues, margins: PaddingValues(0.Dp()), shapes: shapes, scale: false, content: content, modifier: modifier, __composer: __composer, __changed: 0b_01_00_01_01_01_00_00 | (__dirty & 0b_00_00_00_00_00_11_00));
                        __composer.EndReplaceGroup(1447968013);
                        break;
                    default:
                        __composer.StartReplaceGroup(1016956234);
                        __composer.EndReplaceGroup(1016956234);
                        throw new ArgumentOutOfRangeException();
                }
            })), __composer: __composer, __changed: 0b_01_00_00);
            __dirty = 0b_01_01_01_01;
            __composer.EndRestartGroup(1225070605, __isRestarted)?.UpdateScope(() => __AlertDialogButton(__onClick, __content, __interactionSource, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
            return;
            IEnumerator OnClickCoroutine()
            {
                dismiss();
                yield return new WaitForSeconds(bounce.With(delay: delay).TotalDuration);
                onClick();
                onDismiss();
            }
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01;
        __composer.EndRestartGroup(1225070605, __isRestarted)?.UpdateScope(() => __AlertDialogButton(__onClick, __content, __interactionSource, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static void __AlertDialogButtons(ComposableContent confirmButton, ComposableContent? actionButton, ComposableContent? dismissButton, bool visible, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__confirmButton, __actionButton, __dismissButton, __visible, __modifier) = (confirmButton, actionButton, dismissButton, visible, modifier);
        var __isCreated = __composer.StartRestartGroup(949584808);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(confirmButton) ? 0b_00_00_00_00_10 : 0b_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(actionButton) ? 0b_00_00_00_10_00 : 0b_00_00_00_01_00;
        if ((__changed & 0b_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(dismissButton) ? 0b_00_00_10_00_00 : 0b_00_00_01_00_00;
        if ((__changed & 0b_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(visible) ? 0b_00_10_00_00_00 : 0b_00_01_00_00_00;
        if ((__changed & 0b_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00_00 : 0b_01_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01)
        {
            var visibilityProgress = __VisibilityProgress(visible, Tween(delay: 0.1f, duration: 0.2f), __composer: __composer, __changed: ((__dirty & 0b_11_00_00_00) >> 6)).Value;
            __Row(verticalAlignment: Alignment.CenterVertically, modifier: modifier.OrEmpty().Padding(right: 8.Dp()).Offset(x: 100 * (1 - visibilityProgress).Dp()).Alpha(visibilityProgress), content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00) == 0b_00_00_10_00_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __ListSelection(content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_11_00_00) == 0b_00_00_10_00_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __ListSelectionItem((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(item =>
                    {
                        __Spacer(Modifier.FillMaxHeight().Width(8.Dp() + AlertButtonPadding.Dp() * item.SelectionProgress), __composer: __composer, __changed: 0b_00);
                    })), __composer: __composer, __changed: 0b_00);
                    __ListSelectionItem((!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(_ =>
                    {
                        __CompositionLocalProvider(LocalAlertDialogButtonType.Provides(AlertDialogButtonType.Confirm), LocalDelay.Provides(0.3f), content: confirmButton, __composer: __composer, __changed: ((__dirty & 0b_00_00_11) << 4));
                    })), __composer: __composer, __changed: 0b_00);
                    __composer.StartReplaceGroup(803546118);
                    if (actionButton != null)
                    {
                        __ListSelectionItem((!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_11_00) == 0b_00_00_00_10_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(_ =>
                        {
                            __CompositionLocalProvider(LocalAlertDialogButtonType.Provides(AlertDialogButtonType.Action), LocalDelay.Provides(0.2f), content: actionButton, __composer: __composer, __changed: ((__dirty & 0b_00_11_00) << 2));
                        })), __composer: __composer, __changed: 0b_00);
                    }

                    __composer.EndReplaceGroup(803546118);
                    __composer.StartReplaceGroup(891890449);
                    if (dismissButton != null)
                    {
                        __ListSelectionItem((!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_11_00_00) == 0b_00_00_10_00_00).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(_ =>
                        {
                            __CompositionLocalProvider(LocalAlertDialogButtonType.Provides(AlertDialogButtonType.Dismiss), LocalDelay.Provides(0.4f), content: dismissButton, __composer: __composer, __changed: (__dirty & 0b_11_00_00));
                        })), __composer: __composer, __changed: 0b_00);
                    }

                    __composer.EndReplaceGroup(891890449);
                })), __composer: __composer, __changed: 0b_01_00);
            })), __composer: __composer, __changed: 0b_01_00_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01;
        __composer.EndRestartGroup(949584808, __isRestarted)?.UpdateScope(() => __AlertDialogButtons(__confirmButton, __actionButton, __dismissButton, __visible, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}