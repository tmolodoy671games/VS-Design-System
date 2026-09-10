// ReSharper disable ArrangeNamespaceBody

using System;
using Sirenix.OdinInspector;
using UnityEngine;
using VS.UiToolkit;

namespace Samples.Samples.Behaviors
{
    [HideMonoScript, ExecuteAlways, DefaultExecutionOrder(-1_000_000)]
    internal class ThemeSynchronizer : MonoBehaviour
    {
        [SerializeField] private SerializableDsThemeConfig theme = null!;

        private void Awake()
        {
            Update();
        }

        private void Update()
        {
            if (!theme)
                return;
            DsThemeHolder.SetDsTheme(theme.ToDsThemeConfig());
        }
    }
}