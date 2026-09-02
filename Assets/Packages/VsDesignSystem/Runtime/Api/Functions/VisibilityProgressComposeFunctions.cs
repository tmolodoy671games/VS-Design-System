// ReSharper disable CheckNamespace

using SharpExtensions;
using UnityCompose;
using UnityEngine;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static IState<float> VisibilityProgress(
        bool visible,
        Optional<AnimationSpec> animationSpec = default
    )
    {
        if (IsInPreview)
        {
            return MutableStateOf<float>(visible.ToInt());
        }
        var animation = RememberSingleAnimationPlayer(animationSpec);
        var result = Remember(() => MutableStateOf(0f));
        SideEffect(visible, () => animation.Play(force: true, backward: !visible));
        DisposableEffect(animation, scope =>
        {
            var disposable = animation.Subscribe(it =>
            {
                result.Value = it;
            });
            return scope.OnDispose(disposable.Dispose);
        });
        return result;
    }
}