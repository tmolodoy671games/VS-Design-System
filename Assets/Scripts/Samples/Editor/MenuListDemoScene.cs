using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Samples.Editor;

public static class MenuListDemoScene
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

    [MenuItem("Tools/VS Design System/Add Menu List Sample to Scene")]
    public static void AddToScene() => Selection.activeGameObject = EnsureInScene(SceneManager.GetActiveScene()).gameObject;

    public static MenuListSample EnsureInScene(Scene scene)
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
        var existing = roots.SelectMany(root => root.GetComponentsInChildren<MenuListSample>(true)).FirstOrDefault();
        var go = existing ? existing.gameObject : roots.SelectMany(root => root.GetComponentsInChildren<Transform>(true))
            .Select(transform => transform.gameObject).FirstOrDefault(item => item.name == "Menu List");
        if (!go)
        {
            go = new GameObject("Menu List");
            SceneManager.MoveGameObjectToScene(go, scene);
            Undo.RegisterCreatedObjectUndo(go, "Add Menu List demo");
        }
        Undo.RecordObject(go, "Configure Menu List demo");
        go.SetActive(false);
        Undo.SetTransformParent(go.transform, demos.transform, "Move Menu List under Demos");
        var renderer = go.GetComponent<PanelRenderer>();
        if (!renderer) renderer = Undo.AddComponent<PanelRenderer>(go);
        Undo.RecordObject(renderer, "Configure Menu List panel");
        renderer.panelSettings = AssetDatabase.LoadAssetAtPath<PanelSettings>("Assets/Panel Settings.asset");
        renderer.visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/t.molodoy.compose.net.unity/Runtime/Layout/ComposeView Root.uxml");
        renderer.sortingOrder = 220;
        if (!existing) existing = Undo.AddComponent<MenuListSample>(go);
        Undo.RecordObject(existing, "Enable Menu List demo"); existing.enabled = true;
        go.SetActive(true); EditorSceneManager.MarkSceneDirty(scene);
        return existing;
    }
}
