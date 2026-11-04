using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Samples.Editor;

public static class ExpeditionDemoScene
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

    [MenuItem("Tools/VS Design System/Add Expedition Sample to Scene")]
    public static void AddToScene() => InstallInSampleScene();

    public static ExpeditionSample EnsureInScene(Scene scene)
    {
        if (!scene.IsValid() || !scene.isLoaded) throw new System.InvalidOperationException("Open a scene first.");
        var roots = scene.GetRootGameObjects();
        foreach (var lab in roots.SelectMany(root => root.GetComponentsInChildren<MaterialsSample>(true)))
        { lab.gameObject.SetActive(false); }
        var demos = roots.FirstOrDefault(root => root.name == "Samples");
        if (!demos)
        {
            demos = new GameObject("Samples");
            SceneManager.MoveGameObjectToScene(demos, scene);

        }
        var existing = roots.SelectMany(root => root.GetComponentsInChildren<ExpeditionSample>(true)).FirstOrDefault();
        var go = existing ? existing.gameObject : roots.SelectMany(root => root.GetComponentsInChildren<Transform>(true))
            .Select(transform => transform.gameObject).FirstOrDefault(item => item.name == "Expedition");
        if (!go)
        {
            go = new GameObject("Expedition");
            SceneManager.MoveGameObjectToScene(go, scene);

        }

        go.SetActive(false);
        go.transform.SetParent(demos.transform, false);
        var renderer = go.GetComponent<PanelRenderer>();
        if (!renderer) renderer = go.AddComponent<PanelRenderer>();

        renderer.panelSettings = AssetDatabase.LoadAssetAtPath<PanelSettings>("Assets/Panel Settings.asset");
        renderer.visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/t.molodoy.compose.net.unity/Runtime/Layout/ComposeView Root.uxml");
        renderer.sortingOrder = 220;
        if (!existing) existing = go.AddComponent<ExpeditionSample>();
        existing.enabled = true;
        go.SetActive(true); EditorSceneManager.MarkSceneDirty(scene);
        return existing;
    }
}
