#nullable enable
// ReSharper disable CheckNamespace

using System;
using UnityCompose;
using SharpExtensions;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __WithTheme(ComposableContent content, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var __content = (content);
        var __isCreated = __composer.StartRestartGroup(364224264);
        var __dirty = __changed;
        if ((__changed & 0b_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_10 : 0b_01;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01)
        {
            __CompositionLocalProvider(LocalTheme.Provides(DsThemeHolder.CurrentTheme), content, __composer: __composer, __changed: ((__dirty & 0b_00_11) << 2));
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01;
        __composer.EndRestartGroup(364224264, __isRestarted)?.UpdateScope(() => __WithTheme(__content, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}