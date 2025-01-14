using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MinigamesForever.Events;
using MinigamesForever.GameLoader;
using MinigamesForever.Games;
using MinigamesForever.Patches;

namespace MinigamesForever;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    private readonly Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
    internal static new ManualLogSource Log;

    public override void Load()
    {
        // Plugin startup logic
        Log = base.Log;
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        
        GameManager.RegisterGame(new MakeManekenGame());
        
        SceneLoadedEvent.RegisterEvent();
        harmony.PatchAll();
    }
}
