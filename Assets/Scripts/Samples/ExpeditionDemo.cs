using System;
using System.Linq;
using Compose.Net;
using StableCollections;
using VS.DesignSystem;
using static Compose.Net.ComposeFunctions;
using static VS.DesignSystem.WithDsThemeFunctions;
using static Samples.NavigationFunctions;
using static Samples.DropdownSelectorFunctions;
using static StableCollections.StableCollectionsFactory;

namespace Samples;

[global::Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
public static partial class ExpeditionDemo
{
    private static readonly string[] Names = { "Field pack", "Signal beacon", "Survey lens", "Thermal flask", "First aid kit", "Navigation module" };
    private static readonly string[] Descriptions = { "A durable linen carry system. Everything you need, exactly where you need it.", "A long-range emergency transmitter. A small signal with a very long reach.", "Precision optics for reading the terrain. Find a different perspective.", "Double-wall ceramic insulation. Keep a little warmth for the journey.", "Compact essentials for the unexpected. Prepared is a good place to be.", "A brushed-metal navigation tool. Your bearings, even beyond the network." };
    private static readonly string[] Kinds = { "EQUIPMENT", "TOOLS", "TOOLS", "SUPPLIES", "SUPPLIES", "EQUIPMENT" };
    private static readonly int[] Categories = { 1, 2, 2, 3, 3, 1 };
    private static readonly string[] Places = { "Base camp", "Pine ridge", "North observatory", "Silent lake" };
    private static readonly float[] MapX = { .22f, .43f, .76f, .65f }, MapY = { .68f, .36f, .23f, .73f };
    private static readonly IStableList<string> Sorts = MutableStableListOf("Recommended", "Name A–Z", "Equipped first");
    private static readonly IStableList<string> Qualities = MutableStableListOf("Low", "Medium", "High", "Ultra");
    private static readonly IStableList<string> Resolutions = MutableStableListOf("1280 × 720", "1920 × 1080", "2560 × 1440");
    private static ColorScheme C => VS.DesignSystem.DsTheme.ColorScheme;
    private static Shape Round(float radius = 16) => RoundedCornerShape(radius.Dp());
    private static Color Tint(Color c, float a) => c with { Alpha = a };
    private static Color Accent(int i) => i % 3 == 0 ? C.Primary : i % 3 == 1 ? C.Secondary : C.Tertiary;
    private static AnimationSpec Motion(ExpeditionState s, int duration = 240) => Tween(s.ReducedMotion.Value ? 0 : duration, easing: EaseOutEasing);
    [Composable] private static void Label(string text, float size = 13, Color? color = null, bool bold = false, IModifier? modifier = null) =>
        Text(text, style: VS.DesignSystem.DsTheme.Typography.BodyMedium, fontSize: size.Sp(), color: color ?? C.OnSurface,
            fontWeight: bold ? FontWeight.Bold : FontWeight.Normal, modifier: modifier);
    [Composable] private static void Gap(float size = 16) => Spacer(Modifier.Height(size.Dp()));
    [Composable] private static void Badge(string text, Color color) => Box(modifier: Modifier.Background(Tint(color, .10f), Round(20)).Padding(horizontal: 10.Dp(), vertical: 6.Dp()), content: () => Label(text, 10, color, true));

    [Composable] public static void Content(ExpeditionState s) => ProvideDsTheme(colorScheme: s.Light.Value ? DsLightThemeFunctions.DsLightTheme.ColorScheme : DsDarkThemeFunctions.DsDarkTheme.ColorScheme, content: () => Body(s));
    [Composable] private static void Body(ExpeditionState s)
    {
        LaunchedEffect(s.Travel.Value, async scope =>
        {
            if (!s.Travelling.Value) return;
            var destination = s.Destination.Value;
            await scope.Delay(s.ReducedMotion.Value ? 1 : 1400);
            s.Location.Value = destination; s.Travelling.Value = false; s.Notice.Value = "Arrived at " + Places[destination];
        });
        Column(modifier: Modifier.FillMaxSize().Background(C.Background, RoundedCornerShape(0.Dp())).Clip(RoundedCornerShape(0.Dp())).OnSizeChanged(size => s.Width.Value = size.Width).TestTag("expedition.root"), content: () =>
        {
            Row(modifier: Modifier.FillMaxWidth().Height(84.Dp()).Padding(horizontal: 28.Dp()), verticalAlignment: Alignment.CenterVertically, content: () =>
            {
                Box(modifier: Modifier.Size(38.Dp()).Background(C.Primary, Round(12)).Clip(Round(12)), contentAlignment: Alignment.Center,
                    content: () => Label("F", 22, C.OnPrimary, true));
                Spacer(Modifier.Width(14.Dp()));
                Column(content: () => { Label("FIELDWORK", 15, bold: true); Label("EXPEDITION  /  007", 9, C.OnSurfaceVariant); });
                Spacer(Modifier.Weight(1));
                Badge("●  OFFLINE READY", C.Primary);
                Spacer(Modifier.Width(18.Dp()));
                ActionButton(s.Light.Value ? "Dark mode" : "Light mode", () => s.Light.Value = !s.Light.Value, "theme", s);
            });
            Row(modifier: Modifier.FillMaxWidth().Background(C.SurfaceContainerLow).Padding(horizontal: 28.Dp()), verticalAlignment: Alignment.CenterVertically, content: () =>
            {
                NavigationFunctions.Tab(s.Page.Value == 0, () => s.SelectPage(0), () => Text("01   Inventory"), Modifier.TestTag("expedition.tab.0"));
                NavigationFunctions.Tab(s.Page.Value == 1, () => s.SelectPage(1), () => Text("02   Map"), Modifier.TestTag("expedition.tab.1"));
                NavigationFunctions.Tab(s.Page.Value == 2, () => s.SelectPage(2), () => Text("03   System settings"), Modifier.TestTag("expedition.tab.2"));
                Spacer(Modifier.Weight(1));
                if (s.Width.Value > 950) Label("NORTH SECTOR  /  64° 08′", 10, C.OnSurfaceVariant);
            });
            Box(modifier: Modifier.Weight(1).FillMaxWidth().Clip(), content: () =>
                AnimatedContent(s.Page.Value, content: page =>
                {
                    Column(modifier: Modifier.FillMaxSize().VerticalScroll(RememberScrollState()).TestTag("expedition.page." + page), content: () =>
                        Column(modifier: Modifier.FillMaxWidth().Padding(28.Dp()), content: () =>
                        {
                            if (page == 0) Inventory(s);
                            else if (page == 1) Map(s);
                            else Settings(s);
                        }));
                }, modifier: Modifier.FillMaxSize(), transitionSpec: _ =>
                    (FadeIn(Motion(s, 240)) + SlideInVertically(Motion(s, 300), _ => 12)).TogetherWith(FadeOut(Motion(s, 140))).Using(null)));
            Row(modifier: Modifier.FillMaxWidth().Height(38.Dp()).Background(C.SurfaceContainerLow).Padding(horizontal: 28.Dp()), verticalAlignment: Alignment.CenterVertically, content: () =>
            {
                Label("●  " + s.Notice.Value, 11, C.Primary, modifier: Modifier.TestTag("expedition.notice"));
                Spacer(Modifier.Weight(1)); Label("FIELDWORK  /  LOCAL DEMO", 9, C.OnSurfaceVariant);
            });
        });
    }
    [Composable] private static void Heading(string eyebrow, string title, string subtitle)
    {
        Label(eyebrow, 10, C.Primary, true); Gap(7); Label(title, 30, bold: true); Gap(6); Label(subtitle, 12, C.OnSurfaceVariant); Gap(24);
    }
    [Composable] private static void Inventory(ExpeditionState s)
    {
        Heading("YOUR NEXT CHAPTER", "Pack for the unexpected.", "Thoughtfully chosen essentials. Ready for wherever the trail takes you.");
        Row(modifier: Modifier.FillMaxWidth(), horizontalArrangement: Arrangement.SpacedBy(24.Dp()), content: () =>
        {
            Column(modifier: Modifier.Width(174.Dp()), content: () =>
            {
                Label("COLLECTION", 10, C.OnSurfaceVariant, true); Gap(12);
                var categories = new[] { "All items", "Equipment", "Tools", "Supplies" };
                for (var i = 0; i < categories.Length; i++)
                {
                    var index = i;
                    MenuItem(() => s.Category.Value = index, () => Text(categories[index]), modifier: Modifier.FillMaxWidth().TestTag("expedition.filter." + index),
                        selected: s.Category.Value == index, trailingContent: () => Text(index == 0 ? "06" : "02")); Gap(4);
                }
                Gap(24);
                Box(modifier: Modifier.FillMaxWidth().Background(C.SurfaceContainer, Round()).Clip(Round()).Padding(18.Dp()), content: () => Column(content: () =>
                {
                    Label("YOUR LOADOUT", 9, C.OnSurfaceVariant, true); Gap(12);
                    Label(s.Equipped.Count(e => e.Value) + " / 6", 28, C.Primary, true); Gap(8);
                    Label("items equipped", 11, C.OnSurfaceVariant); Gap(16);
                    Progress(s.Equipped.Count(e => e.Value) / 6f, C.Primary, s); Gap(14);
                    Label("Carry less.\nDiscover more.", 12, C.OnSurfaceVariant);
                }));
            });
            Column(modifier: Modifier.Weight(1), content: () =>
            {
                Row(modifier: Modifier.FillMaxWidth(), verticalAlignment: Alignment.CenterVertically, content: () =>
                {
                    Label("THE ESSENTIALS", 10, C.OnSurfaceVariant, true); Spacer(Modifier.Weight(1));
                    DropdownSelector(s.SortOpen.Value, v => s.SortOpen.Value = v,
                        content: () => Text(s.Sort.Value),
                        dropdownContent: () =>
                        {
                            foreach (var item in Sorts)
                                MenuItem(() => { if (!s.SortOpen.Value) return; s.Sort.Value = item; s.SortOpen.Value = false; },
                                    () => Text(item), selected: s.Sort.Value == item, modifier: Modifier.FillMaxWidth(),
                                    contentPadding: DropdownSelectorDefaults.ContentPadding);
                        },
                        modifier: Modifier.TestTag("expedition.sort"));
                }); Gap(18);
                var items = Enumerable.Range(0, 6).Where(i => s.Category.Value == 0 || Categories[i] == s.Category.Value);
                if (s.Sort.Value == "Name A–Z") items = items.OrderBy(i => Names[i]);
                if (s.Sort.Value == "Equipped first") items = items.OrderByDescending(i => s.Equipped[i].Value);
                var ids = items.ToArray();
                var columns = s.Width.Value > 1250 ? 3 : 2;
                for (var row = 0; row < (ids.Length + columns - 1) / columns; row++)
                {
                    var start = row * columns;
                    Row(modifier: Modifier.FillMaxWidth(), horizontalArrangement: Arrangement.SpacedBy(16.Dp()), content: () =>
                    {
                        for (var col = 0; col < columns; col++)
                        {
                            var at = start + col;
                            if (at < ids.Length) ItemCard(s, ids[at], Modifier.Weight(1)); else Spacer(Modifier.Weight(1));
                        }
                    }); Gap(16);
                }
                if (s.Width.Value <= 1080) Details(s);
            });
            if (s.Width.Value > 1080) Column(modifier: Modifier.Width(252.Dp()), content: () => Details(s));
        });
    }
    [Composable] private static void ItemCard(ExpeditionState s, int id, IModifier modifier)
    {
        var source = Remember(MutableInteractionSource);
        var hover = source.CollectIsHoveredAsState().Value; var pressed = source.CollectIsPressedAsState().Value;
        var selected = s.Selected.Value == id;
        var lift = AnimateFloatAsState(pressed ? 1 : hover ? -3 : 0, Motion(s, 180)).Value;
        var edge = AnimateColorAsState(selected ? Accent(id) : hover ? C.Outline : C.OutlineVariant, Motion(s)).Value;
        var accent = Accent(id); var face = Color.Lerp(C.SurfaceContainer, accent, .08f);
        Box(modifier: modifier.Offset(y: lift.Dp()).Background(face, Round()).Clip(Round())
            .Border((selected ? 1.5f : .6f).Dp(), SolidColor(edge), Round()), content: () =>
            Column(modifier: Modifier.FillMaxWidth().Clickable(() => s.Selected.Value = id, interactionSource: source, indication: null).TestTag("expedition.item." + id).Padding(16.Dp()), content: () =>
            {
                Row(modifier: Modifier.FillMaxWidth(), content: () => { Label("0" + (id + 1), 10, C.OnSurfaceVariant); Spacer(Modifier.Weight(1)); Label(s.Equipped[id].Value ? "● EQUIPPED" : "IN STORAGE", 8, s.Equipped[id].Value ? accent : C.OnSurfaceVariant); });
                ItemArt(s, id, accent, 112); Label(Names[id], 15, bold: true); Gap(6); Label(Kinds[id], 9, C.OnSurfaceVariant);
            }));
    }
    [Composable] private static void Details(ExpeditionState s)
    {
        var id = s.Selected.Value; var accent = Accent(id);
        Column(modifier: Modifier.FillMaxWidth().Background(C.SurfaceContainer, Round()).Clip(Round()).Padding(22.Dp()), content: () =>
        {
            Label("A CLOSER LOOK", 9, C.OnSurfaceVariant, true); Gap(10);
            ItemArt(s, id, accent, 160); Badge(Kinds[id], accent); Gap(14); Label(Names[id], 23, bold: true); Gap(12);
            Label(Descriptions[id], 12, C.OnSurfaceVariant); Gap(24);
            DetailLine("CONDITION", "Excellent"); Gap(14); Progress(.92f, accent, s); Gap(20);
            DetailLine("WEIGHT", id == 0 ? "1.2 kg" : "0.4 kg"); Gap(14); DetailLine("MATERIAL", id == 0 ? "Linen" : id == 3 ? "Ceramic" : id == 2 ? "Paper composite" : "Anodised metal"); Gap(24);
            ActionButton(s.Equipped[id].Value ? "−  Unequip item" : "+  Equip item", s.ToggleEquipment, "equip", s, true, Modifier.FillMaxWidth()); Gap(10);
            Label("Changes are saved for this session.", 10, C.OnSurfaceVariant);
        });
    }
    [Composable] private static void DetailLine(string key, string value) => Row(modifier: Modifier.FillMaxWidth(), content: () =>
    { Label(key, 9, C.OnSurfaceVariant); Spacer(Modifier.Weight(1)); Label(value, 11); });
    [Composable] private static void Progress(float target, Color color, ExpeditionState s)
    {
        var amount = AnimateFloatAsState(target, Motion(s, 360));
        Box(modifier: Modifier.FillMaxWidth().Height(5.Dp()).Draw(d =>
        {
            d.DrawRoundRect(Tint(color, .12f), default, d.Size, 3);
            d.DrawRoundRect(color, default, new Size(d.Size.Width * amount.Value, d.Size.Height), 3);
        }), content: () => { });
    }
    [Composable, NonRestartableComposable] private static void ActionButton(string text, Action action, string tag, ExpeditionState s, bool primary = false, IModifier? modifier = null, bool enabled = true)
    {
        var source = Remember(MutableInteractionSource); var hover = source.CollectIsHoveredAsState().Value; var pressed = source.CollectIsPressedAsState().Value;
        var lift = AnimateFloatAsState(hover && enabled && !pressed ? 2f : 0f, Motion(s, 150)).Value;
        var targetColor = primary ? C.PrimaryContainer : C.SurfaceContainerHigh;
        if (hover)
            targetColor = Color.Lerp(targetColor, primary ? C.OnPrimaryContainer : C.OnSurface, .08f);
        var color = AnimateColorAsState(targetColor, Motion(s)).Value;
        Box(modifier: (modifier ?? Modifier).Offset(y: (-lift).Dp()).Alpha(enabled ? 1 : .4f)
            .Background(color, Round(10)).Clip(Round(10)),
            content: () => Box(
                modifier: (modifier == null ? Modifier : Modifier.FillMaxWidth())
                    .Clickable(action, enabled: enabled, interactionSource: source, indication: null)
                    .Padding(horizontal: 16.Dp(), vertical: 12.Dp()).TestTag("expedition." + tag),
                contentAlignment: Alignment.Center,
                content: () => Label(text, 12, primary ? C.OnPrimaryContainer : C.OnSurface, true)));
    }
    [Composable] private static void ItemArt(ExpeditionState s, int id, Color color, float height)
    {
        Box(modifier: Modifier.FillMaxWidth().Height(height.Dp()).Draw(d =>
        {
            var cx = d.Size.Width * .5f; var cy = d.Size.Height * .5f;
            var r = Math.Min(d.Size.Width * .28f, d.Size.Height * .32f);
            for (var ring = 1; ring <= (s.Quality.Value == "Low" ? 1 : s.Quality.Value == "Ultra" ? 5 : 3); ring++) d.DrawCircle(Tint(color, .06f), r + ring * 12, new Offset(cx, cy), style: Stroke(.7f));
            void Line(float x, float y, float x2, float y2, float width = 1.5f) => d.DrawLine(color, new Offset(cx + x * r, cy + y * r), new Offset(cx + x2 * r, cy + y2 * r), width);
            void Rect(float x, float y, float w, float h, float radius = 5) => d.DrawRoundRect(color, new Offset(cx+x*r,cy+y*r), new Size(w*r,h*r), radius, style: Stroke(1.7f));
            if (id == 0) { Rect(-.65f,-.75f,1.3f,1.5f,9); Rect(-.4f,.05f,.8f,.45f); Rect(-.25f,-1,.5f,.3f); Line(-.6f,-.3f,.6f,-.3f); }
            else if (id == 1) { Rect(-.4f,-.55f,.8f,1.3f); Line(.1f,-.55f,.4f,-1); d.DrawCircle(color, r*.14f,new Offset(cx,cy)); Line(-.2f,.4f,.2f,.4f); }
            else if (id == 2) { d.DrawCircle(color,r*.7f,new Offset(cx,cy),style:Stroke(2)); d.DrawCircle(color,r*.43f,new Offset(cx,cy),style:Stroke(1)); Line(.5f,.5f,.9f,.9f,5); }
            else if (id == 3) { Rect(-.42f,-.7f,.84f,1.55f,10); Rect(-.3f,-.95f,.6f,.25f,3); Line(-.4f,-.2f,.4f,-.2f); Line(-.4f,.35f,.4f,.35f); }
            else if (id == 4) { Rect(-.8f,-.55f,1.6f,1.15f,8); Rect(-.3f,-.8f,.6f,.25f,3); Line(-.3f,0,.3f,0,4); Line(0,-.3f,0,.3f,4); }
            else { d.DrawCircle(color,r*.8f,new Offset(cx,cy),style:Stroke(2)); Line(0,-.65f,.3f,.3f); Line(.3f,.3f,-.3f,.3f); Line(-.3f,.3f,0,-.65f); Line(0,-.95f,0,-1.1f); }
        }), content: () => { });
    }
    [Composable] private static void Map(ExpeditionState s)
    {
        Heading("BEYOND THE FAMILIAR", "A little further north.", "Choose a destination, trace a route, and see where curiosity takes you.");
        Row(modifier: Modifier.FillMaxWidth(), horizontalArrangement: Arrangement.SpacedBy(24.Dp()), content: () =>
        {
            Column(modifier: Modifier.Weight(1), content: () =>
            {
                var size = Remember(() => MutableStateOf(new Size(720, 420)));
                var zoom = AnimateFloatAsState(s.Zoom.Value, Motion(s));
                var travel = AnimateFloatAsState(s.Travelling.Value ? 1 : 0, Motion(s, 1300));
                var accent = C.Primary; var line = C.OutlineVariant; var muted = C.OnSurfaceVariant;
                var from = s.Location.Value; var to = s.Destination.Value;
                Box(modifier: Modifier.FillMaxWidth().Height(420.Dp()).Background(C.SurfaceContainerLow, Round()).Clip(Round())
                    .Clip(Round()).OnSizeChanged(v => size.Value = v).TestTag("expedition.map"), content: () =>
                {
                    Box(modifier: Modifier.FillMaxSize().Draw(d =>
                    {
                        var w=d.Size.Width; var h=d.Size.Height; var z=zoom.Value;
                        Offset Point(float x,float y) => new(w*(.5f+(x-.5f)*z),h*(.5f+(y-.5f)*z));
                        for(var x=0; x<w; x+=32) d.DrawLine(Tint(line,.3f),new Offset(x,0),new Offset(x,h),.5f);
                        for(var y=0; y<h; y+=32) d.DrawLine(Tint(line,.3f),new Offset(0,y),new Offset(w,y),.5f);
                        for(var hill=0;hill<5;hill++)
                        for(var contour=0;contour<(s.Quality.Value=="Low"?3:s.Quality.Value=="Medium"?6:s.Quality.Value=="Ultra"?12:9);contour++)
                        {
                            using var path=Path();
                            for(var step=0;step<=72;step++)
                            {
                                var angle=step*Math.PI/36; var radius=.035f+contour*.022f;
                                var ripple=1+.1*Math.Sin(angle*3+hill)+.07*Math.Cos(angle*5);
                                var point=Point(.12f+hill*.21f+(float)(Math.Cos(angle)*radius*ripple), .22f+(hill%2)*.47f+(float)(Math.Sin(angle)*radius*ripple*1.3));
                                if(step==0) path.MoveTo(point); else path.LineTo(point);
                            }
                            d.DrawPath(path,Tint(muted,.13f),style:Stroke(.8f));
                        }
                        var a=Point(MapX[from],MapY[from]); var b=Point(MapX[to],MapY[to]);
                        for(var i=0;i<30;i++)
                        {
                            var t=i/30f; var t2=(i+.55f)/30f;
                            d.DrawLine(Tint(accent,.55f), new Offset(a.X+(b.X-a.X)*t,a.Y+(b.Y-a.Y)*t),new Offset(a.X+(b.X-a.X)*t2,a.Y+(b.Y-a.Y)*t2),1.5f);
                        }
                        if(s.Travelling.Value)
                        {
                            var point=new Offset(a.X+(b.X-a.X)*travel.Value,a.Y+(b.Y-a.Y)*travel.Value);
                            d.DrawCircle(Tint(accent,.14f),14,point); d.DrawCircle(accent,4,point);
                        }
                    }), content: () => { });
                    for(var i=0;i<Places.Length;i++)
                    {
                        var index=i; var selected=s.Destination.Value==i;
                        var x=size.Value.Width*(.5f+(MapX[i]-.5f)*zoom.Value)-12;
                        var y=size.Value.Height*(.5f+(MapY[i]-.5f)*zoom.Value)-12;
                        Column(modifier: Modifier.Offset(x.Dp(),y.Dp()), content: () =>
                        {
                            Box(modifier: Modifier.Size(26.Dp()).Background(selected ? C.Primary : C.SurfaceContainerHighest, Round(13))
                                .Border(1.Dp(),SolidColor(C.Primary),Round(13)).Clickable(() => s.Destination.Value=index, enabled: !s.Travelling.Value).TestTag("expedition.waypoint."+index),
                                contentAlignment: Alignment.Center,content: () => Label(index==s.Location.Value ? "●" : "+",13,selected ? C.OnPrimary : C.Primary,true));
                            Gap(6); Label(Places[index],10,bold:true);
                        });
                    }
                    Row(modifier: Modifier.Align(Alignment.BottomLeft).Padding(18.Dp()), horizontalArrangement: Arrangement.SpacedBy(8.Dp()), content: () =>
                    {
                        ActionButton("−",()=>s.Zoom.Value=Math.Max(.8f,s.Zoom.Value-.2f),"zoom.out",s);
                        ActionButton("+",()=>s.Zoom.Value=Math.Min(1.6f,s.Zoom.Value+.2f),"zoom.in",s);
                        Badge((s.Zoom.Value*100).ToString("0")+"%",C.Primary);
                    });
                    Box(modifier: Modifier.Align(Alignment.TopRight).Padding(20.Dp()),content:()=>Label("N ↑",13,C.Primary,true));
                }); Gap(14); DetailLine("TERRAIN VIEW", "1 : 25 000  /  NORTH SECTOR");
            });
            Column(modifier: Modifier.Width(250.Dp()), content: () =>
            {
                Label("WAYPOINTS",10,C.OnSurfaceVariant,true); Gap(14);
                for(var i=0;i<Places.Length;i++)
                {
                    var index=i;
                    MenuItem(()=>s.Destination.Value=index,()=>Text(Places[index]),modifier:Modifier.FillMaxWidth().TestTag("expedition.destination."+index),selected:s.Destination.Value==i,enabled:!s.Travelling.Value,
                        supportingContent:()=>Text(index==s.Location.Value ? "You are here" : (2+index*1.4f).ToString("0.0")+" km away")); Gap(6);
                }
                Gap(20);
                Box(modifier:Modifier.FillMaxWidth().Background(C.SecondaryContainer, Round()).Clip(Round()).Padding(20.Dp()),content:()=>Column(content:()=>
                {
                    Label("NEXT STOP",9,C.OnSecondaryContainer,true);Gap(10);Label(Places[s.Destination.Value],20,C.OnSecondaryContainer,true);Gap(12);
                    Label(s.Travelling.Value ? "Following the trail…" : "A clear sky. A fresh perspective.",12,C.OnSecondaryContainer);Gap(22);
                    ActionButton(s.Travelling.Value ? "Travelling…" : s.Location.Value==s.Destination.Value ? "You are here" : "Begin route  →",()=>
                    { s.Travelling.Value=true;s.Travel.Value++;s.Notice.Value="On the way to "+Places[s.Destination.Value]; },"travel",s,true,Modifier.FillMaxWidth(),!s.Travelling.Value&&s.Location.Value!=s.Destination.Value);
                }));
            });
        });
    }
    [Composable] private static void Settings(ExpeditionState s)
    {
        Heading("MAKE IT YOURS", "A quieter kind of control.", "Tune your environment. Every change takes effect in this demo immediately.");
        Row(modifier:Modifier.FillMaxWidth(),horizontalArrangement:Arrangement.SpacedBy(24.Dp()),content:()=>
        {
            Column(modifier:Modifier.Weight(1),content:()=>
            {
                SettingsPanel("01 / DISPLAY",()=>
                {
                    SettingRow("Render quality","Changes map contours and illustration detail",()=>DropdownSelector(
                        s.QualityOpen.Value, v => s.QualityOpen.Value = v,
                        content: () => Text(s.Quality.Value),
                        dropdownContent: () =>
                        {
                            foreach (var item in Qualities)
                                MenuItem(() => { if (!s.QualityOpen.Value) return; s.Quality.Value = item; s.QualityOpen.Value = false; s.Notice.Value="Demo quality preset: "+item; },
                                    () => Text(item), selected: s.Quality.Value == item, modifier: Modifier.FillMaxWidth(),
                                    contentPadding: DropdownSelectorDefaults.ContentPadding);
                        },
                        modifier: Modifier.Width(180.Dp()).TestTag("expedition.quality")));
                    Gap(20);
                    SettingRow("Resolution","Preview preference · no window resize",()=>DropdownSelector(
                        s.ResolutionOpen.Value, v => s.ResolutionOpen.Value = v,
                        content: () => Text(s.Resolution.Value),
                        dropdownContent: () =>
                        {
                            foreach (var item in Resolutions)
                                MenuItem(() => { if (!s.ResolutionOpen.Value) return; s.Resolution.Value = item; s.ResolutionOpen.Value = false; },
                                    () => Text(item), selected: s.Resolution.Value == item, modifier: Modifier.FillMaxWidth(),
                                    contentPadding: DropdownSelectorDefaults.ContentPadding);
                        },
                        modifier: Modifier.Width(180.Dp()).TestTag("expedition.resolution")));Gap(20);
                    SettingRow("Vertical sync","Store this session’s preference",()=>Toggle(s.VSync,"vsync"));
                });Gap(20);
                SettingsPanel("02 / SOUND",()=>
                {
                    SettingRow("Sound enabled","Session preference · this demo is silent",()=>Toggle(s.Sound,"sound"));Gap(20);
                    SettingRow("Master volume",s.Volume.Value+"%",()=>Row(horizontalArrangement:Arrangement.SpacedBy(8.Dp()),content:()=>
                    {
                        ActionButton("−",()=>s.Volume.Value=Math.Max(0,s.Volume.Value-10),"volume.down",s,enabled:s.Sound.Value);
                        ActionButton("+",()=>s.Volume.Value=Math.Min(100,s.Volume.Value+10),"volume.up",s,enabled:s.Sound.Value);
                    }));Gap(12);Progress(s.Volume.Value/100f,s.Sound.Value?C.Primary:C.Outline,s);
                });
            });
            Column(modifier:Modifier.Weight(1),content:()=>
            {
                SettingsPanel("03 / EXPERIENCE",()=>
                {
                    SettingRow("Light appearance","Switch the entire design-system theme",()=>Toggle(s.Light,"appearance"));Gap(24);
                    SettingRow("Reduced motion","Shorten page, route and card animations",()=>Toggle(s.ReducedMotion,"motion"));
                });Gap(20);
                Box(modifier:Modifier.FillMaxWidth().Background(C.TertiaryContainer, Round()).Clip(Round()).Padding(24.Dp()),content:()=>Column(content:()=>
                {
                    Label("YOUR SPACE, YOUR PACE",10,C.OnTertiaryContainer,true);Gap(14);Label("Small details.\nA different feeling.",26,C.OnTertiaryContainer,true);Gap(16);
                    Label("Material surfaces, responsive controls and a palette that follows your theme.",12,C.OnTertiaryContainer);Gap(24);
                    ActionButton("Restore defaults",s.ResetSettings,"reset",s);
                }));
            });
        });
    }
    [Composable] private static void SettingsPanel(string title,[Composable] Action content) =>
        Column(modifier:Modifier.FillMaxWidth().Background(C.SurfaceContainer, Round()).Clip(Round()).Padding(24.Dp()),content:()=>{Label(title,10,C.OnSurfaceVariant,true);Gap(24);content();});
    [Composable] private static void SettingRow(string title,string subtitle,[Composable] Action control) =>
        Row(modifier:Modifier.FillMaxWidth(),horizontalArrangement:Arrangement.SpacedBy(16.Dp()),verticalAlignment:Alignment.CenterVertically,content:()=>
        {Column(modifier:Modifier.Weight(1),content:()=>{Label(title,14,bold:true);Gap(5);Label(subtitle,10,C.OnSurfaceVariant);});control();});
    [Composable] private static void Toggle(IMutableState<bool> state,string tag) =>
        VS.DesignSystem.DsSwitchFunctions.DsSwitch(value:state.Value,onValueChange:v=>state.Value=v,modifier:Modifier.TestTag("expedition."+tag));
}
