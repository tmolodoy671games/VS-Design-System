using Compose.Net;
using Compose.Net.Unity;

namespace Samples;

public sealed partial class MenuListSample : ComposeUI
{
    private MenuListState? _state;
    public MenuListState State => _state ??= new MenuListState();
    [Composable] protected override void Content() => MenuListDemo.Content(State);
    [Composable] protected override void Preview() => Content();
}
