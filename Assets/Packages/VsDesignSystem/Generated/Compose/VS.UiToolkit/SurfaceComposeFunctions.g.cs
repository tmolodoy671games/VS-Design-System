#nullable enable
// ReSharper disable CheckNamespace

using SharpExtensions;
using UnityCompose;
using UnityEngine;
using System;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __Surface(ComposableContent content, Alignment? alignment = null, Optional<Color> color = default, Optional<Color> contentColor = default, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__content, __alignment, __color, __contentColor, __modifier) = (content, alignment, color, contentColor, modifier);
        var __isCreated = __composer.StartRestartGroup(1605996389);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_00_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_00_10 : 0b_00_00_00_00_01;
        if ((__changed & 0b_00_00_00_11_00) == 0)
            __dirty |= __composer.Changed(alignment) ? 0b_00_00_00_10_00 : 0b_00_00_00_01_00;
        if ((__changed & 0b_00_00_11_00_00) == 0)
            __dirty |= __composer.Changed(color) ? 0b_00_00_10_00_00 : 0b_00_00_01_00_00;
        if ((__changed & 0b_00_11_00_00_00) == 0)
            __dirty |= __composer.Changed(contentColor) ? 0b_00_10_00_00_00 : 0b_00_01_00_00_00;
        if ((__changed & 0b_11_00_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00_00 : 0b_01_00_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01_01)
        {
            var resolvedColor = color.GetOrDefault(Theme.ColorScheme.Surface);
            var resolvedContentColor = contentColor.GetOrDefault(__ContentColorFor(resolvedColor, __composer: __composer, __changed: 0b_00));
            __Box(alignment: alignment, modifier: modifier.OrEmpty().Background(resolvedColor), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_00_11) == 0b_00_00_00_00_10).Changed<global::UnityEngine.Color>(resolvedContentColor!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __CompositionLocalProvider(LocalContentColor.Provides(resolvedContentColor), content, __composer: __composer, __changed: ((__dirty & 0b_00_11) << 2));
            })), __composer: __composer, __changed: ((__dirty & 0b_00_11_00) << 2));
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01_01;
        __composer.EndRestartGroup(1605996389, __isRestarted)?.UpdateScope(() => __Surface(__content, __alignment, __color, __contentColor, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    private static Color __ContentColorFor(Color color, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var __dirty = __changed;
        if ((__changed & 0b_11) == 0)
            __dirty |= __composer.Changed(color) ? 0b_10 : 0b_01;
        var colors = Theme.ColorScheme;
        return color.Switch().Case(colors.Surface, colors.OnSurface).Case(colors.SurfaceVariant, colors.OnSurfaceVariant).Case(colors.Primary, colors.OnPrimary).Case(colors.PrimaryContainer, colors.OnPrimaryContainer).Case(colors.Secondary, colors.OnSecondary).Case(colors.SecondaryContainer, colors.OnSecondaryContainer).Default(colors.OnSurface).Get();
    }
}