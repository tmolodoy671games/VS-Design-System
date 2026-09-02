using System;
using System.Collections;
using SharpExtensions;
using StableCollections;
using UnityCompose;
using UnityEngine;

// ReSharper disable CheckNamespace

namespace VS.UiToolkit;

public interface ISingleAnimationPlayer
{
    float Progress { get; }

    void Play(
        bool force = false,
        bool sticky = true,
        bool backward = false
    );

    IDisposable Subscribe(Action<float> onProgressChanged);

    void Reset();
}

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static ISingleAnimationPlayer RememberSingleAnimationPlayer(
        Optional<AnimationSpec> animationSpec = default
    )
    {
        var coroutineScope = RememberCoroutineScope();
        var result = Remember(coroutineScope, () => new SingleAnimationPlayerImpl(
            coroutineScope
        ));
        SideEffect(animationSpec, () => result.SetAnimationSpec(animationSpec.GetOrDefault()));
        return result;
    }
}

internal class SingleAnimationPlayerImpl : ISingleAnimationPlayer
{
    private readonly IComposeCoroutineScope _coroutineScope;
    private readonly IMutableState<float> _progress = MutableStateOf(0f);
    private IDisposable? _coroutine;
    private AnimationSpec _animationSpec = AnimationSpec.Default;
    private readonly IMutableStableList<Action<float>> _onProgressChanged = MutableStableListOf<Action<float>>();

    public SingleAnimationPlayerImpl(
        IComposeCoroutineScope coroutineScope
    )
    {
        _coroutineScope = coroutineScope;
    }

    public float Progress => _progress.Value;

    public void Play(
        bool force,
        bool sticky,
        bool backward
    )
    {
        if (force)
            _coroutine?.Dispose();
        _coroutine = _coroutineScope.StartCoroutine(AnimateProgressCoroutine(
            sticky: sticky,
            backward: backward
        ));
    }

    public IDisposable Subscribe(Action<float> onProgressChanged)
    {
        _onProgressChanged.Add(onProgressChanged);
        return new CustomDisposable(() => _onProgressChanged.Remove(onProgressChanged));
    }

    public void Reset()
    {
        _progress.Value = 0f;
    }

    public void SetAnimationSpec(AnimationSpec animationSpec)
    {
        _animationSpec = animationSpec;
    }

    private IEnumerator AnimateProgressCoroutine(bool sticky, bool backward)
    {
        var startTime = Time.time;
        var duration = _animationSpec.TotalDuration;
        while (Time.time - startTime < duration)
        {
            var timeElapsed = Time.time - startTime;
            var progress = _animationSpec.GetProgress(timeElapsed);
            _progress.Value = backward ? 1 - progress : progress;
            OnProgressChanged();
            yield return null;
        }

        var finalProgress = sticky ? 1f : 0f;
        if (backward)
            finalProgress = 1 - finalProgress;
        _progress.Value = finalProgress;
        OnProgressChanged();
    }

    private void OnProgressChanged()
    {
        var value = _progress.Value;
        foreach (var subscriber in _onProgressChanged)
            subscriber(value);
    }
}