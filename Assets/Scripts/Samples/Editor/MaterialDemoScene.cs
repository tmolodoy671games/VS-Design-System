using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Samples.Editor;

public static class MaterialDemoScene
{
    // Explicit entry point for the installer/validation runner; safe to call again.
    public static void InstallInSampleScene()
    {
        const string path = "Assets/Scenes/SampleScene.unity";
        var scene = SceneManager.GetSceneByPath(path);
        if (!scene.IsValid() || !scene.isLoaded) scene = EditorSceneManager.OpenScene(path, OpenSceneMode.Additive);
        Selection.activeGameObject = EnsureInScene(scene).gameObject;
        if (!EditorSceneManager.SaveScene(scene)) throw new System.InvalidOperationException("Could not save " + path);
    }

    [MenuItem("Tools/VS Design System/Add Materials Sample to Scene")]
    public static void AddToScene() => Selection.activeGameObject = EnsureInScene(SceneManager.GetActiveScene()).gameObject;

    public static MaterialsSample EnsureInScene(Scene scene)
    {
        if (!scene.IsValid() || !scene.isLoaded) throw new System.InvalidOperationException("Open a scene first.");
        var roots = scene.GetRootGameObjects();
        var demos = roots.FirstOrDefault(root => root.name == "Samples");
        if (!demos)
        {
            demos = new GameObject("Samples");
            SceneManager.MoveGameObjectToScene(demos, scene);
            Undo.RegisterCreatedObjectUndo(demos, "Add demo group");
        }
        var existing = roots.SelectMany(root => root.GetComponentsInChildren<MaterialsSample>(true)).FirstOrDefault();
        var go = existing ? existing.gameObject : roots.SelectMany(root => root.GetComponentsInChildren<Transform>(true))
            .Select(transform => transform.gameObject).FirstOrDefault(item => item.name == "Materials");
        if (!go)
        {
            go = new GameObject("Materials");
            SceneManager.MoveGameObjectToScene(go, scene);
            Undo.RegisterCreatedObjectUndo(go, "Add Material Lab demo");
        }
        Undo.RecordObject(go, "Configure Material Lab demo");
        go.SetActive(false);
        Undo.SetTransformParent(go.transform, demos.transform, "Move Material Lab under Demos");
        var renderer = go.GetComponent<PanelRenderer>();
        if (!renderer) renderer = Undo.AddComponent<PanelRenderer>(go);
        Undo.RecordObject(renderer, "Configure Material Lab panel");
        renderer.panelSettings = AssetDatabase.LoadAssetAtPath<PanelSettings>("Assets/Panel Settings.asset");
        renderer.visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/t.molodoy.compose.net.unity/Runtime/Layout/ComposeView Root.uxml");
        renderer.sortingOrder = 210;
        if (!existing) existing = Undo.AddComponent<MaterialsSample>(go);
        Undo.RecordObject(existing, "Enable Material Lab demo"); existing.enabled = true;
        go.SetActive(true); EditorSceneManager.MarkSceneDirty(scene);
        return existing;
    }
}
