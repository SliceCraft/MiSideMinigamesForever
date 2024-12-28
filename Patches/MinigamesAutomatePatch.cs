using HarmonyLib;
using MinigamesForever.Utils;
using UnityEngine;

namespace MinigamesForever.Patches;

[HarmonyPatch(typeof(MinigamesAutomate))]
public class MinigamesAutomatePatch
{
    public static int startWait = -1;
    
    [HarmonyPatch(nameof(MinigamesAutomate.StartGame))]
    [HarmonyPrefix]
    public static void StartGamePatch()
    {
        if (SteamManagerPatch.PlayingCarSpace)
        {
            Time.timeScale = 1f;
            Location7 location = Object.FindObjectOfType<Location7>(true);
            if (location == null || location.gameObject == null)
            {
                Plugin.Log.LogInfo("Unable to find Location7 class, maybe the world was already destroyed?");
                return;
            }
            Object.Destroy(location.gameObject);
            PrepareCarGame.TogglePlayerStatus(false);
        }
    }
    
    [HarmonyPatch(nameof(MinigamesAutomate.Update))]
    [HarmonyPrefix]
    public static void UpdatePatch(MinigamesAutomate __instance)
    { 
        if (startWait == 0)
        {
            __instance.StartLoading();
            Time.timeScale = 20f;
        }
        
        if (startWait > -1)
        {
            startWait--;
        }
    } 
}