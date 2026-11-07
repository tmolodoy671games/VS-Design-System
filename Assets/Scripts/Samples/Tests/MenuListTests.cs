using System.Collections;
using NUnit.Framework;
using Samples.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.UIElements.TestFramework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;
using UnityEngine.UIElements.TestFramework;

namespace Samples.Tests;

public sealed class MenuListTests : EditorWindowUITestFixture<MenuListDemoWindow>
{
    [SetUp] public void Setup()
    {
        RecreatePanel(); panelSize = new Vector2(900, 880); simulate.needsRendering = true;
    }
    private VisualElement E(string tag) => rootVisualElement.Q("menu." + tag)
        ?? throw new AssertionException("Missing menu." + tag);
    private IEnumerator Settle(float seconds = .8f)
    {
        var end = EditorApplication.timeSinceStartup + seconds;
        while (EditorApplication.timeSinceStartup < end)
        {
            yield return null;
            Compose.Net.Unity.ComposeInvalidatorHolder.ComposeInvalidator.Tick();
            simulate.FrameUpdate();
        }
    }
    [UnityTest] public IEnumerator SelectionGrowsRowsAndMovesOneIndicatorInBothThemes()
    {
        yield return Settle(1.2f);
        var oldHeight = E("light.item.0").layout.height;
        var newHeight = E("light.item.3").layout.height;
        var start = E("light.indicator").worldBound.y;
        simulate.Click(E("light.item.3"));
        yield return Settle();
        Assert.That(window.State.Selected.Value, Is.EqualTo(3));
        Assert.That(E("light.item.0").layout.height, Is.LessThan(oldHeight - 5));
        Assert.That(E("light.item.3").layout.height, Is.GreaterThan(newHeight + 5));
        Assert.That(E("light.indicator").worldBound.y, Is.GreaterThan(start + 40));
        foreach (var theme in new[] { "light", "dark" })
        {
            Assert.That(E(theme + ".indicator").worldBound.y,
                Is.EqualTo(E(theme + ".item.3").worldBound.y).Within(2));
            Assert.That(E(theme + ".indicator").worldBound.height,
                Is.EqualTo(E(theme + ".item.3").worldBound.height).Within(2));
        }
        simulate.Click(E("dark.item.5")); yield return Settle();
        Assert.That(window.State.Selected.Value, Is.EqualTo(3));
        simulate.Click(E("dark.item.1"));
        yield return Settle(.08f);
        simulate.Click(E("light.item.2")); yield return Settle();
        Assert.That(window.State.Selected.Value, Is.EqualTo(2));
        Assert.That(E("light.indicator").worldBound.y,
            Is.EqualTo(E("light.item.2").worldBound.y).Within(2));
    }
    [UnityTest] public IEnumerator SharedIndicatorFollowsTheSelectedRowAfterResize()
    {
        yield return Settle();
        simulate.Click(E("light.item.4")); yield return Settle();
        panelSize = new Vector2(1060, 900); yield return Settle();
        foreach (var theme in new[] { "light", "dark" })
        {
            var item = E(theme + ".item.4").worldBound;
            var indicator = E(theme + ".indicator").worldBound;
            Assert.That(indicator.x, Is.EqualTo(item.x).Within(2));
            Assert.That(indicator.y, Is.EqualTo(item.y).Within(2));
            Assert.That(indicator.width, Is.EqualTo(item.width).Within(2));
            Assert.That(indicator.height, Is.EqualTo(item.height).Within(2));
        }
    }

    [UnityTest] public IEnumerator BothTabLevelsMoveIndicatorsAndKeepTheirOwnSelection()
    {
        yield return Settle();
        var primaryX = E("light.primary").Q("ds.tabs.indicator").worldBound.x;
        var secondaryX = E("light.secondary").Q("ds.tabs.indicator").worldBound.x;
        simulate.Click(E("light.primary.tab.1")); yield return Settle();
        Assert.That(window.State.Primary.Value, Is.EqualTo(1));
        Assert.That(window.State.Secondary.Value, Is.Zero);
        Assert.That(E("light.primary").Q("ds.tabs.indicator").worldBound.x, Is.GreaterThan(primaryX + 40));
        simulate.Click(E("dark.secondary.tab.2")); yield return Settle();
        Assert.That(window.State.Secondary.Value, Is.EqualTo(2));
        Assert.That(window.State.Primary.Value, Is.EqualTo(1));
        Assert.That(E("light.secondary").Q("ds.tabs.indicator").worldBound.x, Is.GreaterThan(secondaryX + 40));
        simulate.Click(E("light.secondary.tab.2")); yield return Settle();
        Assert.That(window.State.Secondary.Value, Is.EqualTo(2));
        var folder = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "vs-menu");
        System.IO.Directory.CreateDirectory(folder);
        rootVisualElement.CaptureToPNG(System.IO.Path.Combine(folder, "menu.png"));
    }
    [UnityTest] public IEnumerator TabLevelsHaveDifferentSizesAndFollowResizeAndInterruptedSelection()
    {
        yield return Settle();
        Assert.That(E("light.primary.tab.0").layout.height, Is.EqualTo(56).Within(1));
        Assert.That(E("light.secondary.tab.0").layout.height, Is.EqualTo(40).Within(1));
        simulate.Click(E("light.primary.tab.1"));
        yield return Settle(.08f);
        simulate.Click(E("light.primary.tab.0"));
        yield return Settle();
        panelSize = new Vector2(1060, 900);
        yield return Settle();
        foreach (var theme in new[] { "light", "dark" })
        {
            var tab = E(theme + ".primary.tab.0").worldBound;
            var indicator = E(theme + ".primary").Q("ds.tabs.indicator").worldBound;
            Assert.That(indicator.x, Is.EqualTo(tab.x).Within(2));
            Assert.That(indicator.width, Is.EqualTo(tab.width).Within(2));
        }
    }

}
