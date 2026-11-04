using Compose.Net;
using static Compose.Net.ComposeFunctions;

namespace Samples;

public sealed class ExpeditionState
{
    public readonly IMutableState<int> Page = MutableStateOf(0), Category = MutableStateOf(0), Selected = MutableStateOf(0);
    public readonly IMutableState<string> Sort = MutableStateOf("Recommended"), Quality = MutableStateOf("High"), Resolution = MutableStateOf("1920 × 1080");
    public readonly IMutableState<bool> SortOpen = MutableStateOf(false), QualityOpen = MutableStateOf(false), ResolutionOpen = MutableStateOf(false);
    public readonly IMutableState<bool> Light = MutableStateOf(false), Sound = MutableStateOf(true), VSync = MutableStateOf(true), ReducedMotion = MutableStateOf(false);
    public readonly IMutableState<int> Volume = MutableStateOf(70), Destination = MutableStateOf(2), Location = MutableStateOf(0), Travel = MutableStateOf(0);
    public readonly IMutableState<float> Zoom = MutableStateOf(1f), Width = MutableStateOf(1200f);
    public readonly IMutableState<bool> Travelling = MutableStateOf(false);
    public readonly IMutableState<string> Notice = MutableStateOf("All systems ready");
    public readonly IMutableState<bool>[] Equipped = { MutableStateOf(true), MutableStateOf(false), MutableStateOf(false), MutableStateOf(true), MutableStateOf(false), MutableStateOf(false) };
    public void SelectPage(int page) { Page.Value = page; SortOpen.Value = QualityOpen.Value = ResolutionOpen.Value = false; }
    public void ToggleEquipment() { var i = Selected.Value; Equipped[i].Value = !Equipped[i].Value; Notice.Value = Equipped[i].Value ? "Added to your loadout" : "Returned to storage"; }
    public void ResetSettings() { Quality.Value = "High"; Resolution.Value = "1920 × 1080"; Sound.Value = VSync.Value = true; ReducedMotion.Value = false; Volume.Value = 70; Notice.Value = "Default settings restored"; }
}
