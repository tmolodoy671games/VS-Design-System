// ReSharper disable CheckNamespace

using UnityCompose;
using UnityEngine;

namespace VS.UiToolkit;

public static partial class ModifierExtensions
{
    public static IModifier DsHoverIndication(
        this IModifier modifier,
        bool enabled = true
    )
    {
        if (!enabled)
            return modifier;
        return modifier + new DsHoverIndicationModifierImpl();
    }
}

internal partial class DsHoverIndicationModifierImpl : BaseComposableModifier<DsHoverIndicationModifierImpl>
{
    [Composable]
    public override void DrawAfter()
    {
        Spacer(
            modifier: Modifier
                .Size(20.Dp())
                .Border(10.Dp())
                .Background(Color.cornflowerBlue)
                .Alpha(0.5f)
                .Float()
                .Offset(x: -50.Percent(), y: -50.Percent())
                .Position(
                    top: 50.Percent(),
                    left: 50.Percent()
                )
        );
    }

    protected override bool Equals(DsHoverIndicationModifierImpl other)
    {
        return true;
    }
}