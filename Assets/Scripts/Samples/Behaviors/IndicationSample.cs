// ReSharper disable ArrangeNamespaceBody

using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using VS.UiToolkit;

namespace Samples.Samples.Behaviors
{
    internal partial class IndicationSample : ComposeUI
    {
        [Composable]
        protected override void Content()
        {
            WithDsTheme(() =>
            {
                Box(
                    alignment: Alignment.Center,
                    modifier: Modifier.FillMaxSize(),
                    content: () =>
                    {
                        var interactionSource = Remember(MutableInteractionSource);
                        var isHovered = interactionSource.CollectIsHoveredAsState().Value;
                        var isPressed = interactionSource.CollectIsPressedAsState().Value;
                        Box(
                            alignment: Alignment.Center,
                            modifier: Modifier
                                .Padding(
                                    horizontal: 32.Dp(),
                                    vertical: 8.Dp()
                                )
                                .Scale(AnimateFloatAsState(isHovered ? 1.1f : 1f).Value)
                                .Border(32.Dp())
                                .Background(DsTheme.ColorScheme.Primary)
                                .DsClickIndication(
                                    onClick: () => { },
                                    interactionSource: interactionSource
                                ),
                            content: () =>
                            {
                                CompositionLocalProvider(
                                    LocalContentColor.Provides(DsTheme.ColorScheme.OnPrimary),
                                    () =>
                                    {
                                        Text(
                                            text: "Click me!",
                                            fontSize: 64.Sp(),
                                            modifier: Modifier
                                                .Scale(
                                                    AnimateFloatAsState(isPressed ? 0.75f : 1f).Value
                                                )
                                        );
                                    }
                                );
                            }
                        );
                    }
                );
            });
        }

        [Composable]
        protected override void Preview()
        {
            Content();
        }
    }
}