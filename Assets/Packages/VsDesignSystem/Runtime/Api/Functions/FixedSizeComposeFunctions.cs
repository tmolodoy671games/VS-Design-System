// ReSharper disable CheckNamespace

using UnityCompose;

namespace VS.UiToolkit;

public static partial class UiToolkitComposeFunctions
{
    [Composable]
    public static void FixedSize(
        ComposableContent content,
        IModifier? modifier = null
    )
    {
        Box(
            alignment: Alignment.Center,
            modifier: modifier,
            content: () =>
            {
                WithIsActive(false, () =>
                {
                    Box(
                        modifier: Modifier.Alpha(0),
                        content: content
                    );
                });
                Spacer(
                    Modifier.FillMaxSize()
                        .Float()
                        .OnClick(() => { })
                );
                Box(
                    modifier: Modifier
                        .FillMaxSize()
                        .Float(),
                    content: content
                );
            }
        );
    }
}