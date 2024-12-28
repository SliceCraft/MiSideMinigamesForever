using HarmonyLib;
using MinigamesForever.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinigamesForever.Patches;

[HarmonyPatch]
[HarmonyPatch(typeof(MinigamesFastMenu))]
public class MinigamesFastMenuPatch
{
    [HarmonyPatch(nameof(MinigamesFastMenu.FastMenuClickButton))]
    [HarmonyPrefix]
    public static bool FastMenuClickButtonPatch(MinigamesFastMenu __instance)
    {
        if ((!SteamManagerPatch.PlayingHetoor && !SteamManagerPatch.PlayingCarSpace) ||
            __instance.cases[__instance.indexChangeButton].isLock ||
            __instance.cases[__instance.indexChangeButton].typeCase != MenuCaseOption.TypeCaseOption.Exit) return true;
        if (SteamManagerPatch.PlayingCarSpace)
        {
            PrepareCarGame.TogglePlayerStatus(true);
        }
        SteamManagerPatch.PlayingHetoor = false;
        SteamManagerPatch.PlayingCarSpace = false;
        GlobalGame.LoadingLevel = "SceneMenu";
        SceneManager.LoadScene("SceneLoading");
        return false;
    }    
}