using System;
using System.IO;
using Compose.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using VS.DesignSystem;



namespace Samples.Editor;

[global::Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
internal static class MaterialValidation
{
    private static MaterialDemoWindow? _window;
    private static string _result = "";
    private static int _stable;
    private static double _next;
    private static Vector2 _size;
    private static string? _failure;
    private static void OnLog(string message, string stack, LogType type)
    { if (type == LogType.Error || type == LogType.Exception) _failure = message; }
    internal static void Start(string result)
    {
        _result = result;
        try
        {
            var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            var first = MaterialDemoScene.EnsureInScene(scene);
            if (MaterialDemoScene.EnsureInScene(scene) != first || first.transform.parent.name != "Samples")
                throw new Exception("Sample installation is not idempotent");
            MaterialDemoWindow.Open();
            _window = EditorWindow.GetWindow<MaterialDemoWindow>();
            _window.position = new UnityEngine.Rect(80, 80, 680, 640);
            _failure = null; Application.logMessageReceived += OnLog;
            _stable = 0; _next = EditorApplication.timeSinceStartup + 1;
            EditorApplication.update += Tick;
        }
        catch (Exception e) { File.WriteAllText(_result, e.ToString()); }
    }
    private static void Tick()
    {
        if (EditorApplication.timeSinceStartup < _next) return;
        _next = EditorApplication.timeSinceStartup + 0.4;
        try
        {
            if (_failure != null) throw new Exception(_failure);
            var root = _window!.rootVisualElement;
            if (root.layout.size != _size) { _size = root.layout.size; _stable = 0; }
            if (++_stable < 3) return;
            foreach (var dark in new[] { false, true })
            {
                var tag = dark ? "dark" : "light";
                var column = root.Q("materials." + tag);
                if (column == null || column.layout.width <= 0)
                    throw new Exception("Missing theme column: " + tag);
                var expected = (dark ? DsDarkThemeFunctions.DsDarkTheme : DsLightThemeFunctions.DsLightTheme).ColorScheme.Surface;
                var actual = column.resolvedStyle.backgroundColor;
                if (Math.Abs(actual.r - expected.Red) > 0.01f || Math.Abs(actual.g - expected.Green) > 0.01f || Math.Abs(actual.b - expected.Blue) > 0.01f)
                    throw new Exception("Incorrect theme surface: " + tag);
                for (var i = 0; i < 5; i++)
                {
                    var swatch = root.Q("materials." + tag + "." + i);
                    if (swatch == null || swatch.layout.width <= 0 || swatch.layout.height <= 0)
                        throw new Exception("Missing material: " + tag + "." + i);
                    if (swatch.worldBound.yMax > column.worldBound.yMax)
                        throw new Exception("Material exceeds column bounds: " + tag + "." + i);
                }
            }
            EditorApplication.update -= Tick; Application.logMessageReceived -= OnLog;
            File.WriteAllText(_result, "PASS: scene idempotence; five color roles in both VS Light/Dark theme columns with visible layout.");
        }
        catch (Exception e) { EditorApplication.update -= Tick; Application.logMessageReceived -= OnLog; File.WriteAllText(_result, e.ToString()); }
    }
}
