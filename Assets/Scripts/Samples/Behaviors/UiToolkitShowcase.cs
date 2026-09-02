// ReSharper disable ArrangeNamespaceBody

using System.Reflection.Emit;
using Sirenix.OdinInspector;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using Label = UnityEngine.UIElements.Label;

namespace Samples.Samples.Behaviors
{
    [HideMonoScript]
    internal partial class UiToolkitShowcase : ComposeUI
    {
        [Composable]
        protected override void Content()
        {
            WithTheme(() =>
            {
                Box(
                    alignment: Alignment.Center,
                    modifier: Modifier.FillMaxSize(),
                    content: () =>
                    {
                        Row(
                            modifier: Modifier
                                .Background(Theme.ColorScheme.Surface)
                                .Padding(all: 16.Dp())
                                .Clip(RoundedCornerShape(16.Dp())),
                            content: () =>
                            {
                                Buttons();
                                Spacer(Modifier.Width(16.Dp()));
                                Switches();
                                Spacer(Modifier.Width(16.Dp()));
                                Column(() =>
                                {
                                    Sliders();
                                    Selection();
                                });
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

        [Composable]
        private static void Buttons()
        {
            Column(() =>
            {
                Button(
                    onClick: () => { },
                    content: () => Text("Button ")
                );
                Button(
                    enabled: false,
                    onClick: () => { },
                    content: () => Text("Disabled Button ")
                );
                SecondaryButton(
                    onClick: () => { },
                    content: () => Text("SecondaryButton ")
                );
                SecondaryButton(
                    enabled: false,
                    onClick: () => { },
                    content: () => Text("Disabled SecondaryButton ")
                );
                TextButton(
                    onClick: () => { },
                    content: () => Text("TextButton ")
                );
                TextButton(
                    enabled: false,
                    onClick: () => { },
                    content: () => Text("Disabled TextButton ")
                );
            });
        }

        [Composable]
        private static void Switches()
        {
            Column(() =>
            {
                var isChecked = Remember(() => MutableStateOf(true));
                Switch(
                    isChecked: isChecked.Value,
                    onCheckedChange: it => isChecked.Value = it
                );
                Switch(
                    isChecked: false,
                    onCheckedChange: _ => { }
                );
                Switch(
                    isChecked: true,
                    onCheckedChange: _ => { },
                    enabled: false
                );
                Switch(
                    isChecked: false,
                    onCheckedChange: _ => { },
                    enabled: false
                );
            });
        }

        [Composable]
        private static void Sliders()
        {
            Column(() =>
            {
                var sliderValue = Remember(() => MutableStateOf(0.75f));
                Slider(
                    value: sliderValue.Value,
                    onValueChange: it => sliderValue.Value = it,
                    steps: 4
                );
                Slider(
                    value: 0.5f,
                    onValueChange: _ => { },
                    steps: 4,
                    enabled: false
                );
            });
        }

        [Composable]
        private static void Selection()
        {
            Row(() =>
            {
                ListSelection(
                    animationSpec: Theme.AnimationSpecs.Bounce,
                    content: () =>
                    {
                        ListSelectionItem(scope =>
                        {
                            var interactionSource = Remember(MutableInteractionSource);
                            var isHovered = interactionSource.CollectIsHoveredAsState().Value;
                            SideEffect(isHovered, () =>
                            {
                                if (isHovered)
                                    scope.Select();
                            });
                            Spacer(
                                Modifier
                                    .Hoverable(interactionSource)
                                    .Background(Color.indianRed)
                                    .Height(40.Dp())
                                    .Width(80.Dp() + scope.SelectionProgress * 120.Dp())
                            );
                        });

                        ListSelectionItem(scope =>
                        {
                            var interactionSource = Remember(MutableInteractionSource);
                            var isHovered = interactionSource.CollectIsHoveredAsState().Value;
                            SideEffect(isHovered, () =>
                            {
                                if (isHovered)
                                    scope.Select();
                            });
                            Spacer(
                                Modifier
                                    .Hoverable(interactionSource)
                                    .Background(Color.lightGreen)
                                    .Height(40.Dp())
                                    .Width(80.Dp() + scope.SelectionProgress * 120.Dp())
                            );
                        });

                        ListSelectionItem(scope =>
                        {
                            var interactionSource = Remember(MutableInteractionSource);
                            var isHovered = interactionSource.CollectIsHoveredAsState().Value;
                            SideEffect(isHovered, () =>
                            {
                                if (isHovered)
                                    scope.Select();
                            });
                            Spacer(
                                Modifier
                                    .Hoverable(interactionSource)
                                    .Background(Color.cornflowerBlue)
                                    .Height(40.Dp())
                                    .Width(80.Dp() + scope.SelectionProgress * 120.Dp())
                            );
                        });
                    }
                );
            });
        }
    }
}