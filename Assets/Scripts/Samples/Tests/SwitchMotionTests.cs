using System.Collections;
using System.Linq;
using Compose.Net;
using Compose.Net.Unity;
using Compose.Net.Unity.Preview;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.UIElements.TestFramework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;
using UnityEngine.UIElements.TestFramework;
using VS.DesignSystem;
using static Compose.Net.ComposeFunctions;

namespace Samples.Tests;

public sealed class SwitchMotionTests : EditorWindowUITestFixture<UnityPreviewWindow>
{
    private VisualElement Thumb => rootVisualElement.Q("ds.switch.thumb");
    private VisualElement Track => rootVisualElement.Q("ds.switch.track");

    private IEnumerator Settle(float seconds)
    {
        var end = EditorApplication.timeSinceStartup + seconds;
        while (EditorApplication.timeSinceStartup < end)
        {
            yield return null;
            simulate.FrameUpdate();
        }
    }

    [UnityTest]
    public IEnumerator ThumbMovesAndResizesThroughIntermediateValues()
    {
        panelSize = new Vector2(400, 300);
        SwitchMotionPreview.Value = MutableStateOf(false);
        var entry = UnityPreviewCatalog.Discover().Single(e => e.Method.DeclaringType == typeof(SwitchMotionPreview));
        yield return null;
        window.StartPreview(entry.Id);
        yield return Settle(.2f);
        var start = Thumb.worldBound.center.x;
        Assert.That(Thumb.layout.width, Is.EqualTo(16).Within(.5));
        simulate.Click(Track);
        Assert.That(SwitchMotionPreview.Value.Value, Is.True);
        var intermediateSize = false;
        var intermediatePosition = false;
        var end = EditorApplication.timeSinceStartup + .5;
        while (EditorApplication.timeSinceStartup < end)
        {
            yield return null;
            simulate.FrameUpdate();
            intermediateSize |= Thumb.layout.width > 16.5f && Thumb.layout.width < 23.5f;
            intermediatePosition |= Thumb.worldBound.center.x > start + 1 && Thumb.worldBound.center.x < start + 19;
        }
        Assert.That(intermediateSize, Is.True, "Thumb size jumped straight to the target.");
        Assert.That(intermediatePosition, Is.True, "Thumb position jumped straight to the target.");
        Assert.That(Thumb.layout.width, Is.EqualTo(24).Within(.5));
        Assert.That(Thumb.worldBound.center.x - start, Is.EqualTo(20).Within(.5));

        simulate.Click(Track);
        yield return Settle(.04f);
        simulate.Click(Track);
        yield return Settle(.5f);
        Assert.That(SwitchMotionPreview.Value.Value, Is.True);
        Assert.That(Thumb.layout.width, Is.EqualTo(24).Within(.5));
        Assert.That(Thumb.worldBound.center.x - start, Is.EqualTo(20).Within(.5));
        var layer = rootVisualElement.Q("material.switch.stateLayer");
        Assert.That(layer.worldBound.center.x, Is.EqualTo(Thumb.worldBound.center.x).Within(.5));
    }
}

[global::Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
public static partial class SwitchMotionPreview
{
    public static IMutableState<bool> Value = MutableStateOf(false);

    [UnityPreview("DS switch motion regression", 240, 160)]
    [Composable]
    public static void Content()
    {
        VS.DesignSystem.WithDsThemeFunctions.ProvideDsTheme(content: () =>
            Box(modifier: Modifier.FillMaxSize(), contentAlignment: Alignment.Center,
                content: () => DsSwitch(Value.Value, value => Value.Value = value)));
    }
}
