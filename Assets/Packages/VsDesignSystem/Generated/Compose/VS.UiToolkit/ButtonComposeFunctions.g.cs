#nullable enable
// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Api.Models;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using UnityEngine.UIElements;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __Button(Action onClick, ComposableContent content, IMutableInteractionSource? interactionSource = null, bool enabled = true, Optional<ButtonShapes> shapes = default, Optional<ButtonColors> colors = default, Optional<PaddingValues> contentPadding = default, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onClick, __content, __interactionSource, __enabled, __shapes, __colors, __contentPadding, __modifier) = (onClick, content, interactionSource, enabled, shapes, colors, contentPadding, modifier);
        var __isCreated = __composer.StartRestartGroup(1820355391);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_00_00_00_00_00_10 : 0b_00_00_00_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_00_00_00_10_00 : 0b_00_00_00_00_00_00_01_00;
        if ((__changed & 0b_00_00_00_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_00_00_00_00_00_10_00_00 : 0b_00_00_00_00_00_01_00_00;
        if ((__changed & 0b_00_00_00_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_00_00_00_00_10_00_00_00 : 0b_00_00_00_00_01_00_00_00;
        if ((__changed & 0b_00_00_00_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(shapes) ? 0b_00_00_00_10_00_00_00_00 : 0b_00_00_00_01_00_00_00_00;
        if ((__changed & 0b_00_00_11_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(colors) ? 0b_00_00_10_00_00_00_00_00 : 0b_00_00_01_00_00_00_00_00;
        if ((__changed & 0b_00_11_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(contentPadding) ? 0b_00_10_00_00_00_00_00_00 : 0b_00_01_00_00_00_00_00_00;
        if ((__changed & 0b_11_00_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00_00_00_00_00 : 0b_01_00_00_00_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01_01_01_01)
        {
            var typography = Theme.Typography;
            var resolvedColors = colors.GetOrDefault(ButtonDefaults.__ButtonColors(__composer: __composer, __changed: 0b_00));
            var resolvedContentPadding = contentPadding.GetOrDefault(ButtonDefaults.ContentPadding);
            interactionSource ??= (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
            var resolvedShape = shapes.GetOrDefault(ButtonDefaults.Shapes).GetShape(isHovered);
            var isPressed = interactionSource.__CollectIsPressedAsState(__composer: __composer, __changed: 0b_00).Value;
            var contentBackground = __AnimateColorAsState(resolvedColors.GetContainerColor(enabled), __composer: __composer, __changed: 0b_01_00).Value;
            __Box(alignment: Alignment.Center, modifier: modifier.OrEmpty().Padding(resolvedContentPadding).Scale(__AnimateFloatAsState(isHovered ? 1.1f : 1f, __composer: __composer, __changed: 0b_01_00).Value).Clip(__AnimateRoundedCornerShapeAsState(resolvedShape, __composer: __composer, __changed: 0b_01_00).Value).Background(contentBackground).__DsClickIndication(enabled: enabled, onClick: onClick, interactionSource: interactionSource, __composer: __composer, __changed: 0b_01_00_00 | (__dirty & 0b_00_00_11) | (__dirty & 0b_11_00_00_00)), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_00_00_00_11_00_00_00) == 0b_00_00_00_00_10_00_00_00).Changed<global::VS.UiToolkit.TypographyConfig>(typography!).Changed<global::VS.UiToolkit.ButtonColors>(resolvedColors!).Changed<bool>(isPressed!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                var contentTint = __AnimateColorAsState(resolvedColors.GetContentColor(enabled), __composer: __composer, __changed: 0b_01_00).Value;
                __CompositionLocalProvider(LocalTextStyle.Provides(typography.LabelLarge), LocalContentColor.Provides(contentTint), (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_00_00_11_00) == 0b_00_00_00_00_00_00_10_00).Changed<bool>(isPressed!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Row(verticalAlignment: Alignment.CenterVertically, horizontalArrangement: Arrangement.Center, modifier: Modifier.Scale(__AnimateFloatAsState(isPressed ? 0.75f : 1f, __composer: __composer, __changed: 0b_01_00).Value), content: content, __composer: __composer, __changed: ((__dirty & 0b_00_00_11_00) >> 2));
                })), __composer: __composer, __changed: 0b_00_00_00);
            })), __composer: __composer, __changed: 0b_00_00_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01_01_01_01;
        __composer.EndRestartGroup(1820355391, __isRestarted)?.UpdateScope(() => __Button(__onClick, __content, __interactionSource, __enabled, __shapes, __colors, __contentPadding, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    public static void __TextButton(Action onClick, ComposableContent content, IMutableInteractionSource? interactionSource = null, bool enabled = true, Optional<ButtonShapes> shapes = default, Optional<ButtonColors> colors = default, Optional<PaddingValues> contentPadding = default, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__onClick, __content, __interactionSource, __enabled, __shapes, __colors, __contentPadding, __modifier) = (onClick, content, interactionSource, enabled, shapes, colors, contentPadding, modifier);
        var __isCreated = __composer.StartRestartGroup(869694853);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_00_00_00_00_00_10 : 0b_00_00_00_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_00_00_00_10_00 : 0b_00_00_00_00_00_00_01_00;
        if ((__changed & 0b_00_00_00_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(interactionSource) ? 0b_00_00_00_00_00_10_00_00 : 0b_00_00_00_00_00_01_00_00;
        if ((__changed & 0b_00_00_00_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(enabled) ? 0b_00_00_00_00_10_00_00_00 : 0b_00_00_00_00_01_00_00_00;
        if ((__changed & 0b_00_00_00_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(shapes) ? 0b_00_00_00_10_00_00_00_00 : 0b_00_00_00_01_00_00_00_00;
        if ((__changed & 0b_00_00_11_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(colors) ? 0b_00_00_10_00_00_00_00_00 : 0b_00_00_01_00_00_00_00_00;
        if ((__changed & 0b_00_11_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(contentPadding) ? 0b_00_10_00_00_00_00_00_00 : 0b_00_01_00_00_00_00_00_00;
        if ((__changed & 0b_11_00_00_00_00_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00_00_00_00_00 : 0b_01_00_00_00_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01_01_01_01)
        {
            var resolvedColors = colors.GetOrDefault(ButtonDefaults.__TextButtonColors(__composer: __composer, __changed: 0b_00));
            __Button(onClick: onClick, content: content, interactionSource: interactionSource, enabled: enabled, shapes: shapes, colors: resolvedColors, contentPadding: contentPadding, modifier: modifier, __composer: __composer, __changed: (__dirty & 0b_00_00_00_00_00_00_00_11) | (__dirty & 0b_00_00_00_00_00_00_11_00) | (__dirty & 0b_00_00_00_00_00_11_00_00) | (__dirty & 0b_00_00_00_00_11_00_00_00) | (__dirty & 0b_00_00_00_11_00_00_00_00) | (__dirty & 0b_00_11_00_00_00_00_00_00) | (__dirty & 0b_11_00_00_00_00_00_00_00));
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01_01_01_01;
        __composer.EndRestartGroup(869694853, __isRestarted)?.UpdateScope(() => __TextButton(__onClick, __content, __interactionSource, __enabled, __shapes, __colors, __contentPadding, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}

internal static partial class ButtonDefaults
{
    public static ButtonColors __TextButtonColors(global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var colors = Theme.ColorScheme;
        return new ButtonColors(ContainerColor: new Color(), ContentColor: colors.Primary, DisabledContainerColor: new Color(), DisabledContentColor: colors.OnSurface.With(a: DisabledAlpha));
    }

    public static ButtonColors __ButtonColors(global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var colors = Theme.ColorScheme;
        return new ButtonColors(ContainerColor: colors.Primary, ContentColor: colors.OnPrimary, DisabledContainerColor: colors.OnSurface.With(a: DisabledAlpha), DisabledContentColor: colors.OnSurface.With(a: DisabledAlpha));
    }
}