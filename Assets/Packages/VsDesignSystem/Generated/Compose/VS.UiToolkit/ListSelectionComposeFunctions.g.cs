#nullable enable
// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static IListSelection __RememberListSelection(Optional<AnimationSpec> animationSpec = default, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var __dirty = __changed;
        if ((__changed & 0b_11) == 0)
            __dirty |= __composer.Changed(animationSpec) ? 0b_10 : 0b_01;
        var coroutineScope = __RememberCoroutineScope(__composer: __composer, __changed: 0b_00);
        return (!__composer.Changed() ? __composer.RememberedValue<global::VS.UiToolkit.ListSelectionImpl>() : __composer.UpdateRememberedValue<global::VS.UiToolkit.ListSelectionImpl>(new ListSelectionImpl(coroutineScope, animationSpec.GetOrDefault())));
    }

    public static void __ListSelection(ComposableContent content, IListSelection? selection = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__content, __selection) = (content, selection);
        var __isCreated = __composer.StartRestartGroup(1337872093);
        var __dirty = __changed;
        if ((__changed & 0b_00_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_10 : 0b_00_01;
        if ((__changed & 0b_11_00) == 0)
            __dirty |= __composer.Changed(selection) ? 0b_10_00 : 0b_01_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01)
        {
            __CompositionLocalProvider(LocalListSelection.Provides(selection ?? __RememberListSelection(__composer: __composer, __changed: 0b_01)), content, __composer: __composer, __changed: ((__dirty & 0b_00_11) << 2));
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01;
        __composer.EndRestartGroup(1337872093, __isRestarted)?.UpdateScope(() => __ListSelection(__content, __selection, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    public static void __ListSelectionItem(ComposableContent<IListSelectionItem> content, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var __content = (content);
        var __isCreated = __composer.StartRestartGroup(877338818);
        var __dirty = __changed;
        if ((__changed & 0b_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_10 : 0b_01;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01)
        {
            var selection = LocalListSelection.Current;
            var item = (!__composer.Changed<global::VS.UiToolkit.IListSelection>(selection!) ? __composer.RememberedValue<global::VS.UiToolkit.IListSelectionItem>() : __composer.UpdateRememberedValue<global::VS.UiToolkit.IListSelectionItem>(selection.CreateItem));
            __composer.StartReplaceGroup(350639283);
            __CompositionLocalProvider(LocalListSelectionItem.Provides(item), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_11) == 0b_10).Changed<global::VS.UiToolkit.IListSelectionItem>(item!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => content(item))), __composer: __composer, __changed: 0b_00_00);
            __composer.EndReplaceGroup(350639283);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01;
        __composer.EndRestartGroup(877338818, __isRestarted)?.UpdateScope(() => __ListSelectionItem(__content, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}