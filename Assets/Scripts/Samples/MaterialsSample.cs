using Compose.Net;
using Compose.Net.Unity;

namespace Samples;

public sealed partial class MaterialsSample : ComposeUI
{
    [Composable] protected override void Content() => MaterialLab.Content();
    [Composable] protected override void Preview() => Content();
}
