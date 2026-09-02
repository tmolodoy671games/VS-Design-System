#nullable enable
// ReSharper disable ArrangeNamespaceBody

using System;
using Sirenix.OdinInspector;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using SharpExtensions;
using static UnityCompose.ComposeFunctions;

namespace Samples.Samples.Behaviors
{
    internal partial class UiToolkitShowcase
    {
        protected override void __Content(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1143526624);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __WithTheme((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Box(alignment: Alignment.Center, modifier: Modifier.FillMaxSize(), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __Column(horizontalAlignment: Alignment.CenterHorizontally, content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                        {
                            __TabsSample(__composer: __composer, __changed: 0b_00);
                            __Spacer(Modifier.Height(64.Dp()), __composer: __composer, __changed: 0b_00);
                            __Row(modifier: Modifier.Background(Theme.ColorScheme.Surface).Padding(all: 16.Dp()).Clip(RoundedCornerShape(16.Dp())), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                            {
                                __Buttons(__composer: __composer, __changed: 0b_00);
                                __Spacer(Modifier.Width(16.Dp()), __composer: __composer, __changed: 0b_00);
                                __Switches(__composer: __composer, __changed: 0b_00);
                                __Spacer(Modifier.Width(16.Dp()), __composer: __composer, __changed: 0b_00);
                                __Column((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                                {
                                    __Sliders(__composer: __composer, __changed: 0b_00);
                                    __Selection(__composer: __composer, __changed: 0b_00);
                                    __AlertDialogSample(__composer: __composer, __changed: 0b_00);
                                    __DropdownSample(__composer: __composer, __changed: 0b_00);
                                })), __composer: __composer, __changed: 0b_01_01_01_00);
                            })), __composer: __composer, __changed: 0b_01_01_00_00);
                        })), __composer: __composer, __changed: 0b_01_00_01_00);
                    })), __composer: __composer, __changed: 0b_00_00_00);
                })), __composer: __composer, __changed: 0b_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(1143526624, __isRestarted)?.UpdateScope(() => __Content(__composer, 0));
        }

        protected override void __Preview(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(452502114);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __Content(__composer: __composer, __changed: 0b_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(452502114, __isRestarted)?.UpdateScope(() => __Preview(__composer, 0));
        }

        private static void __Buttons(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1432834659);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __Column((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Button(onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Button ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_00_00);
                    __Button(enabled: false, onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Disabled Button ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_00_00);
                    __SecondaryButton(onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("SecondaryButton ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_00_00);
                    __SecondaryButton(enabled: false, onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Disabled SecondaryButton ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_00_00);
                    __TextButton(onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("TextButton ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_00_00);
                    __TextButton(enabled: false, onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Disabled TextButton ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_00_00);
                })), __composer: __composer, __changed: 0b_01_01_01_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(1432834659, __isRestarted)?.UpdateScope(() => __Buttons(__composer, 0));
        }

        private static void __Switches(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(107688370);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __Column((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    var isChecked = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<bool>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<bool>>(MutableStateOf(true)));
                    __Switch(isChecked: isChecked.Value, onCheckedChange: (!__composer.Changed<global::UnityCompose.IMutableState<bool>>(isChecked!) ? __composer.RememberedValue<global::System.Action<bool>>() : __composer.UpdateRememberedValue<global::System.Action<bool>>(it => isChecked.Value = it)), __composer: __composer, __changed: 0b_01_01_01_01_01_00_00);
                    __Switch(isChecked: false, onCheckedChange: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action<bool>>() : __composer.UpdateRememberedValue<global::System.Action<bool>>(_ =>
                    {
                    })), __composer: __composer, __changed: 0b_01_01_01_01_01_00_01);
                    __Switch(isChecked: true, onCheckedChange: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action<bool>>() : __composer.UpdateRememberedValue<global::System.Action<bool>>(_ =>
                    {
                    })), enabled: false, __composer: __composer, __changed: 0b_01_01_01_01_01_00_01);
                    __Switch(isChecked: false, onCheckedChange: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action<bool>>() : __composer.UpdateRememberedValue<global::System.Action<bool>>(_ =>
                    {
                    })), enabled: false, __composer: __composer, __changed: 0b_01_01_01_01_01_00_01);
                })), __composer: __composer, __changed: 0b_01_01_01_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(107688370, __isRestarted)?.UpdateScope(() => __Switches(__composer, 0));
        }

        private static void __Sliders(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(2136478715);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __Column((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    var sliderValue = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<float>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<float>>(MutableStateOf(0.75f)));
                    __Slider(value: sliderValue.Value, onValueChange: (!__composer.Changed<global::UnityCompose.IMutableState<float>>(sliderValue!) ? __composer.RememberedValue<global::System.Action<float>>() : __composer.UpdateRememberedValue<global::System.Action<float>>(it => sliderValue.Value = it)), steps: 4, __composer: __composer, __changed: 0b_01_01_01_01_01_00_00);
                    __Slider(value: 0.5f, onValueChange: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action<float>>() : __composer.UpdateRememberedValue<global::System.Action<float>>(_ =>
                    {
                    })), steps: 4, enabled: false, __composer: __composer, __changed: 0b_01_01_01_01_01_00_01);
                })), __composer: __composer, __changed: 0b_01_01_01_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(2136478715, __isRestarted)?.UpdateScope(() => __Sliders(__composer, 0));
        }

        private static void __Selection(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1669558311);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                var bounce = Theme.AnimationSpecs.Bounce;
                __Row((!__composer.Changed<global::UnityCompose.AnimationSpec>(bounce!) ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __ListSelection(selection: __RememberListSelection(bounce, __composer: __composer, __changed: 0b_00), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __ListSelectionItem((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(scope =>
                        {
                            var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
                            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
                            __SideEffect(isHovered, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.IListSelectionItem>(scope!).Changed<bool>(isHovered!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                            {
                                if (isHovered)
                                    scope.Select();
                            })), __composer: __composer, __changed: 0b_00_00);
                            __Spacer(Modifier.Hoverable(interactionSource).Background(Color.indianRed).Height(40.Dp()).Width(80.Dp() + scope.SelectionProgress * 120.Dp()), __composer: __composer, __changed: 0b_00);
                        })), __composer: __composer, __changed: 0b_00);
                        __ListSelectionItem((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(scope =>
                        {
                            var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
                            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
                            __SideEffect(isHovered, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.IListSelectionItem>(scope!).Changed<bool>(isHovered!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                            {
                                if (isHovered)
                                    scope.Select();
                            })), __composer: __composer, __changed: 0b_00_00);
                            __Spacer(Modifier.Hoverable(interactionSource).Background(Color.lightGreen).Height(40.Dp()).Width(80.Dp() + scope.SelectionProgress * 120.Dp()), __composer: __composer, __changed: 0b_00);
                        })), __composer: __composer, __changed: 0b_00);
                        __ListSelectionItem((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(scope =>
                        {
                            var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
                            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
                            __SideEffect(isHovered, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.IListSelectionItem>(scope!).Changed<bool>(isHovered!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                            {
                                if (isHovered)
                                    scope.Select();
                            })), __composer: __composer, __changed: 0b_00_00);
                            __Spacer(Modifier.Hoverable(interactionSource).Background(Color.cornflowerBlue).Height(40.Dp()).Width(80.Dp() + scope.SelectionProgress * 120.Dp()), __composer: __composer, __changed: 0b_00);
                        })), __composer: __composer, __changed: 0b_00);
                    })), __composer: __composer, __changed: 0b_00_00);
                })), __composer: __composer, __changed: 0b_01_01_01_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(1669558311, __isRestarted)?.UpdateScope(() => __Selection(__composer, 0));
        }

        private static void __AlertDialogSample(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(929855255);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                var alertDialogVisibility = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<bool>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<bool>>(MutableStateOf(false)));
                __composer.StartReplaceGroup(1135512664);
                if (alertDialogVisibility.Value)
                {
                    __ModalMenu((!__composer.Changed<global::UnityCompose.IMutableState<bool>>(alertDialogVisibility!) ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __WithTheme((!__composer.Changed<global::UnityCompose.IMutableState<bool>>(alertDialogVisibility!) ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                        {
                            __AlertDialog(onDismiss: (!__composer.Changed<global::UnityCompose.IMutableState<bool>>(alertDialogVisibility!) ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => alertDialogVisibility.Value = false)), title: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Alert Dialog Title", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), text: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Alert Dialog Text", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), confirmButton: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __AlertDialogButton(onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                            {
                            })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Confirm", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_00_00))), actionButton: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __AlertDialogButton(onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                            {
                            })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Action", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_00_00))), dismissButton: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __AlertDialogButton(onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                            {
                            })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Dismiss", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_00_00))), __composer: __composer, __changed: 0b_01_01_00_00_00_00_00_00);
                        })), __composer: __composer, __changed: 0b_00);
                    })), __composer: __composer, __changed: 0b_01_00);
                }

                __composer.EndReplaceGroup(1135512664);
                __Button(onClick: (!__composer.Changed<global::UnityCompose.IMutableState<bool>>(alertDialogVisibility!) ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => alertDialogVisibility.Value = true)), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Show AlertDialog", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_00_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(929855255, __isRestarted)?.UpdateScope(() => __AlertDialogSample(__composer, 0));
        }

        private static void __TabsSample(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1294453841);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                var currentTab = MutableStateOf(0);
                __Tabs((!__composer.Changed<global::UnityCompose.IMutableState<int>>(currentTab!) ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Tab(selected: currentTab.Value == 0, onClick: (!__composer.Changed<global::UnityCompose.IMutableState<int>>(currentTab!) ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => currentTab.Value = 0)), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Inventory", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_00_00_00);
                    __Tab(selected: currentTab.Value == 1, onClick: (!__composer.Changed<global::UnityCompose.IMutableState<int>>(currentTab!) ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => currentTab.Value = 1)), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Map", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_00_00_00);
                    __Tab(selected: currentTab.Value == 2, onClick: (!__composer.Changed<global::UnityCompose.IMutableState<int>>(currentTab!) ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => currentTab.Value = 2)), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("System", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_00_00_00);
                })), __composer: __composer, __changed: 0b_01_01_01_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(1294453841, __isRestarted)?.UpdateScope(() => __TabsSample(__composer, 0));
        }

        private static void __DropdownSample(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(159246542);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                var state = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<string>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<string>>(MutableStateOf("Item 1")));
                var isExpanded = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableState<bool>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableState<bool>>(MutableStateOf(false)));
                __Dropdown(state: state.Value, expanded: isExpanded.Value, onClick: (!__composer.Changed<global::UnityCompose.IMutableState<bool>>(isExpanded!) ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => isExpanded.Value = true)), onDismiss: (!__composer.Changed<global::UnityCompose.IMutableState<bool>>(isExpanded!) ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => isExpanded.Value = false)), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<string>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<string>>(it => __Text(it, __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_00))), sizeContent: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Item 1000", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), dropdownContent: (!__composer.Changed<global::UnityCompose.IMutableState<string>>(state!) ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __composer.StartReplaceGroup(1228399252);
                    for (var i = 0; i < 20; i++)
                    {
                        var currentI = i;
                        __DropdownItem(onClick: (!__composer.BuildChanged().Changed<global::UnityCompose.IMutableState<string>>(state!).Changed<int>(currentI!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() => state.Value = $"Item {currentI}")), content: (!__composer.Changed<int>(currentI!) ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text($"Item {currentI}", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_00))), __composer: __composer, __changed: 0b_01_00_00);
                    }

                    __composer.EndReplaceGroup(1228399252);
                })), __composer: __composer, __changed: 0b_01_01_00_00_00_00_00_00_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(159246542, __isRestarted)?.UpdateScope(() => __DropdownSample(__composer, 0));
        }
    }
}