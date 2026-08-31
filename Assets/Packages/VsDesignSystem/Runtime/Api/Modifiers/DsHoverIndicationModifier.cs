// ReSharper disable CheckNamespace

using SharpExtensions;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using VS.UiToolkit.Packages.VsDesignSystem.Runtime.Impl.Extensions;

namespace VS.UiToolkit;

public static partial class ModifierExtensions
{
    [Composable]
    public static IModifier DsHoverIndication(
        this IModifier modifier,
        IMutableInteractionSource? interactionSource = null,
        bool enabled = true
    )
    {
        if (!enabled)
            return modifier;
        interactionSource ??= Remember(MutableInteractionSource);
        return modifier
            .Clip()
            .Hoverable(interactionSource, enabled)
            .DrawAfter(() =>
            {
                var isHovered = interactionSource.CollectIsHoveredAsState().Value;
                var visibilityProgress = AnimateFloatAsState(isHovered.ToInt()).Value;
                Spacer(
                    modifier: Modifier
                        .Size(100.Percent())
                        .Clip(RoundedCornerShape(10.Dp()))
                        .Background(Color.cornflowerBlue.With(a: visibilityProgress * 0.5f))
                        .Scale(0.76f + 0.25f * visibilityProgress)
                        .Float()
                        .Offset(x: -50.Percent(), y: -50.Percent())
                        .Position(
                            top: 50.Percent(),
                            left: 50.Percent()
                        )
                );
            });
    }
}