using Compose.Net;
using Compose.Net.Unity;

namespace Samples;

public sealed partial class ExpeditionSample : ComposeUI
{
    private ExpeditionState? _state;
    public ExpeditionState State => _state ??= new ExpeditionState();
    [Composable] protected override void Content() => ExpeditionDemo.Content(State);
    [Composable] protected override void Preview() => Content();
}
