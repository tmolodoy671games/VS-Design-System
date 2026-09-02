// ReSharper disable ArrangeNamespaceBody

using System;
using Sirenix.OdinInspector;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;

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
                        Column(
                            horizontalAlignment: Alignment.CenterHorizontally,
                            content: () =>
                            {
                                TabsSample();
                                Spacer(Modifier.Height(64.Dp()));
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
                                            var alertDialogVisibility = Remember(() => MutableStateOf(false));
                                            Button(
                                                onClick: () => alertDialogVisibility.Value = true,
                                                content: () => Text("Show AlertDialog")
                                            );
                                            if (alertDialogVisibility.Value)
                                                AlertDialogSample(() => alertDialogVisibility.Value = false);
                                        });
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
            var bounce = Theme.AnimationSpecs.Bounce;
            Row(() =>
            {
                ListSelection(
                    selection: RememberListSelection(bounce),
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

        [Composable]
        private static void AlertDialogSample(Action onDismiss)
        {
            ModalMenu(() =>
            {
                WithTheme(() =>
                {
                    AlertDialog(
                        onDismiss: onDismiss,
                        title: () => Text("Alert Dialog Title"),
                        text: () => Text("Alert Dialog Text"),
                        confirmButton: () => AlertDialogButton(
                            onClick: () => { },
                            content: () => Text("Confirm")
                        ),
                        actionButton: () => AlertDialogButton(
                            onClick: () => { },
                            content: () => Text("Action")
                        ),
                        dismissButton: () => AlertDialogButton(
                            onClick: () => { },
                            content: () => Text("Dismiss")
                        )
                    );
                });
            });
        }

        [Composable]
        private static void TabsSample()
        {
            var currentTab = MutableStateOf(0);
            Tabs(() =>
            {
                Tab(
                    selected: currentTab.Value == 0,
                    onClick: () => currentTab.Value = 0,
                    content: () => Text("Inventory")
                );
                Tab(
                    selected: currentTab.Value == 1,
                    onClick: () => currentTab.Value = 1,
                    content: () => Text("Map")
                );
                Tab(
                    selected: currentTab.Value == 2,
                    onClick: () => currentTab.Value = 2,
                    content: () => Text("System")
                );
            });
        }
    }
}