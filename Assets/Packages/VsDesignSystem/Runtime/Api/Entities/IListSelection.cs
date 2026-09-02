using System;
using System.Collections;
using StableCollections;
using UnityCompose;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace VS.UiToolkit;

public interface IListSelection
{
    IListSelectionScope CreateItem();

    void Select(ListSelectionChange change);
}

public enum ListSelectionChange
{
    Previous,
    Next,
}

public interface IListSelectionScope
{
    bool IsSelected { get; }
    float SelectionProgress { get; }
    void Select();
}

internal class ListSelectionScopeImpl : IListSelectionScope
{
    private readonly Func<bool> _isSelected;
    private readonly Func<float> _selectionProgress;
    private readonly Action _select;

    public ListSelectionScopeImpl(
        Func<bool> isSelected,
        Func<float> selectionProgress,
        Action select
    )
    {
        _isSelected = isSelected;
        _selectionProgress = selectionProgress;
        _select = select;
    }

    public bool IsSelected => _isSelected();
    public float SelectionProgress => _selectionProgress();
    public void Select() => _select();
}

internal class ListSelectionImpl : IListSelection
{
    private readonly IMutableState<int> _selection = MutableStateOf(0);
    private readonly IMutableStableList<float> _items = MutableStateListOf<float>();
    private readonly IComposeCoroutineScope _coroutineScope;
    private readonly AnimationSpec _animationSpec;
    private IDisposable? _coroutine;

    public ListSelectionImpl(IComposeCoroutineScope coroutineScope, AnimationSpec animationSpec)
    {
        _coroutineScope = coroutineScope;
        _animationSpec = animationSpec;
    }

    public IListSelectionScope CreateItem()
    {
        var index = _items.Count;
        var newItem = new ListSelectionScopeImpl(
            isSelected: () => _selection.Value == index,
            selectionProgress: () => _items[index],
            select: () => Select(index)
        );
        _items.Add(index == 0 ? 1 : 0);
        return newItem;
    }

    public void Select(ListSelectionChange change)
    {
    }

    private void Select(int index)
    {
        if (_selection.Value == index)
            return;
        _selection.Value = index;
        _coroutine?.Dispose();
        _coroutine = _coroutineScope.StartCoroutine(SelectCoroutine(index));
    }

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
}