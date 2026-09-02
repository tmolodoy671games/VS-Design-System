#nullable enable
// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __ListSelection(ComposableContent content, Optional<AnimationSpec> animationSpec = default, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__content, __animationSpec) = (content, animationSpec);
        var __isCreated = __composer.StartRestartGroup(481524893);
        var __dirty = __changed;
        if ((__changed & 0b_00_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_10 : 0b_00_01;
        if ((__changed & 0b_11_00) == 0)
            __dirty |= __composer.Changed(animationSpec) ? 0b_10_00 : 0b_01_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01)
        {
            var coroutineScope = __RememberCoroutineScope(__composer: __composer, __changed: 0b_00);
            var listSelection = (!__composer.Changed() ? __composer.RememberedValue<global::VS.UiToolkit.ListSelectionImpl>() : __composer.UpdateRememberedValue<global::VS.UiToolkit.ListSelectionImpl>(new ListSelectionImpl(coroutineScope, animationSpec.GetOrDefault())));
            __CompositionLocalProvider(LocalListSelection.Provides(listSelection), content, __composer: __composer, __changed: ((__dirty & 0b_00_11) << 2));
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01;
        __composer.EndRestartGroup(481524893, __isRestarted)?.UpdateScope(() => __ListSelection(__content, __animationSpec, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    public static void __ListSelectionItem(ComposableContent<IListSelectionScope> content, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var __content = (content);
        var __isCreated = __composer.StartRestartGroup(1225302210);
        var __dirty = __changed;
        if ((__changed & 0b_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_10 : 0b_01;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01)
        {
            var selection = LocalListSelection.Current;
            var item = (!__composer.Changed<global::VS.UiToolkit.IListSelection>(selection!) ? __composer.RememberedValue<global::VS.UiToolkit.IListSelectionScope>() : __composer.UpdateRememberedValue<global::VS.UiToolkit.IListSelectionScope>(selection.CreateItem));
            __composer.StartReplaceGroup(7097093);
            content(item);
            __composer.EndReplaceGroup(7097093);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01;
        __composer.EndRestartGroup(1225302210, __isRestarted)?.UpdateScope(() => __ListSelectionItem(__content, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}