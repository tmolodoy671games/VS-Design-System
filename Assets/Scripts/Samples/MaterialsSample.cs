using Compose.Net;
using Compose.Net.Unity;
using static VS.DesignSystem.WithThemeFunctions;

namespace Samples;

public sealed partial class MaterialsSample : ComposeUI
{
    private MaterialLabState? _state;
    public MaterialLabState State => _state ??= new MaterialLabState();
    [Composable] protected override void Content() => WithTheme(content: () => MaterialLab.Content(State));
    [Composable] protected override void Preview() => Content();
}
