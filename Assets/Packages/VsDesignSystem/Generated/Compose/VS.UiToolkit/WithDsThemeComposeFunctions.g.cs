#nullable enable
// ReSharper disable CheckNamespace

using UnityCompose;
using System;
using SharpExtensions;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __WithDsTheme(ComposableContent content, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var __content = (content);
        var __isCreated = __composer.StartRestartGroup(1639732998);
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
        __composer.EndRestartGroup(1639732998, __isRestarted)?.UpdateScope(() => __WithDsTheme(__content, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}