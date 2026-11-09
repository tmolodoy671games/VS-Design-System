using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
[InitializeOnLoad]
[Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
internal static class PreviewSizeProbe
{
    static PreviewSizeProbe() { EditorApplication.delayCall += () => EditorApplication.update += Tick; }
    private static void Tick()
    {
        const string request = "/private/tmp/preview-size-probe.request";
        if (!File.Exists(request) || EditorApplication.isCompiling || EditorApplication.isUpdating) return;
        File.Delete(request);
        var text = new StringBuilder();
        foreach (var window in Resources.FindObjectsOfTypeAll<EditorWindow>())
        {
            if (window.GetType().Name != "UnityPreviewWindow") continue;
            text.AppendLine(window.titleContent.text + " position=" + window.position + " min=" + window.minSize + " max=" + window.maxSize);
            Dump(window.rootVisualElement, text, 0);
        }
        File.WriteAllText("/private/tmp/preview-size-probe.txt", text.ToString());
    }
    private static void Dump(VisualElement e, StringBuilder text, int depth)
    {
        text.AppendLine(new string(' ', depth * 2) + e.GetType().Name + " " + e.name + " layout=" + e.layout + " world=" + e.worldBound + " width=" + e.style.width + " height=" + e.style.height + " min=" + e.style.minWidth + "," + e.style.minHeight + " max=" + e.style.maxWidth + "," + e.style.maxHeight + " scale=" + e.resolvedStyle.scale);
        if (depth < 9) foreach (var child in e.Children()) Dump(child, text, depth + 1);
    }
}
