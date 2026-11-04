using System.Collections;
using System.IO;
using System.Linq;
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

public sealed class ExpeditionTests : EditorWindowUITestFixture<ExpeditionDemoWindow>
{
    [SetUp] public void Setup() { RecreatePanel(); panelSize = new Vector2(1380, 960); simulate.needsRendering = true; }
    private VisualElement E(string tag) => rootVisualElement.Q("expedition." + tag) ?? throw new AssertionException("Missing " + tag);
    private IEnumerator Settle(float seconds = .65f)
    {
        var end = EditorApplication.timeSinceStartup + seconds;
        while (EditorApplication.timeSinceStartup < end) { yield return null; Compose.Net.Unity.ComposeInvalidatorHolder.ComposeInvalidator.Tick(); simulate.FrameUpdate(); }
    }
    private void Capture(string name)
    {
        var folder = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "vs-expedition"); Directory.CreateDirectory(folder);
        rootVisualElement.CaptureToPNG(System.IO.Path.Combine(folder, name + ".png"));
    }
    [UnityTest] public IEnumerator InventoryFiltersSelectsAndEquipsAcrossTabs()
    {
        yield return Settle(1.2f); Capture("inventory");
        simulate.Click(E("filter.2")); yield return Settle();
        Assert.That(rootVisualElement.Q("expedition.item.0"), Is.Null);
        simulate.Click(E("item.1")); yield return Settle(); Assert.That(window.State.Selected.Value, Is.EqualTo(1));
        simulate.Click(E("equip")); yield return Settle(); Assert.That(window.State.Equipped[1].Value, Is.True);
        simulate.Click(E("tab.1")); yield return Settle(); Assert.That(window.State.Page.Value, Is.EqualTo(1)); Capture("map");
        simulate.Click(E("tab.0")); yield return Settle(); Assert.That(window.State.Selected.Value, Is.EqualTo(1)); Assert.That(window.State.Equipped[1].Value, Is.True);
    }
    [UnityTest] public IEnumerator NarrowWindowKeepsNavigationAndSettingsUsable()
    {
        panelSize = new Vector2(980, 760); yield return Settle(1.2f);
        simulate.Click(E("tab.2")); yield return Settle();
        Assert.That(E("quality").worldBound.xMax, Is.LessThanOrEqualTo(rootVisualElement.worldBound.xMax));
        Assert.That(E("theme").worldBound.width, Is.LessThan(180));
        Capture("narrow-settings");
        simulate.Click(E("motion")); yield return Settle(); Assert.That(window.State.ReducedMotion.Value, Is.True);
        simulate.Click(E("tab.0")); yield return Settle(); Assert.That(window.State.Page.Value, Is.Zero);
    }
    [UnityTest] public IEnumerator MapSelectsZoomsAndCompletesRoute()
    {
        yield return Settle(); simulate.Click(E("tab.1")); yield return Settle();
        simulate.Click(E("destination.3")); yield return Settle(); Assert.That(window.State.Destination.Value, Is.EqualTo(3));
        simulate.Click(E("zoom.in")); yield return Settle(); Assert.That(window.State.Zoom.Value, Is.EqualTo(1.2f).Within(.01));
        simulate.Click(E("travel")); yield return Settle(.2f); Assert.That(window.State.Travelling.Value, Is.True);
        yield return Settle(1.6f); Assert.That(window.State.Location.Value, Is.EqualTo(3)); Assert.That(window.State.Travelling.Value, Is.False);
        Capture("route-complete");
    }
    [UnityTest] public IEnumerator SettingsDropdownTogglesAndResetAreInteractive()
    {
        yield return Settle(); simulate.Click(E("tab.2")); yield return Settle(); Capture("settings");
        simulate.Click(E("quality")); yield return Settle(); Assert.That(window.State.QualityOpen.Value, Is.True); Capture("dropdown");
        var ultra = rootVisualElement.Query<TextElement>().ToList().FirstOrDefault(e => e.text == "Ultra");
        Assert.That(ultra, Is.Not.Null); simulate.Click(ultra); yield return Settle(); Assert.That(window.State.Quality.Value, Is.EqualTo("Ultra")); Assert.That(window.State.QualityOpen.Value, Is.False);
        simulate.Click(E("sound")); yield return Settle(); Assert.That(window.State.Sound.Value, Is.False);
        simulate.Click(E("theme")); yield return Settle(); Assert.That(window.State.Light.Value, Is.True); Capture("light");
        simulate.Click(E("reset")); yield return Settle(); Assert.That(window.State.Sound.Value, Is.True); Assert.That(window.State.Quality.Value, Is.EqualTo("High"));
    }
}
