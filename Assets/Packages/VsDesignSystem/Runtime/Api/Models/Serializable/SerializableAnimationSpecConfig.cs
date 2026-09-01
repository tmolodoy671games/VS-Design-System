// ReSharper disable CheckNamespace

using System;
using UnityCompose;
using UnityEngine;

namespace VS.UiToolkit;

[Serializable]
public class SerializableAnimationSpecConfig
{
    [SerializeField] private SerializableAnimationSpec bounce = new();

    public AnimationSpecConfig ToAnimationSpecConfig()
    {
        return new AnimationSpecConfig(
            Bounce: bounce.ToAnimationSpec()
        );
    }
}

[Serializable]
public class SerializableAnimationSpec
{
    [SerializeField] private AnimationCurve curve = new();
    [SerializeField] private float duration = 0.25f;
    [SerializeField] private float delay = 0f;

    public AnimationSpec ToAnimationSpec()
    {
        return Tween(
            easing: AnimationCurveEasing(curve),
            duration: duration,
            delay: delay
        );
    }
}