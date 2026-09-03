using System;
using System.Collections;
using System.Linq;
using SharpExtensions;
using StableCollections;
using UnityCompose;
using UnityEngine;
using Random = System.Random;

// ReSharper disable CheckNamespace

namespace VS.UiToolkit;

public interface IListSelection
{
    int SelectedId { get; }
    IListSelectionItem CreateItem();

    void Select(ListSelectionChange change);
}

public enum ListSelectionChange
{
    Previous,
    Next,
}

public interface IListSelectionItem
{
    int Id { get; }
    bool IsSelected { get; }
    float SelectionProgress { get; }
    float Delay { get; }
    void Select();
    void Deselect();
}

internal class ListSelectionItemImpl : IListSelectionItem
{
    private readonly ListSelectionImpl _selection;

    public ListSelectionItemImpl(
        ListSelectionImpl selection,
        int id
    )
    {
        Id = id;
        _selection = selection;
    }

    public int Id { get; }
    public bool IsSelected => _selection.IsSelected(Id);
    public float SelectionProgress => _selection.SelectionProgress(Id);
    public float Delay => _selection.Delay(Id);
    public void Select() => _selection.Select(Id);
    public void Deselect() => _selection.Select(0);
}

internal class ListSelectionImpl : IListSelection
{
    private readonly IMutableState<int> _selection = MutableStateOf(0);
    private readonly IMutableStableList<float> _items = MutableStateListOf<float>();
    private readonly IMutableStableList<float> _delays = MutableStateListOf<float>();
    private readonly IComposeCoroutineScope _coroutineScope;
    private readonly AnimationSpec _animationSpec;
    private IDisposable? _coroutine;
    private readonly Random _random = new();

    public ListSelectionImpl(IComposeCoroutineScope coroutineScope, AnimationSpec animationSpec)
    {
        _coroutineScope = coroutineScope;
        _animationSpec = animationSpec;
    }

    public int SelectedId => _selection.Value;

    public IListSelectionItem CreateItem()
    {
        var index = _items.Count;
        var newItem = new ListSelectionItemImpl(
            selection: this,
            id: index
        );
        _items.Add(index == 0 ? 1 : 0);
        _delays.Add(_random.NextDouble().ToFloat().Remap(0, 1, 0.1f, 0.3f));
        Shuffle(_delays);
        return newItem;
    }

    public void Select(ListSelectionChange change)
    {
    }

    public bool IsSelected(int id) => _selection.Value == id;
    public float SelectionProgress(int id) => _items[id];

    public void Select(int index)
    {
        if (_selection.Value == index)
            return;
        _selection.Value = index;
        _coroutine?.Dispose();
        _coroutine = _coroutineScope.StartCoroutine(SelectCoroutine(index));
    }

    public float Delay(int id) => _delays[id];

    private IEnumerator SelectCoroutine(int selection)
    {
        var startTime = Time.time;
        var initialSelectionValue = _items[selection];
        var initialValues = new float[_items.Count];
        var initialOthersSum = 0f;

        for (var i = 0; i < _items.Count; i++)
        {
            initialValues[i] = _items[i];

            if (i != selection)
                initialOthersSum += _items[i];
        }

        while (Time.time - startTime < _animationSpec.TotalDuration)
        {
            var progress = _animationSpec.GetProgress(Time.time - startTime);
            var selectionValue = Mathf.LerpUnclamped(
                initialSelectionValue,
                1f,
                progress
            );
            _items[selection] = selectionValue;
            var remainingValue = 1f - selectionValue;
            var assigned = 0f;
            var lastOtherIndex = -1;

            for (var i = 0; i < _items.Count; i++)
            {
                if (i == selection)
                    continue;
                lastOtherIndex = i;
                var value = initialOthersSum > 0f
                    ? remainingValue * initialValues[i] / initialOthersSum
                    : 0f;
                _items[i] = value;
                assigned += value;
            }

            if (lastOtherIndex >= 0)
                _items[lastOtherIndex] += remainingValue - assigned;
            yield return null;
        }

        _items[selection] = 1f;
        for (var i = 0; i < _items.Count; i++)
        {
            if (i != selection)
                _items[i] = 0f;
        }
    }

    private static void Shuffle<T>(IMutableStableList<T> list)
    {
        // var random = new Random();
        // for (var i = 0; i < list.Count; i++)
        // {
        //     var j = random.Next(i + 1);
        //     (list[i], list[j]) = (list[j], list[i]);
        // }
    }
}