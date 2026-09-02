#nullable enable
// ReSharper disable CheckNamespace

using System;
using SharpExtensions;
using StableCollections;
using UnityCompose;
using UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils;
using static UnityCompose.ComposeFunctions;

namespace VS.UiToolkit;
public static partial class UiToolkitComposeFunctions
{
    public static void __Tabs(ComposableContent content, Optional<AnimationSpec> animationSpec = default, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__content, __animationSpec, __modifier) = (content, animationSpec, modifier);
        var __isCreated = __composer.StartRestartGroup(1314956366);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_10 : 0b_00_00_01;
        if ((__changed & 0b_00_11_00) == 0)
            __dirty |= __composer.Changed(animationSpec) ? 0b_00_10_00 : 0b_00_01_00;
        if ((__changed & 0b_11_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00 : 0b_01_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01)
        {
            var theme = Theme;
            var colors = theme.ColorScheme;
            animationSpec = animationSpec.GetOrDefault(Tween(duration: 0.25f));
            __Surface(color: colors.Primary, modifier: modifier.OrEmpty().Clip(RoundedCornerShape(16.Dp())), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11) == 0b_00_00_10).Changed<global::SharpExtensions.Optional<global::UnityCompose.AnimationSpec>>(animationSpec!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
            {
                __FixedSize((!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11) == 0b_00_00_10).Changed<global::SharpExtensions.Optional<global::UnityCompose.AnimationSpec>>(animationSpec!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Row(horizontalArrangement: Arrangement.Center, verticalAlignment: Alignment.CenterVertically, content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11) == 0b_00_00_10).Changed<global::SharpExtensions.Optional<global::UnityCompose.AnimationSpec>>(animationSpec!).Changed<global::VS.UiToolkit.ColorSchemeConfig>(colors!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        var selection = __RememberListSelection(__composer: __composer, __changed: 0b_01);
                        var tabLayouts = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.IMutableStateDictionary<int, global::UnityCompose.LayoutCoordinates>>() : __composer.UpdateRememberedValue<global::UnityCompose.IMutableStateDictionary<int, global::UnityCompose.LayoutCoordinates>>(MutableStateDictionaryOf<int, LayoutCoordinates>));
                        var selectedId = selection.SelectedId;
                        __composer.StartReplaceGroup(1548542559);
                        if (tabLayouts.ContainsKey(selectedId))
                        {
                            __Spacer(Modifier.Background(colors.OnPrimary).Alpha(0.1f).Clip(RoundedCornerShape(16.Dp())).Size(width: __AnimateFloatAsState(key: selectedId, targetValueFactory: (!__composer.BuildChanged().Changed<global::UnityCompose.IMutableStateDictionary<int, global::UnityCompose.LayoutCoordinates>>(tabLayouts!).Changed<int>(selectedId!).Get() ? __composer.RememberedValue<global::System.Func<float>>() : __composer.UpdateRememberedValue<global::System.Func<float>>(() => tabLayouts[selectedId].Size.x)), animationSpec: animationSpec, __composer: __composer, __changed: 0b_00_00_00).Value.Dp(), height: __AnimateFloatAsState(key: selectedId, targetValueFactory: (!__composer.BuildChanged().Changed<global::UnityCompose.IMutableStateDictionary<int, global::UnityCompose.LayoutCoordinates>>(tabLayouts!).Changed<int>(selectedId!).Get() ? __composer.RememberedValue<global::System.Func<float>>() : __composer.UpdateRememberedValue<global::System.Func<float>>(() => tabLayouts[selectedId].Size.y)), animationSpec: animationSpec, __composer: __composer, __changed: 0b_00_00_00).Value.Dp()).Scale(1.01f).Float().Position(left: __AnimateFloatAsState(key: selectedId, targetValueFactory: (!__composer.BuildChanged().Changed<global::UnityCompose.IMutableStateDictionary<int, global::UnityCompose.LayoutCoordinates>>(tabLayouts!).Changed<int>(selectedId!).Get() ? __composer.RememberedValue<global::System.Func<float>>() : __composer.UpdateRememberedValue<global::System.Func<float>>(() => tabLayouts[selectedId].LocalPosition.x)), animationSpec: animationSpec, __composer: __composer, __changed: 0b_00_00_00).Value.Dp(), top: __AnimateFloatAsState(key: selectedId, targetValueFactory: (!__composer.BuildChanged().Changed<global::UnityCompose.IMutableStateDictionary<int, global::UnityCompose.LayoutCoordinates>>(tabLayouts!).Changed<int>(selectedId!).Get() ? __composer.RememberedValue<global::System.Func<float>>() : __composer.UpdateRememberedValue<global::System.Func<float>>(() => tabLayouts[selectedId].LocalPosition.y)), animationSpec: animationSpec, __composer: __composer, __changed: 0b_00_00_00).Value.Dp()), __composer: __composer, __changed: 0b_00);
                        }

                        __composer.EndReplaceGroup(1548542559);
                        __CompositionLocalProvider(LocalTabsCoordinates.Provides(tabLayouts), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_11) == 0b_00_00_10).Changed<global::VS.UiToolkit.IListSelection>(selection!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                        {
                            __ListSelection(selection: selection, content: content, __composer: __composer, __changed: (__dirty & 0b_00_11));
                        })), __composer: __composer, __changed: 0b_00_00);
                    })), __composer: __composer, __changed: 0b_00_01_00);
                })), __composer: __composer, __changed: 0b_01_00);
            })), __composer: __composer, __changed: 0b_01_00_01_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01;
        __composer.EndRestartGroup(1314956366, __isRestarted)?.UpdateScope(() => __Tabs(__content, __animationSpec, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }

    public static void __Tab(ComposableContent content, Action onClick, bool selected, IModifier? modifier = null, global::UnityCompose.Composer __composer = null !, int __changed = -1)
    {
        var(__content, __onClick, __selected, __modifier) = (content, onClick, selected, modifier);
        var __isCreated = __composer.StartRestartGroup(458527140);
        var __dirty = __changed;
        if ((__changed & 0b_00_00_00_11) == 0)
            __dirty |= __composer.Changed(content) ? 0b_00_00_00_10 : 0b_00_00_00_01;
        if ((__changed & 0b_00_00_11_00) == 0)
            __dirty |= __composer.Changed(onClick) ? 0b_00_00_10_00 : 0b_00_00_01_00;
        if ((__changed & 0b_00_11_00_00) == 0)
            __dirty |= __composer.Changed(selected) ? 0b_00_10_00_00 : 0b_00_01_00_00;
        if ((__changed & 0b_11_00_00_00) == 0)
            __dirty |= __composer.Changed(modifier) ? 0b_10_00_00_00 : 0b_01_00_00_00;
        var __isRestarted = __composer.IsRestarted();
        if (__isCreated || __isRestarted || __dirty != 0b_01_01_01_01)
        {
            var theme = Theme;
            var bounce = theme.AnimationSpecs.Bounce;
            var interactionSource = (!__composer.Changed() ? __composer.RememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>() : __composer.UpdateRememberedValue<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(MutableInteractionSource));
            var isPressed = interactionSource.__CollectIsPressedAsState(__composer: __composer, __changed: 0b_00).Value;
            var tabsCoordinates = LocalTabsCoordinates.Current;
            __ListSelectionItem((!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_11) == 0b_00_00_00_10).ChangedAsFlag((__dirty & 0b_00_00_11_00) == 0b_00_00_10_00).ChangedAsFlag((__dirty & 0b_00_11_00_00) == 0b_00_10_00_00).ChangedAsFlag((__dirty & 0b_11_00_00_00) == 0b_10_00_00_00).Changed<global::UnityCompose.AnimationSpec>(bounce!).Changed<global::UnityCompose.Packages.UnityCompose.Runtime.Impl.Utils.IMutableInteractionSource>(interactionSource!).Changed<bool>(isPressed!).Changed<global::StableCollections.IMutableStableDictionary<int, global::UnityCompose.LayoutCoordinates>>(tabsCoordinates!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent<global::VS.UiToolkit.IListSelectionItem>>(item =>
            {
                __SideEffect(selected, (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_11_00_00) == 0b_00_10_00_00).Changed<global::VS.UiToolkit.IListSelectionItem>(item!).Get() ? __composer.RememberedValue<global::System.Action>() : __composer.UpdateRememberedValue<global::System.Action>(() =>
                {
                    if (selected)
                        item.Select();
                })), __composer: __composer, __changed: ((__dirty & 0b_11_00_00) >> 4));
                __Box(modifier: modifier.OrEmpty().Padding(vertical: 4.Dp(), horizontal: 16.Dp() + 32.Dp() * item.SelectionProgress).OnGloballyPositioned(onGloballyPositioned: (!__composer.BuildChanged().Changed<global::StableCollections.IMutableStableDictionary<int, global::UnityCompose.LayoutCoordinates>>(tabsCoordinates!).Changed<global::VS.UiToolkit.IListSelectionItem>(item!).Get() ? __composer.RememberedValue<global::System.Action<global::UnityCompose.LayoutCoordinates>>() : __composer.UpdateRememberedValue<global::System.Action<global::UnityCompose.LayoutCoordinates>>(it => tabsCoordinates[item.Id] = it))).Clip(RoundedCornerShape(16.Dp())).__ClickIndication(onClick: onClick, interactionSource: interactionSource, __composer: __composer, __changed: 0b_01_01_00_00 | ((__dirty & 0b_11_00) >> 2)), content: (!__composer.BuildChanged().ChangedAsFlag((__dirty & 0b_00_00_00_11) == 0b_00_00_00_10).Changed<global::UnityCompose.AnimationSpec>(bounce!).Changed<bool>(isPressed!).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                {
                    __Box(modifier: Modifier.Scale(__AnimateFloatAsState(isPressed ? 0.75f : 1f, bounce, __composer: __composer, __changed: 0b_00_00).Value), content: (!__composer.BuildChanged().Changed().ChangedAsFlag((__dirty & 0b_00_00_00_11) == 0b_00_00_00_10).Get() ? __composer.RememberedValue<global::UnityCompose.ComposableContent>() : __composer.UpdateRememberedValue<global::UnityCompose.ComposableContent>(() =>
                    {
                        __CompositionLocalProvider(LocalTextStyle.Provides(Theme.Typography.Title), content: content, __composer: __composer, __changed: ((__dirty & 0b_00_11) << 2));
                    })), __composer: __composer, __changed: 0b_01_00_00);
                })), __composer: __composer, __changed: 0b_01_00_00);
            })), __composer: __composer, __changed: 0b_00);
        }
        else
        {
            __composer.SkipToGroupEnd();
        }

        __dirty = 0b_01_01_01_01;
        __composer.EndRestartGroup(458527140, __isRestarted)?.UpdateScope(() => __Tab(__content, __onClick, __selected, __modifier, __composer, __composer.UpdateChangedFlags(__changed)));
    }
}