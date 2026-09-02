#nullable enable
// ReSharper disable ArrangeNamespaceBody

using System.Reflection.Emit;
using Sirenix.OdinInspector;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using UnityEngine;
using Label = UnityEngine.UIElements.Label;
using System;
using SharpExtensions;
using static UnityCompose.ComposeFunctions;

namespace Samples.Samples.Behaviors
{
    internal partial class UiToolkitShowcase
    {
        protected override void __Content(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1687940705);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __WithTheme((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Box(alignment: Alignment.Center, modifier: Modifier.FillMaxSize(), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
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
                            })), __composer: __composer, __changed: 0b_01_01_01_00);
                        })), __composer: __composer, __changed: 0b_01_01_00_00);
                    })), __composer: __composer, __changed: 0b_00_00_00);
                })), __composer: __composer, __changed: 0b_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(1687940705, __isRestarted)?.UpdateScope(() => __Content(__composer, 0));
        }

        protected override void __Preview(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(958464444);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __Content(__composer: __composer, __changed: 0b_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(958464444, __isRestarted)?.UpdateScope(() => __Preview(__composer, 0));
        }

        private static void __Buttons(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1807169796);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __Column((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Button(onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Button ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_00_00);
                    __Button(enabled: false, onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Disabled Button ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_00_00);
                    __SecondaryButton(onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("SecondaryButton ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_00_00);
                    __SecondaryButton(enabled: false, onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Disabled SecondaryButton ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_00_00);
                    __TextButton(onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("TextButton ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_00_00);
                    __TextButton(enabled: false, onClick: (!__composer.Changed() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                    {
                    })), content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() => __Text("Disabled TextButton ", __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_01_01))), __composer: __composer, __changed: 0b_01_01_01_01_01_01_01_00_00);
                })), __composer: __composer, __changed: 0b_01_01_01_00);
            }
            else
            {
                __composer.SkipToGroupEnd();
            }

            __composer.EndRestartGroup(1807169796, __isRestarted)?.UpdateScope(() => __Buttons(__composer, 0));
        }

        private static void __Switches(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1983418007);
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

            __composer.EndRestartGroup(1983418007, __isRestarted)?.UpdateScope(() => __Switches(__composer, 0));
        }

        private static void __Sliders(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1631338009);
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

            __composer.EndRestartGroup(1631338009, __isRestarted)?.UpdateScope(() => __Sliders(__composer, 0));
        }

        private static void __Selection(global::UnityCompose.Composer __composer = null !, int __changed = -1)
        {
            var __isCreated = __composer.StartRestartGroup(1847619751);
            var __isRestarted = __composer.IsRestarted();
            if (__isCreated || __isRestarted || __changed != 0b_00)
            {
                __Row((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __ListSelection(animationSpec: Theme.AnimationSpecs.Bounce, content: (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __ListSelectionItem((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionScope>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionScope>>(scope =>
                        {
                            var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
                            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
                            __SideEffect(isHovered, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.IListSelectionScope>(scope!).Changed<bool>(isHovered!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                            {
                                if (isHovered)
                                    scope.Select();
                            })), __composer: __composer, __changed: 0b_00_00);
                            __Spacer(Modifier.Hoverable(interactionSource).Background(Color.indianRed).Height(40.Dp()).Width(80.Dp() + scope.SelectionProgress * 120.Dp()), __composer: __composer, __changed: 0b_00);
                        })), __composer: __composer, __changed: 0b_00);
                        __ListSelectionItem((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionScope>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionScope>>(scope =>
                        {
                            var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
                            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
                            __SideEffect(isHovered, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.IListSelectionScope>(scope!).Changed<bool>(isHovered!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                            {
                                if (isHovered)
                                    scope.Select();
                            })), __composer: __composer, __changed: 0b_00_00);
                            __Spacer(Modifier.Hoverable(interactionSource).Background(Color.lightGreen).Height(40.Dp()).Width(80.Dp() + scope.SelectionProgress * 120.Dp()), __composer: __composer, __changed: 0b_00);
                        })), __composer: __composer, __changed: 0b_00);
                        __ListSelectionItem((!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionScope>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionScope>>(scope =>
                        {
                            var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
                            var isHovered = interactionSource.__CollectIsHoveredAsState(__composer: __composer, __changed: 0b_00).Value;
                            __SideEffect(isHovered, (!__composer.BuildChanged().Changed<global::VS.UiToolkit.IListSelectionScope>(scope!).Changed<bool>(isHovered!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
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

            __composer.EndRestartGroup(1847619751, __isRestarted)?.UpdateScope(() => __Selection(__composer, 0));
        }
    }
}