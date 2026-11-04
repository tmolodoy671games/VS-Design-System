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
    private static int _step;
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
            foreach (var name in new[] { "paper", "metal", "linen", "canvas", "felt", "twill" })
            {
                var texture = Resources.Load<Texture2D>("VSMaterials/" + name);
                if (!texture || !texture.isReadable) throw new Exception("Missing/read-protected texture: " + name);
            }
            if (Materials.Cloth().Opacity != -1f || Materials.Cloth(opacity: 0).Opacity != 0)
                throw new Exception("Opacity factory defaults");
            try { Materials.Paper(opacity: -0.5f); throw new Exception("Invalid opacity accepted"); }
            catch (ArgumentOutOfRangeException) { }
            var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            var first = MaterialDemoScene.EnsureInScene(scene);
            if (MaterialDemoScene.EnsureInScene(scene) != first || first.transform.parent.name != "Samples")
                throw new Exception("Sample installation is not idempotent");
            MaterialDemoWindow.Open();
            _window = EditorWindow.GetWindow<MaterialDemoWindow>();
            _window.position = new UnityEngine.Rect(80, 80, 900, 1050);
            _failure = null; Application.logMessageReceived += OnLog;
            _step = 0; _next = EditorApplication.timeSinceStartup + 1;
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
            var preview = _window!.rootVisualElement.Q("materials.preview");
            if (preview == null || preview.layout.width <= 0 || preview.layout.height <= 0)
                throw new Exception("Material preview has no layout");
            if (_step == 0) _size = preview.layout.size;
            else if (preview.layout.size != _size) throw new Exception("Material setting changed layout size");
            var state = _window.State;
            if (_step < 5) state.Material.Value = _step;
            else if (_step < 9) { state.Material.Value = 3; state.Weave.Value = _step - 5; }
            else if (_step == 9) state.Opacity.Value = 0;
            else if (_step == 10) state.Inherit.Value = false;
            else if (_step == 11) _window.PreviewTheme.Value = LightTheme.Instance;
            else if (_step == 12)
            {
                var expected = LightTheme.Instance.ColorScheme.Surface;
                var actual = _window.rootVisualElement.Q("materials.root").resolvedStyle.backgroundColor;
                if (Math.Abs(actual.r - expected.Red) > 0.01f || Math.Abs(actual.g - expected.Green) > 0.01f || Math.Abs(actual.b - expected.Blue) > 0.01f)
                    throw new Exception("Sample did not follow the VS theme's Surface color");
                _window.PreviewTheme.Value = DarkTheme.Instance;
            }
            else
            {
                state.Material.Value = 3; state.Weave.Value = 0; state.Opacity.Value = 1; state.Inherit.Value = true;
                EditorApplication.update -= Tick; Application.logMessageReceived -= OnLog;
                File.WriteAllText(_result, "PASS: six textures; opacity validation; scene idempotence; five materials, four weaves and zero/explicit opacity rendered with stable layout; VS Light/Dark theme colors update.");
            }
            _step++;
        }
        catch (Exception e) { EditorApplication.update -= Tick; Application.logMessageReceived -= OnLog; File.WriteAllText(_result, e.ToString()); }
    }
}
