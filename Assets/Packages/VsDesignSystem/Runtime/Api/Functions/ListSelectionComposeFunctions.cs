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

    [Composable]
    public static void ListSelection(
        ComposableContent content,
        Optional<AnimationSpec> animationSpec = default
    )
    {
        var coroutineScope = RememberCoroutineScope();
        var listSelection = Remember(() => new ListSelectionImpl(coroutineScope, animationSpec.GetOrDefault()));
        CompositionLocalProvider(
            LocalListSelection.Provides(listSelection),
            content
        );
    }

    [Composable]
    public static void ListSelectionItem(ComposableContent<IListSelectionScope> content)
    {
        var selection = LocalListSelection.Current;
        var item = Remember(selection, selection.CreateItem);
        content(item);
    }
}