using System;
using System.Collections;
using SharpExtensions;
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
}

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static ISingleAnimationPlayer RememberSingleAnimationPlayer(
        Optional<AnimationSpec> animationSpec
    )
    {
        var coroutineScope = RememberCoroutineScope();
        var result = Remember(coroutineScope, () => new SingleAnimationPlayerImpl(
            coroutineScope,
            animationSpec.GetOrDefault()
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
    private AnimationSpec _animationSpec;

    public SingleAnimationPlayerImpl(
        IComposeCoroutineScope coroutineScope,
        AnimationSpec animationSpec
    )
    {
        _animationSpec = animationSpec;
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
            var progress = (Time.time - startTime) / duration;
            progress = _animationSpec.GetProgress(progress);
            _progress.Value = backward ? 1 - progress : progress;
            yield return null;
        }

        var finalProgress = sticky ? 1f : 0f;
        if (backward)
            finalProgress = 1 - finalProgress;
        _progress.Value = finalProgress;
    }
}