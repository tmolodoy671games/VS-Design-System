#nullable enable
// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __AlertDialog(Action onDismiss, ComposableContent confirmButton, ComposableContent? title = null, ComposableContent? text = null, ComposableContent? actionButton = null, ComposableContent? dismissButton = null, IModifier? modifier = null, Optional<DialogProperties> properties = default, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onDismiss, __confirmButton, __title, __text, __actionButton, __dismissButton, __modifier, __properties) = (onDismiss, confirmButton, title, text, actionButton, dismissButton, modifier, properties);
        var __isCreated = __composer.StartRestartGroup(429543589);
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
            var typography = theme.Typography;
            __Box(modifier: Modifier.FillMaxSize().OnClick(enabled: resolvedProperties.DismissOnClickOutside, onClick: onDismiss), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00_00) == 0b_00_00_00_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_00_00_00_11_00_00_00) == 0b_00_00_00_00_10_00_00_00).ChangedAsFlag((__dirty & 0b_00_11_00_00_00_00_00_00) == 0b_00_10_00_00_00_00_00_00).Changed<global::VS.UiToolkit.TypographyConfig>(typography!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __Surface(modifier: modifier.OrEmpty().Clip(RoundedCornerShape(16.Dp())).Padding(all: 16.Dp()), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00_00) == 0b_00_00_00_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_00_00_00_11_00_00_00) == 0b_00_00_00_00_10_00_00_00).Changed<global::VS.UiToolkit.TypographyConfig>(typography!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Column(horizontalAlignment: Alignment.CenterHorizontally, content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_11_00_00) == 0b_00_00_00_00_00_10_00_00).ChangedAsFlag((__dirty & 0b_00_00_00_00_11_00_00_00) == 0b_00_00_00_00_10_00_00_00).Changed<global::VS.UiToolkit.TypographyConfig>(typography!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __composer.StartReplaceGroup(441302578);
                        if (title != null)
                        {
                            __CompositionLocalProvider(LocalTextStyle.Provides(typography.Title), content: title, __composer: __composer, __changed: ((__dirty & 0b_11_00_00) >> 2));
                        }

                        __composer.EndReplaceGroup(441302578);
                        __composer.StartReplaceGroup(1833131831);
                        if (text != null)
                        {
                            __CompositionLocalProvider(LocalTextStyle.Provides(typography.Body), content: text, __composer: __composer, __changed: ((__dirty & 0b_11_00_00_00) >> 4));
                        }

                        __composer.EndReplaceGroup(1833131831);
                    })), __composer: __composer, __changed: 0b_01_00_01_00);
                })), __composer: __composer, __changed: 0b_01_01_00);
            })), __composer: __composer, __changed: 0b_01_00_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01_01_01_01;
        __composer.EndRestartGroup(429543589, __isRestarted)?.UpdateScope(() => __AlertDialog(__onDismiss, __confirmButton, __title, __text, __actionButton, __dismissButton, __modifier, __properties, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}