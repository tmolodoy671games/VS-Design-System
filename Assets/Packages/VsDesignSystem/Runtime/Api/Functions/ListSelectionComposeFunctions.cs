// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using UnityCompose;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    private static readonly ICompositionLocal<IListSelection> LocalListSelection =
        CompositionLocalOf<IListSelection>(() =>
            throw new InvalidOperationException("LocalListSelection is not provided!")
        );

    private static readonly ICompositionLocal<IListSelectionItem> LocalListSelectionItem =
        CompositionLocalOf<IListSelectionItem>(() =>
            throw new InvalidOperationException("LocalListSelectionItem is not provided!")
        );

    [Composable]
    public static IListSelection RememberListSelection(
        Optional<AnimationSpec> animationSpec = default
    )

    {
        var coroutineScope = RememberCoroutineScope();
        return Remember(() => new ListSelectionImpl(coroutineScope, animationSpec.GetOrDefault()));
    }

    [Composable]
    public static void ListSelection(
        ComposableContent content,
        IListSelection? selection = null
    )
    {
        CompositionLocalProvider(
            LocalListSelection.Provides(selection ?? RememberListSelection()),
            content
        );
    }

    [Composable]
    public static void ListSelectionItem(ComposableContent<IListSelectionItem> content)
    {
        var selection = LocalListSelection.Current;
        var item = Remember(selection, selection.CreateItem);
        CompositionLocalProvider(
            LocalListSelectionItem.Provides(item),
            content: () => content(item)
        );
    }
}