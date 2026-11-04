using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Samples.Editor;

// Only an explicit, project-scoped request saves a scene. Ordinary imports do nothing.
[InitializeOnLoad]
[global::Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
internal static class MaterialSceneRequest
{
    private static readonly string Folder = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "vs-materials",
        System.IO.Path.GetFileName(System.IO.Path.GetDirectoryName(Application.dataPath)));
    static MaterialSceneRequest() => EditorApplication.update += Poll;
    private static void Poll()
    {
        var request = System.IO.Path.Combine(Folder, "scene.request");
        if (!File.Exists(request) || EditorApplication.isCompiling || EditorApplication.isUpdating || EditorApplication.isPlayingOrWillChangePlaymode) return;
        var command = File.ReadAllText(request).Trim();
        File.Delete(request);
        try
        {
            if (command == "expedition")
            {
                ExpeditionDemoScene.InstallInSampleScene();
                ExpeditionDemoWindow.Open();
                File.WriteAllText(System.IO.Path.Combine(Folder, "expedition.result"), "Installed Expedition sample");
                return;
            }
            if (command == "validate")
            {
                MaterialValidation.Start(System.IO.Path.Combine(Folder, "validation.result"));
                return;
            }
            MaterialDemoScene.InstallInSampleScene();
            File.WriteAllText(System.IO.Path.Combine(Folder, "scene.result"), "Saved Assets/Scenes/SampleScene.unity / Samples / Materials");
        }
        catch (Exception exception) { File.WriteAllText(System.IO.Path.Combine(Folder, "scene.result"), exception.ToString()); }
    }
}
